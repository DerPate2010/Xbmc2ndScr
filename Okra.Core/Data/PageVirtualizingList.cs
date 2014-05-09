using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okra.Helpers;

namespace Okra.Data
{
    public class PageVirtualizingList<T> : IList<T>
    {
        // *** Fields ***

        private T[][] internalPages = new T[0][];
        private int pageCacheSize = int.MaxValue;
        private List<int> recentlyAccessedPageList = new List<int>();

        // *** IList<T> Properties ***

        public T this[int index]
        {
            get
            {
                // Validate that the index is within range

                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

                // If the page does not exist then return a placeholder

                int pageIndex = index / PageSize;
                T[] page = internalPages[pageIndex];

                if (page == null)
                    return default(T);

                // Add the page to the recently accessed page list

                AddRecentlyUsedPage(pageIndex);
                
                // Return the element

                int elementIndex = index % PageSize;
                return page[elementIndex];
            }
            set
            {
                // Validate that the index is within range

                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

                // If the page does not exist then create it

                int pageIndex = index / PageSize;
                T[] page = internalPages[pageIndex];

                if (page == null)
                {
                    page = new T[PageSize];
                    internalPages[pageIndex] = page;
                }

                // Add the page to the recently accessed page list

                AddRecentlyUsedPage(pageIndex);

                // Set the element

                int elementIndex = index % PageSize;
                page[elementIndex] = value;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public int PageSize
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public int PageCacheSize
        {
            get
            {
                return pageCacheSize;
            }
            set
            {
                // Validate that new value

                if (value <= 0)
                    throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ParameterMustBePositive"));

                // Set the field

                pageCacheSize = value;
            }
        }

        // *** Methods ***

        public void UpdateCount(int count, int pageSize)
        {
            // Validate that the arguments are within range

            if (count < 0)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ParameterOutOfRange_CountMustBeZeroOrPositive"));

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ParameterMustBePositive"));

            // If the page size has changed then clear the internal page list

            if (this.PageSize != pageSize)
                internalPages = new T[0][];

            // Update the properties

            this.Count = count;
            this.PageSize = pageSize;

            // If the number of pages has changed then update the internal page list

            int pageCount = (Count - 1) / PageSize + 1;

            if (pageCount > internalPages.Length)
            {
                T[][] newInternalPages = new T[pageCount][];
                internalPages.CopyTo(newInternalPages, 0);
                internalPages = newInternalPages;
            }
        }

        // *** IList<T> Methods ***

        public void Add(T item)
        {
            int newIndex = Count;
            UpdateCount(Count + 1, PageSize);
            this[newIndex] = item;
        }

        public void Clear()
        {
            Count = 0;
            internalPages = new T[0][];
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            T[] blankPage = new T[PageSize];

            // For each page, copy to the destination in turn (or use the blank page to overwrite elsewhere)

            for (int pageIndex = 0; pageIndex < internalPages.Length - 1; pageIndex++)
            {
                T[] page = internalPages[pageIndex] ?? blankPage;
                page.CopyTo(array, arrayIndex + pageIndex * PageSize);
            }

            // For the last page only copy the items up to count

            T[] lastPage = internalPages[internalPages.Length - 1] ?? blankPage;
            int lastPageStartIndex = (internalPages.Length - 1) * PageSize;
            int lastPageLength = Count - lastPageStartIndex;

            Array.ConstrainedCopy(lastPage, 0, array, arrayIndex + lastPageStartIndex, lastPageLength);
        }

        public int IndexOf(T item)
        {
            // Enumerate all the pages

            for (int pageIndex = 0; pageIndex < internalPages.Length; pageIndex++)
            {
                T[] page = internalPages[pageIndex];

                if (page != null)
                {
                    // If the page exists then enumerate all the items within the page

                    for (int itemIndex = 0; itemIndex < PageSize; itemIndex++)
                    {
                        T internalItem = page[itemIndex];

                        if (internalItem != null && internalItem.Equals(item))
                            return pageIndex * PageSize + itemIndex;
                    }
                }
            }

            // Otherwise return -1

            return -1;
        }

        public void Insert(int index, T item)
        {
            // Validate that the index is within range

            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // Ensure that there is enough room in the collection

            UpdateCount(Count + 1, PageSize);

            // If there are items after the inserted item them move them along

            Insert_MoveItems(index);

            // Insert the new item

            this[index] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            // Validate that the index is within range

            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ArrayIndexOutOfRange"));

            // Reduce the count (NB: We don't worry about contracting the internal page list)

            Count--;

            // Move all items after the removed item to the left

            Remove_MoveItems(index);
        }

        // *** IEnumerable<T> Methods ***

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        // *** Private Methods ***

        private void AddRecentlyUsedPage(int pageIndex)
        {
            // If we are not limiting the number of pages to cache then skip this

            if (PageCacheSize == int.MaxValue)
                return;

            // Otherwise more the specified page index to the end of the list

            recentlyAccessedPageList.Remove(pageIndex);
            recentlyAccessedPageList.Add(pageIndex);

            // If there are more than the maxium pages then remove the last recently used

            if (recentlyAccessedPageList.Count > PageCacheSize)
            {
                internalPages[recentlyAccessedPageList[0]] = null;
                recentlyAccessedPageList.RemoveAt(0);
            }
        }

        private void Insert_MoveItems(int index)
        {
            int insertPage = index / PageSize;
            int insertIndex = index % PageSize;

            // Move full pages (starting at the end)

            for (int pageIndex = internalPages.Length - 1; pageIndex >= insertPage; pageIndex--)
            {
                T[] page = internalPages[pageIndex];

                if (page != null)
                {
                    int startIndex = pageIndex == insertPage ? insertIndex : 0;
                    int endIndex = pageIndex == internalPages.Length ? (Count - 1) % PageSize - 1 : PageSize - 1;

                    // If we need to copy the last element into the next page then do this

                    if (endIndex == PageSize - 1)
                    {
                        int lastItemIndex = pageIndex * PageSize + endIndex;
                        this[lastItemIndex + 1] = this[lastItemIndex];
                    }

                    // Move the rest of the items along

                    Array.ConstrainedCopy(page, startIndex, page, startIndex + 1, endIndex - startIndex);
                }
            }
        }

        private void Remove_MoveItems(int index)
        {
            int removePage = index / PageSize;
            int removeIndex = index % PageSize;

            // Move full pages (starting at the start)

            for (int pageIndex = removePage; pageIndex < internalPages.Length; pageIndex++)
            {
                T[] page = internalPages[pageIndex];
                T[] nextPage = pageIndex == internalPages.Length - 1 ? null : internalPages[pageIndex + 1];

                if (page != null)
                {
                    int startIndex = pageIndex == removePage ? removeIndex + 1 : 1;

                    // Move all the items to the left by one

                    Array.ConstrainedCopy(page, startIndex, page, startIndex - 1, PageSize - startIndex);

                    // Set the last item of this page to the first item of the next page

                    if (nextPage != null)
                        page[PageSize - 1] = nextPage[0];
                    else
                        page[PageSize - 1] = default(T);
                    
                }
            }
        }
    }
}

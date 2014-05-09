using System;
using Okra.Helpers;

namespace Okra.Data
{
    public static class DataListSource
    {
        public static IDataListSource<TSource> Skip<TSource>(this IDataListSource<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (count < 0)
                throw new ArgumentOutOfRangeException("count", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ParameterMustBeZeroOrPositive"));

            return new DataListSource_Skip<TSource>(source, count);
        }

        public static IDataListSource<TSource> Take<TSource>(this IDataListSource<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (count < 0)
                throw new ArgumentOutOfRangeException("count", ResourceHelper.GetErrorResource("Exception_ArgumentOutOfRange_ParameterMustBeZeroOrPositive"));

            return new DataListSource_Take<TSource>(source, count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xbmc2S.Model
{
    [DataContract]
    public class ItemsSourceReference : IEquatable<ItemsSourceReference>
    {
        private string _param;

        public override string ToString()
        {
            return ((int) Type) + "_" + ((int) Filter) + "_" + Param + "_" + Selection;
        }

        public static ItemsSourceReference Parse(object reference)
        {
            if (reference is string)
            {
                return Parse((string) reference);
            }

            if (reference is ItemsSourceReference)
            {
                return (ItemsSourceReference) reference;
            }
            throw new NotSupportedException();
        }

        public static ItemsSourceReference Parse(string text)
        {
            var parts = text.Split('_');
            var isr = new ItemsSourceReference();
            isr.Type = (ItemsSourceType) int.Parse(parts[0]);
            isr.Filter = (ItemsSourceFilter) int.Parse(parts[1]);
            isr.Param = parts[2];
            isr.Selection = int.Parse(parts[3]);
            return isr;
        }

        public ItemsSourceReference()
        {
            
        }

        public ItemsSourceReference(ItemsSourceType type, ItemsSourceFilter filter)
        {
            Type = type;
            Filter = filter;
        }
        public ItemsSourceReference(ItemsSourceType type, int id)
        {
            Type = type;
            Filter= ItemsSourceFilter.Id;
            Param = id.ToString();
        }

        [DataMember]
        public ItemsSourceType Type { get; set; }
        [DataMember]
        public ItemsSourceFilter Filter { get; set; }

        [DataMember]
        public string Param
        {
            get
            {
                return _param ?? "";
            }
            set
            {
                _param = value;
            }
        }

        [DataMember]
        public int Selection { get; set; }

        public bool Equals(ItemsSourceReference other)
        {
            return Equals((object) other);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var p = obj as ItemsSourceReference;
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Type == p.Type) && (Filter == p.Filter) && (Param==p.Param);

        }

        public override int GetHashCode()
        {
            if (Param == null)
            {
                return Type.GetHashCode() ^ Filter.GetHashCode();    
            }
            return Type.GetHashCode() ^ Filter.GetHashCode() ^ Param.GetHashCode();
        }
    }

    public class ItemSourceRefComparer : IEqualityComparer<ItemsSourceReference>
    {
        public bool Equals(ItemsSourceReference x, ItemsSourceReference y)
        {
            if (x == null)
            {
                if (y != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return x.Equals(y);
        }

        public int GetHashCode(ItemsSourceReference obj)
        {
            var hash= obj.GetHashCode();
            return hash;
        }
    }
}
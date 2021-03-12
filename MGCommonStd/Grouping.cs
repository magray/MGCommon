using System.Collections.Generic;

namespace MGCommon
{
    public class Grouping<T, TV> : ObservableRangeCollection<TV>
    {
        public T Key { get; private set; }

        public new IList<TV> Items => base.Items;
        
        public Grouping(T key, IEnumerable<TV> items)
        {
            Key = key;
            AddRange(items);
        }
    }
}

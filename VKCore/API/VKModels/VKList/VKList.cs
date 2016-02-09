using System.Collections.Generic;

namespace ВКонтакте.Models.List
{
    public class VKList<T>
    {
        public int count { get; set; }

        public List<T> items { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient.VKApplication.VKClient.Service
{
    public class ListUtil
    {
        public List<T> CombineListsWithoutDuplicates<T>(List<List<T>> listsOfLists)
        {
            HashSet<T> combinedSet = new HashSet<T>();
            foreach (List<T> list in listsOfLists)
            {
                foreach (T item in list)
                {
                    combinedSet.Add(item);
                }
            }
            return combinedSet.ToList();
        }
    }
}

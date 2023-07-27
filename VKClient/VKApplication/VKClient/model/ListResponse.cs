using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient.VKApplication.VKClient.model
{
     public class ListResponse<T>
     {
         public List<T> response { get; set; }
     }
}

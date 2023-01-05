using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TransferCarbon
    {
        public string SenderUser { get; set; }
        public string ReceiverUser { get; set; }
        public int Amount { get; set; }
    }
}

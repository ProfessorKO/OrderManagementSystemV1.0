using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Order state enum type for convert integer into the state name in string
    /// </summary>
    public enum OrderStates
    {
        New = 1,
        Pending = 2,
        Rejected = 3,
        Complete = 4,
    }

    public abstract class OrderState
    {
        OrderHeader _orderHeader;
        public OrderState()
        {
        }

        public abstract OrderStates State { get; set; }
        public abstract void Complete();
        public abstract void Reject();
        public abstract void Submit();
    }



}

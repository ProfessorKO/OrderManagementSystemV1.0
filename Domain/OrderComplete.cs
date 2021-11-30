using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderComplete : OrderState
    {
        /// <summary>
        /// field 
        /// </summary>
        public override OrderStates State { get; set; }

        public override void Complete()
        {
            throw new NotImplementedException(); // throu new exception ("New Order has to be the pending state before it can be completed")
        }

        public override void Reject()
        {
            throw new NotImplementedException(); // throw new exception ("New Order has to be pending state before it can be rejeceted")
        }

        public override void Submit()
        {
            throw new NotImplementedException();
        }

        public OrderComplete()
        {

        }
    }
}

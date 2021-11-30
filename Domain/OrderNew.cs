using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderNew : OrderState
    {
        public override OrderStates State { get; set; }

        public override void Complete()
        {
            throw new InvalidOrderStateException("New Order has to be the pending state before it can be completed"); // throu new exception ("New Order has to be the pending state before it can be completed")
        }

        public override void Reject()
        {
            throw new InvalidOrderStateException("New Order has to be the pending state before it can be rejected"); // throw new exception ("New Order has to be pending state before it can be rejeceted")
        }

        public override void Submit()
        {
            new OrderPending();
        }

        public OrderNew()
        {
            
        }

    }
}

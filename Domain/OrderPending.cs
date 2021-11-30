using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class OrderPending : OrderState
    {
        public override OrderStates State { get; set; }

        public override void Complete()
        {
            //TOTO complete for pending
            new OrderComplete();
            /*throw new NotImplementedException();*/ // throu new exception ("New Order has to be the pending state before it can be completed")
        }

        public override void Reject()
        {
            //TODO reject for pending
            new OrderRejected();
            /* throw new NotImplementedException();*/ // throw new exception ("New Order has to be pending state before it can be rejeceted")
        }

        public override void Submit()
        {
            throw new InvalidOrderStateException("Order is already in the pending/submit state");
        }

        public OrderPending()
        {

        }
    }
}

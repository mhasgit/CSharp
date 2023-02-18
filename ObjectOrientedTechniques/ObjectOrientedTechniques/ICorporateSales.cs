using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedTechniques
{
    interface ICorporateSales
    {
        int CreditLimit
        {
            get;
            set;
        }

        void ChangeCreditLimit(int changeAmount);
        void RecordOrders(string customerID, params int[] Orders);
    }
}

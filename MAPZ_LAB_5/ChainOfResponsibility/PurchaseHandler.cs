using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.ChainOfResponsibility
{
    abstract class PurchaseHandler 
    {
        public PurchaseHandler Succesor { get; set; }
        public abstract void BuyHandle(Customer customer, string itemName);

    }
}

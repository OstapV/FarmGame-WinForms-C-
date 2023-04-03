using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.ChainOfResponsibility
{
    class Purchase : PurchaseHandler
    {
        public override void BuyHandle(Customer customer, string itemName)
        {
            if(customer.SimplePurchase == true)
            {
                if (itemName == "Sawmill")
                {
                    customer.Farmer.Money -= (int)Price.Sawmill;
                }
                else if (itemName == "Fishing Port")
                {
                    customer.Farmer.Money -= (int)Price.FishingPort;
                }
                else if (itemName == "Forest")
                {
                    customer.Farmer.Money -= (int)Price.Forest;
                }
                else if (itemName == "Garden")
                {
                    customer.Farmer.Money -= (int)Price.Garden;
                }
                else if (itemName == "Chicken Gate")
                {
                    customer.Farmer.Money -= (int)Price.ChickenGate;
                }
                else
                {
                    customer.Farmer.Money -= (int)Price.Chickens;
                }
            }
            else if(Succesor != null)
            {
                Succesor.BuyHandle(customer, itemName);
            }
        }
    }
}

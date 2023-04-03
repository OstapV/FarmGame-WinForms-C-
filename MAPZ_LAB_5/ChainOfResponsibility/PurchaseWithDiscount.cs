using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.ChainOfResponsibility
{
    class PurchaseWithDiscount : PurchaseHandler
    {
        static double DiscountPerсentage = 15;
        public override void BuyHandle(Customer customer, string itemName)
        {
            if(customer.PurchaseWithDiscount == true)
            {
                if (itemName == "Sawmill")
                {
                    customer.Farmer.Money -= (int)Price.Sawmill - CalculateDiscount((int)Price.Sawmill);
                }
                else if (itemName == "Fishing Port")
                {
                    customer.Farmer.Money -= (int)Price.FishingPort - CalculateDiscount((int)Price.FishingPort);
                }
                else if (itemName == "Forest")
                {
                    customer.Farmer.Money -= (int)Price.Forest - CalculateDiscount((int)Price.Forest);
                }
                else if (itemName == "Garden")
                {
                    customer.Farmer.Money -= (int)Price.Garden - CalculateDiscount((int)Price.Garden);
                }
                else if (itemName == "Chicken Gate")
                {
                    customer.Farmer.Money -= (int)Price.ChickenGate - CalculateDiscount((int)Price.ChickenGate);
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

        protected double CalculateDiscount(double price)
        {
            return price *= (DiscountPerсentage / 100);
        }
    }
}

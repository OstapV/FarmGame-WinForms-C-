using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.ChainOfResponsibility
{
    class PurchaseMaintance : PurchaseHandler
    {
        static double MaintancePercentage = 20;
        public override void BuyHandle(Customer customer, string itemName)
        {
            if(customer.PurchaseAndMaintance == true)
            {
                if (itemName == "Sawmill")
                {
                    customer.Farmer.Money -= (int)Price.Sawmill + CalculateMaintancePrice((int)Price.Sawmill);
                }
                else if (itemName == "Fishing Port")
                {
                    customer.Farmer.Money -= (int)Price.FishingPort + CalculateMaintancePrice((int)Price.FishingPort);
                }
                else if (itemName == "Forest")
                {
                    customer.Farmer.Money -= (int)Price.Forest + CalculateMaintancePrice((int)Price.Forest);
                }
                else if (itemName == "Garden")
                {
                    customer.Farmer.Money -= (int)Price.Garden + CalculateMaintancePrice((int)Price.Garden);
                }
                else if (itemName == "Chicken Gate")
                {
                    customer.Farmer.Money -= (int)Price.ChickenGate + CalculateMaintancePrice((int)Price.ChickenGate);
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

        protected double CalculateMaintancePrice(double price)
        {
            return price *= (MaintancePercentage / 100); 
        }
    }
}

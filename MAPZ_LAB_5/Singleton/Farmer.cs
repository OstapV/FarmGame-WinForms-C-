using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MAPZ_LAB_5
{

    public sealed class Farmer : ISeller, IBuyer  // Singleton
    {
        private Farmer() { }
        private static Farmer instance = null;
        private static readonly object syncRoot = new object();  
        
        public static Farmer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Farmer();
                        }
                    }
                }

                return instance;
            }
        }

        public double Money { get; set; }



        public void Sell(string itemName, int count)
        {
            if(itemName == "Wheat")
            {
                Money += (int)Price.Wheat * count;
               
            }
            else if(itemName == "Pumpkin")
            {
                Money += (int)Price.Pumpkin * count;
               
            }
            else if(itemName == "Fish")
            {
                Money += (int)Price.Fish * count;
            }
            else
            {
                Money += (int)Price.Egg * count;
            }
          
        }

        public void Buy(string itemName)
        {
            if(itemName == "Sawmill")
            {
                Money -= (int)Price.Sawmill;
            }
            else if(itemName == "Fishing Port")
            {
                Money -= (int)Price.FishingPort;
            }
            else if(itemName == "Forest")
            {
                Money -= (int)Price.Forest;
            }
            else if(itemName == "Garden")
            {
                Money -= (int)Price.Garden;
            }
            else if(itemName == "Chicken Gate")
            {
                Money -= (int)Price.ChickenGate;
            }
            else
            {
                Money -= (int)Price.Chickens;
            }
        }

        public int FeedChicken(int wheat, int chickenCount)
        {
            int numberOfWheat = chickenCount * 2;

            if (wheat >= numberOfWheat)
            {
                wheat -= (chickenCount * 2);
            }

            return numberOfWheat;
        }


        public bool IsEnoughToFeed(int wheat, int chickenCount)
        {
            int numberOfWheat = chickenCount * 2;

            if(wheat >= numberOfWheat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

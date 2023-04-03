using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.TemplateMethod
{
    class Products : ContextAnalyzer
    {
        private List<string> productsNames;

        public override void Initialize()
        {
            productsNames = new List<string>();
        }

        public override void Select(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if ((items[i] == "Wheat") || (items[i] == "Fish")
                    || (items[i] == "Egg") || (items[i] == "Pumpkin"))
                {
                    productsNames.Add(items[i]);
                }
            }
        }

        public override void FillMain()
        {
            Items.AddRange(productsNames);
        }

        public override void Sort()
        {
            productsNames.Sort();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAPZ_LAB_5.TemplateMethod
{
    class Buildings : ContextAnalyzer
    {
        private List<string> buildingsNames;

        public override void Initialize()
        {
            buildingsNames = new List<string>();
        }

        public override void Select(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if ((items[i] == "Sawmill") || (items[i] == "Fishing Port")
                    || (items[i] == "Garden") || (items[i] == "Forest")
                    || (items[i] == "Chicken Gate"))
                {
                    buildingsNames.Add(items[i]);
                }
            }
        }

        public override void FillMain()
        {
            Items.AddRange(buildingsNames);
        }

        public override void Sort()
        {
            buildingsNames.Sort();
        }
    }
}

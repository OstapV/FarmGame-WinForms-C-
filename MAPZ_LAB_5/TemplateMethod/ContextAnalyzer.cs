using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.TemplateMethod
{
    public abstract class ContextAnalyzer
    {
        public List<string> Items = new List<string>();

        abstract public void Initialize();

        abstract public void Select(List<string> items);

        abstract public void Sort();

        abstract public void FillMain();

        public void Analyze(List<string> items)
        {
            Initialize();
            Select(items);
            Sort();
            FillMain();
        }

    }
}

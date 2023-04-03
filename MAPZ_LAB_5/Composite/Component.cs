using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MAPZ_LAB_5
{
    abstract class Component
    {
        public string name;
        public string path;

        public Component(string _name, string _path)
        {
            this.name = _name;
            this.path = _path;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract Component GetSpecificFolder(string name);
        public abstract Image GetFolderLeaf(Folder c, string name);
        protected abstract Image ConvertComponent(Component c);

    }
}

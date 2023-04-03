using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class Folder : Component
    {
        public List<Component> childrenComponent;
        
        public Folder(string _name, string _path)
            : base(_name, _path)
        {
           childrenComponent = new List<Component>();
        }

        public override void Add(Component component)
        {
            childrenComponent.Add(component);
        }

        public override void Remove(Component component)
        {
            childrenComponent.Remove(component);
        }

        public override Component GetSpecificFolder(string name)
        {
            return this.childrenComponent.Find(c => c.name == name);
        }

        public override Image GetFolderLeaf(Folder c, string name)
        {
            return ConvertComponent(c.childrenComponent.Find(x => x.name == name));
        }

        protected override Image ConvertComponent(Component c)
        {
            return Image.FromFile(c.path);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MAPZ_LAB_5
{
    class FolderLeaf : Component
    {
        public FolderLeaf(string _name, string _path)
            : base(_name, _path)
        {
        }

        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override Image GetFolderLeaf(Folder c, string name)
        {
            return ConvertComponent(c.childrenComponent.Find(x => x.name == name));
        }

        protected override Image ConvertComponent(Component c)
        {
            return Image.FromFile(c.path);
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }

        public override Component GetSpecificFolder(string name)
        {
            throw new NotImplementedException();
        }
    }
}

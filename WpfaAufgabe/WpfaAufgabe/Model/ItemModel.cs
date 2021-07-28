using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfaAufgabe.Model
{
    public class ItemModel 
    {
        private string _nameItem;

        private List<PropertyModel> _properties;

        public List<PropertyModel> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        public string NameItem
        {
            get { return _nameItem; }
            set { _nameItem = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfaAufgabe.Model;

namespace WpfaAufgabe.Core
{
    public static class TiaFileConverter
    {
        private static XDocument xDocument;
        private static List<ItemModel> manifestModel;
        public static List<ItemModel> GetModels(string fileName)
        {
            xDocument = XDocument.Load(fileName);
            string version = xDocument.Root.Attribute("Version").Value;

            manifestModel = new List<ItemModel>();

            foreach (XElement e in xDocument.Descendants("node"))
            {
                manifestModel.Add(new ItemModel()
                {
                    NameItem = (string)e.Attribute("Type").Value
                    
                }
                );
            }

            return manifestModel;
        }


        public static List<PropertyModel> GetProperties(string itemName)
        {

            List<PropertyModel> properties = new List<PropertyModel>();


            foreach (XElement e in xDocument.Descendants("node"))
            {
                string name = (string)e.Attribute("Type").Value;
                if (name.Equals(itemName))
                {
                    foreach(XElement propertie in e.Descendants("property"))
                    {
                        properties.Add(new PropertyModel()
                            {
                                KeyName = (string)propertie.Element("key").Value,
                                Value = (string)propertie.Element("value").Value
                            }
                        );
                    }
                }

            }
            return properties;
        }
    }
}

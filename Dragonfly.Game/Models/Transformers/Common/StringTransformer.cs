using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    // TODO properly escape the strings
    public class StringTransformer
    {
         #region instance
        
        private static StringTransformer _Instance;
        public static StringTransformer Instance 
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new StringTransformer();
                }

                return _Instance;
            }
        }

        private StringTransformer() { }

        #endregion

        public XElement ToXElement(string entity, XName name)
        {
            return new XElement(name, entity);                        
        }

        public string ToEntity(XElement xElement)
        {
            return xElement.Value;
        }

        public string ToEntity(XAttribute attribute)
        {
            return attribute.Value;
        }

        public XAttribute ToXAttribute(string entity, XName name)
        {
            return new XAttribute(name, entity);
        }

      
    }
}

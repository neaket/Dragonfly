using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml.Linq;
using Dragonfly.Models.Transformers.Exceptions;

namespace Dragonfly.Models.Transformers.Common
{
    public class ColorTransformer
    {
        #region instance

        private static ColorTransformer _Instance;

        public static ColorTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ColorTransformer();
                }

                return _Instance;
            }
        }

        private ColorTransformer() { }

        #endregion

        public void ToEntity(XAttribute attribute, ref Color entity)
        {
            string value = attribute.Value;

            if (value[0] != '#')
            {
                throw new TransformerException(String.Format("The color '{0}' is not in a valid format."));
            }
            else
            {
                value = value.Substring(1);
                if (value.Length != 8 && value.Length != 6)
                {
                    throw new TransformerException(String.Format("The color '{0}' is not in a valid format."));
                }

                string alpha;
                string red;
                string green;
                string blue;
                if (value.Length == 8)
                {
                    alpha = value.Substring(0, 2);
                    value = value.Substring(2);
                    entity.A = Convert.ToByte(alpha);
                }
                red = value.Substring(0, 2);
                green = value.Substring(2, 2);
                blue = value.Substring(4, 2);

                entity.R = Convert.ToByte(red);
                entity.G = Convert.ToByte(green);
                entity.B = Convert.ToByte(blue);
            }            
        }

        public Color ToEntity(XAttribute attribute)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException();
            }

            Color entity = new Color();
            ToEntity(attribute, ref entity);
            return entity;
        }

        public XAttribute ToXAttribute(Color entity, string name)
        {            
            string color = "#";
            byte[] data;
            if (entity.A != 255)
            {
                data = new byte[] {entity.A, entity.R, entity.G, entity.B};
            } 
            else 
            {
                data = new byte[] {entity.R, entity.G, entity.B};
            }

            color += BitConverter.ToString(data).Replace("-", String.Empty);

            return new XAttribute(name, color);
        }
    }
}

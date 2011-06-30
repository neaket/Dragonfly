using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace Indicle.Dragonfly.Models.Transformers.Common
{
    public class Vector2Transformer
    {
        private const string STR_X = "X";
        private const string STR_Y = "Y";

        #region instance

        private static Vector2Transformer _Instance;

        public static Vector2Transformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Vector2Transformer();
                }

                return _Instance;
            }
        }

        private Vector2Transformer() { }

        #endregion

        public XElement ToXElement(Vector2 entity, XName name)
        {
            XElement xElement = new XElement(name);
            ToXElement(entity, xElement);
            return xElement;
        }

        public void ToXElement(Vector2 entity, XElement xElement)
        {
            xElement.SetAttributeValue(STR_X, entity.X);
            xElement.SetAttributeValue(STR_Y, entity.Y);
        }

        public Vector2 ToEntity(XElement xElement)
        {
            Vector2 entity = new Vector2();
            entity.X = (float)xElement.Attribute(STR_X);
            entity.Y = (float)xElement.Attribute(STR_Y);
            return entity;
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace Dragonfly.Models.Transformers.Common
{
    public class Vector2Transformer : EntityXElementTransformer<Vector2>
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

        public override void ToXElement(Vector2 entity, XElement xElement)
        {
            xElement.SetAttributeValue(STR_X, entity.X);
            xElement.SetAttributeValue(STR_Y, entity.Y);
        }

        public override void ToEntity(XElement xElement, Vector2 entity)
        {
            entity.X = (float)xElement.Attribute(STR_X);
            entity.Y = (float)xElement.Attribute(STR_Y);
        }
    }

    
}

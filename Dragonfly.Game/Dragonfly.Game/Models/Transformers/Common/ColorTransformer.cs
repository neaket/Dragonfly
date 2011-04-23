using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    public class ColorTransformer : IEntityXAttributeTransformer<Color>
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

        public void ToEntity(XAttribute attribute, Color entity)
        {
            throw new NotImplementedException();
        }

        public Color ToEntity(XAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public XAttribute ToXAttribute(Color entity, string name)
        {
            throw new NotImplementedException();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    class ColorTransformer : EntityXElementTransformer<Color>
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

        public override void FromEntity(Color entity, XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(XElement xElement, Color entity)
        {
            throw new NotImplementedException();
        }
    }
}

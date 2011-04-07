using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Dragonfly.Models.Transformers.Common
{
    class MaterialTransformer : EntityXElementTransformer<Texture2D>
    {
        #region instance

        private static MaterialTransformer _Instance;

        public static MaterialTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MaterialTransformer();
                }

                return _Instance;
            }
        }

        private MaterialTransformer() { }

        #endregion

        public override void FromEntity(Texture2D entity, System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(System.Xml.Linq.XElement xElement, Texture2D entity)
        {
            throw new NotImplementedException();
        }
    }
}

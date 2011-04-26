using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    public class MaterialTransformer : IEntityXAttributeTransformer<Texture2D>
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

        public void ToEntity(XAttribute attribute, Texture2D entity)
        {
            throw new NotImplementedException();
        }

        public Texture2D ToEntity(XAttribute attribute)
        {
            if (attribute == null)
            {
                return null;
            }

            throw new NotImplementedException();
        }

        public XAttribute ToXAttribute(Texture2D entity, XName name)
        {
            throw new NotImplementedException();
        }


       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Models.Transformers.WorldElements
{
    public class PolygonElementTransformer : EntityXElementTransformer<PolygonElementEntity>
    {
        public const string STR_PolygonElement = "PolygonElement";
        
        #region Instance
        private static PolygonElementTransformer _Instance;
        public static PolygonElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PolygonElementTransformer();
                }

                return _Instance;
            }
        }

        private PolygonElementTransformer() { }
        #endregion

        public override void ToXElement(PolygonElementEntity entity, System.Xml.Linq.XElement xElement)
        {
            WorldElementTransformer.Instance.ToXElement(entity, xElement);
            throw new NotImplementedException();
        }

        public override void ToEntity(System.Xml.Linq.XElement xElement, PolygonElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

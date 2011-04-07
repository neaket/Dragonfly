using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class PolygonElementTransformer : EntityXElementTransformer<PolygonElementEntity>
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

        public override void FromEntity(PolygonElementEntity entity, System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(System.Xml.Linq.XElement xElement, PolygonElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

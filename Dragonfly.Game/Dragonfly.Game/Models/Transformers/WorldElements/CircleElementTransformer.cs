using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class CircleElementTransformer : EntityXElementTransformer<CircleElementEntity>
    {
        public const string STR_CircleElement = "CircleElement";

        #region Instance
        private static CircleElementTransformer _Instance;
        public static CircleElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CircleElementTransformer();
                }

                return _Instance;
            }
        }

        private CircleElementTransformer() { }
        #endregion

        public override void FromEntity(CircleElementEntity entity, System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(System.Xml.Linq.XElement xElement, CircleElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

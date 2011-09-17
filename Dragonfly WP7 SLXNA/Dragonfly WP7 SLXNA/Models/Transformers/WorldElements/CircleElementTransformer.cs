using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Transformers.Common;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    public class CircleElementTransformer : EntityXElementTransformer<CircleElementEntity>
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

        public override void ToXElement(CircleElementEntity entity, XElement xElement)
        {
            WorldElementTransformer.Instance.ToXElement(entity, xElement);
            throw new NotImplementedException();
        }

        public override void ToEntity(XElement xElement, CircleElementEntity entity)
        {
            WorldElementTransformer.Instance.ToEntity(xElement, entity);
            throw new NotImplementedException();
        }

        public XElement FromEntity(IWorldElementEntity entity)
        {
            throw new NotImplementedException();
        }

        public string EntityName
        {
            get { return STR_CircleElement; }
        }

        public Type Type
        {
            get { return typeof(CircleElementEntity); }
        }

        public PhysicsWorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            throw new NotImplementedException();
        }

        public XElement FromWorldElementEntity(PhysicsWorldElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

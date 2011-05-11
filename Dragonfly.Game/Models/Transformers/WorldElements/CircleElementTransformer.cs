using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.WorldElements
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

        public IWorldElementEntity ToEntity(XElement xElement)
        {
            CircleElementEntity entity = new CircleElementEntity();

            ToEntity(xElement, entity);

            return entity;
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

        public WorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            throw new NotImplementedException();
        }

        public XElement FromWorldElementEntity(WorldElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

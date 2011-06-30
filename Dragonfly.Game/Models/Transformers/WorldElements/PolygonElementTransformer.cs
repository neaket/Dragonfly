using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Transformers.Common;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;
using Indicle.Dragonfly.Models.Transformers.Exceptions;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    public class PolygonElementTransformer : EntityXElementTransformer<PolygonElementEntity>, IWorldElementTransformer
    {
        public const string STR_PolygonElement = "PolygonElement";
        public const string STR_Vertices = "Vertices";
        
        
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

        public override void ToXElement(PolygonElementEntity entity, XElement xElement)
        {
            WorldElementTransformer.Instance.ToXElement(entity, xElement);

            xElement.Add(VerticesTransformer.Instance.ToXAttribute(entity.Vertices, STR_Vertices));
            
        }

        public override void ToEntity(System.Xml.Linq.XElement xElement, PolygonElementEntity entity)
        {
            WorldElementTransformer.Instance.ToEntity(xElement, entity);

            entity.Vertices = VerticesTransformer.Instance.ToEntity(xElement.Attribute(STR_Vertices));
        }

        public string EntityName
        {
            get { return STR_PolygonElement; }
        }

        private Type _Type = typeof(PolygonElementEntity);
        public Type Type
        {
            get { return _Type; }
        }

        public IWorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            PolygonElementEntity entity = new PolygonElementEntity();
            ToEntity(xElement, entity);
            return entity;            
        }

        public XElement FromWorldElementEntity(IWorldElementEntity entity)
        {
            PolygonElementEntity polygon = entity as PolygonElementEntity;
            if (polygon == null)
            {
                throw new TransformerException("Entity was not of type " + typeof(PolygonElementEntity).FullName);
            }

            XElement xElement = new XElement(TransformerSettings.WorldNamespace + EntityName);
            ToXElement(polygon, xElement);
            return xElement;
            throw new NotImplementedException();
        }
    }
}

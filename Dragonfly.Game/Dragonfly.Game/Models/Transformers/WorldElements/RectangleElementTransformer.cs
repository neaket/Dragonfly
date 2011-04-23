using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.WorldElements;
using Dragonfly.Models.Transformers.Common;
using System.Xml.Linq;
using Dragonfly.Models.Transformers.Exceptions;

namespace Dragonfly.Models.Transformers.WorldElements
{
    public class RectangleElementTransformer : EntityXElementTransformer<RectangleElementEntity>, IWorldElementTransformer
    {
        public const string STR_RectangleElement = "BoxElement";
        public const string STR_Size = "Size";

        #region Instance
        
        private static RectangleElementTransformer _Instance;
        public static RectangleElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RectangleElementTransformer();
                }

                return _Instance;
            }
        }

        private RectangleElementTransformer() 
        {
            
        }

        #endregion

        public override void ToXElement(RectangleElementEntity entity, XElement xElement)
        {
            WorldElementTransformer.Instance.ToXElement(entity, xElement);

            xElement.Add(Vector2Transformer.Instance.ToXElement(entity.Size, STR_Size));

        }

        public override void ToEntity(XElement xElement, RectangleElementEntity entity)
        {
            WorldElementTransformer.Instance.ToEntity(xElement, entity);

            entity.Size = Vector2Transformer.Instance.ToEntity(xElement.Element(STR_Size));
        }

        public string EntityName
        {
            get { return STR_RectangleElement; }
        }

        public Type Type
        {
            get { return typeof(RectangleElementEntity); }
        }

        public WorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            RectangleElementEntity entity = new RectangleElementEntity();
            
            ToEntity(xElement, entity);

            return entity;            
        }

        public XElement FromWorldElementEntity(WorldElementEntity entity)
        {
            RectangleElementEntity rectangle = entity as RectangleElementEntity;
            if (rectangle == null)
            {
                throw new TransformerException("Entity was not of type RectangleElementEntity");
            }

            XElement xElement = new XElement(EntityName);
            ToXElement(rectangle, xElement);
            return xElement;
        }
    }
}

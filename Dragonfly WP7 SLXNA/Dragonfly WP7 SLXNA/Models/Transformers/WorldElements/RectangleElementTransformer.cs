using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using Indicle.Dragonfly.Models.Transformers.Common;
using System.Xml.Linq;
using Indicle.Dragonfly.Models.Transformers.Exceptions;
using Microsoft.Xna.Framework.Graphics;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    public class RectangleElementTransformer : EntityXElementTransformer<RectangleElementEntity>, IWorldElementTransformer
    {
        public const string STR_RectangleElement = "RectangleElement";
        public const string STR_Size = "Size";
        public const string STR_Width = "Width";
        public const string STR_Height = "Height";

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

            xElement.Add(new XAttribute(STR_Width, entity.Width));
            xElement.Add(new XAttribute(STR_Height, entity.Height));
        }

        public override void ToEntity(XElement xElement, RectangleElementEntity entity)
        {
            WorldElementTransformer.Instance.ToEntity(xElement, entity);


            entity.Width = (float)xElement.Attribute(STR_Width);
            entity.Height = (float)xElement.Attribute(STR_Height);
            
        }

        public string EntityName
        {
            get { return STR_RectangleElement; }
        }

        private static Type _Type = typeof(RectangleElementEntity);

        public Type Type
        {
            get { return _Type; }
        }

        public IWorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            RectangleElementEntity entity = new RectangleElementEntity();
            
            ToEntity(xElement, entity);

            return entity;            
        }

        public XElement FromWorldElementEntity(IWorldElementEntity entity)
        {
            RectangleElementEntity rectangle = entity as RectangleElementEntity;
            if (rectangle == null)
            {
                throw new TransformerException("Entity was not of type " + typeof(RectangleElementEntity).FullName);
            }

            XElement xElement = new XElement(TransformerSettings.WorldNamespace + EntityName);
            ToXElement(rectangle, xElement);
            return xElement;
        }

    }
}

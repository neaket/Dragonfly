using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Transformers.Common;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Indicle.Dragonfly.Models.Transformers.Exceptions;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    public class WorldElementTransformer : IEntityXElementTransformer<PhysicsWorldElementEntity>
    {
        public const string STR_Name = "Name";
        public const string STR_BodyType = "BodyType";
        public const string STR_FillColor = "FillColor";
        public const string STR_OutlineColor = "OutlineColor";
        public const string STR_Material = "Material";
        public const string STR_Position = "Position";
        public const string STR_Rotation = "Rotation";

        #region Instance
        
        private static WorldElementTransformer _Instance;
        public static WorldElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new WorldElementTransformer();
                }

                return _Instance;
            }
        }

        private WorldElementTransformer() 
        {
        }

   

        #endregion

        private List<IWorldElementTransformer> ChildTransformers = new List<IWorldElementTransformer>() 
        {
            RectangleElementTransformer.Instance,
            //CircleElementTransformer.Instance,
            PolygonElementTransformer.Instance,
            TextElementTransformer.Instance
        };          


        public IWorldElementEntity ToEntity(XElement xElement)
        {
            foreach (var transformer in ChildTransformers)            
            {
                if (transformer.EntityName == xElement.Name.LocalName)
                {
                    return transformer.ToWorldElementEntity(xElement);
                }
            }

            throw new TransformerException(String.Format("World element XElement name '{0}' is unknown.", xElement.Name.LocalName));
        }

        public XElement ToXElement(IWorldElementEntity entity)
        {
            foreach (var transformer in ChildTransformers)
            {
                if (transformer.Type == entity.GetType())
                {
                    return transformer.FromWorldElementEntity(entity);
                }
            }

            throw new TransformerException(String.Format("World element entity type '{0}' is unknown.", entity.GetType()));
        }

        public void ToEntity(XElement xElement, PhysicsWorldElementEntity entity)
        {
            XAttribute xAttribute;
            entity.Name = (xAttribute = xElement.Attribute(STR_Name)) != null ? (string)xAttribute : null;
            entity.Position = Vector2Transformer.Instance.ToEntity(xElement.Element(TransformerSettings.WorldNamespace + STR_Position));
            

            xAttribute = xElement.Attribute(STR_FillColor);

            if (xAttribute != null)
            {
                entity.FillColor = ColorTransformer.Instance.ToEntity(xAttribute);
            }


            xAttribute = xElement.Attribute(STR_Rotation);
            if (xAttribute != null)
            {
                entity.Rotation = (float)xAttribute;
            }

            xAttribute = xElement.Attribute(STR_OutlineColor);
            if (xAttribute != null)
            {
                entity.OutlineColor = ColorTransformer.Instance.ToEntity(xAttribute);
            }

            entity.Material = MaterialTransformer.Instance.ToEntity(xElement.Attribute(STR_Material));
            entity.BodyType = BodyTypeTransformer.Instance.ToEntity(xElement.Attribute(STR_BodyType));
            
        }

        public void SetupTransformer() { }

        public void ToXElement(PhysicsWorldElementEntity entity, XElement xElement)
        {
            if (entity.Name != null)
            {
                xElement.Add(new XAttribute(STR_Name, entity.Name));
            }

            xElement.Add(Vector2Transformer.Instance.ToXElement(entity.Position, TransformerSettings.WorldNamespace + STR_Position));
            xElement.Add(new XAttribute(STR_Rotation, entity.Rotation));
            xElement.Add(ColorTransformer.Instance.ToXAttribute(entity.FillColor, STR_FillColor));
            xElement.Add(ColorTransformer.Instance.ToXAttribute(entity.OutlineColor, STR_OutlineColor));
            xElement.Add(BodyTypeTransformer.Instance.ToXAttribute(entity.BodyType, STR_BodyType));

            if (entity.Material != null)
            {
                xElement.Add(MaterialTransformer.Instance.ToXAttribute(entity.Material, STR_Material));
            }

        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Dragonfly.Models.Transformers.Exceptions;

namespace Dragonfly.Models.Transformers.WorldElements
{
    public class WorldElementTransformer : IEntityXElementTransformer<WorldElementEntity>
    {
        public const string STR_Color = "Color";
        public const string STR_Material = "Material";
        public const string STR_Position = "Position";

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
            CircleElementTransformer.Instance
        };          


        public WorldElementEntity ToEntity(XElement xElement)
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

        public XElement ToXElement(WorldElementEntity entity)
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

        public void ToEntity(XElement xElement, WorldElementEntity entity)
        {
            entity.Positon = Vector2Transformer.Instance.ToEntity(xElement.Element(TransformerSettings.WorldNamespace + STR_Position));

            if (entity.Color == null)
            {
                entity.Color = ColorTransformer.Instance.ToEntity(xElement.Attribute(TransformerSettings.WorldNamespace + STR_Color));
            }
            if (entity.Material == null)
            {
                entity.Material = MaterialTransformer.Instance.ToEntity(xElement.Attribute(TransformerSettings.WorldNamespace + STR_Material));
            }
        }

        public void SetupTransformer() { }

        public void ToXElement(WorldElementEntity entity, XElement xElement)
        {
            xElement.Add(Vector2Transformer.Instance.ToXElement(entity.Positon, TransformerSettings.WorldNamespace + STR_Position));
            xElement.Add(ColorTransformer.Instance.ToXAttribute(entity.Color, TransformerSettings.WorldNamespace + STR_Color));


            if (entity.Material != null)
            {
                xElement.Add(MaterialTransformer.Instance.ToXAttribute(entity.Material, TransformerSettings.WorldNamespace + STR_Material));
            }

        }
    }
}

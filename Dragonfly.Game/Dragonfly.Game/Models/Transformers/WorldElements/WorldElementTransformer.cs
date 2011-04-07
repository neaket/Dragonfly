using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class WorldElementTransformer : IEntityXElementTransformer<WorldElementEntity>
    {
        public const string STR_Color = "Color";
        public const string STR_Position = "Position";
        public const string STR_WorldElements = "WorldElements";


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
            ChildTransformers = new List<Type>();
        }

        #endregion

        public List<Type> ChildTransformers { get; private set; }

        public void FromEntity(WorldElementEntity entity, XElement xElement)
        {
            entity.Positon = Vector2Transformer.Instance.ToEntity(xElement.Element(STR_Position));
            entity.Color = ColorTransformer.Instance.ToEntity(xElement.Attribute(STR_Color));
            entity.Material = MaterialTransformer.Instance.ToEntity(xElement.Attribute(STR_Material));

            switch (xElement.Name.LocalName)
            {
                case RectangleElementTransformer.STR_BoxElement:

                    break;
                case CircleElementTransformer.STR_CircleElement:
                    break;
            }
        }

        public void SetupTransformer() { }

        public void XElementToEntity(XElement xElement, WorldElementEntity entity)
        {

        }


    }
}

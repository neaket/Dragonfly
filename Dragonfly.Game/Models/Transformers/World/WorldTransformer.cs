using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.World;
using System.Xml.Linq;
using Dragonfly.Models.Transformers.Physics;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Transformers.WorldElements;

namespace Dragonfly.Models.Transformers.World
{
    public class WorldTransformer : EntityXElementTransformer<WorldEntity>
    {
        public const string STR_World = "World";
        public const string STR_WorldElements = "WorldElements";

        #region instance
        
        private static WorldTransformer _Instance;
        public static WorldTransformer Instance 
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new WorldTransformer();
                }

                return _Instance;
            }
        }

        private WorldTransformer() { }

        #endregion

        public XElement ToXElement(WorldEntity entity) 
        {
            return ToXElement(entity, STR_World);
        }

        public override void ToXElement(WorldEntity entity, XElement xElement)
        {
            xElement.Add(WorldInfoTransformer.Instance.ToXElement(entity.WorldInfo, TransformerSettings.WorldNamespace + WorldInfoTransformer.STR_WorldInfo));
            xElement.Add(PhysicsSettingsTransformer.Instance.ToXElement(entity.PhysicsSettings));

            XElement worldElements = new XElement(TransformerSettings.WorldNamespace + STR_WorldElements);
            foreach (var element in entity.WorldElements)
            {
                worldElements.Add(WorldElementTransformer.Instance.ToXElement(element));
            }
            xElement.Add(worldElements);
        }

        public override void ToEntity(XElement xElement, WorldEntity entity)
        {
            entity.WorldInfo = WorldInfoTransformer.Instance.ToEntity(xElement.Element(TransformerSettings.WorldNamespace + WorldInfoTransformer.STR_WorldInfo));
            entity.PhysicsSettings = PhysicsSettingsTransformer.Instance.ToEntity(xElement.Element(TransformerSettings.WorldNamespace + PhysicsSettingsTransformer.STR_PhysicsSettings));

            foreach (var worldElement in xElement.Element(TransformerSettings.WorldNamespace + STR_WorldElements).Elements())
            {
                entity.WorldElements.Add(WorldElementTransformer.Instance.ToEntity(worldElement));
            }           

        }
    }
}

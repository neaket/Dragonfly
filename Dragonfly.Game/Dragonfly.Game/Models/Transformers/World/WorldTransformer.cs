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
    class WorldTransformer : EntityXElementTransformer<WorldEntity>
    {
        public const string STR_World = "World";

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

        public XElement EntityToXElement(WorldEntity entity) 
        {
            return FromEntity(entity, STR_World);
        }

        public override void FromEntity(WorldEntity entity, XElement xElement)
        {
            xElement.Add(PhysicsSettingsTransformer.Instance.EntityToXElement(entity.PhysicsSettings));
        }

        public override void XElementToEntity(XElement xElement, WorldEntity entity)
        {
            entity.WorldInfo = WorldInfoTransformer.Instance.ToEntity(xElement.Element(WorldInfoTransformer.STR_WorldInfo));
            entity.PhysicsSettings = PhysicsSettingsTransformer.Instance.ToEntity(xElement.Element(PhysicsSettingsTransformer.STR_PhysicsSettings));
            
            //load world elements
            foreach (var worldElement in xElement.Elements(RectangleElementTransformer.STR_BoxElement))
            {
                entity.WorldElements.Add(RectangleElementTransformer.Instance.ToEntity(worldElement));
            }

            foreach (var worldElement in xElement.Elements(CircleElementTransformer.STR_CircleElement))
            {
                entity.WorldElements.Add(CircleElementTransformer.Instance.ToEntity(worldElement));
            }

            foreach (var worldElement in xElement.Elements(ElipsisElementTransformer.STR_ElipsisElement))
            {
                entity.WorldElements.Add(ElipsisElementTransformer.Instance.ToEntity(worldElement));
            }


        }
    }
}

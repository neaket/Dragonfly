using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.World;
using System.Xml.Linq;
using Dragonfly.Models.Transformers.Physics;
using Dragonfly.Models.Transformers.Common;

namespace Dragonfly.Models.Transformers.World
{
    class WorldTransformer : EntityXElementTransformer<WorldEntity>
    {
        public const string STR_World = "World";

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

        public XElement EntityToXElement(WorldEntity entity) 
        {
            return EntityToXElement(entity, STR_World);
        }

        public override void EntityToXElement(WorldEntity entity, XElement xElement)
        {
            xElement.Add(PhysicsSettingsTransformer.Instance.EntityToXElement(entity.PhysicsSettings));
        }

        public override void XElementToEntity(XElement xElement, WorldEntity entity)
        {
            entity.PhysicsSettings = PhysicsSettingsTransformer.Instance.XElementToEntity(xElement.Element(PhysicsSettingsTransformer.STR_PhysicsSettings));
        }
    }
}

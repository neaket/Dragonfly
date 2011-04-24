using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Dragonfly.Models.Entities.Physics;
using Dragonfly.Models.Transformers.Common;

namespace Dragonfly.Models.Transformers.Physics
{
    public class PhysicsSettingsTransformer : EntityXElementTransformer<PhysicsSettingsEntity>
    {
        public const string STR_PhysicsSettings = "PhysicsSettings";
        public const string STR_Gravity = "Gravity";

        private static PhysicsSettingsTransformer _Instance;
        public static PhysicsSettingsTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PhysicsSettingsTransformer();
                }

                return _Instance;
            }
        }

        public XElement ToXElement(PhysicsSettingsEntity entity)
        {
            return ToXElement(entity, STR_PhysicsSettings);
        }

        public override void ToXElement(PhysicsSettingsEntity entity, XElement xElement)
        {
            xElement.Add(Vector2Transformer.Instance.ToXElement(entity.Gravity, STR_Gravity));
        }

        public override void ToEntity(XElement xElement, PhysicsSettingsEntity entity)
        {
            entity.Gravity = Vector2Transformer.Instance.ToEntity(xElement.Element(STR_Gravity));
        }
    }
}

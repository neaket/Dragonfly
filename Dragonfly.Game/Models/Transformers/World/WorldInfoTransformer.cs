using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.World;
using Dragonfly.Models.Transformers.Common;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.World
{
    public class WorldInfoTransformer : EntityXElementTransformer<WorldInfoEntity>
    {
        public const string STR_WorldInfo = "WorldInfo";
        public const string STR_Name = "Name";
        public const string STR_Description = "Description";
        public const string STR_Language = "Language";

        #region Instance
        private static WorldInfoTransformer _Instance;
        public static WorldInfoTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new WorldInfoTransformer();
                }

                return _Instance;
            }
        }

        private WorldInfoTransformer() { }
        #endregion

        public override void ToXElement(WorldInfoEntity entity, XElement xElement)
        {
            xElement.Add(StringTransformer.Instance.ToXAttribute(entity.Name, TransformerSettings.WorldNamespace + STR_Name));
            xElement.Add(StringTransformer.Instance.ToXAttribute(entity.Description, TransformerSettings.WorldNamespace + STR_Description));
            xElement.Add(StringTransformer.Instance.ToXAttribute(entity.Language, TransformerSettings.WorldNamespace + STR_Language));
        }

        public override void ToEntity(XElement xElement, WorldInfoEntity entity)
        {
            entity.Name = StringTransformer.Instance.ToEntity(xElement.Attribute(TransformerSettings.WorldNamespace + STR_Name));
            entity.Description = StringTransformer.Instance.ToEntity(xElement.Attribute(TransformerSettings.WorldNamespace + STR_Description));
            entity.Language = StringTransformer.Instance.ToEntity(xElement.Attribute(TransformerSettings.WorldNamespace + STR_Language));
        }
    }
}

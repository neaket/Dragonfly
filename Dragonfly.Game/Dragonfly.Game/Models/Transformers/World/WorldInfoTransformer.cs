using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.World;
using Dragonfly.Models.Transformers.Common;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.World
{
    class WorldInfoTransformer : EntityXElementTransformer<WorldInfoEntity>
    {
        public const string STR_WorldInfo = "WorldInfo";

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

        public override void FromEntity(WorldInfoEntity entity, XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(XElement xElement, WorldInfoEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

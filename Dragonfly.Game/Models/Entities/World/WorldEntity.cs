using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.Physics;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Models.Entities.World
{
    public class WorldEntity
    {
        public PhysicsSettingsEntity PhysicsSettings { get; set; }
        public List<WorldElementEntity> WorldElements { get; set; }
        public WorldInfoEntity WorldInfo { get; set; }

        public WorldEntity()
        {
            WorldElements = new List<WorldElementEntity>();
        }
    }
}

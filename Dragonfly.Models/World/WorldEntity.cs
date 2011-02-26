using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Physics;
using Dragonfly.Models.WorldElements;

namespace Dragonfly.Models.World
{
    class WorldEntity
    {
        WorldInfoEntity WorldInfo { get; set; }
        PhysicsSettingsEntity PhysicsSettings { get; set; }
        public List<WorldElementEntity> WorldElements { get; set; }

    }
}

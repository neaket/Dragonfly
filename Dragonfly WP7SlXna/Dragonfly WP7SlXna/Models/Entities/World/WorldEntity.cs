using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Entities.Physics;
using Indicle.Dragonfly.Models.Entities.WorldElements;

namespace Indicle.Dragonfly.Models.Entities.World
{
    public class WorldEntity
    {
        public PhysicsSettingsEntity PhysicsSettings { get; set; }
        public List<IWorldElementEntity> WorldElements { get; set; }
        public WorldInfoEntity WorldInfo { get; set; }

        public WorldEntity()
        {
            WorldElements = new List<IWorldElementEntity>();
        }

        public override bool Equals(object obj)
        {
            if (obj is WorldEntity)
            {
                WorldEntity w2 = obj as WorldEntity;
                if (!PhysicsSettings.Equals(w2.PhysicsSettings))
                {
                    return false;
                }

                if (WorldInfo.Equals(w2.WorldInfo))
                {
                    return false;
                }

                foreach (var e1 in WorldElements)
                {
                    bool contains = false;
                    foreach (var e2 in w2.WorldElements)
                    {
                        if (e1.Equals(e2))
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (!contains)
                    {
                        return false;
                    }
                }

                return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
            //return base.GetHashCode();
           
        }
    }
}

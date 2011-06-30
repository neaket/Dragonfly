using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indicle.Dragonfly.Models.Entities.WorldElements
{
    public class CircleElementEntity : PhysicsWorldElementEntity
    {
        public float Radius { get; set; }

        public override ElementType ElementType
        {
            get
            {
                return ElementType.Circle;
            }
        }
    }
}

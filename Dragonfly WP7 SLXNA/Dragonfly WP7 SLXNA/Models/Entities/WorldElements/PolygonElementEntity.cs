using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Common;

namespace Indicle.Dragonfly.Models.Entities.WorldElements
{
    public class PolygonElementEntity : PhysicsWorldElementEntity
    {
        public Vertices Vertices { get; set; }

        public override ElementType ElementType
        {
            get { return ElementType.Polygon; }
        }


        

    }
}

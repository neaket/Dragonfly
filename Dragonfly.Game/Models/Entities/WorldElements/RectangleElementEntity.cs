using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Indicle.Dragonfly.Models.Entities.WorldElements
{
    public class RectangleElementEntity : PhysicsWorldElementEntity
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public override ElementType ElementType
        {
            get { return ElementType.Rectangle; }
        }
    }
}

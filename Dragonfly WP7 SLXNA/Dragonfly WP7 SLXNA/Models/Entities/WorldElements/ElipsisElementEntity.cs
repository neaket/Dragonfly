using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Indicle.Dragonfly.Models.Entities.WorldElements
{
    public class ElipsisElementEntity : PhysicsWorldElementEntity
    {
        public Vector2 Radius { get; set; }

        public override ElementType ElementType
        {
            get { return ElementType.Elipsis; }
        }
    }
}

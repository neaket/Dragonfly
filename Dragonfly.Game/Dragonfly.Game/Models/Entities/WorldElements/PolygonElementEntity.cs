using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Common;

namespace Dragonfly.Models.Entities.WorldElements
{
    public class PolygonElementEntity : WorldElementEntity
    {
        public Vertices Vertices { get; set; }
    }
}

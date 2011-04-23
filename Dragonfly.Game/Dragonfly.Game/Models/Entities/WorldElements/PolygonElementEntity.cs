using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dragonfly.Models.Entities.WorldElements
{
    public class PolygonElementEntity : WorldElementEntity
    {
        public LinkedList<Vector2> Vertices { get; set; }
    }
}

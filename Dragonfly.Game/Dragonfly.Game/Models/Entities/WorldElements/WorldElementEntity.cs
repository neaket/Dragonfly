using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dragonfly.Models.Entities.WorldElements
{
    public class WorldElementEntity
    {
        public Vector2 Positon {get; set;}
        public Color Color { get; set; }
        public Texture2D Material { get; set; }
        // public Body Body { get; set; }
    }
}

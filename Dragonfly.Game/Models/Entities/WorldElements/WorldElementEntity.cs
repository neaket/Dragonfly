using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace Dragonfly.Models.Entities.WorldElements
{
    public class WorldElementEntity
    {
        public ElementType ElementType { get; set; }
        public float Density { get; set; }

        private Vector2 _Position;
        public Vector2 Positon
        {
            get
            {
                if (Body != null)
                {
                    return Body.Position;
                }
                else
                {
                    return _Position;
                }
            }
            set
            {
                _Position = value;
            }
        }

        public Color Color { get; set; }
        public Texture2D Material { get; set; }
        public Body Body { get; set; }


    }

    public enum ElementType
    {
        Circle,
        Elipsis,
        Polygon,
        Rectangle
    }
}

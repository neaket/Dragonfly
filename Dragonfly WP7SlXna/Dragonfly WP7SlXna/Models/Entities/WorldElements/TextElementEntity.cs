using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Indicle.Dragonfly.Models.Entities.WorldElements
{
    public class TextElementEntity : IWorldElementEntity
    {
        public Vector2 Position { get; set; }
        public SpriteFont Font { get; set; }
        public HorizontalAlignment HorizontalAlignment {get; set;}
        public VerticalAlignment VerticalAlignment { get; set; }
        public string Text { get; set; }
        public Color FillColor { get; set; }
        
    }

    public enum HorizontalAlignment
    {
        Left,
        Center,
        Right
    }

    public enum VerticalAlignment
    {
        Top,
        Middle,
        Bottom
    }
}

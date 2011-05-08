using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Engine.Loader
{
    class RectangleElementLoader
    {
        public static void GenerateTexture(GraphicsDevice graphicsDevice, RectangleElementEntity entity)
        {
            Texture2D texture = new Texture2D(graphicsDevice, entity.Size.X, entity.Size.Y, false, SurfaceFormat.Color);
            




        }
        
    }
}

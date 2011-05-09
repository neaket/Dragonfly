using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Dragonfly.Models.Entities.WorldElements;
using Dragonfly.Models.Entities.World;
using Dragonfly.Engine.Renderer.WorldElements;
using Microsoft.Xna.Framework.Graphics;
using Dragonfly.Engine.Renderers;
using System.Diagnostics;

namespace Dragonfly.Engine.Renderer
{
    class WorldRenderer
    {
        protected WorldEntity _WorldEntity;
        protected CircleElementRenderer _CircleElementRenderer;
        protected Camera2D _camera;

        public WorldRenderer(GraphicsDevice graphicsDevice, WorldEntity worldEntity)
        {
            _WorldEntity = worldEntity;
            _CircleElementRenderer = new CircleElementRenderer();
            _camera = new Camera2D(graphicsDevice);

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(0, null, null, null, null, null, _camera.View);
            foreach (var entity in _WorldEntity.WorldElements)
            {
                if (entity.Texture2D != null)
                {
                    Debug.WriteLine(entity.Position.ToString());
                    spriteBatch.Draw(entity.Texture2D, 
                                     ConvertUnits.ToDisplayUnits(entity.Position), 
                                     null, 
                                     Color.White, 
                                     entity.Rotation,
                                     Vector2.Zero, 
                                     1f, 
                                     SpriteEffects.None, 
                                     0f); 
                }

                //switch (entity.ElementType)
                //{
                //    case ElementType.Circle:
                //        _CircleElementRenderer.Draw(gameTime, entity as CircleElementEntity);
                //        break;
                //    case ElementType.Elipsis:
                //        throw new NotImplementedException();
                //    case ElementType.Polygon:
                //        throw new NotImplementedException();
                //    case ElementType.Rectangle:
                //        throw new NotImplementedException();
                //    default:
                //        throw new NotSupportedException();
                //}



            }

            spriteBatch.End();


        }
    }
}

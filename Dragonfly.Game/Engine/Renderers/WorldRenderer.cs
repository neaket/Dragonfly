using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using Indicle.Dragonfly.Models.Entities.World;
using Indicle.Dragonfly.Engine.Renderer.WorldElements;
using Microsoft.Xna.Framework.Graphics;
using Indicle.Dragonfly.Engine.Renderers;
using System.Diagnostics;

namespace Indicle.Dragonfly.Engine.Renderer
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
                if (entity is PhysicsWorldElementEntity)
                {
                    PhysicsWorldElementEntity physicsEntity = entity as PhysicsWorldElementEntity;
                    if (physicsEntity.Texture2D != null)
                    {
                        spriteBatch.Draw(physicsEntity.Texture2D,
                                         ConvertUnits.ToDisplayUnits(physicsEntity.Position),
                                         null,
                                         Color.White,
                                         physicsEntity.Rotation,
                                         physicsEntity.Origin,
                                         1f,
                                         SpriteEffects.None,
                                         0f);
                    }
                } else if (entity is TextElementEntity){
                    TextElementEntity textEntity = entity as TextElementEntity;
                    spriteBatch.DrawString(textEntity.Font, textEntity.Text, ConvertUnits.ToDisplayUnits(textEntity.Position), textEntity.FillColor);
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

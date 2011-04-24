using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Dragonfly.Models.Entities.WorldElements;
using Dragonfly.Models.Entities.World;
using Dragonfly.Engine.Renderer.WorldElements;

namespace Dragonfly.Engine.Renderer
{
    class WorldRenderer
    {
        protected WorldEntity _WorldEntity;
        protected CircleElementRenderer _CircleElementRenderer;

        public WorldRenderer(WorldEntity worldEntity)
        {
            _WorldEntity = worldEntity;
            _CircleElementRenderer = new CircleElementRenderer();

        }

        public void Draw(GameTime gameTime)
        {
            foreach (var entity in _WorldEntity.WorldElements)
            {

                switch (entity.ElementType)
                {
                    case ElementType.Circle:
                        _CircleElementRenderer.Draw(gameTime, entity as CircleElementEntity);
                        break;
                    case ElementType.Elipsis:
                        throw new NotImplementedException();
                    case ElementType.Polygon:
                        throw new NotImplementedException();
                    case ElementType.Rectangle:
                        throw new NotImplementedException();
                    default:
                        throw new NotSupportedException();
                }

            }
        }
    }
}

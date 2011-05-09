using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Collision;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Engine.Generators
{
    class TextureGenerator
    {
        private GraphicsDevice _graphicsDevice;
        private BasicEffect _effect;
        private Dictionary<string, Texture2D> _materials = new Dictionary<string, Texture2D>();

        public TextureGenerator(GraphicsDevice graphicsDevice, Dictionary<string, Texture2D> materials)
        {
            _graphicsDevice = graphicsDevice;
            _materials = materials;
            _effect = new BasicEffect(graphicsDevice);
        }

        public Texture2D TextureFromWorldElement(WorldElementEntity elementEntity)
        {
            Vertices vertices;
            switch (elementEntity.ElementType)
            {
                case ElementType.Circle:
                    throw new NotImplementedException();
                case ElementType.Elipsis:
                    throw new NotImplementedException();
                case ElementType.Polygon:
                    PolygonElementEntity polygon = elementEntity as PolygonElementEntity;
                    throw new NotImplementedException();
                case ElementType.Rectangle:
                    RectangleElementEntity rectangle = elementEntity as RectangleElementEntity;
                    vertices = new Vertices(4);
                    vertices.Add(Vector2.Zero);
                    vertices.Add(new Vector2(rectangle.Width, 0));
                    vertices.Add(new Vector2(rectangle.Width, rectangle.Height));
                    vertices.Add(new Vector2(0, rectangle.Height));
                    break;
                default:
                    throw new NotSupportedException(String.Format("ElementType '{0}' is not supported", elementEntity.ElementType));                                        
            }

            return TextureFromVertices(vertices, elementEntity.Material, elementEntity.FillColor, elementEntity.OutlineColor, elementEntity.MaterialScale);            
        }        

        public Texture2D TextureFromVertices(Vertices vertices, Texture2D material, Color fillColor, Color outlineColor, float materialScale)
        {
            Vertices verts = new Vertices(vertices);

            AABB vertsBounds = verts.GetCollisionBox();
            verts.Translate(-vertsBounds.Center);

            List<Vertices> decomposedVerts;
            if (!verts.IsConvex())
            {
                decomposedVerts = EarclipDecomposer.ConvexPartition(verts);
            }
            else
            {
                decomposedVerts = new List<Vertices>()
                    {
                        verts
                    };
            }

            //fill
            List<VertexPositionColorTexture[]> verticesFill = new List<VertexPositionColorTexture[]>(decomposedVerts.Count);
            for (int i = 0; i < decomposedVerts.Count; i++)
            {
                verticesFill.Add(new VertexPositionColorTexture[3 * (decomposedVerts[i].Count - 2)]);
                for (int j = 0; j < decomposedVerts[i].Count - 2; j++)
                {
                    verticesFill[i][3 * j].Position = new Vector3(decomposedVerts[i][0], 0f);
                    verticesFill[i][3 * j + 1].Position = new Vector3(decomposedVerts[i].NextVertex(j), 0f);
                    verticesFill[i][3 * j + 2].Position = new Vector3(decomposedVerts[i].NextVertex(j + 1), 0f);
                    verticesFill[i][3 * j].TextureCoordinate = decomposedVerts[i][0] * materialScale;
                    verticesFill[i][3 * j + 1].TextureCoordinate = decomposedVerts[i].NextVertex(j) * materialScale;
                    verticesFill[i][3 * j + 2].TextureCoordinate = decomposedVerts[i].NextVertex(j + 1) * materialScale;
                    verticesFill[i][3 * j].Color = verticesFill[i][3 * j + 1].Color = verticesFill[i][3 * j + 2].Color = fillColor;
                }
            }

            //outline
            VertexPositionColor[] verticesOutline = new VertexPositionColor[2 * verts.Count];
            for (int i = 0; i < verts.Count; i++)
            {
                verticesOutline[2 * i].Position = new Vector3(verts[i], 0f);
                verticesOutline[2 * i + 1].Position = new Vector3(verts.NextVertex(i), 0f);
                verticesOutline[2 * i + 1].Color = verticesOutline[2 * i + 1].Color = outlineColor;
            }

            Vector2 vertsSize = new Vector2(vertsBounds.UpperBound.X - vertsBounds.LowerBound.X, vertsBounds.UpperBound.Y - vertsBounds.LowerBound.Y);

            return RenderTexture((int)(vertsSize.X), (int)vertsSize.Y, material, verticesFill, verticesOutline);            
        }

        public Texture2D RenderTexture(int width, int height, Texture2D material, List<VertexPositionColorTexture[]> verticesFill, VertexPositionColor[] verticesOutline)
        {
            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0f);
            PresentationParameters pp = _graphicsDevice.PresentationParameters;
            RenderTarget2D texture = new RenderTarget2D(_graphicsDevice, width + 2, height + 2, false, SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);

            _graphicsDevice.RasterizerState = RasterizerState.CullNone;
            _graphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
            _graphicsDevice.SetRenderTarget(texture);
            _graphicsDevice.Clear(Color.Transparent);

            _effect.Projection = Matrix.CreateOrthographic(width + 2f, -height - 2f, 0f, 1f);
            _effect.View = halfPixelOffset;

            // render shape
            _effect.TextureEnabled = material != null;
            _effect.Texture = material;
            _effect.VertexColorEnabled = true;
            _effect.Techniques[0].Passes[0].Apply();
            for (int i = 0; i < verticesFill.Count; i++)
            {
                _graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, verticesFill[i], 0, verticesFill[i].Length / 3);
            }

            //render outline
            _effect.TextureEnabled = false;
            _effect.Techniques[0].Passes[0].Apply();
            _graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, verticesOutline, 0, verticesOutline.Length / 2);
            _graphicsDevice.SetRenderTarget(null);

            return texture;
        }
    }
}

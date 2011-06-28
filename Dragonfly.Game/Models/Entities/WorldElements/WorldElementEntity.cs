using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using System.Xml.Serialization;

namespace Dragonfly.Models.Entities.WorldElements
{
    public abstract class PhysicsWorldElementEntity : IWorldElementEntity
    {
        public string Name { get; set; }        
        public Texture2D Texture2D { get; set; }
        public Vector2 Origin { get; set; }
        public abstract ElementType ElementType { get; }
        private float _Density = 1f;
        

        public float Density { 
            get
            {
                return _Density;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Density must be greater than 0");
                }
            }
        }

        private Vector2 _Position;
        public Vector2 Position
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

        private float _Rotation;
        public float Rotation
        {
            get
            {
                if (Body != null)
                {
                    return Body.Rotation;
                }
                else
                {
                    return _Rotation;
                }
            }
            set
            {
                _Rotation = value;
            }
        }

        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; }
        public Texture2D Material { get; set; }
        public float MaterialScale { get; set; }
        public Body Body { get; set; }
        public BodyType BodyType { get; set; }


    }

    public enum ElementType
    {
        Circle,
        Elipsis,
        Polygon,
        Rectangle
    }

}

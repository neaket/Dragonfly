using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Common;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.Common
{
    class VerticesTransformer : IEntityXAttributeTransformer<Vertices>
    {
        #region instance

        private static VerticesTransformer _Instance;

        public static VerticesTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VerticesTransformer();
                }

                return _Instance;
            }
        }

        private VerticesTransformer() { }

        #endregion

        public void ToEntity(System.Xml.Linq.XAttribute attribute, Vertices entity)
        {
            throw new NotImplementedException();
        }

        public Vertices ToEntity(System.Xml.Linq.XAttribute attribute)
        {
            
            string data = (string)attribute.Value;
            
            data = Regex.Replace(data, "[ \t]+", " ");
            data = data.Trim();

            string[] vertices = data.Split(new char[] { ' ' });

            Vertices ret = new Vertices(vertices.Length);

            foreach(string vertex in data.Split(new char[] {' '})) 
            {
                string[] points = vertex.Split(new char[] { ',' });
                ret.Add(new Vector2(System.Convert.ToSingle(points[0]), System.Convert.ToSingle(points[1])));
            }

            return ret;
        }

        public XAttribute ToXAttribute(Vertices entity, XName name)
        {

            StringBuilder value = new StringBuilder(entity.Count * 5);

            foreach (Vector2 vertex in entity)
            {
                value.Append(vertex.X.ToString());
                value.Append(',');
                value.Append(vertex.Y.ToString());
                value.Append(' ');
            }

            return new XAttribute(name, value.ToString());
        }
    }
}

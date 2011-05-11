using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Models.Transformers.WorldElements
{
    public class TextElementTransformer : IWorldElementTransformer
    {
        public const string STR_TextElement = "TextElement";
        public const string STR_Font = "Font";
        public const string STR_HorizontalAlignment = "HorizontalAlignment";
        public const string STR_VerticalAlignment = "VerticalAlignment";
        public const string STR_Text = "Text";
        


        #region Instance
        
        private static TextElementTransformer _Instance;
        public static TextElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TextElementTransformer();
                }

                return _Instance;
            }
        }

        private TextElementTransformer() 
        {
            
        }

        #endregion

        public string EntityName
        {
            get { return STR_TextElement; }
        }

        private static Type _Type = typeof(TextElementEntity);
        public Type Type
        {
            get { return _Type; }
        }

        public WorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            WorldElementEntity entity = new WorldElementEntity();

        }

        public XElement FromWorldElementEntity(WorldElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

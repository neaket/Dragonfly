using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using Indicle.Dragonfly.Module.Content;
using Indicle.Dragonfly.Models.Transformers.Common;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
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

        public IWorldElementEntity ToWorldElementEntity(XElement xElement)
        {
            TextElementEntity entity = new TextElementEntity();

            entity.Font = MenuResources.MenuFont;
            entity.Text = xElement.Attribute(STR_Text).Value;
            entity.Position = Vector2Transformer.Instance.ToEntity(xElement.Element(TransformerSettings.WorldNamespace + WorldElementTransformer.STR_Position));
            entity.FillColor = ColorTransformer.Instance.ToEntity(xElement.Attribute(WorldElementTransformer.STR_FillColor));

            return entity;

        }

        public XElement FromWorldElementEntity(IWorldElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

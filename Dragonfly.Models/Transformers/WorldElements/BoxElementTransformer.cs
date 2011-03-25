using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.WorldElements;
using Dragonfly.Models.Transformers.Common;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class BoxElementTransformer : EntityXElementTransformer<BoxElementEntity>, IEntityXElementTransformer<BoxElementEntity>
    {
        public const string STR_BoxElement = "BoxElement";

        #region Instance
        
        private static BoxElementTransformer _Instance;
        public static BoxElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BoxElementTransformer();
                }

                return _Instance;
            }
        }

        static BoxElementTransformer()
        {
            WorldElementTransformer.Instance.ChildTransformers.Add(typeof(BoxElementTransformer));
        }

        private BoxElementTransformer() 
        {
            
        }

        #endregion

        public override void EntityToXElement(BoxElementEntity entity, System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(System.Xml.Linq.XElement xElement, BoxElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

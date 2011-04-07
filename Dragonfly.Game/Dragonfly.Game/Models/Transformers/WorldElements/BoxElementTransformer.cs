using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.WorldElements;
using Dragonfly.Models.Transformers.Common;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class RectangleElementTransformer : EntityXElementTransformer<RectangleElementEntity>, IEntityXElementTransformer<RectangleElementEntity>
    {
        public const string STR_BoxElement = "BoxElement";

        #region Instance
        
        private static RectangleElementTransformer _Instance;
        public static RectangleElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RectangleElementTransformer();
                }

                return _Instance;
            }
        }

        static RectangleElementTransformer()
        {
            WorldElementTransformer.Instance.ChildTransformers.Add(typeof(RectangleElementTransformer));
        }

        private RectangleElementTransformer() 
        {
            
        }

        #endregion

        public override void FromEntity(RectangleElementEntity entity, System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(System.Xml.Linq.XElement xElement, RectangleElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

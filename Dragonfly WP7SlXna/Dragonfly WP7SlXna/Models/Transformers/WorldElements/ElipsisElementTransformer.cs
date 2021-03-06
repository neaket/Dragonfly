using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using Indicle.Dragonfly.Models.Transformers.Common;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    public class ElipsisElementTransformer : EntityXElementTransformer<ElipsisElementEntity>
    {
        public const string STR_ElipsisElement = "ElipsisElement";
          
        #region Instance
        private static ElipsisElementTransformer _Instance;
        public static ElipsisElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ElipsisElementTransformer();
                }

                return _Instance;
            }
        }

        private ElipsisElementTransformer() { }
        #endregion

        public override void ToXElement(ElipsisElementEntity entity, XElement xElement)
        {
            WorldElementTransformer.Instance.ToXElement(entity, xElement);
            throw new NotImplementedException();
        }

        public override void ToEntity(System.Xml.Linq.XElement xElement, ElipsisElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

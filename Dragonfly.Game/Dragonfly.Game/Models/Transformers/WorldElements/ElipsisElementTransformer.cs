using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.WorldElements;
using Dragonfly.Models.Transformers.Common;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class ElipsisElementTransformer : EntityXElementTransformer<ElipsisElementEntity>
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

        public override void FromEntity(ElipsisElementEntity entity, System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }

        public override void XElementToEntity(System.Xml.Linq.XElement xElement, ElipsisElementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

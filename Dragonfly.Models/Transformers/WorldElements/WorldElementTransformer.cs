using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.Common;
using Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.WorldElements
{
    class WorldElementTransformer : IEntityXElementTransformer<WorldElementEntity>
    {
        public const string STR_WorldElements = "WorldElements";

        #region Instance
        
        private static WorldElementTransformer _Instance;
        public static WorldElementTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new WorldElementTransformer();
                }

                return _Instance;
            }
        }

        private WorldElementTransformer() 
        {
            ChildTransformers = new List<Type>();
        }

        #endregion

        public List<Type> ChildTransformers { get; private set; }

        public void EntityToXElement(WorldElementEntity entity, XElement xElement)
        {
            foreach (var e in xElement.Elements())
            {
                switch (e.Name.LocalName)
                {
                    case BoxElementTransformer.STR_BoxElement:

                        break;
                    case CircleElementTransformer.STR_CircleElement:
                        break;
                }
            }
        }

        public void SetupTransformer() { }

        public void XElementToEntity(XElement xElement, WorldElementEntity entity)
        {

        }


    }
}

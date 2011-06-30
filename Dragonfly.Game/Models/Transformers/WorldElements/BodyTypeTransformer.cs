using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Indicle.Dragonfly.Models.Transformers.Common;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    class BodyTypeTransformer
    {
        private const string STR_Dynamic = "Dynamic";
        private const string STR_Kinematic = "Kinematic";
        private const string STR_Static = "Static";        

        #region Instance
        
        private static BodyTypeTransformer _Instance;
        public static BodyTypeTransformer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BodyTypeTransformer();
                }

                return _Instance;
            }
        }

        private BodyTypeTransformer() 
        {
            
        }

        #endregion


        public XAttribute ToXAttribute(BodyType entity, XName xName)
        {
           
            switch (entity)
            {
                case BodyType.Dynamic:
                    return new XAttribute(xName, STR_Dynamic);
                case BodyType.Kinematic:
                    return new XAttribute(xName, STR_Kinematic);
                case BodyType.Static:
                    return new XAttribute(xName, STR_Static);
                default:
                    throw new NotSupportedException(String.Format("BodyType '{0}' is not supported.", entity.ToString()));

            }
        }

        public BodyType ToEntity(XAttribute xAttribute)
        {
            if (xAttribute == null)
            {
                throw new ArgumentNullException("xAttribute");
            }

            BodyType entity;

            switch (xAttribute.Value)
            {
                case STR_Dynamic:
                    entity = BodyType.Dynamic;
                    break;
                case STR_Kinematic:
                    entity = BodyType.Kinematic;
                    break;
                case STR_Static:
                    entity = BodyType.Static;
                    break;
                default:
                    throw new NotSupportedException(String.Format("BodyType '{0}' is not supported.", xAttribute.Value));
            }
            return entity;
        }
    }
}

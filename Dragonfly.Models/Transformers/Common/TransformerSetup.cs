using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.World;

namespace Dragonfly.Models.Transformers.Common
{
    class TransformerSetup
    {
        public void SetupTransformers()
        {
            WorldTransformer.Instance.SetupTransformer();
        }
    }
}

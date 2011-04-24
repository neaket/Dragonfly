using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.WorldElements
{
    public interface IWorldElementTransformer
    {
        string EntityName { get; }
        Type Type { get; }
        WorldElementEntity ToWorldElementEntity(XElement xElement);
        XElement FromWorldElementEntity(WorldElementEntity entity);
    }
}

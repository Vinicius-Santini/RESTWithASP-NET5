using System.Collections.Generic;

namespace RestWithASPNET.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}

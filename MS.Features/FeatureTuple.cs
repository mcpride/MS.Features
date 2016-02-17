using System.Collections.Generic;
using MS.Features.Strategies;

namespace MS.Features
{
    public class FeatureTuple
    {
        public FeatureBase Feature { get; private set; }
        public IList<IStrategy> Strategies { get; private set; }

        public FeatureTuple(FeatureBase feature, IList<IStrategy> strategies)
        {
            Feature = feature;
            Strategies = strategies;
        }
    }
}

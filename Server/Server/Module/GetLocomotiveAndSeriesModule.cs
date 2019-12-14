using System.Collections.Generic;
using Server.Models;
using Server.Response;

namespace Server.Module
{
    public class GetLocomotiveAndSeriesModule : MainModule<List<LocomotiveAndSeries>>
    {
        public GetLocomotiveAndSeriesModule() : base("GetLocomotiveAndSeries", new GetLocomotiveAndSeries())
        {
        }
    }
}

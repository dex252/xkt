using System.Collections.Generic;
using Server.Models;
using Server.Response;

namespace Server.Module
{
    public class GetResultModule : MainModule<List<LocoData>>
    {
        public GetResultModule() : base("GetResult", new GetResult())
        {
        }
    }
}

using System.Collections.Generic;

namespace RedingtonMiniProject.Api.Data
{
    public static class ProbablityTypes
    {
        public const string CombinedWith = "CombinedWith";
        public const string Either = "Either";

        public static readonly ICollection<string> ProbabilityFunctions = new List<string>
        {
            CombinedWith, Either
        };
    }
}
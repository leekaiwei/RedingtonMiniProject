using RedingtonMiniProject.Api.Data;

namespace RedingtonMiniProject.Api.Validators
{
    public static class Validator
    {
        public static bool ValidateProbabilityFunction(string probabilityFunction)
        {
            if (!Database.ProbabilityFunctions.Contains(probabilityFunction))
            {
                return false;
            }

            return true;
        }
    }
}
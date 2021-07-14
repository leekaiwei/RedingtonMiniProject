using RedingtonMiniProject.Api.Data;
using RedingtonMiniProject.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
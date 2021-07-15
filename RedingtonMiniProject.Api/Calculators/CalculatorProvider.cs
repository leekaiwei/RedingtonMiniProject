using RedingtonMiniProject.Api.Data;
using System;
using System.Collections.Generic;

namespace RedingtonMiniProject.Api.Calculators
{
    public static class CalculatorProvider
    {
        private static readonly IReadOnlyDictionary<string, Type> _calculators = new Dictionary<string, Type>
        {
            { ProbablityTypes.CombinedWith, typeof(CombinedWithCalculator) },
            { ProbablityTypes.Either, typeof(EitherCalculator) },
        };

        public static ICalculator GetCalculator(string probabilityFunction)
        {
            if (string.IsNullOrEmpty(probabilityFunction))
            {
                throw new ArgumentNullException(nameof(probabilityFunction));
            }

            if (!_calculators.TryGetValue(probabilityFunction, out var calculatorType))
            {
                return null;
            }

            return (ICalculator)Activator.CreateInstance(calculatorType);
        }
    }
}
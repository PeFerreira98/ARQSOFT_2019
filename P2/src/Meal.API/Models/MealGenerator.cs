namespace GorgeousFood.Meal.API.Models
{
    public class MealGenerator
    {
        private string Prefix;
        private string Suffix;

        public MealGenerator(string prefix, string suffix) => OverrideGenerationBase(prefix, suffix);

        public string GetGeneratedNumber(long id) => $"{Prefix}{id.ToString()}{Suffix}";

        public void OverrideGenerationBase(string prefix, string suffix)
        {
            Prefix = prefix;
            Suffix = suffix;
        }
    }
}
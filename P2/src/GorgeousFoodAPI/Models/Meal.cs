using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GorgeousFoodAPI.Models
{
    public partial class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MealID { get; set; }
        public string Description { get; set; }
        public string Prefix { get; private set; }
        public string Suffix { get; private set; }

        public Meal()
        {
            Prefix = "##"; 
            Suffix = "$$";
        }

        public string GetGenNumber() => $"{Prefix}{MealID.ToString()}{Suffix}";

        public void OverrideGenerator(string prefix, string suffix)
        {
            Prefix = prefix;
            Suffix = suffix;
        }
    }
}

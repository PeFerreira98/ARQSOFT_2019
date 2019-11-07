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
        private MealGenerator MealGenerator;

        public Meal(string description, string prefix, string suffix){
            Description = description;
            MealGenerator = new MealGenerator(prefix, suffix);
        }
        
        public string GetGenNumber() => MealGenerator.GetGeneratedNumber(MealID);

        public void OverrideGenerator(string prefix, string suffix) => MealGenerator.OverrideGenerationBase(prefix, suffix);
    }
}

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
    }
}

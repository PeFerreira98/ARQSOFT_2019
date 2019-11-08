using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GorgeousFoodAPI.Models
{
    public class MealItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MealItemID { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string MealIdentificationNumber { get; private set; } = "";
        public bool AvailableStatus { get; set; }
        public long MealID { get; set; }
        public Meal Meal { get; set; }

        public MealItem()
        {
            ProductionDate = DateTime.Now;
            AvailableStatus = true;
        }

        public void DisableMealItem() => AvailableStatus = false;

        public void InstantiateMealIDNumber() => MealIdentificationNumber = string.IsNullOrEmpty(MealIdentificationNumber) && Meal != null ? Meal.GetGenNumber() : MealIdentificationNumber;
    }
}

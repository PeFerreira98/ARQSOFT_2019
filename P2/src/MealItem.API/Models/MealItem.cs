using System;

namespace GorgeousFood.MealItem.API.Models
{
    public class MealItem
    {
        public long MealItemID { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string MealIdentificationNumber { get; set; }
        public bool AvailableStatus { get; set; }
        public long MealID { get; set; }
        public long PointOfSaleID { get; set; }

        public MealItem()
        {
            ProductionDate = DateTime.Now;
            AvailableStatus = true;
        }

        public void DisableMealItem() => AvailableStatus = false;
    }
}

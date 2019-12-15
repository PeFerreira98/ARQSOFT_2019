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
            ProductionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            MealIdentificationNumber = "fckThis";
            AvailableStatus = true;
        }

        public MealItem(MealItem mealitem) : this()
        {
            ExpirationDate = mealitem.ExpirationDate;
            MealID = mealitem.MealID;
            PointOfSaleID = mealitem.PointOfSaleID;
        }

        public void DisableMealItem() => AvailableStatus = false;
    }
}

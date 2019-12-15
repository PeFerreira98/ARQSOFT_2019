using System;

namespace GorgeousFood.MealItem.API.DTOs
{
    public class GroupedMealItem
    {
        public long PointOfSaleID { get; set; }
        public long MealID { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }

        public GroupedMealItem(long pointOfSaleID, long mealID, DateTime productionDate, DateTime expirationDate)
        {
            PointOfSaleID = pointOfSaleID;
            MealID = mealID;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

        public GroupedMealItem(long pointOfSaleID, long mealID, DateTime productionDate, DateTime expirationDate, int quantity) : this(pointOfSaleID, mealID, productionDate, expirationDate) => Quantity = quantity;

        public override bool Equals(object obj) => obj is GroupedMealItem items && PointOfSaleID == items.PointOfSaleID && MealID == items.MealID && ProductionDate == items.ProductionDate && ExpirationDate == items.ExpirationDate;
        public override int GetHashCode() => HashCode.Combine(PointOfSaleID, MealID, ProductionDate, ExpirationDate);
    }
}

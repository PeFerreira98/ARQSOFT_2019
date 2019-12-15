using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFood.Gateway.API.DTOs
{
    public class GroupedMealItemOutputDTO
    {

        public long PointOfSaleID { get; set; }
        public string PointOfSaleDescription { get; set; }
        public long MealID { get; set; }
        public string MealDescription { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }

        public GroupedMealItemOutputDTO()
        {
        }

        public GroupedMealItemOutputDTO(long pointOfSaleID, string pointOfSaleDescription, long mealID, string mealDescription, DateTime productionDate, DateTime expirationDate, int quantity)
        {
            PointOfSaleID = pointOfSaleID;
            PointOfSaleDescription = pointOfSaleDescription;
            MealID = mealID;
            MealDescription = mealDescription;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Quantity = quantity;
        }
    }
}

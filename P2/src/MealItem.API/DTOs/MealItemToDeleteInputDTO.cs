using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFood.MealItem.API.DTOs
{
    public class MealItemToDeleteInputDTO
    {
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public long MealID { get; set; }
        public long PointOfSaleID { get; set; }
    }
}

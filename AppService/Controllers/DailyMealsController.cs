using Common.ApiModels.FoodModels;
using Data.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppService.Controllers
{
    public class DailyMealsController : Base.BaseController
    {
        public DailyMealsController(IHomiesDataSystem data) : base(data)
        {
        }

        // GET: api/DailyMeals
        public IEnumerable<FoodApiModel> Get()
        {
            var mealsOfTheDay = new List<FoodApiModel>();

            var foods = this.Data.Foods.All().Where(m => m.CanFoodShowOnApp && m.IsMealOfTheDay).OrderByDescending(m => m.CreatedOn).ToList();
            return Mappers.FoodMapper.MapFoodDbModelToApiModels(foods);
        }
    }
}

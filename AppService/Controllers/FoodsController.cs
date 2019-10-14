using Data.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppService.Controllers
{
    public class FoodsController : Base.BaseController
    {
        public FoodsController(IHomiesDataSystem data) : base(data)
        {
        }

        // GET: api/Food
        public IEnumerable<Common.Models.FoodApiModel> Get(int? count = 10, int? skip = 0)
        {
            var returnFoods = new List<Common.Models.FoodApiModel>();

            var foods = this.Data.Foods.All().OrderByDescending(m => m.CreatedOn).Skip(skip.Value)
                .Take(count.Value)
                .ToList();
            foreach (var c in foods)
            {
                var food = new Common.Models.FoodApiModel()
                {
                    CategoryName = c.Category.Name,
                    Currency = c.Currency.ToString(),
                    Description = c.Description,
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                };
                if (c.Pictures.Any())
                    food.PicturePath = c.Pictures.FirstOrDefault().FileName;
                else
                    food.PicturePath = Common.GlobalConstants.DefaultFoodPicture;

                returnFoods.Add(food);
            }

            return returnFoods;
        }

        // GET: api/Food/5
        public string Get(int id)
        {
            return "value";
        }

    }
}

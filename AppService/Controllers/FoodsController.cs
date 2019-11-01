using AppService.Services.Food;
using Common.ApiModels.FoodModels;
using Data.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppService.Controllers
{

    public class FoodsController : Base.BaseController
    {
        private FoodService FoodService;

        public FoodsController(IHomiesDataSystem data) : base(data)
        {
            this.FoodService = new Services.Food.FoodService(data);
        }

        // GET: api/Foods
        public IEnumerable<FoodApiModel> Get(int? count = 10, int? skip = 0)
        {
            var foods = this.HomiesData.Foods.All().Where(m => m.CanFoodShowOnApp).OrderByDescending(m => m.CreatedOn).Skip(skip.Value)
                .Take(count.Value)
                .ToList();

            return Mappers.FoodMapper.MapFoodDbModelToApiModels(foods);
        }

        public FoodApiModel Get(Guid id)
        {
            var foodDbModel = this.HomiesData.Foods.GetById(id);
            return Mappers.FoodMapper.MapSingleFoodToApiModel(foodDbModel);
        }

        [HttpPost]
        public async Task<bool> Post(FoodApiModel model)
        {
           return await this.FoodService.AddFoodAsync(model);
        }

        [HttpPut]
        public async Task<bool> Put(FoodApiModel model)
        {
            return await this.FoodService.UpdateFoodAsync(model);
        }



    }
}

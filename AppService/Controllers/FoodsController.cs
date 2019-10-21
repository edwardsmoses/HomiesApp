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
    
    public class FoodsController : Base.BaseController
    {
        public FoodsController(IHomiesDataSystem data) : base(data)
        {
        }

        // GET: api/Foods
        public IEnumerable<FoodApiModel> Get(int? count = 10, int? skip = 0)
        {
            var foods = this.Data.Foods.All().Where(m => m.CanFoodShowOnApp).OrderByDescending(m => m.CreatedOn).Skip(skip.Value)
                .Take(count.Value)
                .ToList();

            return  Mappers.FoodMapper.MapFoodDbModelToApiModels(foods);
        }

        public Common.ApiModels.FoodModels.FoodApiModel Get(Guid id)
        {
            var foodDbModel = this.Data.Foods.GetById(id);
            if(foodDbModel != null)
                return Mappers.FoodMapper.MapSingleFoodToApiModel(foodDbModel);

            return null;
        }

    }
}

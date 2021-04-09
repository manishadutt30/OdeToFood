using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponent
{
    public class RestaurantCountViewComponent: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        private readonly IRestaurantData _restaurantData;

        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountRestaurant();
            return View(count);
        }
    }
}

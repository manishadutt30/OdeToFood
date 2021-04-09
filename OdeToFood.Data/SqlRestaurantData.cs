using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly odeToFoodDbContext _odeToFoodDbContext;
        public SqlRestaurantData(odeToFoodDbContext odeToFoodDbContext)
        {
            _odeToFoodDbContext = odeToFoodDbContext;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _odeToFoodDbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _odeToFoodDbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var resturant = GetById(id);
            if(resturant != null)
            {
                _odeToFoodDbContext.restaurants.Remove(resturant);
            }            
            return resturant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return _odeToFoodDbContext.restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in _odeToFoodDbContext.restaurants
                        where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = _odeToFoodDbContext.restaurants.Attach(updateRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updateRestaurant;
        }

        public int GetCountRestaurant()
        {
            return _odeToFoodDbContext.restaurants.Count();
        }
    }
}

using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant> {
                new Restaurant { Id=1, Name = "Testing1", Location="Testing1", Cuisine=CuisineType.None},
                new Restaurant { Id=2, Name = "Testing2", Location="Testing2", Cuisine=CuisineType.Mexican},
                new Restaurant { Id=3, Name = "Testing3", Location="Testing3", Cuisine=CuisineType.Italian},
                new Restaurant { Id=4, Name = "Testing4", Location="Testing4", Cuisine=CuisineType.Indian}
            };
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updateRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        IEnumerable<Restaurant> IRestaurantData.GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        IEnumerable<Restaurant> IRestaurantData.GetRestaurantByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(x => x.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountRestaurant()
        {
            return restaurants.Count();
        }
    }
}

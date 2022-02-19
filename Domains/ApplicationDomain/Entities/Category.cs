using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public enum Category
    {
        SoupStarterSalad,
        BurgerPasta,
        Beefsteak,
        LambPorkChickenFish,
        SideSauceDessert,
        Wine,
        ButcherFreshMeat,
        Souvenir,
    }

    public static class CategoryMap
    {
        public static string ToName(Category category)
        {
            switch (category)
            {
                case Category.SoupStarterSalad: return "Soups~Starters~Salads";
                case Category.BurgerPasta: return "Burgers~Pastas";
                case Category.Beefsteak: return "Beef~Steaks";
                case Category.LambPorkChickenFish: return "Lamb~Pork~Chicken~Fish";
                case Category.SideSauceDessert: return "Sides~Sauces~Desserts";
                case Category.Wine: return "Wine";
                case Category.ButcherFreshMeat: return "El Butcher~Fresh Meats";
                case Category.Souvenir: return "El Souvenirs";
            }
            return string.Empty;
        }
    }
}

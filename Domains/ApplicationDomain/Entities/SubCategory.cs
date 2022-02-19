
using System.Collections.Generic;

namespace ApplicationDomain.Entities
{
    public enum SubCategory
    {
        Soup,
        Salads,
        Starters,
        Pastas,
        Burger,
        Wagyu,
        SpecialSelection,
        BoneIn,
        Beef,
        Chicken,
        Lamb,
        Fish,
        Pork,
        Desserts,
        Sauces,
        Sides,
        Champagne,
        SparklingWine,
        RoseWine,
        WhiteWine,
        RedWine,
        ButcherFreshMeats,
        Souvenirs,
    }

    public static class SubCategoryMap
    {
        public static List<SubCategory> MapFromCategory(Category category)
        {
            switch (category)
            {
                case Category.SoupStarterSalad:
                    return new List<SubCategory>() { SubCategory.Soup, SubCategory.Starters, SubCategory.Salads };
                case Category.BurgerPasta:
                    return new List<SubCategory>() { SubCategory.Pastas, SubCategory.Burger };
                case Category.Beefsteak:
                    return new List<SubCategory>() { SubCategory.Wagyu, SubCategory.SpecialSelection, SubCategory.BoneIn, SubCategory.Beef };
                case Category.LambPorkChickenFish:
                    return new List<SubCategory>() { SubCategory.Chicken, SubCategory.Lamb, SubCategory.Pork, SubCategory.Fish };
                case Category.SideSauceDessert:
                    return new List<SubCategory>() { SubCategory.Sides, SubCategory.Sauces, SubCategory.Desserts };
                case Category.Wine:
                    return new List<SubCategory>() { SubCategory.Champagne, SubCategory.SparklingWine, SubCategory.RoseWine, SubCategory.WhiteWine, SubCategory.RedWine };
                case Category.ButcherFreshMeat:
                    return new List<SubCategory>() { SubCategory.ButcherFreshMeats };
                case Category.Souvenir:
                    return new List<SubCategory>() { SubCategory.Souvenirs };
            }
            return null;
        }

        public static string ToName(SubCategory subCategory)
        {
            switch (subCategory)
            {
                case SubCategory.Soup: return "Soup";
                case SubCategory.Salads: return "Salads";
                case SubCategory.Starters: return "Starters";
                case SubCategory.Pastas: return "Pastas";
                case SubCategory.Burger: return "El Gaucho Burger";
                case SubCategory.Wagyu: return "Wagyu";
                case SubCategory.SpecialSelection: return "Special Selection";
                case SubCategory.BoneIn: return "Bone-In";
                case SubCategory.Beef: return "Beef";
                case SubCategory.Chicken: return "Chicken";
                case SubCategory.Lamb: return "Lamb";
                case SubCategory.Fish: return "Fish";
                case SubCategory.Pork: return "Pork";
                case SubCategory.Desserts: return "Desserts";
                case SubCategory.Sauces: return "Sauces";
                case SubCategory.Sides: return "Sides";
                case SubCategory.Champagne: return "Champagne";
                case SubCategory.SparklingWine: return "Sparkling Wine";
                case SubCategory.RoseWine: return "Rose’ Wine";
                case SubCategory.WhiteWine: return "White Wine";
                case SubCategory.RedWine: return "Red Wine";
                case SubCategory.ButcherFreshMeats: return "El Butcher | Fresh Meats";
                case SubCategory.Souvenirs: return "El Souvenirs";
            }
            return string.Empty;
        }
    }
}

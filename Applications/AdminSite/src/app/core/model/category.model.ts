import { SubCategory } from './subcategory.model';

export enum Category {
  SoupStarterSalad,
  BurgerPasta,
  Beefsteak,
  LambPorkChickenFish,
  SideSauceDessert,
  Wine,
  ButcherFreshMeat,
  Souvenir,
}

export const CATEGORY_NAME = new Map<Category, string>([
  [Category.SoupStarterSalad, 'Soups~Starters~Salads'],
  [Category.BurgerPasta, 'Burgers~Pastas'],
  [Category.Beefsteak, 'Beef~Steaks'],
  [Category.LambPorkChickenFish, 'Lamb~Pork~Chicken~Fish'],
  [Category.SideSauceDessert, 'Sides~Sauces~Desserts'],
  [Category.Wine, 'Wine'],
  [Category.ButcherFreshMeat, 'El Butcher~Fresh Meats'],
  [Category.Souvenir, 'El Souvenirs'],
]);

export const CATEGORIES: Category[] = [
  Category.SoupStarterSalad,
  Category.BurgerPasta,
  Category.Beefsteak,
  Category.LambPorkChickenFish,
  Category.SideSauceDessert,
  Category.Wine,
  Category.ButcherFreshMeat,
  Category.Souvenir,
];

export const CATEGORY_CHILD = new Map<Category, SubCategory[]>([
  [Category.SoupStarterSalad, [SubCategory.Soup, SubCategory.Salads, SubCategory.Starters]],
  [Category.BurgerPasta, [SubCategory.Pastas, SubCategory.Burger]],
  [Category.Beefsteak, [SubCategory.Wagyu, SubCategory.SpecialSelection, SubCategory.BoneIn, SubCategory.Beef]],
  [Category.LambPorkChickenFish, [SubCategory.Lamb, SubCategory.Pork, SubCategory.Chicken, SubCategory.Fish]],
  [Category.SideSauceDessert, [SubCategory.Desserts, SubCategory.Sauces, SubCategory.Sides]],
  [Category.Wine, [SubCategory.Champagne, SubCategory.SparklingWine, SubCategory.RoseWine, SubCategory.WhiteWine, SubCategory.RedWine]],
  [Category.ButcherFreshMeat, [SubCategory.ButcherFreshMeats]],
  [Category.Souvenir, [SubCategory.Souvenirs]],
]);

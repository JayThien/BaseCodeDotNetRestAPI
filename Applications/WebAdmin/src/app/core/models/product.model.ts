import { Category } from './category.model';
import { SubCategory } from './subcategory.model';

export class Product {
  id: number;
  name: string;
  price: number;
  isAvailable: boolean;
  image: string;
  description: string;
  currency: string;
  category: Category;
  subCategory: SubCategory;
}

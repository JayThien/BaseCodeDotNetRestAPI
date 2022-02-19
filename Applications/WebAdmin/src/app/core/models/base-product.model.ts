import { Category } from './category.model';
import { SubCategory } from './subcategory.model';

export class BaseProduct {
  id: number;
  name: string;
  isAvailable: boolean;
  image: string;
  description: string;
  category: Category;
  subCategory: SubCategory;
}

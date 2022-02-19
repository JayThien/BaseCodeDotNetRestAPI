import { Country } from './country.model';

export class RestaurantListItem {
  id: number;
  name: string;
  address: string;
  email: string;
  phoneNumber: string;
  country: Country;
  isOpening: boolean;
}

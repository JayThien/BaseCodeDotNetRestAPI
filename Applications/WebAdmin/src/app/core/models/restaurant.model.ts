import { Country } from './country.model';

export class Restaurant {
  id: number;
  name: string;
  address: string;
  email: string;
  phoneNumber: string;
  openTime: string;
  closeTime: string;
  reservationLink: string;
  //
  country: Country;
}

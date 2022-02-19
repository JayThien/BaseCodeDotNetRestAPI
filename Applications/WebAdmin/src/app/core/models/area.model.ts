import { Country } from './country.model';

export class Area {
  id: number;
  code: string;
  name: string;
  country: Country;
  user: { id: number, fullname: string };
}

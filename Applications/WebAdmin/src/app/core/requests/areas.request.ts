import { IPaginationRequest } from 'src/app/core/requests/ipagination.request';
import { IRequest } from 'src/app/core/requests/irequest';
import { Country } from '../models/country.model';

export class AreasRequest extends IRequest implements IPaginationRequest {
  pageNumber = 1;
  rowsPerPage = 10;
  searchTerm = '';
  country: Country;
}

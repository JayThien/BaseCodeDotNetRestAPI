import { IPaginationRequest } from 'src/app/core/requests/ipagination.request';
import { IRequest } from 'src/app/core/requests/irequest';

export class RestaurantsRequest extends IRequest implements IPaginationRequest {
  pageNumber = 1;
  rowsPerPage = 10;
  searchTerm = '';
  countryCodes: string[] = [];
}

import { IPaginationRequest } from 'src/app/core/requests/ipagination.request';
import { IRequest } from 'src/app/core/requests/irequest';
import { Country } from '../models/country.model';

export class UserDropdownRequest extends IRequest {
  searchTerm = '';
  roleName = '';
}

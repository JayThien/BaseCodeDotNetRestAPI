import { IPaginationRequest } from '../common/ipagination.request';
import { IRequest } from '../common/irequest';

export class UsersRequest extends IRequest implements IPaginationRequest {
  pageNumber = 1;
  rowsPerPage = 10;
  searchTerm = '';
}

import { IPaginationRequest } from 'src/app/core/requests/ipagination.request';
import { IRequest } from 'src/app/core/requests/irequest';

export class ProductsRequest extends IRequest implements IPaginationRequest {
  pageNumber = 1;
  rowsPerPage = 10;
  searchTerm = '';
  menuId: number;
  category: number;
  subCategories: number[] = [];
}

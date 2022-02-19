import { HttpParams } from '@angular/common/http';
import { IRequest } from '../irequest';

export class UserSearchRequest extends IRequest {
  searchTerm: string;
}

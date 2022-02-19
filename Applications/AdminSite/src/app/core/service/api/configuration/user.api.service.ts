import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DropdownResponse } from 'src/app/core/common/dropdown.response';
import { UserDropdown } from 'src/app/core/model/user-dropdown.model';
import { UserDropdownRequest } from 'src/app/core/request/user-dropdown.request';
import { PaginationResponse } from '../../../common/pagination.response';
import { UsersRequest } from '../../../request/users.request';
import { IConfigurationService } from './iconfiguration.service';

@Injectable({ providedIn: 'root' })
export class UserService implements IConfigurationService {
  constructor(
    private http: HttpClient,
  ) {
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`user`, {
      id: 0,
      fullname: data.fullname,
      dateOfBirth: data.dateOfBirth,
      gender: data.gender,
      avatarURL: data.avatarURL,
      status: 0,
      phoneNumber: data.phoneNumber,
      email: data.email,
      roleId: data.roleId,
    });
  }

  save(data: any): Observable<any> {
    return this.http.put<any>('user', data);
  }

  delete(data: any): Observable<any> {
    throw new Error('Method not implemented.');
  }

  list(request: UsersRequest): Observable<PaginationResponse<any>> {
    const params = request.createParam();
    return this.http.get<PaginationResponse<any>>(`user/list`, { params });
  }

  dropdown(userDropdownRequest: UserDropdownRequest): Observable<DropdownResponse<UserDropdown>> {
    const param = userDropdownRequest.createParam();
    return this.http.get<DropdownResponse<UserDropdown>>(`user/dropdown`, { params: param });
  }


}

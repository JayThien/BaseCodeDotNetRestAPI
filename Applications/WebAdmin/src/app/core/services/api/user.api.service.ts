import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDropdown } from '../../models/user-dropdown.model';
import { UserDropdownRequest } from '../../requests/user-dropdown.request';
import { DropdownResponse } from '../../responses/dropdown.responses';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(
    private http: HttpClient,
  ) {
  }

  dropdown(userDropdownRequest: UserDropdownRequest): Observable<DropdownResponse<UserDropdown>> {
    const param = userDropdownRequest.createParam();
    return this.http.get<DropdownResponse<UserDropdown>>(`user/dropdown`, { params: param });
  }

}

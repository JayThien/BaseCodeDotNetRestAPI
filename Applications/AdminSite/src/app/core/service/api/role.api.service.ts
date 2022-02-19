import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dropdown } from '../../common/dropdown.model';
import { DropdownResponse } from '../../common/dropdown.response';

@Injectable({ providedIn: 'root' })
export class RoleService {
  constructor(
    private http: HttpClient,
  ) {
  }

  dropdown(): Observable<DropdownResponse<Dropdown>> {
    return this.http.get<DropdownResponse<Dropdown>>(`role/dropdown`);
  }


}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dropdown } from '../../models/dropdown.model';
import { DropdownResponse } from '../../responses/dropdown.responses';

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

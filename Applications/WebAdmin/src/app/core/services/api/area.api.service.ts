import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Area } from '../../models/area.model';
import { Dropdown } from '../../models/dropdown.model';
import { AreasRequest } from '../../requests/areas.request';
import { AreasResponse } from '../../responses/areas.response';
import { DropdownResponse } from '../../responses/dropdown.responses';

@Injectable({ providedIn: 'root' })
export class AreaService {
  constructor(
    private http: HttpClient,
  ) {
  }

  list(areasRequest: AreasRequest): Observable<AreasResponse> {
    const param = areasRequest.createParam();
    return this.http.get<AreasResponse>(`area/list`, { params: param });
  }

  get(id: number): Observable<Area> {
    return this.http.get<any>(`area/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`area`, {
      id: 0,
      code: data.code,
      name: data.name,
      country: data.country,
    });
  }

  update(data: any) {
    return this.http.put<any>(`area?id=${data.id}`, data);
  }

  dropdown(): Observable<DropdownResponse<Dropdown>> {
    return this.http.get<DropdownResponse<Dropdown>>(`area/dropdown`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dropdown } from 'src/app/core/common/dropdown.model';
import { DropdownResponse } from 'src/app/core/common/dropdown.response';
import { PaginationResponse } from '../../../common/pagination.response';
import { AreasRequest } from '../../../request/areas.request';
import { IConfigurationService } from './iconfiguration.service';

@Injectable({ providedIn: 'root' })
export class AreaService implements IConfigurationService {
  constructor(
    private http: HttpClient,
  ) {
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`area`, {
      id: 0,
      code: data.code,
      name: data.name,
      country: data.country,
      userId: data.userId,
    });
  }

  save(data: any): Observable<any> {
    return this.http.put<any>(`area`, data);
  }

  delete(data: any): Observable<any> {
    throw new Error('Method not implemented.');
  }

  list(request: AreasRequest): Observable<PaginationResponse<any>> {
    const params = request.createParam();
    return this.http.get<PaginationResponse<any>>(`area/list`, { params });
  }

  dropdown(): Observable<DropdownResponse<Dropdown>> {
    return this.http.get<DropdownResponse<Dropdown>>(`area/dropdown`);
  }

}

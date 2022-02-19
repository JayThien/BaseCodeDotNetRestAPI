import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestaurantsRequest } from 'src/app/core/request/restaurants.request';
import { PaginationResponse } from '../../../common/pagination.response';
import { AreasRequest } from '../../../request/areas.request';
import { IConfigurationService } from './iconfiguration.service';

@Injectable({ providedIn: 'root' })
export class RestaurantService implements IConfigurationService {
  constructor(
    private http: HttpClient,
  ) {
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`restaurant`, data);
  }

  save(data: any): Observable<any> {
    return this.http.put<any>(`restaurant`, data);
  }

  delete(data: any): Observable<any> {
    throw new Error('Method not implemented.');
  }

  list(request: RestaurantsRequest): Observable<PaginationResponse<any>> {
    const params = request.createParam();
    return this.http.get<PaginationResponse<any>>(`restaurant/list`, { params });
  }


}

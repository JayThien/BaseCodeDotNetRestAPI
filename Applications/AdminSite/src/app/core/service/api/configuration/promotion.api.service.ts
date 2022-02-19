import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseProductsRequest } from 'src/app/core/request/base-products.request';
import { PromotionsRequest } from 'src/app/core/request/promotions.request';
import { PaginationResponse } from '../../../common/pagination.response';
import { IConfigurationService } from './iconfiguration.service';

@Injectable({ providedIn: 'root' })
export class PromotionService implements IConfigurationService {
  constructor(
    private http: HttpClient,
  ) {
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`promotion`, data);
  }

  save(data: any): Observable<any> {
    return this.http.put<any>(`promotion`, data);
  }

  delete(data: any): Observable<any> {
    throw new Error('Method not implemented.');
  }

  list(request: PromotionsRequest): Observable<PaginationResponse<any>> {
    const params = request.createParam();
    return this.http.get<PaginationResponse<any>>(`promotion/list`, { params });
  }


}

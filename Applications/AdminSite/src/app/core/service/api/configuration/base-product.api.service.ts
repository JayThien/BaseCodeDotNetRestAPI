import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseProductsRequest } from 'src/app/core/request/base-products.request';
import { PaginationResponse } from '../../../common/pagination.response';
import { IConfigurationService } from './iconfiguration.service';

@Injectable({ providedIn: 'root' })
export class BaseProductService implements IConfigurationService {
  constructor(
    private http: HttpClient,
  ) {
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`baseproduct`, {
      category: data.category,
      description: data.description,
      id: 0,
      imageUrl: data.imageUrl,
      isAvailable: data.isAvailable,
      name: data.name,
      subCategory: data.subCategory,
    });
  }

  save(data: any): Observable<any> {
    return this.http.put<any>(`baseproduct`, data);
  }

  delete(data: any): Observable<any> {
    throw new Error('Method not implemented.');
  }

  list(request: BaseProductsRequest): Observable<PaginationResponse<any>> {
    const params = request.createParam();
    return this.http.get<PaginationResponse<any>>(`baseproduct/list`, { params });
  }


}

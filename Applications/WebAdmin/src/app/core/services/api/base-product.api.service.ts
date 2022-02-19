import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BaseProductsRequest } from '../../requests/base-products.request';
import { BaseProductsResponse } from '../../responses/base-products.response';

@Injectable({ providedIn: 'root' })
export class BaseProductService {
  constructor(
    private http: HttpClient,
  ) {
  }
  getBaseProducts(baseProductsRequest: BaseProductsRequest): Observable<BaseProductsResponse> {
    const param = baseProductsRequest.createParam();
    return this.http.get<BaseProductsResponse>(`baseproduct/list`, { params: param });
  }

  // changeMenuItemStatus(menuitemId: number): Observable<any> {
  //   return this.http.put<any>(`${environment.apiUrl}/product/status/${menuitemId}`, {});
  // }

  getBaseProduct(id: number): Observable<any> {
    return this.http.get<any>(`baseproduct/${id}`);
  }

  createBaseProduct(data: any): Observable<any> {
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

  updateBaseProduct(data: any) {
    return this.http.put<any>(`baseproduct?id=${data.id}`, data);
  }
}

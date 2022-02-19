import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductsRequest } from '../../requests/products.request';

@Injectable({ providedIn: 'root' })
export class ProductService {
  constructor(
    private http: HttpClient,
  ) {
  }

  list(productsRequest: ProductsRequest): Observable<any> {
    const param = productsRequest.createParam();
    return this.http.get<any>(`product/list`, { params: param });
  }

  get(id: number): Observable<any> {
    return this.http.get<any>(`product/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`product`, {
      additions: data.additions,
      category: data.category,
      description: data.description,
      id: 0,
      imageUrl: data.imageUrl,
      isAvailable: data.isAvailable,
      name: data.name,
      price: data.price,
      menuId: data.menuId,
      subCategory: data.subCategory,
    });
  }

  update(data: any): Observable<any> {
    return this.http.put<any>(`product?id=${data.id}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`product?id=${id}`);
  }

}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Area } from '../../models/area.model';
import { AreasRequest } from '../../requests/areas.request';
import { PromotionsRequest } from '../../requests/promotions.request';
import { AreasResponse } from '../../responses/areas.response';
import { PromotionsResponse } from '../../responses/promotions.response';

@Injectable({ providedIn: 'root' })
export class PromotionService {
  constructor(
    private http: HttpClient,
  ) {
  }

  list(promotionsRequest: PromotionsRequest): Observable<PromotionsResponse> {
    const param = promotionsRequest.createParam();
    return this.http.get<PromotionsResponse>(`promotion/list`, { params: param });
  }

  get(id: number): Observable<any> {
    return this.http.get<any>(`promotion/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`promotion`, data);
  }

  update(data: any) {
    return this.http.put<any>(`area?id=${data.id}`, data);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MenuItem } from '../../models/menu_item.model';

@Injectable({ providedIn: 'root' })
export class MenuService {
  constructor(
    private http: HttpClient,
  ) {
  }

  list(): Observable<any> {
    return this.http.get<any>(`menu/list`);
  }

  get(id: number): Observable<MenuItem> {
    return this.http.get<MenuItem>(`menu/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(`menu`, {
      id: 0,
      AreaId: data.AreaId,
    });
  }

  update(data: any) {
    return this.http.put<any>(`menu?id=${data.id}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`menu?id=${id}`);
  }
}

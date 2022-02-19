import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Gender } from '../const/gender';
import { Country } from '../models/country.model';
import { User } from '../models/user';
import { ProductsRequest } from '../requests/products.request';
import { RestaurantsRequest } from '../requests/restaurants.request';
import { UsersRequest } from '../requests/user/users.request';
import { LoginResponse } from '../responses/login.response';
import { PaginationResponse } from '../responses/pagination.response';

@Injectable({ providedIn: 'root' })
export class APIService {
  constructor(
    private http: HttpClient,
  ) {
  }

  login(body: any): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${environment.apiUrl}/auth/login`, body);
  }

  getArea(country: Country): Observable<Country[]> {
    return this.http.get<Country[]>(`${environment.apiUrl}/Area/list?country=${country}`);
  }
  // restaurant
  getRestaurants(restaurantsRequest: RestaurantsRequest): Observable<any> {
    const params = restaurantsRequest.createParam();
    return this.http.get<any>(`${environment.apiUrl}/restaurant/list`, { params });
  }

  createRestaurant(restaurant: any): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/restaurant`, restaurant);
  }

  getRestaurant(id: number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/restaurant/${id}`);
  }

  changeRestaurantStatus(id: number): Observable<any> {
    return this.http.put<any>(`${environment.apiUrl}/restaurant/status/${id}`, {});
  }

  getRestaurantDropdown(): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/restaurant/dropdown`);
  }

  updateRestaurant(restaurant: any): Observable<any> {
    return this.http.put<any>(`${environment.apiUrl}/restaurant?id=${restaurant.id}`, restaurant);
  }


  // user
  getUsers(usersRequest: UsersRequest): Observable<PaginationResponse<User>> {
    const params = usersRequest.createParam();
    return this.http.get<PaginationResponse<User>>(`${environment.apiUrl}/user/list`, { params });
  }

  getUser(id: number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/user/${id}`);
  }

  updateUser(updatedUser: any): Observable<any> {
    return this.http.put<any>(`${environment.apiUrl}/user?id=${updatedUser.id}`, updatedUser);
  }

  createUser(data: any): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/user`, {
      id: 0,
      fullname: data.fullname,
      dateOfBirth: data.dateOfBirth,
      gender: data.gender ? Gender.MALE : Gender.FEMALE,
      avatarURL: data.avatarURL,
      status: 0,
      phoneNumber: data.phoneNumber,
      email: data.email,
      roleId: data.roleId,
    });
  }
}

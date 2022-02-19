import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse } from 'src/app/core/responses/login.response';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthAPIService {

    constructor(
        private http: HttpClient
    ) {
    }

    login(body: any): Observable<LoginResponse> {
        return this.http.post<LoginResponse>(`${environment.apiUrl}/auth/login`, body);
    }

    changePassword(body: any): Observable<boolean> {
        return this.http.put<boolean>(`${environment.apiUrl}/auth/change-password`, body);
    }
}

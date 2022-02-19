// import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';

// import { Observable } from 'rxjs';
// import { Injectable } from '@angular/core';
// import { AuthService } from 'src/app/feature/auth/core/auth.service';
// import { environment } from 'src/environments/environment';

// @Injectable()
// export class JwtInterceptor implements HttpInterceptor {
//     constructor(private authService: AuthService) { }
//     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//         const token = localStorage.getItem(environment.tokenKey);
//         if (token) {
//             req = req.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
//         }
//         return next.handle(req);
//     }
// }

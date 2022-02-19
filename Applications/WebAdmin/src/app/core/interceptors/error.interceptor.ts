import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Injectable, Injector } from '@angular/core';
import { AuthService } from 'src/app/feature/auth/core/auth.service';
import { LoaderService } from '../services/loader.service';
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService, private modalService: NzModalService, private injector: Injector) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const loaderService = this.injector.get(LoaderService);
    if (req.method === 'GET') {
      return next.handle(req).pipe(
        retry(2),
        catchError((error: HttpErrorResponse) => {
          loaderService.hide();
          switch (error.status) {
            case 401:
              this.modalService.error({
                nzTitle: 'Lỗi đăng nhập',
                nzContent: 'Vui lòng đăng nhập lại.'
              });
              this.authService.logout();
              // tslint:disable-next-line: deprecation
              location.reload(true);
              break;
            case 500:
              this.modalService.error({
                nzTitle: 'Hệ thống đang gặp lỗi',
                nzContent: 'Vui lòng thử lại sau.'
              });
              break;
            default:
              const err = error.error.message || error.statusText;
              return throwError(err);
          }
        })
      );
    }
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        loaderService.hide();
        switch (error.status) {
          case 401:
            this.modalService.error({
              nzTitle: 'Lỗi đăng nhập',
              nzContent: 'Vui lòng đăng nhập lại.'
            });
            this.authService.logout();
            // tslint:disable-next-line: deprecation
            location.reload(true);
            break;
          case 500:
            this.modalService.error({
              nzTitle: 'Hệ thống đang gặp lỗi',
              nzContent: 'Vui lòng thử lại sau.'
            });
            break;
          default:
            const err = error.error.message || error.statusText;
            return throwError(err);
        }
      })
    );
  }
}

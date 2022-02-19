import { Observable } from 'rxjs';

export interface IConfigurationService {
  list(request: any): Observable<any>;
  create(data: any): Observable<any>;
  save(data: any): Observable<any>;
  delete(data: any): Observable<any>;
}

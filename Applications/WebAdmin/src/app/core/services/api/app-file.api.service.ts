import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MediaFile } from '../../models/media-file.model';

@Injectable({ providedIn: 'root' })
export class AppFileAPIService {
    constructor(
        private http: HttpClient
    ) {
    }

    getAppFileById(id: number): Observable<MediaFile> {
        return this.http.get<MediaFile>(`${environment.apiUrl}/file?id=${id}`);
    }


    share(file: MediaFile): Observable<any> {
        return this.http.put<any>(`${environment.apiUrl}/file/share`, file);
    }
}

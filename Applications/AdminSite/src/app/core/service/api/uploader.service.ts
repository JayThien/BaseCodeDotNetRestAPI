import { HttpClient, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Dropdown } from '../../common/dropdown.model';
import { DropdownResponse } from '../../common/dropdown.response';

@Injectable({ providedIn: 'root' })
export class UploadService {
    constructor(
        private http: HttpClient,
    ) {
    }

    uploadToServer(file: File): Observable<any> {
        const formData: FormData = new FormData();
        formData.append('file', file);

        return this.http.post<any>('https://localhost:44310/api/file/upload', formData, { reportProgress: true, observe: 'events' });
    }
}

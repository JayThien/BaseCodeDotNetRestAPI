import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserMention } from '../../models/user-mention.model';
import { UserSearch } from '../../models/user-search.model';
import { UserMentionRequest } from '../../requests/user/user-mention.request';
import { UserSearchRequest } from '../../requests/user/user-search.request';


@Injectable({ providedIn: 'root' })
export class UserSystemAPIService {

  constructor(
    private http: HttpClient
  ) {
  }

  getUserSearch(userSearchRequest: UserSearchRequest): Observable<UserSearch[]> {
    const params = userSearchRequest.createParam();
    return this.http.get<UserSearch[]>(`${environment.apiUrl}/user/search`, { params });
  }

  getMentionUser(userMentionRequest: UserMentionRequest): Observable<UserMention[]> {
    const params = userMentionRequest.createParam();
    return this.http.get<UserMention[]>(`${environment.apiUrl}/user/mention?fullname=${userMentionRequest.fullname}`, { params });
  }
}

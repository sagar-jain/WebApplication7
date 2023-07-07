import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url = environment.apiUrl;
  constructor(private http: HttpClient) { }

  signUp(username: string, password: string): Observable<any> {
    const payload = { username, password };
    return this.http.post(this.url, payload);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User, RegistrationRequest, LoginResponse, LoginRequest } from '../models/user';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http : HttpClient) { }

  login(model: LoginRequest) {
    return this.http.post<LoginResponse>(this.baseUrl + 'authentication/login', model).pipe(
      map((response: LoginResponse) => {
        const user = response;
        if(user) {
          console.clear();
          console.log(user);
          // localStorage.setItem('user', JSON.stringify(user));
          // this.currentUserSource.next(user);
        }
      })
    )
  }

  registerUser(model: RegistrationRequest) {
    return this.http.post<LoginResponse>(this.baseUrl + 'authentication/register', model).pipe(
      map((user : LoginResponse) => {
        if(user) {
          console.clear();
          console.log(user);
          // localStorage.setItem('user', JSON.stringify(user));
          // this.currentUserSource.next(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }
}

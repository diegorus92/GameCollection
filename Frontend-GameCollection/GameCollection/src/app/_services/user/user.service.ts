import { Injectable } from '@angular/core';

import {ENVIRONMENT} from '../../../assets/env';
import { BehaviorSubject, Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http'
import { User } from 'src/app/_models/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private _apiUrl = ENVIRONMENT.baseUrl+'user/';
  private _userSubject = new BehaviorSubject<User>(new User());

  constructor(private http:HttpClient) { }

  get userSubject$():Observable<User>{
    return this._userSubject.asObservable(); 
  }

  setUserSubject$(user:User):void{
    this._userSubject.next(user);
  }


  getUserByEmail(email:string):Observable<any>{
    return this.http.get(this._apiUrl+email);
  }
}

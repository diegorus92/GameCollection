import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ENVIRONMENT } from 'src/assets/env';

@Injectable({
  providedIn: 'root'
})
export class DevelopmentCompanyService {

  private _apiUrl = ENVIRONMENT.baseUrl+"DevelopmentCompany";

  constructor(private http:HttpClient) { }


  getCompanyNames():Observable<any>{
    return this.http.get(this._apiUrl);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ENVIRONMENT } from 'src/assets/env';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private _apiUrl = ENVIRONMENT.baseUrl+"Category";

  constructor(private http:HttpClient) { }



  getCategoryNames():Observable<any>{
    return this.http.get(this._apiUrl);
  }
}

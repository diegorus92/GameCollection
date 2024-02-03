import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { GameDTO, GameUser } from 'src/app/_models/game';
import { ENVIRONMENT } from 'src/assets/env';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private _apiUrl = ENVIRONMENT.baseUrl+"game";
  private _gamesSubject = new BehaviorSubject<GameUser[]>([]);

  constructor(private http:HttpClient) { }

  get gamesSubject$():Observable<GameUser[]>{
    return this._gamesSubject.asObservable();
  }

  setGamesSubject$(games:GameUser[]){
    this._gamesSubject.next(games);
  }


  getAllGames():Observable<any>{
    return this.http.get(this._apiUrl);
  }

  postGame(formData:FormData):Observable<any>{
    console.log("[GameService] formData", formData);
    return this.http.post(this._apiUrl+"/new-game",formData, {responseType:'text'});
  }


  prepareGameFormData(gameToPost:GameDTO):FormData{
    const formData:FormData = new FormData();
      if(gameToPost.imageFile !== null && gameToPost.imageFile !== undefined){
        formData.append('imageFile', gameToPost.imageFile);
      }
  
      formData.append('gameName', gameToPost.gameName);
      formData.append('gameRank', gameToPost.gameRank.toString());
      formData.append('gameSynopsis', gameToPost.gameSynopsis);
      
      formData.append('categories', gameToPost.categories.toString());
      formData.append('developmentCompanyName', gameToPost.developmentCompanyName);
      
    return formData;
  }
}

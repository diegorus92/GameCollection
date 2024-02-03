import { Component } from '@angular/core';
import { GameUser } from 'src/app/_models/game';
import { GameService } from 'src/app/_services/game/game.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {

  games!: GameUser[];

  constructor(private gameService:GameService){}

  ngOnInit(){
    this.getAllGames();
  }


  getAllGames(){
    this.gameService.getAllGames().subscribe({
      next: games => {
        console.log("[MAIN]: ", games);
        const game:GameUser = new GameUser();
        this.games = game.PrepareGamesData(games);
        console.log("[MAIN] game list OK: ", this.games);

        this.gameService.setGamesSubject$(this.games);
      }
    })
  }
}

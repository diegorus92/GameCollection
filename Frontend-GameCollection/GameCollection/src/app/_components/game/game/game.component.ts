import { Component, Input } from '@angular/core';
import { GameUser } from 'src/app/_models/game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent {

  @Input() game:any;

  ngOnInit(){
    console.log("[Game]: ", this.game);
  }
}

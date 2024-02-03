import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './_components/user/user/user.component';
import { MenuComponent } from './_components/menu/menu/menu.component';
import { MainComponent } from './_components/main/main/main.component';
import { GameComponent } from './_components/game/game/game.component';
import { GameCreateUpdateComponent } from './_components/game/game-create-update/game-create-update.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    MenuComponent,
    MainComponent,
    GameComponent,
    GameCreateUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

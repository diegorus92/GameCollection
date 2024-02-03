import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './_components/user/user/user.component';
import { MainComponent } from './_components/main/main/main.component';
import { GameCreateUpdateComponent } from './_components/game/game-create-update/game-create-update.component';

const routes: Routes = [
  {path:"", component:MainComponent, pathMatch:"full"},
  {path:"user", component:UserComponent},
  {path:"game-create-update", component:GameCreateUpdateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

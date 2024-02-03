import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';
import { FAKEUSER } from 'src/assets/FakeUser';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  constructor(private rute:ActivatedRoute, private userService:UserService){}

  user!:User;

  ngOnInit(){
    this.userService.userSubject$.subscribe(data => {
      this.user = data;
      console.log("[User]User retrieve from service:" , this.user);
    })
  }


}

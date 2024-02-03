import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {


  constructor(private userService:UserService, private formBuilder:FormBuilder, private router: Router){

  }


  searchUserForm = this.formBuilder.group({
    email: ['',[Validators.email]]
  });

  isSearcSubmitButtonDisabled = false;
  user:User = new User();

  onSubmit(){
    if(this.searchUserForm.valid){
      console.log("[Menu] search email: ", this.searchUserForm.value);
      this.isSearcSubmitButtonDisabled = true;
      this.userService.getUserByEmail(this.searchUserForm.value['email']!).subscribe({
        next: data => {
          console.log("[Menu] user data from api: ", data);

          this.user = this.user.PrepareUserGameData(data);
          console.log("[Menu] User obj ready: ", this.user);
          this.userService.setUserSubject$(this.user);

          this.router.navigate(["user"]);
        },
        error: error => {
          console.log("[Menu] ", error);
        },
        complete: () =>{
          this.isSearcSubmitButtonDisabled = false;
          console.log("[Menu] retrieve user complete");
        }
      })
    }
    else{
      console.log("[Menu] email invalid");
    }
  }
}

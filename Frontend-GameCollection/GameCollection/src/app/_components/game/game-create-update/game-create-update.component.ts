import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GameDTO, GameUser } from 'src/app/_models/game';
import { CategoryService } from 'src/app/_services/category/category.service';
import { DevelopmentCompanyService } from 'src/app/_services/development_company/development-company.service';
import { GameService } from 'src/app/_services/game/game.service';

@Component({
  selector: 'app-game-create-update',
  templateUrl: './game-create-update.component.html',
  styleUrls: ['./game-create-update.component.css']
})
export class GameCreateUpdateComponent {

  companyNames:string[] = [];
  categoryNames:string[] = [];

  formGroupGame = this.formBuilder.group({
    gameName:['',[Validators.required]],
    gameCompanyName:['',[Validators.required]],
    gameImage:[null],
    gameCategories: [[''],[Validators.required]],
    gameSynopsis: ['',[Validators.required]]
  });


  constructor(
    private devCompanyService:DevelopmentCompanyService,
    private categoryService:CategoryService,
    private gameService:GameService,
    private formBuilder:FormBuilder){}

  ngOnInit(){
    this.getCompanyNames();
    this.getCategoryNames();
  }



  getCompanyNames(){
    this.devCompanyService.getCompanyNames().subscribe({
      next: compNames =>{
        for(let companyName of compNames){
          this.companyNames.push(companyName.developmentCompanyName);
        }
      },
      complete:() => console.log("[GameCreateUpdate] company names:",this.companyNames)
    })
  }

  getCategoryNames(){
    this.categoryService.getCategoryNames().subscribe({
      next: categories =>{
        for(let categoryName of categories){
          this.categoryNames.push(categoryName.categoryName);
        }
      },
      complete: () => console.log("[GameCreateUpdate] category names: ", this.categoryNames)
    });
  }

  //Here is captured the file data from input
  //and set in its corresponding formControl in the formGroup
  onFileChange(event:any, formControlName:string){ 
    if(event.target.files.length > 0){ 
      const file = event.target.files[0];
      console.log("[GameCreateUpdate] file catched in file input",file);
      
      //this.formGroupGame.get('gameImage')?.setValue(file);
      this.formGroupGame.get(formControlName)?.patchValue(file); //Set file data in its control
      this.formGroupGame.get(formControlName)?.updateValueAndValidity(); //update new value in control changed
    }
  }

  onSubmit(event:Event){

    event.preventDefault();

    if(this.formGroupGame.valid){
      
      console.log("[GameCreateUpdate]: form group data = ", this.formGroupGame.value);

      //Prepare GameDTO object for append to a FormData for post it
      const gameToPost:GameDTO={
        gameName: this.formGroupGame.value['gameName']!,
        gameRank: 1,
        gameSynopsis: this.formGroupGame.value["gameSynopsis"]!,
        imageFile: this.formGroupGame.get("gameImage")?.value,
        categories:  this.formGroupGame.value["gameCategories"]!,
        developmentCompanyName: this.formGroupGame.value["gameCompanyName"]!
      }

      console.log("[GameCreateUpdate]: GameDTO to post = ", gameToPost);

      //Prepare FormData in order to post it
      const formData:FormData = this.gameService.prepareGameFormData(gameToPost);
      
      console.log("[GameCreateUpdate] formData before to post: ",formData.get('gameName'));

      //Post new game info into a FormData obj in order to upload files.
      this.gameService.postGame(formData).subscribe({
        next: response =>{
          console.log("[GameCreateUpdate]: game post obj ready: ", gameToPost);
          console.log("[GameCreateUpdate]: Response = ",response);
        },
        error: err => console.log("[GameCreateUpdate] error in post: ", err),
        complete:() => console.log("[GameCreateUpdate]: game post successfull")
      });
    }
    else{
      console.log("[GameCreateUpdate]: form invalid!");
      this.formGroupGame.markAllAsTouched();
    }
  }
}

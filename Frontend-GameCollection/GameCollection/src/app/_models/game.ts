

export class GameUser{
    gameId!:number;
    gameName!:string;
    gameRank!:number;
    gameImage!:string;
    gameSynopsis!:string;



    PrepareGamesData(rawData:any): GameUser[]{
        const gameList:GameUser[] = [];

        for(let game of rawData){
            const gameToAdd:GameUser = new GameUser();
            gameToAdd.gameId = game.gameId;
            gameToAdd.gameName = game.gameName;
            gameToAdd.gameImage = game.gameImage;
            gameToAdd.gameRank = game.gameRank;
            gameToAdd.gameSynopsis = game.gameSynopsis;

            gameList.push(gameToAdd);
        }

        return gameList;
    }
}

export class GameDTO{
    gameName!:string;
    gameRank!:number;
    gameSynopsis!:string;
    imageFile!: any;
    categories!:string[];
    developmentCompanyName!:string;
}
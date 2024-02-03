import { GameUser } from "./game";

export class User{
    userNickName!:string;
    userEmail!:string;
    userRolName!:string;

    userGames:GameUser[] = [];

    PrepareUserGameData(rawData:any):User{
        const user = new User();

        user.userNickName = rawData.userNickName;
        user.userEmail = rawData.userEmail;
        user.userRolName = rawData.roleName;
        for(var game of rawData.games){
            const gameToAppend = new GameUser();
            
            gameToAppend.gameId = game.gameId;
            gameToAppend.gameName = game.gameName;
            gameToAppend.gameRank = game.gameRank;
            gameToAppend.gameImage = game.gameImage;
            gameToAppend.gameSynopsis = game.gameSynopsis;

            user.userGames.push(gameToAppend);
        }

        return user;
    }
}
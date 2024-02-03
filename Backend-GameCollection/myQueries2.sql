SELECT G.GameId, G.GameName, U.UserId, U.UserNickName FROM GameUser GU
RIGHT JOIN Games G
ON G.GameId = GU.UserGamesGameId
	LEFT JOIN Users U
	ON U.UserId = GU.GameUsersUserId;


INSERT INTO GameUser
	(GameUsersUserId, UserGamesGameId) 
	VALUES(1,1);

INSERT INTO GameUser
	(GameUsersUserId, UserGamesGameId) 
	VALUES(2,1);

INSERT INTO GameUser
	(GameUsersUserId, UserGamesGameId) 
	VALUES(3,1);
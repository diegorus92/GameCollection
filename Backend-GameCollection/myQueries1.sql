USE GamesCollection;

SELECT U.UserNickName, U.UserEmail, R.RoleName FROM Users AS U
INNER JOIN Roles AS R
ON U.UserRoleRoleId = R.RoleId;

SELECT R.RoleName, U.UserNickName FROM Roles AS R
INNER JOIN Users AS U
ON R.RoleId = U.UserRoleRoleId;

SELECT * FROM Users;
SELECT * FROM Roles;
SELECT * FROM Games;
SELECT * FROM Categories;
SELECT * FROM CategoryGame;

SELECT * FROM DevelopmentCompanies;


SELECT G.GameName, CG.GameCategoryCategoryId, C.CategoryName FROM Games AS G
INNER JOIN CategoryGame AS CG
ON G.GameId = CG.GamesGameId
INNER JOIN Categories AS C
ON C.CategoryId = CG.GameCategoryCategoryId
WHERE G.GameName = 'Hitman 1';

SELECT DevComp.DevelopmentCompanyName, G.GameName FROM Games AS G
INNER JOIN DevelopmentCompanies AS DevComp
ON DevComp.DevelopmentCompanyId = G.GameDevelopmentCompanyDevelopmentCompanyId
WHERE DevComp.DevelopmentCompanyName LIKE('Eidos%');

/*
DELETE GameImages FROM GameImages GI
INNER JOIN Games G
ON GI.ImageGameGameId = G.GameId
WHERE G.GameName = 'Hitman 1';
*/

SELECT G.GameName, GI.GameImageName FROM GameImages GI
INNER JOIN Games G 
ON GI.ImageGameGameId = G.GameId
WHERE G.GameName = 'Hitman 1';

SELECT * FROM GameImages;
SELECT * FROM Games;
SELECT * FROM DevelopmentCompanies;

--Replacing a path for Game Image Path in GAMEIMAGES table for another path (relative path)
UPDATE GameImages 
SET GameImageName = REPLACE(
						GameImageName,--field to update
						'..\assets\images\', --old data
						'') --new data


--Replacing a path for Game Image in GAME table for another path (relative path)						
UPDATE Games
SET GameImage = REPLACE(
				GameImage, 
				'..\assets\images\dmitry-slivin-.jpg',
				'');


UPDATE DevelopmentCompanies 
SET DevelopmentCompanyLogo = REPLACE(
								DevelopmentCompanyLogo,
								'..\assets\images\',
								'');

UPDATE DevelopmentCompanies 
SET DevelopmentCompanyLogo = 'nintendo.jpg' 
WHERE DevelopmentCompanyId = 4;



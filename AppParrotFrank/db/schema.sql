CREATE DATABASE `parrot_frank2` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;


CREATE TABLE `categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Status` int NOT NULL,
  `DateCreation` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `subcategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CategoryId` int DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Price` decimal(10,0) DEFAULT NULL,
  `Status` int NOT NULL,
  `DateCreation` datetime NOT NULL,
  `ImageUrl` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `Nick` varchar(100) NOT NULL,
  `Secret` varchar(100) NOT NULL,
  `Status` int NOT NULL,
  `DateCreation` datetime NOT NULL,
  `LastAccess` datetime NOT NULL,
  `Token` varchar(4000) DEFAULT NULL,
  `RefreshTime` datetime DEFAULT NULL,
  `RefreshToken` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `categories` (`Id`,`Name`,`Status`,`DateCreation`) VALUES (1,'Beer',1,'0001-01-01 00:00:00');
INSERT INTO `categories` (`Id`,`Name`,`Status`,`DateCreation`) VALUES (2,'Jabali',1,'0001-01-01 00:00:00');
INSERT INTO `categories` (`Id`,`Name`,`Status`,`DateCreation`) VALUES (3,'Desserts',1,'2020-10-29 02:02:06');

INSERT INTO `subcategories` (`Id`,`CategoryId`,`Name`,`Price`,`Status`,`DateCreation`,`ImageUrl`) VALUES (1,1,'Victoria',100,1,'0001-01-01 00:00:00','Beer');
INSERT INTO `subcategories` (`Id`,`CategoryId`,`Name`,`Price`,`Status`,`DateCreation`,`ImageUrl`) VALUES (2,1,'Jabali',200,1,'0001-01-01 00:00:00','Beer');
INSERT INTO `subcategories` (`Id`,`CategoryId`,`Name`,`Price`,`Status`,`DateCreation`,`ImageUrl`) VALUES (3,1,'Gorila',110,0,'0001-01-01 00:00:00','Beer');
INSERT INTO `subcategories` (`Id`,`CategoryId`,`Name`,`Price`,`Status`,`DateCreation`,`ImageUrl`) VALUES (4,2,'Ambar',400,0,'0001-01-01 00:00:00','Food');
INSERT INTO `subcategories` (`Id`,`CategoryId`,`Name`,`Price`,`Status`,`DateCreation`,`ImageUrl`) VALUES (6,3,'Bread',200,0,'0001-01-01 00:00:00','Desserts');
INSERT INTO `subcategories` (`Id`,`CategoryId`,`Name`,`Price`,`Status`,`DateCreation`,`ImageUrl`) VALUES (8,3,'Lava Cake',400,1,'0001-01-01 00:00:00','Desserts');

INSERT INTO `users` (`Id`,`Name`,`LastName`,`Nick`,`Secret`,`Status`,`DateCreation`,`LastAccess`,`Token`,`RefreshTime`,`RefreshToken`) VALUES (1,'Fideo','Esteban','Fideo','Fideo123',1,'2020-10-22 17:07:19','2020-10-22 17:07:19','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJQYXJyb3RGcmFua0FjY2Vzc1Rva2VuIiwianRpIjoiYTE2OWY1MDgtNDFmZC00MDE2LTllNWEtMjcxNjg2MDY3M2U1IiwiaWF0IjoiMzAvMTAvMjAyMCAwNzo0NzozMyBhLiBtLiIsImlzc3VlciI6IlBhcnJvdEZyYW5rQWNjZXNzVG9rZW4iLCJhdWRpZW5jZSI6IlBhcnJvdEZyYW5rQWNjZXNzVG9rZW4iLCJJZCI6IjEiLCJGaXJzdE5hbWUiOiJGaWRlbyIsIkxhc3ROYW1lIjoiRXN0ZWJhbiIsIk5pY2siOiJGaWRlbyIsImV4cCI6MTYwNDA0NTU1M30.w0rQtBaZaFwRH8KN46pczS70eS87aw-dNBSGRe9eQoY','2020-10-30 02:12:33','HkTT2ucWjttnqVnSjJdZHCICn85xSJUqCyDsAUFltvA=');
INSERT INTO `users` (`Id`,`Name`,`LastName`,`Nick`,`Secret`,`Status`,`DateCreation`,`LastAccess`,`Token`,`RefreshTime`,`RefreshToken`) VALUES (2,'Ozzie','Esteban','Ozzie','Ozzie123',1,'2020-10-22 19:12:59','2020-10-22 19:12:59',NULL,NULL,NULL);
INSERT INTO `users` (`Id`,`Name`,`LastName`,`Nick`,`Secret`,`Status`,`DateCreation`,`LastAccess`,`Token`,`RefreshTime`,`RefreshToken`) VALUES (3,'Chinchin','Esteban','Chinchin','Chinchin123',1,'2020-10-22 19:13:13','2020-10-22 19:13:13',NULL,NULL,NULL);

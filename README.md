## General info
This is technical assessment for Global Kinetic.
The assessment was to create a coin jar where you can add US coin types.
	
## Technologies
Project tech stack:
* ASP .Net Core
* C#
* HTML
* CSS
* JQuery
* Swagger

##Api calls
The below calls can be fired when the application is running.
Your localhost port may be different.
For the 3rd call, use coin type 1 – 6.

1 = Penny
2 = Nickel
3 = Dime
4 = Quarter
5 = Half Dollar
6 = Dollar


* [Get] https://localhost:44367/api/GetCoinJar
* [Post] https://localhost:44367/api/ResetCoinJar
* [Post] https://localhost:44367/api/AddCoinJar?coinTypeID=5

You can also use the swagger UI for testing the api.
* https://localhost:44367/swagger/index.html
	
## Setup
To run this project, simply run the application in Visual Studio 2019:

```
Project starting…
Coin Jar work!!
Project shutting down…
``` 

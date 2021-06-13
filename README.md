1)Execute databases script given in folder on sql server 
2) change connection string of web api project inside web.config for server name
3)  same is required in .data project in app.config and other project app config
4)  Multistart projects : go to sulution properties and properties , select multi start option , select EvolentEHI.client and EvolentEHI.WebApi with start option
5) Download nuget packages  or restore packages by set path for nuget is https://api.nuget.org/v3/index.json in visual studio if path no set in visual studio.


project structure :

project  developed using ASP.NET MVC , Rest WEB API. Implemeted repository pattern and dependency injection through autofac so autofac should need to install through nugegt

1) EvolentEHI.client  asp.net mvc
2) EvolentEHI.WebApi  web api service 
3) EvolentEHI.DataModel  model is defined inside it , contact class having properties and validation on it
4) EvolentEHI.IBL : Interface business logic which has repositories of contacat with interface and implemeted method
5) Evolent.Data  : Entity framework ORM used to get or update or insert  from sql database





please call if require any concern to run this project


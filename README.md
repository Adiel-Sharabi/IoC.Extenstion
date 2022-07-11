# IoC.Extenstion
Extensions method to auto register services base on attribute (MEF like approach) 

1. Decorate type with [IoCExport] (Optional contract and life time) 
2. Call AddXXX on Configure. 

Two extention method to add services to IoC container. 
* AddAssemblyExports - Load type from a specific Assembly
* AddAssemblyFolderExports - Load all types from dll in a folder (optional -file name filter) 

Example project with two related projects. 

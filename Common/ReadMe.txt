Dodane paczki :

Common :
	-Autofac
	-Automapper
	-Entity FW
	-Quartz
	-NewtonSoftJson
	-Autofac.Extras.Quartz
	-Serilog
	-Serilog.Sinks.File
	-Serilog.Sinks.Console
	-Serilog.Settings.AppSettings
	-Serilog.Exceptions

ConsoleApp :
	- Serilog
	-EntityFramework

Service :


Edit several files :
1) App settings, minimum level etc. 
2) to add crone edit SettingsHelper, you can add other settings there
3) Create your own jobs (TemplateJob is only example) and register it in Processing class (scheduler) and SchedulerExtensions class
4) Insert your dbset in ApplicationDbContext file, edit connectionstrings
5) Set minimum level for logger in SerilogExtensions.cs file
6) To enable migration use command: Enable-Migrations -ProjectName YourClassLibraryNam, the same at Add-Migration and so on
7) Set service name in installer 


NOTE: during run time application read values from AppConfig file in consoleApp when you are debuging and Service when , so be prepared for editing all AppconfigFiles (cron, conectionStrings
just for being sure, to avoid difficulties use Settings.xml file and SettingsHelper class. It will works/ Remeber to set Copy output property to CopyAlways!

NOTE#2 Do not uninstall EF package from any project it may cause this error :
https://stackoverflow.com/questions/14033193/entity-framework-provider-type-could-not-be-loaded

NOTE#3 Some times after migrations MSSM can not see new table in query editor. Refresh intellisense cach by clicking Edit->IntelliSense-> Refresh Local Cache

NOTE#4 Do not create db context in Job classes directly it may cause dbcontext creating fail. Use class with interface and register it in autofac. 

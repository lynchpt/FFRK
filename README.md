# Final Fantasy Record Keeper (FFRK) Tools #

## This project contains the code for tooling and services related to the Final Fantasy Record Keeper mobile game. ##

### Main Project Goals ###

- Provide people with an easier way to answer questions like "What Legend Dives Use Bravery and Dexterity 5* Motes", or "What Soul Breaks do Ice damage in either their entry or Burst Commands" or "What Characters can use at least Support 4 abilities" that can be tedious to answer via current existing data.
- Provide a REST api that reorganizes currently available data from Enlir into a more structured and programmatically friendly fprm so that some enterprising soul can use it to feed and drive a beatiful and useful client user interface.

### Community Interaction ###

- Please contact me via [Reddit](/u/lynchpt) if you are interested in contributing to this project by working on the code.
- I'm looking forward to polishing this project to better serve the community, thus I can use your help in determining areas of focus. The Issues section of this wiki is well suited to this purpose. When you are using the Issues section to make requests, please include on of the following tags in the title of your Issue:
  - [Feature] : For when you would like me to add some new capability to the api.
  - [Documentation] : For when you can't figure out how something works and you hope that more documentation might make it clearer.
  - [Bug] : For when the api is not giving the expected response or returns an error.
  - [Data] : For when the response is generally correct, but is missing an item or two. This can happen if the underlying data source that feeds the api has a small discrepancy.

### There are three main components to the overall system, briefly described below. You can find further details as appropriate for each component in the wiki. ###

### The REST Api Endpoint - Api.FFRK ###

This is the component which will be most interesting to the majority of people. This REST api serves out game data related to the Final Fantasy Record Keeper (FFRK) mobile game. This includes data such as Characters, their Relics, the Soul Breaks attached to Relics, Abilities, Dungeons and more. 

The service is currently hosted at: http://ffrkapi.azurewebsites.net/api/v1.0/, with an associated [Swagger page](http://ffrkapi.azurewebsites.net/swagger/ui/). The Swagger page will show you all available api endpoints and give you instructions on how to call them.

Important Note: As of Release, All data currently exposed via the api is sourced from [Enlir's magisterial spreadsheet](https://docs.google.com/spreadsheets/d/16K1Zryyxrh7vdKVF1f7eRrUAOC5wuzvC3q2gFLch6LQ). The whole FFRK community owes a debt to his work! In the future, I plan to add more data from other sources, and I will call these out as they come online.

As noted above the service endpoints are organized around core entities/concepts in FFRK, like Characters, Relics, etc. There is one major difference between the data exposed by the api and the underlying data from Enlir. While the Enlir data is naturally entirely tabular, being hosted on a spreadsheet, the data from this api is highly relational and hierarchical, and overall more friendly for programmatic use. Please see the details in the wiki.

#### Nuget Package As a Helpful Companion to the REST Api ####

If you want to use the REST api in a program context, you chould consider using the [FFRKApi.Dto Nuget package](https://www.nuget.org/packages/FFRKApi.Dto/) 

This package contains C# classes that exactly match the structure of the json payloads that the REST api emits. Using this Nuget package makes it simple for you to take the json return value from the api and deserialize it into sets of objects for easy in-memory manipulation.


### The Extraction / Transform / Load (ETL) Process - Manager.ETL ###

As mentioned above the Enlir data that the service uses is structured far differently than what the api wants to actually serve out to callers. The ETL Process extensively manipulates and massasges the Enlir data to turn it into the final desired structure, and then stores that structure where the REST Api can use it.

This version of the ETL Process is implemented in a Console App, so anyone can download the code and run it locally.

### The ETL Process, Azure Edition - FFRKLogicApp and FunctionApp.ETL ###

This component does exactly what Manager.ETL does (and even uses the same business logic), but it is implemented using Azure Logic Apps and Azure Functions. FFRKLogicApp is not publically accessible, but you can see the Azure Function part of the solution in the FunctionApp.ETL project.







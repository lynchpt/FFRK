# Final Fantasy Record Keeper (FFRK) Tools #

## This project contains the code for tooling and services related to the Final Fantasy Record Keeper mobile game. ##

#### There are three main components to the overall system, which are described below. You can find further details as appropriate for each component in the wiki. ####

### The REST Service Endpoint (Api.FFRK) ###

This is the component which will be most interesting to the majority of people. This REST service endpoint serves out game data related to the Final Fantasy Record Keeper (FFRK) mobile game. This includes data such as Characters, their Relics, the Soul Breaks attached to Relics, Abilities, Dungeons and more. 

The service is currently hosted at: http://ffrkapi.azurewebsites.net/api/v1.0/, with an associated [Swagger page](http://ffrkapi.azurewebsites.net/swagger/ui/).

Important Note: As of Release, All data currently exposed via the api is sourced from [Enlir's magisterial spreadsheet](https://docs.google.com/spreadsheets/d/16K1Zryyxrh7vdKVF1f7eRrUAOC5wuzvC3q2gFLch6LQ). The whole FFRK community owes a debt to his work! In the future, I plan to add more data from other sources, and I will call these out as they come online.

As noted above the service endpoints are organized around core entities/concepts in FFRK, like Characters, Relics, etc. There is one major difference between the data exposed by the api and the underlying data from Enlir. While the Enlir data is natura;;y entirely tabular, being hosted on a spreadsheet, the data from this api is highly relational and hierarchical. Relationships that Enlir implies by having shared keys (like Character name) in different sheets are made explicit by this api, by generating ids and nesting child entities underneath thie parents. An example of this would by this api exposing Character entities that contain a list of Relics.

Much more information about how the data for the api is structured and exposed is available in the wiki

For wiki:
For each endpoint category, you will see some recurring patterns. There is an endpoint like /Characters that will return data for all Characters, then one like /Characters/{id} that will return data for the one Character with that id, then usually filter endpoints like Characters/RealmType/{id} that returns all Characters for the Realm of that id. There are a lot of 

# HealthCatalystDemo
People Search Application Demo for Health Catalyst

To run the demo, please do the following after importing the project:

1) Create and populate the database using the T-SQL scripts DBCreate.sql and PopulateDB.sql under /SQL directory.

2) Run the application from Visual Studio after checking that the DB connections and permission are in place.

3) For simulating slow page/search load: for Chrome, go to Developer Tools -> Network and from there check "Disable cache" and set to a slower preset, like "Slow 3G". There is an analogous process for Firefox, but Chrome seems to work better at simulating throttled bandwidth.

4) Thanks!

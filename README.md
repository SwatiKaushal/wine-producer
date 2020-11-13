# wine-producer                                                              Wine Producer

Requirement:

As a User I would like to have a manager application about my wine collection. I have more
than one bottle of wine from each producer. On the first page, I would like to see the list of
producers. I would also like to record new producers with their names and addresses.
As a User I would like to add my wine bottles to each producer, see and edit them on a
separate page or even delete it.
Solution:
The solution contains one MVC app with Web API template. The solution has 2 tables “Producer” and “Bottle” in SQL server management studio. I have used Entity model to connect to database. This app has one “Model” folder having one “Producer” and “Bottle” class respectively.
 
 It has one “Controller” folder which has one “Home Controller” as Producer controller and one is “BottleController”. It has all the CRUD operations that we want to perform on application. 
IN Controller folder, I have added two ApiController which will be useful to consuming Web API in MVC. 
 
It has one “View”  folder which has 2 view folder “Home” as producer and “Bottle” as per requirements. You will find all the required view in there.


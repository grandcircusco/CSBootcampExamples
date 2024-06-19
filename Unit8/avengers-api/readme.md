# Avengers API Demo With Database

### To use this app
1. Clone the repository to your computer if you have not already:
   
   `git clone https://github.com/grandcircusco/JavaBootcampExamples.git`
   
2. In Eclipse, select File > Import...
3. Select "Existing Gradle Project"
4. For the project root directory select this folder within the cloned repo. (unit-7/avengers-api)
5. Finish the import.
6. Add `src/main/resources/config/application.properties` and add connection info for your own MySQL schema.
7. Start the project: Select src/main/java >> AvengersApiApplication.java. Run as Java Application.
8. Browse to [http://localhost:8080/characters](http://localhost:8080/characters)
9. Browse to [http://localhost:8080/reset](http://localhost:8080/reset) at any time to restore the database tables with the original data.
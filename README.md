# Emprevo Carpark

This document contains some notes about the architecture and design decisions I've made while working on the project. In addition this document contains some notes about the code and how to use / extend it.

This document will be updated during my work.

### General Assumptions ###

- If enters before midnight Friday and exit during the weekend or after the weekend, but not qualified to a night rate during weekend promotion, the charge will be according to the Hourly rate.

- Car that enters in Sunday after 6PM, and exit on Monday at 3AM (for example) should be charged by the standard rate, since it does not qualify for weekend rate (exit before Sunday Midnight), and does not qualify for night rate (since night rate defined only for weekdays).

- If a rate decision cannot be made (for any reason) the standard rate will be applied.
- Early bird rate: enter between 6AM to 9AM, means 6:00:00 - 8:59:59 (not including 9AM).


### Architecture and Design decisions ###

- The decision of what rate will be used, is done by utilizing a rate decision tree.
- The decision tree is designed to work with this specific carpark app.
- The fake DB holds the rates amount only (just for the sake of using a DB).
- In a real world app, the DB will also holds the rates conditions (enter / exit condition).
- While developing the app, I've tried adhering (as much as possible) to TDD and SOLID principles.

### General Coding notes ###

- In real life, the rates should come from a DB, here I have used a Memory DB (implemented with a dictionary: Dictionary<string, IParkingRate>
- The data folder inside the ParkingRateRepository is actually a fake DB.
- It would be nice to have an IDBEntity as a data in the DB (Dictionary<string, IDBEntity>).
- I deliberately cast the rates enum to int when updating DB, to keep the DB neutral.
- The decision tree and helpers are static, since they does not need to persist data, and one copy per engine is enough for this app.
- The console client, is just a simple client that utilize the carpark engine. The console client is actually running an integration test for the carpark engine (since it's testing an end to end operation).

### Testing ###

- The testing framework I've used is NUnit.
- I've tested

### Some improvements for the future ###

- Take the tree definition from the DB.
- Inject the proper rate instead of using rate factory (or use factory with injector).
- Carpark engine should be on a separate Microservice (if the load is high).

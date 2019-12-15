# Gorgeous Food App ADD P2 Iteration 1#

## What we have now
![componentDiagram](../img/img0.jpeg)

As we can see, actually we have a simple monolithic Web Application with a single FrontEnd, a single BackEnd API and a single Database containing all the information about Meal and MealItems.

---

## Defining Bounded Contexts
![componentDiagram](../img/img1.jpeg)
![componentDiagram](../img/DomainModelDiagram_3Bounded.png)

This second part's main objective is migration to microservices. For that we need to define Bounded Contexts.
Based on Arquitectural Driver 'P2D2' we decided to divide Meal and it's subcomponents (Ingredients, Allergens and Nutrition data) from MealItem and Inventory(PointOfSale) thus creating a Bounded Context on it's own with specific rules.

---

## Perfect Solution according to examples
![componentDiagram](../img/img2.jpeg)

According to ".NET Microservices: Architecture for Containerized .NET Applications", we designed a 'perfect' solution with the best practices according to the book. Infortunatly, this topic is still new for the development team so, Event sourcing and development is still out of technical scope.

---

## Solution found based in team knowledge and separation of entities
![componentDiagram](../img/img3.jpeg)

This solution was designed based on the team's software engineering knowledge, despite the limited knowledge in the microservices area. 
At the right side of the scheme, we can see a single database for all the microservices, this way of structuring application data solves problems related to interdependencies in data access and writing. However, the solution is discarded as it does not follow the database per service pattern.


---

## Dependency study after planed solution and troubleshooting
![componentDiagram](../img/img4.jpeg)

Usually, in a microservice-based architecture, there is a relationship and dependency between bounded context constituent entities, which affects previously developed REST requests. On the right side of the image is an example of the problems represented by the dependencies, for example, it's necessary ensure that a meal exists (is valid) at the moment of creating a meal item. 

---

## Second solution found after troubleshooting
![componentDiagram](../img/img5.jpeg)

In order to address the problems previously presented, the team decided to intruduce a gateway between the microservices and the frontend component. This one, the gateway, needed contains validations, that will be explained.
Each one of the microservices will contain a single database, following the database per microservice pattern.
This option also improves the a maintainability of the product and ease of introducing new elements into the development team.

---

## Reavaluate Bounded Contexts after Service Cutter study
![componentDiagram](../img/DomainModelDiagram_4Bounded.png)

After all, the team decides develop three microservices, based on the Bounded Context ("PointOfSale","MealItem" and "Meal") represented in this image. 

Note: The "Log" Bounded Context is the representation of what would be the GorgeusFood product log system. 

---

## Third Solution after Service Cutter study
![componentDiagram](../img/DeploymentDiagram_Docker2.png)

Finally, this is the final design of all system components, segregated into microservices.
Each one of the microservices has its own database, but all connect to a gateway. This has logic capable of validating the various interactions between microservices and ensuring the fidelity of system transactions.

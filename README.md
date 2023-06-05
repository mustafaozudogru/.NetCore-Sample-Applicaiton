# .NetCore-Sample Application
This sample shows how to create and dockerize an application with .Net Core.

I used Entity Framework Core, an in-memory database (to keep it simple) and the repository pattern.

### Swagger

I used Swagger for API documentation.

### Test

I used xUnit, FakeItEasy, and FluentAssertions in my test projects.

## Prerequities

- Docker

- .Net core 3.1 SDK 

## Build

We are creating our docker image. 
To build an image we use docker build -t ms.customer.api -f Dockerfile ..

![Build-1](https://user-images.githubusercontent.com/39255171/93687437-9d6f3100-fac6-11ea-8ee1-ed006a2bd14d.PNG)
![Build-2](https://user-images.githubusercontent.com/39255171/93687439-9ea05e00-fac6-11ea-8db7-e66f5df4acc9.PNG)

## Run

We are checking that our image was really created.

![Run](https://user-images.githubusercontent.com/39255171/93687460-e626ea00-fac6-11ea-8765-3c8680ca246d.PNG)

To run an application we use docker run -d -p 5000:80 --name microservicesample ms.customer.api

![Run2PNG](https://user-images.githubusercontent.com/39255171/93687492-17071f00-fac7-11ea-8fda-060472c62476.PNG)

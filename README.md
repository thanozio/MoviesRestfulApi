# MovieRatingsApi

## Description

A simple RESTful ASP.NET Core Web API made with C#, .NET 9, and Dapper.

## Usage

1. Run `docker-compose` located in `MovieRatings.Application` project, to setup a PostgreSQL container (this needs to be done separately)
2. Run the `MovieRatings.Api` application, and visit `https://localhost:5001`
3. Visit `https://localhost:5001/scalar/v1` for the OpenAPI-powered interface (Scalar)
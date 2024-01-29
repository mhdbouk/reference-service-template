# .NET Reference Service Template

This is a project template for creating a .NET application. It includes a basic structure for an API service, with separate projects for the API and unit tests.

It was used as part of a YouTube video on creating a .NET project template. You can watch the video here: [Can you create a custom project template in .NET?](https://www.youtube.com/watch?v=AOzSW37mIi8)

[![Can you create a custom project template in .NET?](https://img.youtube.com/vi/AOzSW37mIi8/0.jpg)](https://www.youtube.com/watch?v=AOzSW37mIi8)

## Installation

To install this template, navigate to the root directory of this repository and run the following command:

```sh
dotnet new install .
```

This will install the template in your .NET templates list.

## Usage

To create a new project using this template, use the dotnet new command followed by the template name. You can specify additional parameters to customize the generated project.

```sh
dotnet new reference --UseSwagger true --DatabaseProvider cosmosdb
```

## Parameters

The following parameters are available for this template:

| Parameter          | Short Option | Description                                                                            |
|--------------------|--------------|----------------------------------------------------------------------------------------|
| --UseSwagger       | -U           | Includes Swagger UI in the generated project.                                          |
| --DatabaseProvider | -D           | Specifies the database provider to use. Supported values are sqlserver and cosmosdb.   |    

## Conditional Code and Files

This template uses conditional syntax to include or exclude certain parts of the code based on the parameters you provide. For example, if you specify `-D sqlserver`, the generated project will include a SQL Server-specific repository implementation, and exclude the other database provider files.


## Contributing
Contributions are welcome. Please submit a pull request or create an issue to discuss your changes.

## License
This project is licensed under the terms of the MIT license. See the [LICENSE](LICENSE) file for details.
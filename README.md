# DotNet Microservice Template walkthrough

[![Build Status][github-actions-svg]][github-actions]

This walkthrough will help you learn how to create a .NET Core microservice from scratch.

## Create a microservice
In order to do so, access to [Mia-Platform DevOps Console](https://console.cloud.mia-platform.eu/login), create a new project and go to the **Design** area. From the Design area of your project select _Microservices_ and then create a new one, you have now reached [Mia-Platform Marketplace](https://docs.mia-platform.eu/development_suite/api-console/api-design/marketplace/)!  
In the marketplace you will see a set of Examples and Templates that can be used to set-up microservices with a predefined and tested function.

For this walkthrough select the following template: **.NET Core template**. After clicking on this template you will be asked to give the following information:

- Name (Internal Hostname)
- GitLab Group Name
- GitLab Repository Name
- Docker Image Name
- Description (optional)

You can read more about this fields in [Manage your Microservices from the Dev Console](https://docs.mia-platform.eu/development_suite/api-console/api-design/services/) section of Mia-Platform documentation.

Give your microservice the name you prefer, in this walkthrough we'll refer to it with the following name: **my-dotnetcore-service-name**.
Then, fill the other required fields and confirm that you want to create a microservice. You have now generated a *my-dotnetcore-service-name* repository that is already deployed on Mia-Platform [Nexus Repository Manager](https://nexus.mia-platform.eu/) once build script in CI is successful.

## Save your changes

It is important to know that the microservice that you have just created is not saved yet on the DevOps Console. It is not essential to save the changes that you have made, since you will later make other modifications inside of your project in the DevOps Console.  
If you decide to save your changes now remember to choose a meaningful title for your commit (e.g "created service my_dotnetcore_service_name"). After some seconds you will be prompted with a popup message which confirms that you have successfully saved all your changes.  
A more detailed description on how to create and save a Microservice can be found in [Microservice from template - Get started](https://docs.mia-platform.eu/development_suite/api-console/api-design/custom_microservice_get_started/#2-service-creation) section of Mia-Platform documentation.

## Look inside your repository

After having created your first microservice (based on this template) you will be able to access to its git repository from the DevOps Console. Inside this repository you will find a [App/Controllers/TemplateController.cs](https://github.com/mia-platform-marketplace/DotNet-Microservice-Template/blob/master/App/Controllers/TemplateController.cs) file with the following lines of code:

```csharp
using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Decorators;
using MiaServiceDotNetLibrary.Environment;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ServiceStatusController
    {
        public TemplateController(MiaEnvConfiguration miaEnvConfiguration, ServiceClientFactory serviceClientFactory,
            DecoratorResponseFactory decoratorResponseFactory) : base(miaEnvConfiguration, serviceClientFactory,
            decoratorResponseFactory)
        {
        }

        /*
        * Insert your code here.
        */
    }
}
```

Wonderful! You are now ready to start customizing your service! Read next section to learn how.

## Add an Hello World route

Now that you have successfully created a microservice from our .NET Core template you will add an *hello* route to it.

As you may have noticed in the snippet of code in the previous section, you will use [MiaServiceDotNetLibrary](https://github.com/mia-platform/Mia-service-Net-Library).  
`Mia-service-Net-Library` is a .NET Core library developed by Mia-Platform. This library contains configurations and functions that will help you to modify your template with easiness.

In order to add your route, you need to define a controller method with his `Attributes`.
Below, you can see how the controller file will look like after having defined the *hello* route:

```csharp
using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Decorators;
using MiaServiceDotNetLibrary.Environment;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ServiceStatusController
    {
        public TemplateController(MiaEnvConfiguration miaEnvConfiguration, ServiceClientFactory serviceClientFactory,
            DecoratorResponseFactory decoratorResponseFactory) : base(miaEnvConfiguration, serviceClientFactory,
            decoratorResponseFactory)
        {
        }

        [HttpGet]
        [Route("hello")]
        public string Get()
        {
            return "Hello World!";
        }
    }
}
```

Visiting the defined route: **/hello** through a **GET** request, you will receive the `Hello World!` message as response.

After committing these changes to your repository, you can go back to Mia Platform DevOps Console.

## Expose an endpoint to your microservice

In order to access to your new microservice it is necessary to create an endpoint that targets it. Step 3 of [Microservice from template - Get started](https://docs.mia-platform.eu/development_suite/api-console/api-design/custom_microservice_get_started/#3-creating-the-endpoint) section of Mia-Platform documentation will explain in detail how to create an endpoint from the DevOps Console.

In particular, in this walkthrough you will create an endpoint to your *my-dotnetcore-service-name*. To do so, from the Design area of your project select _Endpoints_ and then create a new endpoint.
Now you need to choose a path for your endpoint and to connect this endpoint to our microservice. Give to your endpoint the following path: **/greetings**. Then, specify that you want to connect your endpoint to a microservice and, finally, select *my-dotnetcore-service-name*.

## Save again your changes

After having created an endpoint to your microservice you should **save** the changes that you have done to your project in the DevOps console, in a similar way to what you have previously done after the microservice creation.

## Deploy

Once all the changes that you have made are saved, you should deploy your project through the DevOps Console. Go to the **Deploy** area of the DevOps Console.  
Once here select the environment and the branch you have worked on and confirm your choices clicking on the *deploy* button. When the deploy process is finished you will receveive a pop-up message that will inform you.  
Step 5 of [Microservice from template - Get started](https://docs.mia-platform.eu/development_suite/api-console/api-design/custom_microservice_get_started/#5-deploy-the-project-through-the-api-console) section of Mia-Platform documentation will explain in detail how to correctly deploy your project.

## Try it

Now, if you launch the following command on your terminal (remember to replace `<YOUR_PROJECT_HOST>` with the real host of your project):  

```shell
curl <YOUR_PROJECT_HOST>/greetings/hello
```

you should see the following message:

```json
"Hello World!"
```

Congratulations! You have successfully learnt how to modify a blank template into an _Hello World_ DotNetCore microservice!

[github-actions]: https://github.com/mia-platform-marketplace/DotNet-Microservice-Template/actions

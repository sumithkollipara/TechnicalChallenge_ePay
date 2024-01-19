# ePay Technical Challenge

## Tools and Technologies:
- Microsoft Visual Studio Professional 2022
- .Net Core 6.0
- xUnit for Tests

#### The whole solution has been divided into two folders, one for each task as following: 

### ATM_DenominationRoutine


| Folder | Project Name | Description | 
| ------ | ------ | ------ |
| ATM_DenominationRoutine | DenominationRoutine| Please run Program.cs, output can be seen in the console.|

#### Execution procedure:
By opening the solution, please go to DenominationRoutine project and run Program.cs, output can be seen in the console.


### CustomerManagement 

| Folder | Project Name | Description |
| ------ | ------ | ------ |
| CustomerManagement | CustomerManagement| Which exposes a Post and a Get Restful APIs to be consumed by the test project.|


| Folder | Project Name | Description |
| ------ | ------ | ------ |
| CustomerManagement | CustomerManagement.Common| This project contains all the common artifacts that can be shared across different projects. This will make sure that we are not duplicating anything that can be ported into a separate dll and added as reference wherever required.


| Folder | Project Name | Description |
| ------ | ------ | ------ |
| CustomerManagement | CustomerManagement.Test| xUnit project. This has one mega test case which generates data(in a random pattern as stated in the test requirements) and push the data on server. It then retrieves the data that exists on the server and aligns the randomly generated data in a way that the application is supposed to persist and return the data that was posted and compares the 2 data sets.

#### Execution procedure:

Step1: Make sure to either delete or empty the **ePayCustomerData.json** file, file location is `ePay\CustomerManagement\bin\Debug\net6.0`

Step2: Run the CustomerManagement WebAPI project (Swagger UI will be loaded, feel free to Post and Get customers)

Step3: Run the CustomerManagement.Test project

# MoneyManager
## Overview
Money manager is a final project to complete a training course ASP.NET Core Advanced in Software University. The application is easy to use and has a simple user-friendly interface. The main functionality of Money manager is to track all of your expenses and incomes by categories, and accounts. If you want to join the app, you have to register first and after that login. You can **add, edit, delete and upload image** to current income and expenses. But before you have to add incomes or expenses, you need to **add account** from which to take money or in which to save money. Categories in application **depends on** income and expense. You also can add new type ot categories. For more comfrot view of your finances you can view the **statistic dashboard**. You have access to **edit and delete** accounts, but only have access to edit incomes and expenses categories, you can not delete it. **Note** that the admin only can delete any category. Admin also is user and can add, remove and edit incomes, expenses, accounts and categories and view own statistic board.
## Programming languages, technologies, libraries and frameworks:
- C#, JavaScript
- ASP.NET Core 6.0, Entity Framework Core 6.0.1
- MSSQL 2019, VS22
- Bootstrap, HTML 5 Canvas
## Application Flow
When the user or admin starts the app he's redirected to the home page.

![This is an home image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/home.png)

The navbar has three buttons for login and register, which loads the login and register form. 
Login form asks for the user's username and password. 
The register form asks for:Username, First name, Last name, Email Address, Password,Confirm Password.

Login                      |   Register
:-------------------------:|:-------------------------:
![This is an login image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/login.png)   |  ![This is an register image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/register.png)

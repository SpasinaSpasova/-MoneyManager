# MoneyManager
## Overview
Money manager is a final project to complete a training course ASP.NET Core Advanced in Software University. The application is easy to use and has a simple user-friendly interface. The main functionality of Money manager is to track all of your expenses and incomes by categories, and accounts. If you want to join the app, you have to register first and after that login. You can **add, edit, delete and upload image** to current income and expenses. But before you have to add incomes or expenses, you need to **add account** from which to take money or in which to save money. Categories in application **depends on** income and expense. You also can add new type ot categories. For more comfrot view of your finances you can view the **statistic dashboard**. You have access to **edit and delete** accounts, but only have access to edit incomes and expenses categories, you can not delete it. **Note** that the admin only can delete any category. Admin also is user and can add, remove and edit incomes, expenses, accounts and categories and can view own statistic board.

## Programming languages, technologies, libraries and frameworks:
- C#, JavaScript
- ASP.NET Core 6.0, Entity Framework Core 6.0.1
- MSSQL 2019, VS22
- Bootstrap, HTML 5 Canvas
## Application Flow

When the user or admin starts the app he's redirected to the home page.

![This is a home image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/home.png)

The navbar has two buttons for login and register, which loads the login and register form. 
Login form asks for the user's username and password. 
The register form asks for:Username, First name, Last name, Email Address, Password,Confirm Password.
After successful registration, the user is redirected to login page.

![This is a login and register image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/login_register.png)

After successful login, the user is redirected to the statistic board which is updated after every action like add, delete, edit and so on.

![This is a statistic board image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/user_dashboard.png)

If the loged user is admin, he is redirect to the admin home page which look like:

![This is a admin home image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/admin_home.png)

The navbar for users content these buttons: Incomes, Expenses, Accounts, Income Categories and Expense Categories.

The "Incomes" buttons shows all incomes for current user.

![This is all incomes image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AllIncomes.png)

The user can edit, delete and upload image to an income with buttons "Edit", "Delete", "Choose file" and "Upload Income Image".

With button "Edit" the user has been redirected to the following page for edit. If the user wants, he can add new category or new account after clicking the buttons in this form. After editting the account ammount is updating always.

![This is edit income image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/EditIncome.png)

When user click the button "Choose file" this appears:

![This is upload income image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/UploadImage.png)

With button "Add New Income" user is redirect to page in which should fill in the information for add new income. If the user wants, he can add new category or new account after clicking the buttons in this form- he is redirect to other pages.

![This is add incomes image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AddIncome.png)

These are the other pages:

![This is add category image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AddCategoryIncome.png)

![This is add account image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AddAccount.png)

- After successful adding of new income the user is redirect to all incomes.
- After successful adding of new category income the user is redirect to all income categories.
- After successful adding of new account the user is redirect to all accounts.

When the user clicks the Accounts button from navbar he is redirect to this page: - can see all his accounts, edit and delete them and also add new.

![This is all accounts image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AllAccounts.png)

If the user click buttons "Add New Account" he is redirect to fill in the form:

![This is add account image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AddAccount.png)

If the user click buttons "Edit" he is redirect to fill in the form:

![This is edit account image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/EditAccount.png)

If the user click buttons "Delete" he delete the account, but do not delete the incomes and expenses that are on this account.

When the user clicks the Income Categories or Expense Categories button from navbar he is redirect to these pages:

![This is categories image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/Categories.png)

**Note that the user can only add new and edit categories, but can not delete them!!!**

The forms for adding new income or expense category looks like: 

![This is new categories for two types image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/NewCategory.png)

The forms for edit new income or expense category looks like: 

![This is edit categories for two types image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/EditCategory.png)

**The functionallity for expenses is same as the incomes! With small difference between  the redirecting of the pages.**
 - To view all expenses he need to click the "Expenses" button in navbar
 - User can edit, delete and upload image to expense
 - When user add new expense, he is redirect to all expenses page
 - He can add new account and category when he is in "add new expense" form
 
 ![This is all expenses image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AllExpenses.png)
 
 ![This is add expense image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/AddExpense.png)
 
 - He also can add new account and categories and see statistic dashboard after every update

**Note that when the admin wants to act like a ordinary user he is redirect to default layout and can add, edit, delete incomes, expenses, accounts and categories- in default layout he only can edit it. If he want to delete category he should redirect back to admin area when he click the "Hello" to the right of the navbar!!!**

When admin click the button "All Income categories" in his home page he is redirect to this page, where he can edit and delete income categories or add new:

![This is income categories admin image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/ICAdmin.png)

When admin click the button "All Expense categories" in his home page he is redirect to this page, where he can edit and delete expense categories or add new:

![This is expense categories admin image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/ECAdmin.png)

Any change in two types of categories is visualized for all users. **When category is deleted all expenses and incomes does not deleted. And the statistics board visualized expense and incomes by deleted categories also -not only by active, because this incomes and expenses are made already.**

## Application setup

You don't have to do anything in particular to start the project, except to consider the following things:

- **You need to uncomment the commented lines in fowder Configuration to seed the database first!!!**
- **You need to add connection string for the database!!!**

## Database
![This is database image](https://github.com/SpasinaSpasova/MoneyManager/blob/main/Screenshots/Database.png)

## Tests

- NUnit 3.13.3
- NUnit3TestAdapter 4.3.1
- Moq 4.18.2
- Microsoft.EntityFrameworkCore.InMemory 6.0.11
- coverlet.collector 3.2

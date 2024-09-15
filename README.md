Expense Tracker


A comprehensive Expense Tracker application built with ASP.NET Core MVC, HTML, CSS, and JavaScript, providing users with powerful tools to manage income, expenses, and transactions through an intuitive and responsive interface.

Features
1. Dashboard
Overview of key financial metrics including:
Total Income
Total Expenses
Balance Amount
Recent Transactions (up to 10)
Charts: Visual representation of income and expenses with 5 different chart types for data insights.
2. Category Management
Add, edit, and delete categories (up to 20) for both income and expense types.
Customize categories for better tracking of financial activities.
3. Transaction Management
Create, edit, and delete transactions.
Categorize each transaction for easy tracking.
Supports handling up to 500 transactions for robust financial management.
Technology Stack
Backend: ASP.NET Core MVC
Frontend: HTML, CSS, JavaScript
Database: SQL Server (or specify if using another database)
Charts: JavaScript libraries for data visualization
Installation
Prerequisites
.NET SDK
SQL Server (or another database of your choice)
Steps
Clone the repository:

bash
Copy code
git clone https://github.com/yourusername/expense-tracker.git
Navigate to the project directory:

bash
Copy code
cd expense-tracker
Install dependencies:

bash
Copy code
dotnet restore
Set up the database:

Configure your connection string in appsettings.json.
Run the database migrations:
bash
Copy code
dotnet ef database update
Build and run the application:

bash
Copy code
dotnet run
Open the app in your browser at https://localhost:5001.

Usage
Visit the Dashboard to view your total income, expenses, balance, and recent transactions.
Use the Category Management page to organize your expenses and income by category.
Go to the Transaction Management page to add, edit, or delete transactions.
Screenshots

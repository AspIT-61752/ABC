# ABC - System Requirements

## Actors

**Guest:** User who hasn't logged in/created an account
**User:** A user who has logged in with an account

### Guest

1. Guest should be able to create an account
2. Guest should be able to log into an existing account

### User

1. User should be able to create a new budget
2. User should be able to calculate how long to pay off debt if they pay a certain amount a month
3. User should be able to calculate how much they would pay a month to pay off debt in a certain amount of time
4. User should be able to log out of account

## Key Features

1. User Registration and Account Management

   - **Signup page**: Users can create a free account in under a minute with minimal information required.
   - **Insecure login**: Stored as plain text.

1. User Interface and Experience

   - **Intuitive UI/UX**: It has to be intuitive to reduce complexity for the user(s).
   - **Just The Bare Minimum Amount of Buttons**: Users should only provide essential financial data, to reduce the time and effort needed to get started.
   - **Finance Dashboard (optional)**: TODO

1. Financial Analysis and Guidance

   - **Debt Repayment Calculator**: Calculate monthly payment(s) to be debt free in a certain amount of time.
   - **Budget Planning**: How much money is allocated to different budget categories.

1. Budget Management Tools
   - **Spending Overview**: View the users’ spending habits, to find areas where they can save money.
   - **Guides**: Blog posts with financial advice. (Like [Aktiedysten](https://inspiration.aktiedysten.dk/))
   - **Savings Goals**: Weekly, monthly or yearly savings goals.

## Non Functional Requirements

1. Database is hosted on a Microsoft SQL Express Server 2019 on a local machine (?)
2. Backend should be developed in C# using Visual Studio 2022.
3. Backend should be an ASP.NET Core application using .NET 8 as the runtime.
4. Backend should be deployable in production on a Windows Server 2019 machine on a IIS with .NET 8 as the runtime.
5. The frontend should be developed using HTML5, Bootstrap and JavaScript.
6. The frontend should be compatible with any browser on a mobile device.
7. The frontend should be compatible with any browser on a desktop device.
8. Communication between the client and server should use HTTP or HTTPS as the protocol.
9. Communication between the client and server should use JSON as the data format.
   NOTE: Things like safety and encryption are not required, as that is out of scope.

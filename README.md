# Calculator_basic

**Calculator_basic** is a mobile-first ASP.NET WebForms application that performs basic arithmetic operations (addition, subtraction, multiplication, division) with optional rounding to whole numbers. It maintains a history of calculations in a SQL database hosted on somee.com.

---

## Features

* **Mobile-First Design**: Fully responsive layout, usable on phones and desktops.
* **Basic Operations**: `+`, `-`, `*`, `/` with divide-by-zero handling.
* **Rounding**: Optionally round results to the nearest whole number.
* **Calculation History**: Stores last 20 calculations in a SQL Server database and displays the 10 most recent.
* **Layered Architecture**: Clear separation of concerns:
  * Presentation: ASPX + code-behind
  * Services: ComputeService & CalculationService
  * Data Access: IDataAccess with Dapper implementation

---

## Interface Preview

<p align="center">
  <img src="https://github.com/user-attachments/assets/425060f3-8976-4a68-9d88-f8f5b639ae78" />
</p>

---

## Technologies Used

* **Framework**: .NET Framework 4.7.2 (ASP.NET WebForms)
* **Language**: C#
* **Data Access**: Dapper
* **Logging**: Serilog
* **Unit Testing**: MSTest, Moq
* **Database**: SQL Server hosted on somee.com
* **IDE**: Visual Studio 2022

---

## Usage

1. Enter two numbers in the input fields.
2. Check **Use whole numbers** to round the result to whole numbers.
3. Click one of the operation buttons (`+`, `-`, `*`, `/`).
4. View the result in **Results** and the recent history in **History**.
5. Logs are written daily under `App_Data/Logs`.

---

## Basic Error Handling

The application handles common errors gracefully and informs the user without crashing.

- **Divide by zero** triggers a clear user-facing message.
- **Invalid input (e.g., text instead of number)** results in a friendly error display.

<p align="center" style="display: flex; justify-content: center; gap: 10px;">
  <img src="https://github.com/user-attachments/assets/2b2f4b19-5923-482e-8b13-0330df149a7f" alt="Divide by Zero" height="400" />
  <img src="https://github.com/user-attachments/assets/7a4d0673-a186-4a96-8995-9c7b62fadc27" alt="Invalid Input" height="400" />
</p>


---

## Future Improvements

* Migrate UI to ASP.NET MVC or Blazor
* Refactor logging (Serilog)
* Dark mode


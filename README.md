# Gas Station Simulation

This is a gas station simulation project developed using C# (.NET Framework) and Microsoft SQL Server. The application includes features such as managing gas prices, performing sales transactions, checking cash register balances, and managing fuel stock levels.

## Database Structure

The SQL database used in this project contains three tables:

1. Gas Table
* ID: Unique identifier for the gas type.
* GasType: Name of the gas type.
* BuyingPrice: Purchase price of the gas.
* SellingPrice: Selling price of the gas.
* Stock: Stock quantity of the gas (in liters).

2. Safe Table
* Amount: Total amount of money in the cash register.

3. Transaction Table
* ID: Unique identifier for the transaction.
* LicensePlate: License plate of the car making the purchase.
* GasYype: Type of gas purchased.
* Liter: Quantity of gas purchased (in liters).
* Price: Total price of the transaction.

## Application Interface

The C# side of the project is built with Windows Forms, featuring a main form divided into six key sections:

1. Gas Prices
* This section displays the gas types and their corresponding selling prices per liter as stored in the database.

2. Selling
  * Users select the quantity of gas (in liters) using NumericUpDown controls beside each gas type.
  * The total price is calculated based on the selected quantity and displayed in TextBoxes.
  * The "Fill the Tank" button completes the sale. A license plate number must be entered for the sale to proceed. If the license plate is missing, an error message is displayed.
  * After a successful sale:
    * The cash register is updated.
    * ProgressBars are updated to reflect the change in stock levels.

3. Fuel Tank Level
* The stock level for each gas type is visualized using ProgressBars. Each gas type has a maximum capacity of 10,000 liters.

4. Safe
* This section displays the current total amount in the cash register.

5. Selling History
* All transactions from the Transaction table are listed in a DataGridView component.

6. Buy Fuel
* Users select the gas type to purchase via a ComboBox.
* The quantity of gas (in liters) is determined using a NumericUpDown control.
* If the total stock after the purchase exceeds 10,000 liters, the system displays an error and does not complete the transaction.
* The purchase cost is calculated by multiplying the buying price by the quantity.
* After completing the purchase:
  * The cash register is updated.
  * Stock levels are updated and reflected in the ProgressBars.

Key Features
* Dynamic Data Management: SQL-based database dynamically updates gas types, sales transactions, and cash register information.
* User-Friendly Interface: A simple and intuitive interface makes operations easy to perform.
* Error Handling: Displays appropriate error messages when user input is incomplete or invalid operations are attempted.
* Data Visualization: Stock levels and cash register status are presented to users through ProgressBars and grid views.

![1](https://github.com/user-attachments/assets/0ad16863-e1cd-4e98-9b61-27cf37ba113c)

![2](https://github.com/user-attachments/assets/6b18f873-d7cb-40ed-8f9f-0fb81d30beda)

![3](https://github.com/user-attachments/assets/2b84575b-dc9a-467f-9150-0605824867c6)

![4](https://github.com/user-attachments/assets/2f1e3091-ffee-47d4-aa43-e843938e0ff1)

![5](https://github.com/user-attachments/assets/f90f3146-f433-4823-af80-1bb80313d437)

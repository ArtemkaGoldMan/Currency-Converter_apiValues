# Currency Converter 🌍💱

Currency Converter is a WPF-based desktop application built using C# that enables users to convert values between different currencies with real-time exchange rates. The app fetches live currency rates from [OpenExchangeRates API](https://openexchangerates.org/), ensuring accurate conversions.

## Features

- 🌐 **Live Currency Rates**: Fetches real-time currency rates from OpenExchangeRates, supporting over a dozen currencies including USD, EUR, JPY, BTC, and more.
- 🔄 **Easy Currency Conversion**: Simply enter the amount, select the source and target currencies, and get the converted value instantly.
- 🖱️ **User-Friendly Interface**: The app is designed with a clean and intuitive interface, allowing seamless navigation and interaction.
- 🔒 **License Display**: The app also displays the licensing information provided by OpenExchangeRates for transparency.

## Screenshots

![Currency Converter UI](https://github.com/user-attachments/assets/e3d547d5-7c43-474a-8902-3997c8bc524d)

## How It Works

1. **Currency Selection**: 
   - The user selects the source currency (`From`) and the target currency (`To`) from dropdown menus populated with real-time exchange rates.
   
2. **Conversion Process**:
   - After entering the amount and selecting the currencies, the "Convert" button triggers the calculation, displaying the result in the target currency.
   
3. **Error Handling**: 
   - The app ensures valid input with error messages if required fields (amount or currency) are missing or incorrect.
   
4. **Reset**: 
   - With the click of the "Clear" button, all inputs are reset to their default state.

## Technologies Used

- **WPF**: The application leverages the Windows Presentation Foundation (WPF) for its user interface, offering rich graphics and seamless user interaction.
- **C#**: The app logic, including currency data fetching and conversion, is implemented in C#.
- **OpenExchangeRates API**: The app connects to the OpenExchangeRates API to retrieve up-to-date exchange rates.
- **JSON**: Used for parsing the API responses and extracting currency data.
- **HTTP Client**: A modern async method for making API requests and fetching data efficiently.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/Currency-Converter.git
   ```
2. Open the solution in Visual Studio.
3. Navigate to the project folder and locate the file path where the OpenExchangeRates API key is stored.
4. Obtain your API key from [OpenExchangeRates](https://openexchangerates.org/) and place it in the file: `ApiKey.txt`.
5. Build and run the project.

## How to Use

1. Launch the application.
2. Enter the amount to be converted.
3. Choose the source currency (`From`) and the target currency (`To`).
4. Click on **Convert** to view the converted value.
5. To reset the fields, click on **Clear**.

## Future Enhancements

- Add more customizable options for users to change themes and styles.
- Extend support for additional currencies.
- Implement historical data charts for visualizing currency trends over time.

## License

This project uses the OpenExchangeRates API with a free-tier license. See their [terms of service](https://openexchangerates.org/terms) for details.


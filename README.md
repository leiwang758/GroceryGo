# GroceryGo
Coding exercise for AbsorbLMS.

# Running program

This program takes JSON files as input and prints out a receipt list.

- Open "GroceryCo.sln" in Visual Studio (I'm using VS2019), install the Newtonsoft.Json package in NuGet.
- Put the required sales.json and prices.json and the input file inside the Files folder that follows the same structure as the example.
- Ctrl-F5 to compile/run or run "\bin\Debug\netcoreapp3.1\GroceryCo.exe", and input the checkout list file (e.g., fruits.json) as the checkout file.

# Framework

- .Net Core 3.1

# Project structure

- Files: JSON files that have the price and sales info and checkout list.
- Models: all data entities.
- Services: services for processing data.

# Design Choice

- I created two types of classes that handle modelling the data and processing the data, respectively.
- For each grocery list, I compacted it so that it's grouped by item name, which is more clean and readable.
- For calculating the correct price, I compared the current time with the time specified in the JSON files.
- The JSON reading logic can also handle the sales.json file with different sales time slots.

# Assumption & Limitation

- I assumed that the format of files follows the exact structure as the example files in the Files folder.
- I didn't implement any data validation logic, just a simple error catch.
- Currently, the sales and prices JSON file is hard-coded.
- This is my first C# experience; variable naming and code structuring might not be conventional.
- No unit tests are written so far.

# Nuget

- Newtonsoft.Json: read and parse JSON file


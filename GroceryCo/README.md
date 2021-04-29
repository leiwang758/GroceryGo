# Running program

This program takes json files as input, place the json files inside the Files foler, and execute the exe file inside the bin folder

- For example, run "\bin\Debug\netcoreapp3.1\GroceryCo.exe" and input "fruits.json" as the checkout file

# Prerequisite

- .Net Core 3.1

# Project structure

- Files: json files that have the price and sales info, and checkout list
- Models: all data entities
- Services: services for processing data

# Design Choice

- I created two types of classes that handles modeling the data and processing the data, respectively.
- For each list input, I compacted it so that it's grouped by item and set the num property for each item.
- For calculating the correct price, I compared the current time with the time specified in the json files.

# Assumption & Limitation

- I assumed that the format of files follows the exact structure as the example files in the Files folder.
- I didn't implement any data validation logic, just simple error catch.
- Currently the sales and prices file are hard-coded.

# Nuget

- Newtonsoft.Json: read and parse JSON file

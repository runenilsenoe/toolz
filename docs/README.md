# Toolz

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE) [![Build Status](https://github.com/runenilsenoe/toolz/actions/workflows/build-and-publish.yaml/badge.svg)](https://github.com/runenilsenoe/toolz/actions) [![NuGet](https://img.shields.io/nuget/v/runenilsenoe-toolz.svg)](https://www.nuget.org/packages/runenilsenoe-toolz)

**Toolz** is a .NET library providing a collection of utilities and extensions to enhance productivity, simplify common coding tasks, and improve the overall quality of .NET applications.

---

## Features

### Number Extensions
- **Range check methods**: Short way to check numbers for different lengths intervals and ranges..

### String Extensions
- **Title Case Conversion**: Easily convert strings to title case.
- **Slugify**: Generate URL-safe strings for SEO-friendly links.
- **Formatted String Builders**: Simplify building lists, paragraphs, and headings with extensions like `NewListPoint` and `AddHeading`.

### Date and Time Utilities
- **Start/End of Day**: Quickly get the start or end of a day for `DateTime`.
- **Age Calculation**: Calculate the age based on a given birthdate.

### Validation
- **Number Validations**: Check if a number is positive, negative, even, odd, within a range, or has a specific number of digits.
- **String Validations**: Validate email addresses, credit card numbers (Luhn algorithm), and passwords for strength.

### Asynchronous Helpers
- **Task Timing**: Measure and log the execution time of tasks, functions, and actions.
- **Retry with Delay**: Automatically retry asynchronous operations with configurable delays.

## Incoming
### File and Directory Helpers
- **Safe Directory Creation**: Ensure a directory exists without manual checks.
- **Read and Write Files**: Simplified methods to handle file encoding and content.

### Networking
- **Internet Connectivity Check**: Verify if the machine is connected to the internet.
- **Local IP Address**: Retrieve the local IP address for the current machine.

---

## Installation

Toolz is available as a [NuGet package](https://www.nuget.org/packages/Toolz). You can install it using the NuGet Package Manager, .NET CLI, or by adding it to your project file.

### Using .NET CLI
```bash
dotnet add package Toolz --version x.y.z
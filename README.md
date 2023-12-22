# Smart Sunrise Project

The Smart Sunrise project is a simple application that utilizes the NooLite library to simulate a sunrise by gradually adjusting the brightness level using a NooLite adapter. This project allows users to specify the COM port name and the desired duration for the sunrise, providing a customizable and automated way to create a gradual and natural wake-up experience.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
  - [Command-line Arguments](#command-line-arguments)
- [Automate Daily Sunrise Simulation](#automate-daily-sunrise-simulation)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

Before running the Smart Sunrise application, make sure you have the following prerequisites installed:

- .NET Core Runtime

### Installation

1. Clone the repository to your local machine:

   git clone https://github.com/novikov-alexander/smart-sunrise.git

2. Navigate to the project directory:

   cd smart-sunrise

3. Build the application:

   dotnet build -c Release

## Usage

### Command-line Arguments

To run the Smart Sunrise application, use the following command-line syntax:

dotnet SmartSunrise.dll <COMPortName> <SunriseDurationMinutes>
<COMPortName>: The name of the COM port where the NooLite adapter is connected.
<SunriseDurationMinutes>: The duration of the simulated sunrise in minutes.

Example:

dotnet SmartSunrise.dll COM4 30

This command initiates a sunrise simulation on COM port COM4 with a duration of 30 minutes.

## Automate Daily Sunrise Simulation

You can automate the sunrise simulation every day by scheduling the Smart Sunrise application using the Windows Task Scheduler. Follow these steps to set up the task:

1. **Open Task Scheduler:**

   - Press `Win + S`, type "Task Scheduler," and select the application from the search results.

2. **Create a Basic Task:**

   - In the right-hand Actions pane, click on "Create Basic Task..."

3. **Task Name and Description:**

   - Enter a name and description for your task, then click "Next."

4. **Trigger Type:**

   - Choose "Daily" as the trigger type, then click "Next."

5. **Daily Trigger Settings:**

   - Set the start date and time you want the task to run every day.
   - Choose "Recur every" and set it to "1 days."
   - Specify the "Repeat task every" if you want the task to repeat.
   - Set the duration or end date if needed.
   - Click "Next" when you're done.

6. **Action Type:**

   - Select "Start a program" as the action type, then click "Next."

7. **Program/Script and Add Arguments:**

   - In the "Program/script" field, enter the full path to your `dotnet.exe` and the full path to your Smart Sunrise DLL, like this:
     ```
     Program/script: C:\Program Files\dotnet\dotnet.exe
     Add arguments: path\to\SmartSunrise.dll COM4 30
     ```
   - Adjust the paths and command-line arguments based on your setup.
   - Click "Next" when you're done.

8. **Summary:**
   - Review your settings, and if everything looks correct, click "Finish."

Now, your task is scheduled to run your Smart Sunrise application every day at the specified time.

Keep in mind:

- Make sure to replace `C:\Program Files\dotnet\dotnet.exe` and `path\to\SmartSunrise.dll` with the actual paths on your system.
- Adjust the COM port and sunrise duration in the command-line arguments as needed.
- You might need to provide the full path to your `dotnet.exe` if it's not in the system's PATH environment variable.

This setup will run your Smart Sunrise application daily at the specified time, simulating a sunrise according to the configured parameters.

## Configuration

You can customize COM port name and sunrise duration via command line.

## Contributing

Contributions are welcome! If you find a bug, have a feature request, or want to contribute improvements, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

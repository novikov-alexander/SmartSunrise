using SmartSunrise;

if (args.Length < 2)
{
    Console.WriteLine("Usage: SmartSunrise.exe <COMPortName> <DelayMilliseconds>");
    return;
}

string comPortName = args[0];

if (!int.TryParse(args[1], out int sunriseDurationMinutes) || sunriseDurationMinutes <= 0)
{
    Console.WriteLine("Error: Invalid or non-positive sunrise duration value. Please provide a valid positive integer for SunriseDurationMinutes.");
    return;
}

using var brightnessAdjuster = new NooLiteBrightnessAdjuster(comPortName);

// Adjust brightness levels gradually
brightnessAdjuster.AdjustBrightness(sunriseDurationMinutes);

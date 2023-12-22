using ThinkingHome.NooLite;

namespace SmartSunrise
{
    public class NooLiteBrightnessAdjuster : IDisposable
    {
        // Constants or configuration settings
        private const byte maxBrightness = 255;
        private const byte channel = 0;

        private readonly MTRFXXAdapter adapter;

        public NooLiteBrightnessAdjuster(string comPortName)
        {
            if (string.IsNullOrWhiteSpace(comPortName))
            {
                throw new ArgumentException("COM port name cannot be empty or whitespace.", nameof(comPortName));
            }

            // Initialize the NooLite adapter
            adapter = new MTRFXXAdapter(comPortName);

            // Subscribe to events
            adapter.Connect += AdapterOnConnect;
            adapter.Disconnect += AdapterOnDisconnect;
            adapter.ReceiveData += AdapterOnReceiveData;
            adapter.Error += AdapterOnError;

            // Open the connection to the NooLite adapter
            adapter.Open();

            // Exit service mode if applicable
            adapter.ExitServiceMode();
        }

        public void AdjustBrightness(int sunriseDurationMinutes)
        {
            int delay = ConvertSunriseDurationToDelay(sunriseDurationMinutes);

            for (byte i = 0; i < maxBrightness; i++)
            {
                // Introduce a delay between brightness adjustments
                Thread.Sleep(delay);

                // Set the brightness level for the specified channel
                adapter.SetBrightness(channel, i);
            }

            Console.WriteLine("Brightness adjustment completed successfully.");
        }

        public void Dispose()
        {
            // Ensure proper cleanup when the object is disposed
            adapter.Dispose();
            GC.SuppressFinalize(this);
        }

        private static int ConvertSunriseDurationToDelay(int sunriseDurationMinutes)
        {
            const int millisecondsPerMinute = 60000;

            return sunriseDurationMinutes * millisecondsPerMinute / maxBrightness;
        }


        private void AdapterOnConnect(object obj)
        {
            Console.WriteLine("Connected to the adapter.");
        }

        private void AdapterOnDisconnect(object obj)
        {
            Console.WriteLine("Disconnected from the adapter.");
        }

        private void AdapterOnReceiveData(object obj, ReceivedData result)
        {
            Console.WriteLine(result);
        }

        private void AdapterOnError(object obj, Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
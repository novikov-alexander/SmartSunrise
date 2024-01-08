namespace SmartSunrise.Tests
{
    [TestClass]
    public class NooLiteBrightnessAdjusterTests
    {
        [TestMethod]
        public void Constructor_WithInvalidComPort_ThrowsArgumentException()
        {
            string invalidComPort = string.Empty;

            Assert.ThrowsException<ArgumentException>(() => new NooLiteBrightnessAdjuster(invalidComPort));
        }
    }
}
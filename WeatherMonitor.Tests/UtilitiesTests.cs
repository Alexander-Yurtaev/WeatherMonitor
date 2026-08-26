using FluentAssertions;
using WeatherMonitor.Application;

namespace WeatherMonitor.Tests
{
    public class UtilitiesTests
    {
        [Theory]
        [InlineData(1, 0.3)]
        [InlineData(1000, 277.8)]
        public void Kmh2Ms_Should_Correct_Convert(double kmh, double expected)
        {
            // Arrange
            // Act
            var actual = Utilities.Kmh2Ms(kmh);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("00:00", 0)]
        [InlineData("01:00", 1)]
        [InlineData("01:49", 1)]
        public void GetHourFromTime_Shoild_Correct(string time, int expected)
        {
            // Arrange
            // Act
            var actual = Utilities.GetHourFromTime(time);

            // Assert
            actual.Should().Be(expected);
        }
    }
}

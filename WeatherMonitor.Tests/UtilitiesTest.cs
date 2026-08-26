using FluentAssertions;
using WeatherMonitor.Application;

namespace WeatherMonitor.Tests
{
    public class UtilitiesTest
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
    }
}

namespace Utilities.Tests;

public class DateTimeParserTests
{
    [Fact]
    public void ParseDateTime_ValidStrings_ReturnsCorrectDateTime()
    {
        // Arrange
        var dateSubstring = "20220101";
        var timeSubstring = "083000";
        var expected = new System.DateTime(2022, 1, 1, 8, 30, 0);

        // Act
        var result = DateTimeParser.ParseDateTime(dateSubstring, timeSubstring);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseDateTime_NullDate_ThrowsArgumentNullException()
    {
        // Arrange
        string dateSubstring = null;
        var timeSubstring = "083000";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => DateTimeParser.ParseDateTime(dateSubstring, timeSubstring));
    }

    [Fact]
    public void ParseDateTime_NullTime_ThrowsArgumentNullException()
    {
        // Arrange
        var dateSubstring = "20220101";
        string timeSubstring = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => DateTimeParser.ParseDateTime(dateSubstring, timeSubstring));
    }

    [Fact]
    public void ParseDateTime_InvalidDate_ThrowsArgumentException()
    {
        // Arrange
        var dateSubstring = "2022-01-01"; // invalid format
        var timeSubstring = "083000";

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => DateTimeParser.ParseDateTime(dateSubstring, timeSubstring));
        Assert.Contains("Invalid date string", ex.Message);
    }

    [Fact]
    public void ParseDateTime_WeirdTime_ConvertsSuccessfully()
    {
        // Arrange
        var dateSubstring = "20220101";
        var timeSubstring = "0830";
        var expected = new System.DateTime(2022, 1, 1, 0, 8, 30);

        // Act
        var result = DateTimeParser.ParseDateTime(dateSubstring, timeSubstring);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseDateTime_ChangingDays_ConvertsSuccessfully()
    {
        // Arrange
        var dateSubstring = "20220101";
        var timeSubstring = "0";
        var expected = new System.DateTime(2022, 1, 1, 0, 0, 0);

        // Act
        var result = DateTimeParser.ParseDateTime(dateSubstring, timeSubstring);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseDate_ValidStrings_ReturnsCorrectDateTime()
    {
        // Arrange
        var dateString = "20220101";
        var expected = new System.DateTime(2022, 1, 1);

        // Act
        var result = DateTimeParser.ParseDate(dateString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseDate_InvalidString_ThrowsArgumentException()
    {
        // Arrange
        var dateString = "2022-01-01"; // invalid format

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => DateTimeParser.ParseDate(dateString));
        Assert.Contains("Invalid date string", ex.Message);
    }

    [Fact]
    public void ParseTime_ValidStrings_ReturnsCorrectTimeSpan()
    {
        // Arrange
        var timeString = "083000";
        var expected = new TimeSpan(8, 30, 0);

        // Act
        var result = DateTimeParser.ParseTime(timeString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseTime_WeirdTime_ConvertsSuccessfully()
    {
        // Arrange
        var timeString = "0830";
        var expected = new TimeSpan(0, 8, 30);

        // Act
        var result = DateTimeParser.ParseTime(timeString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseTime_WeirdTimeWithJustSec_ConvertsSuccessfully()
    {
        // Arrange
        var timeString = "30"; // invalid format
        var expected = new TimeSpan(0, 0, 30);

        // Act
        var result = DateTimeParser.ParseTime(timeString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseTime_WeirdTimeWithJust1Digit_ConvertsSuccessfully()
    {
        // Arrange
        var timeString = "2";
        var expected = new TimeSpan(0, 0, 2);

        // Act
        var result = DateTimeParser.ParseTime(timeString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseTime_WeirdTimeWithJust0_ConvertsSuccessfully()
    {
        // Arrange
        var timeString = "0";
        var expected = new TimeSpan(0, 0, 0);

        // Act
        var result = DateTimeParser.ParseTime(timeString);

        // Assert
        Assert.Equal(expected, result);
    }

}





using System;
using Review;
using Xunit;

namespace Exercise2.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void Constructor_WithNameOnly_ShouldSetDOBUnder16()
        {
            // Arrange
            var person = new People("Alice");

            // Act
            var age = (DateTimeOffset.UtcNow - person.DOB).TotalDays / 365;

            // Assert
            Assert.True(age <= 16, $"Expected age <= 16 but got {age}");
            Assert.Equal("Alice", person.Name);
        }

        [Fact]
        public void Constructor_WithNameAndDOB_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var dob = new DateTime(2000, 1, 1);
            var person = new People("Bob", dob);

            // Assert
            Assert.Equal("Bob", person.Name);
            Assert.Equal(dob, person.DOB.Date);
        }

        // Negative test case: Future DOB should throw (invalid)
        [Fact]
        public void Constructor_ShouldThrow_WhenDOBInFuture()
        {
            var future = DateTime.UtcNow.AddYears(1);
            Assert.Throws<ArgumentException>(() => new People("Tom", future));
        }
    }
}
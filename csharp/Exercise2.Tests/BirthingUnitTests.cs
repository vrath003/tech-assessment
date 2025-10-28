using System;
using System.Linq;
using Review;
using Xunit;

namespace Exercise2.Tests
{
    public class BirthingUnitTests
    {
        [Fact]
        public void GetPeople_ShouldReturnRequestedCount()
        {
            // Arrange
            var unit = new BirthingUnit();

            // Act
            var people = unit.GetPeople(5);
            // Assert
            Assert.Equal(5, people.Count);
        }

        [Fact]
        public void GetPeople_ShouldContainValidNames()
        {
            var unit = new BirthingUnit();
            var people = unit.GetPeople(10);

            Assert.All(people, p => Assert.Contains(p.Name, new[] { "Bob", "Betty" }));
        }

        [Fact]
        public void GetMarried_ShouldCombineNameAndLastName()
        {
            var unit = new BirthingUnit();
            var person = new People("John", new DateTime(1990, 1, 1));
            var marriedName = unit.GetMarried(person, "Smith");

            Assert.Equal("John Smith", marriedName);
        }

        [Fact]
        public void GetMarried_ShouldNotChangeName_WhenLastNameContainsTest()
        {
            var unit = new BirthingUnit();
            var person = new People("Jane", new DateTime(1990, 1, 1));

            var marriedName = unit.GetMarried(person, "testuser");

            Assert.Equal("Jane", marriedName);
        }

         //Negative: GetPeople with negative count
        [Fact]
        public void GetPeople_ShouldThrow_WhenCountIsNegative()
        {
            var unit = new BirthingUnit();
            Assert.Throws<ArgumentOutOfRangeException>(() => unit.GetPeople(-5));
        }
    }
}
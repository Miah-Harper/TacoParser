using System;
using Xunit;


namespace LoggingKata.Test 
{
    public class TacoParserTests 
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

            //first test makes sure that values aren't null
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.49763,-86.875722,Taco Bell Birmingham....", -86.875722)]
        [InlineData("34.784434,-84.771556,Taco Bell Chatswort...", -84.771556)]
        [InlineData("32.524378,-84.88839,Taco Bell Columbus...", -84.88839)]
        [InlineData("31.236691,-85.459825,Taco Bell Dothan...", -85.459825)]
        [InlineData("31.935914,-87.737701,Taco Bell Thomasville...", -87.737701)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
             TacoParser tacoLongitude = new TacoParser();

            //Act

            var actual = tacoLongitude.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Longitude); //makes these both doubles
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.764965, -86.48607, Taco Bell Huntsvill..", 34.764965)]
        [InlineData("34.7348,-86.633875,Taco Bell Huntsville...", 34.7348)]
        [InlineData("30.417628,-86.653669,Taco Bell Mary Esthe..", 30.417628)]
        [InlineData("30.349378, -87.266033, Taco Bell Pensacol...", 30.349378)]
        [InlineData("30.459515,-84.35516,Taco Bell Tallahassee...", 30.459515)]
        [InlineData("724109,-84.937891,Taco Bell Villa Ric...", 724109)]

        public void ShouldParseLatitude(string line, double expected)
        {
            TacoParser tacoLatitude = new TacoParser();

            var actual = tacoLatitude.Parse(line);

            Assert.Equal(expected, actual.Location.Longitude);

        }
    }
}

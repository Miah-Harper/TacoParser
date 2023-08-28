using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Diagnostics;

namespace LoggingKata
{
    class Program
    {
        static Stopwatch stop = new Stopwatch();
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            
            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray(); //LINQ method .Select

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tacoBell1 = new TacoBell();
            ITrackable tacoBell2 = new TacoBell();


               double distance  = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`



            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            //stop.Start();

            //for (var i = 0; i < locations.Length; i++)
            //{
            //    var locA = locations[i];

            //    var corA = new GeoCoordinate();
            //    corA.Latitude = locA.Location.Latitude;
            //    corA.Longitude = locA.Location.Longitude;

            //    for (var x = 0; x < locations.Length; x++)
            //    {
            //        var locB = locations[x];

            //        var corB = new GeoCoordinate()
            //        {
            //            Latitude = locB.Location.Latitude,
            //            Longitude = locB.Location.Longitude
            //        };

            //        if (corA.GetDistanceTo(corB) > distance)
            //        {
            //            distance = corA.GetDistanceTo(corB);
            //            tacoBell1 = locA; //once you compare two locations you'll need to update to the first tacobell, then update the second taco bell 
            //            tacoBell2 = locB;
            //        }
            //    }
            //}

            stop.Start();

            for (var i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (var x = i + 1; x < locations.Length; x++) // i + 1 is starting this next loop at index 1 so that way it only considers locations that come after locA in the array. It eliminates any redundancy by comparing locA to itself
                {
                    var locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA; //once you compare two locations you'll need to update to the first tacobell, then update the second taco bell 
                        tacoBell2 = locB;
                    }
                }
            }

            // Now, tacoBell1 and tacoBell2 hold the pair of locations with the maximum distance exceeding the threshold.


            stop.Stop();
            Console.WriteLine($"This loop took {stop.ElapsedMilliseconds} milliseconds to complete");


            // Create a new corA Coordinate with your locA's lat and long


            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            Console.WriteLine($"\n{tacoBell1.Name} and {tacoBell2.Name} are the furthest apart. Which is {Math.Round(distance *.00062)} miles apart");
            //math.round is used to round up and .00062 is the number to convert to miles
        }
    }
}

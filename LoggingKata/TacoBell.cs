using System;
namespace LoggingKata
{
	public class TacoBell : ITrackable
	{
        public TacoBell()
        {
        }

        public TacoBell(double longitude, double latitude, string name)
		{
		}

        public string Name { get; set; }
        public Point Location { get; set; }
    }
}


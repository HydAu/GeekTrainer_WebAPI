using System.ComponentModel.DataAnnotations;

namespace DemoCommon
{
    public class DemoPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class DemoVector
    {
        [Required]
        public DemoPoint Origin { get; set; }

        [Required]
        public DemoPoint Direction { get; set; }

        public static bool TryParse(string text, out DemoVector vector)
        {
            vector = null; 

            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            
            var coordinates = text.Split('|');

            if (coordinates.Length != 6)
            {
                return false;
            }

            var coordinatesParsed = new double[6];
            
            var x = 0;
            
            while (x < 6)
            {
                double coordParsed;
                if (double.TryParse(coordinates[x], out coordParsed))
                {
                    coordinatesParsed[x] = coordParsed;
                    x++;
                }
                else
                {
                    return false;
                }
            }
            
            vector = new DemoVector
            {
                Origin = new DemoPoint
                {
                    X = coordinatesParsed[0],
                    Y = coordinatesParsed[1],
                    Z = coordinatesParsed[2]
                },
                Direction = new DemoPoint
                {
                    X = coordinatesParsed[3],
                    Y = coordinatesParsed[4],
                    Z = coordinatesParsed[5]
                }
            };

            return true;
        }
    }
}

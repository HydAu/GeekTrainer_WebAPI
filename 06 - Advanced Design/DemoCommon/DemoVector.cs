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
    }
}

using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Operation
    {
        public int OperationID { get; set; }
        [Required]
        public string Name { get; set; }
        

        [Required]
        public byte[] ImageData { get; set; }
        public int OrderInWhichToPerform { get; set; }
        [Required]
        public Device Device { get; set; }
    }

}

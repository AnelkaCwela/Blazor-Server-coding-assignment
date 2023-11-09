using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Device
    {
        public int DeviceID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DeviceType deviceType { get; set; }
     }

}
public enum DeviceType
{
    BarcodeScanner,
    Printer,
    Camera,
    SocketTray
}

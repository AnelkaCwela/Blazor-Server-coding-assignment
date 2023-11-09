using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        List<Device> DeviceList = new List<Device>();
        List<Operation> operationsList = new List<Operation>();

        public int GetNextoperationId()
        {
            if (TempData["operationsList"] != null)
            {
                operationsList = JsonConvert.DeserializeObject<List<Operation>>(TempData["operationsList"].ToString());


                int maxDeviceId = operationsList.Max(op => op.OperationID);
                return maxDeviceId + 1;
            }
            else
            {
                return 1;
            }
        }
        public int GetNextDeviceId()
        {
            if (TempData["DeviceList"] != null)
            {
               
                DeviceList = JsonConvert.DeserializeObject<List<Device>>(TempData["DeviceList"].ToString());


                int maxDeviceId = DeviceList.Max(op => op.DeviceID);
                return maxDeviceId + 1;
            }
            else
            {
                return 1;
            }
        }
        [HttpPost]
            [AutoValidateAntiforgeryToken]
            public IActionResult AddOperation(Operation operation)
            {
               
                    operation.OperationID = GetNextoperationId();
                    operationsList.Add(operation);
                    ViewBag.SuccessMessage = "Operation has been added.";
                    //ViewBag.DeviceList = new SelectList(DeviceList, "DeviceID", "Name");

                   TempData["OperationsList"] = JsonConvert.SerializeObject(operationsList);
  
                
            var data = JsonConvert.DeserializeObject<List<Device>>(TempData["DeviceList"].ToString());
            ViewBag.DeviceList = new SelectList(data, "DeviceID", "Name");
            return View(operation);
            }
       
            [HttpGet]
            public IActionResult AddOperation()
            {
            var data = JsonConvert.DeserializeObject<List<Device>>(TempData["DeviceList"].ToString());
            ViewBag.DeviceList = new SelectList(data, "DeviceID", "Name");
                return View();
            }
        
            public IActionResult Index()
            {
              if (TempData["operationsList"] != null)
              {
               // operationsList = TempData["operationsList"] as List<Operation>;
                operationsList = JsonConvert.DeserializeObject<List<Operation>>(TempData["operationsList"].ToString());
            }
               return View(operationsList);
            }

            [HttpPost]
            [AutoValidateAntiforgeryToken]
            public IActionResult AddDevice(Device device)
            {
                if (ModelState.IsValid)
                {
                    device.DeviceID = GetNextDeviceId();
                    DeviceList.Add(device);
                    ViewBag.SuccessMessage = "Device has been added.";
                TempData["DeviceList"] = JsonConvert.SerializeObject(DeviceList);

                }
                return View(device);
            }

            [HttpGet]
            public IActionResult AddDevice()
            {
                return View();
            }
        

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult GetTrain()
        {
            return Ok(new List<int> { 1, 2, 3, 4, 5 });
        }

        [HttpPost("update")]
        public IActionResult UpdateTrain([FromBody] List<int> trainList)
        {
            return Ok(trainList);
        }

        [HttpPost("add")]
        public IActionResult AddWagon([FromBody] List<int> trainList, [FromQuery] int number, [FromQuery] bool toLeft)
        {
            System.Diagnostics.Debug.WriteLine("number: " + number);
            if (toLeft)
            {
                trainList.Insert(0, number);
            }
            else
            {
                trainList.Add(number);
            }
            return Ok(trainList);
        }

        [HttpPost("remove")]
        public IActionResult RemoveWagon([FromBody] List<int> trainList, [FromQuery] bool fromLeft)
        {
            if (fromLeft && trainList.Count > 0)
            {
                trainList.RemoveAt(0);
            }
            else if (!fromLeft && trainList.Count > 0)
            {
                trainList.RemoveAt(trainList.Count - 1);
            }
            return Ok(trainList);
        }
    }

}

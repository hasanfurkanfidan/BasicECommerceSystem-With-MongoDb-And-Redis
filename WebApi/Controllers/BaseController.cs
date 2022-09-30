using Core.Utils.Result.Abstract;
using Core.Utils.Result.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult GetResponseOnlyResultData<T>(IDataResult<T> result)
        {
            if (result == null)
                return NotFound(new ErrorResult());

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult GetResponseOnlyResult(Core.Utils.Result.Abstract.IResult result)
        {
            if (result == null)
                return NotFound(new ErrorResult());

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}

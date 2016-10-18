using System.Web.Http;

using MobiStore.Web.Models;

namespace MobiStore.Web.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody]File file)
        {
            return this.Ok(file.Content);
        }
    }
}
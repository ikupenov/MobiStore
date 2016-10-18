using System.Web.Http;
using System.Web.Http.Cors;

using MobiStore.Web.Models;

namespace MobiStore.Web.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        [EnableCors("*", "*", "*")]
        public IHttpActionResult Post([FromBody]File file)
        {
            return this.Ok("Content:" + file.Content + "\n" + "Extension:" + file.Extension);
        }
    }
}
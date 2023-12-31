using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace malevaNewsV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private readonly IPostServices _postServices;

        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<PostDto>>>> Get() {
            return Ok(await _postServices.GetAllPosts());
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Post>>>> GetById(int id) {
          return Ok(await _postServices.GetPostById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PostDto>>>> AddPost(PostDto newPost) {
            return Ok(await _postServices.AddPost(newPost));
        }
    }
}

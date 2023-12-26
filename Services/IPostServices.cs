using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace malevaNewsV2.Services
{
    public interface IPostServices
    {
        Task<ServiceResponse<List<PostDto>>> GetAllPosts();
        Task<ServiceResponse<PostDto>> GetPostById(int id);
        Task<ServiceResponse<List<PostDto>>> AddPost(PostDto newPost);
        Task<ServiceResponse<PostDto>> UpdatePost(PostDto updatedPost);
        Task<ServiceResponse<List<PostDto>>> DeletePost(int id);
    }
}
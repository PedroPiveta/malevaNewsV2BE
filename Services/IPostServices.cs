using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace malevaNewsV2.Services
{
    public interface IPostServices
    {
        Task<ServiceResponse<List<GetPostDto>>> GetAllPosts();
        Task<ServiceResponse<GetPostDto>> GetPostById(int id);
        Task<ServiceResponse<List<GetPostDto>>> AddPost(CreatePostDto newPost);
        Task<ServiceResponse<GetPostDto>> UpdatePost(CreatePostDto updatedPost);
        Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id);
    }
}

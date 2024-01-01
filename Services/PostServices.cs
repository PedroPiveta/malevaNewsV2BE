using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using malevaNewsV2.Data;
using Microsoft.EntityFrameworkCore;

namespace malevaNewsV2.Services
{
    public class PostServices : IPostServices
    {
        private static List<Post> posts = new List<Post>{
            new  Post(),
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PostServices(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> AddPost(CreatePostDto newPost)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            try 
            {
                var post = _mapper.Map<Post>(newPost);
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Posts
                    .Select(p => _mapper.Map<GetPostDto>(p))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            var dbPosts = await _context.Posts.ToListAsync();
            serviceResponse.Data = dbPosts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            return serviceResponse;
        }

        public Task<ServiceResponse<GetPostDto>> GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetPostDto>> UpdatePost(CreatePostDto updatedPost)
        {
            throw new NotImplementedException();
        }
    }
}

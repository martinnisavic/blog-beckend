using Application;
using Application.DTO.Paging;
using Application.DTO.User;
using Application.Exceptions;
using Application.Queries;
using DataAccess;
using Domain.Entities;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Queries
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        private readonly IApplicationUser _user;
        public EfGetUsersQuery(BlogDbContext context) : base(context)
        {
        }

        public string Name => "Get Users";

        public string Id => "get-users";

        public async Task<PagedResponse<UserDTO>> ExecuteAsync(UserSearch request)
        { 
            IQueryable<UserEntity> query = ctx.Users;
            if(!string.IsNullOrEmpty(request.Keyword))
            { 
                query=query.Where(x=>x.Name.Contains(request.Keyword) || x.Surname.Contains(request.Keyword) || x.Username.Contains(request.Keyword));
            }
            return await query.PaginateAsync(request, x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Username = x.Username,
                Email = x.Email,
                Phone = x.Phone,
                ActivatedAt = x.ActivatedAt,
                Role = x.Role.Name
            });
            
        }
    }   
}

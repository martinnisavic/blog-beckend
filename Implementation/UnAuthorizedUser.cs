using Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    public class UnAuthorizedUser:IApplicationUser
    {
        public int Id => 0;
        public string Email => "guest@blog.com";
        public string Username => "guest";
        public string Role => "Guest";
        public IEnumerable<string> AllowedUseCases => new List<string> { "register", "get-posts", "get-post", "get-comments", "account-activate", "get-categories" };
    }
}

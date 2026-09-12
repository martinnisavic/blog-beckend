using Application;
using Application.Commands;
using Application.Queries;
using Application.Services;
using BlogApi.JWT;
using DataAccess;
using Implementation;
using Implementation.Emails;
using Implementation.UseCases;
using Implementation.UseCases.Commands;
using Implementation.UseCases.Queries;
using Implementation.UseCases.Validators;

namespace BlogApi
{
    public static class ApiExtensions
    {
        public static void SetUpApplication(this IServiceCollection services, string connString)
        {
            services.AddHttpContextAccessor();

            services.AddScoped(x => new BlogDbContext(connString));
            services.AddScoped<ApplicationUserFactory>();
            services.AddScoped<IApplicationUser>(x=>
            x.GetRequiredService<ApplicationUserFactory>().Create());
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<RatePostValidator>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
            services.AddTransient<IGetPostQuery, EfGetPostQuery>();
            services.AddTransient<IGetCommentsQuery, EfGetCommentsQuery>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IUpdatePostCommand, EfUpdatePostCommand>();
            services.AddTransient<IActivateAccountCommand, EfActivateAccountCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<IGetUsersQuery,EfGetUsersQuery>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IRatePostCommand, EfRatePostCommand>();
        }
    }
}

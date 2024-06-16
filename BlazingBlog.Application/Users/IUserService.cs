﻿namespace BlazingBlog.Application.Users
{
    public interface IUserService
    {
        Task<string> GetCurrentUserIdAsync();
        Task<bool> IsCurrentUserInRoleAsync(string role);
        Task<bool> CurrentUserCanCreateArticlesAsync();
        Task<bool> CurrentUserCanEditiclesAsync(int articleId);

    }
}

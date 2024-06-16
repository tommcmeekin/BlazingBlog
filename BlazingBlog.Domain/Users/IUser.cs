﻿using BlazingBlog.Domain.Articles;

namespace BlazingBlog.Domain.Users;

public interface IUser
{
    public string Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public List<Article> Articles { get; set; }
}

﻿using BlazingBlog.Domain.Users;

namespace BlazingBlog.Application.Articles.GetArticles;

public class GetArticleQueryHandler : IQueryHandler<GetArticleQuery, List<ArticleResponse>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUserRepository _userRepository;

    public GetArticleQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository)
    {
        _articleRepository = articleRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<ArticleResponse>>> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetAllArticlesAsync();
        var response = new List<ArticleResponse>();
        foreach (var article in articles)
        {
            var articleResponse = article.Adapt<ArticleResponse>();

            if (article.UserId is not null)
            {
                var author = await _userRepository.GetUserByIdAsync(article.UserId);
                articleResponse.UserName = author?.UserName ?? "Unknown";
            }
            else
            {
                articleResponse.UserName = "Unknown";
            }
            response.Add(articleResponse);
        }
        return response.OrderByDescending(a => a.DatePublished).ToList();
    }
}

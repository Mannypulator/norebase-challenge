using System;
using Microsoft.EntityFrameworkCore;
using NoreBaseApiChallenge.Domain.entity;
using NoreBaseApiChallenge.Domain.interfaces;

namespace NoreBaseApiChallenge.Infrastructure.Repository;

public class LikeRepository : ILikeRepository
{
    private readonly RepositoryContext _context;

    public LikeRepository(RepositoryContext context)
    {
        _context = context;
    }

    public async Task AddArticleForLike(Like like)
    {
        _context.Likes.Add(like);
        await _context.SaveChangesAsync();
    }

    public async Task<Like?> GetArticleByIdAsync(Guid articleId)
    {
        var like = await _context.Likes.AsNoTracking()
                                        .Where(x => x.ArticleId.Equals(articleId))
                                        .FirstOrDefaultAsync();
        return like;
    }

    public async Task<int> GetNumberOfArticleLikesAsync(Guid articleId)
    {
        var likeCount = await _context.Likes
                       .AsNoTracking()
                       .Where(x => x.ArticleId == articleId)
                       .Select(x => x.LikeCount)
                       .FirstOrDefaultAsync();

        return likeCount;
    }

    public async Task LikeArticle(Like like)
    {
        await _context.SaveChangesAsync();
    }
}

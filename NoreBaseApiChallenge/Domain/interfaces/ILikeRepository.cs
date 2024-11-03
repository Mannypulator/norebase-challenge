using NoreBaseApiChallenge.Domain.entity;

namespace NoreBaseApiChallenge.Domain.interfaces;

public interface ILikeRepository
{
    Task<int> GetNumberOfArticleLikesAsync(Guid articleId);
    Task LikeArticle(Like like);
    Task<Like?> GetArticleByIdAsync(Guid articleId);

    Task AddArticleForLike(Like like);
}

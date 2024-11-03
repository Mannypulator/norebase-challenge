using NoreBaseApiChallenge.Application.Dto;
using NoreBaseApiChallenge.Application.interfaces;
using NoreBaseApiChallenge.Domain.entity;
using NoreBaseApiChallenge.Domain.interfaces;

namespace NoreBaseApiChallenge.Application.LikeArticle;

public class LikeService : ILikeService
{
    private readonly ILikeRepository _likeRepository;

    public LikeService(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<GenericResponse<int>> GetNumberOfArticleLikesAsync(Guid articleId)
    {

        var like = await _likeRepository.GetArticleByIdAsync(articleId);

        if (like == null)
        {
            return GenericResponse<int>.Failed(404, "Article not found");
        }
        var likeCount = await _likeRepository.GetNumberOfArticleLikesAsync(articleId);

        return GenericResponse<int>.Success(200, "success", likeCount);
    }

    public async Task<GenericResponse<string>> LikeArticleAsync(Guid articleId)
    {
         var articleToBeLiked = await _likeRepository.GetArticleByIdAsync(articleId);

        if (articleToBeLiked == null)
        {
            articleToBeLiked = new Like
            {
                ArticleId = articleId,
                LikeCount = 1,
                RowVersion = DateTime.UtcNow.ToString("O")
            };

            await _likeRepository.AddArticleForLike(articleToBeLiked);
        }
        else
        {
            articleToBeLiked.LikeCount++;
        }

        await _likeRepository.LikeArticle(articleToBeLiked);

        return GenericResponse<string>.Success(200, "success", "Article liked successfully");
    }
}

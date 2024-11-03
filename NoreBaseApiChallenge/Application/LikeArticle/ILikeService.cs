using System;
using NoreBaseApiChallenge.Application.Dto;

namespace NoreBaseApiChallenge.Application.interfaces;

public interface ILikeService
{
    Task<GenericResponse<int>> GetNumberOfArticleLikesAsync(Guid articleId);

    Task<GenericResponse<string>> LikeArticleAsync(Guid articleId);


}

using System;
using System.ComponentModel.DataAnnotations;

namespace NoreBaseApiChallenge.Domain.entity;

public class Like
{
    public Guid ArticleId { get; set; }
    public int LikeCount { get; set; }
    public string RowVersion { get; set; }
}

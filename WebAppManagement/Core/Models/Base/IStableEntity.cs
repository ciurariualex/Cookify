namespace Core.Models.Base
{
    using System;

    public interface IStableEntity
    {
        DateTime CreatedAt { get; }
        Guid CreatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
        Guid? UpdatedBy { get; set; }
    }
}
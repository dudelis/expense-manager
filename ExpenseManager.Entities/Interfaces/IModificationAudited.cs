namespace ExpenseManager.Entities.Interfaces
{
    public interface IModificationAudited : IHasModificationTime
    {
        string LastModifiedUserId { get; set; }
    }
}

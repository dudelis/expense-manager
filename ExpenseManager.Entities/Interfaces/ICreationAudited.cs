namespace ExpenseManager.Entities.Interfaces
{
    public interface ICreationAudited : IHasCreationTime
    {
        string CreatorUserId { get; set; }
    }
}

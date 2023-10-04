namespace EFCFExcercise.Core
{
    public interface IUnitOfWork
    {
        IStaffRepository StaffRepository { get; }
        ITitleRepository TitleRepository { get; }
        Task CompleteAsync();
    }
}

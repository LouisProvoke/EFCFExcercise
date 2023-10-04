using EFCFExcercise.Data;

namespace EFCFExcercise.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EFCFExcerciseContext _context;
        public IStaffRepository StaffRepository { get; private set; }

        public ITitleRepository TitleRepository { get; private set; }

        public UnitOfWork(EFCFExcerciseContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");
            StaffRepository = new StaffRepository(context, _logger);
            TitleRepository = new TitleRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

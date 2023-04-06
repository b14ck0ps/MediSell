namespace DAL.Repository
{
    public abstract class Database
    {
        internal AppDbContext Context { get; } = new AppDbContext();
    }
}
namespace WebApplication1
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<Medicament> Medicament { get; set; }
    }
}

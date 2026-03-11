using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;

namespace SupplierHub.Config
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		// DbSets (Models)

		// PurchaseOrder
		public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
		public DbSet<POLine> POLines => Set<POLine>();
		public DbSet<PORevision> PORevisions => Set<PORevision>();
		public DbSet<PoAck> PoAcks => Set<PoAck>();
		public DbSet<ErpExportRef> ErpExportRefs => Set<ErpExportRef>();

		//Invoices
		public DbSet<Invoice> Invoices => Set<Invoice>();
		public DbSet<InvoiceLine> InvoiceLines => Set<InvoiceLine>();
		public DbSet<MatchRef> MatchRefs => Set<MatchRef>();


		public DbSet<ApprovalRule> ApprovalRules => Set<ApprovalRule>();
		public DbSet<Catalog> Catalogs => Set<Catalog>();
		public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();
		public DbSet<Category> Categories => Set<Category>();
		public DbSet<ComplianceDoc> ComplianceDocs => Set<ComplianceDoc>();
		public DbSet<Contract> Contracts => Set<Contract>();
		public DbSet<GRNItemRef> GRNItemRefs => Set<GRNItemRef>();
		public DbSet<GRNRef> GRNRefs => Set<GRNRef>();
		public DbSet<Inspection> Inspections => Set<Inspection>();
		public DbSet<Item> Items => Set<Item>();
		public DbSet<NCR> NCRs => Set<NCR>();
		public DbSet<Organization> Organizations => Set<Organization>();
		public DbSet<Requisition> Requisitions => Set<Requisition>();
		public DbSet<Scorecard> Scorecards => Set<Scorecard>();
		public DbSet<Supplier> Suppliers => Set<Supplier>();
		public DbSet<SupplierContact> SupplierContacts => Set<SupplierContact>();
		public DbSet<SupplierKPI> SupplierKPIs => Set<SupplierKPI>();
		public DbSet<SupplierRisk> SupplierRisks => Set<SupplierRisk>();
		public DbSet<User> Users => Set<User>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Automatically applies all IEntityTypeConfiguration<T> classes in this assembly
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
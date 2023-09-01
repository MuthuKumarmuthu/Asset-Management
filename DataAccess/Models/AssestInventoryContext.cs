using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class AssestInventoryContext : DbContext
{
    public AssestInventoryContext()
    {
    }

    public AssestInventoryContext(DbContextOptions<AssestInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<Assest> Assests { get; set; }

    public virtual DbSet<AssestStatus> AssestStatuses { get; set; }

    public virtual DbSet<AssestType> AssestTypes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DevelopmentTool> DevelopmentTools { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<MembersinRole> MembersinRoles { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ToolsinAssest> ToolsinAssests { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserActivityLogDetail> UserActivityLogDetails { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-92L738U\\SQLEXPRESS;Initial Catalog=AssestInventory;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_ADDRESS");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddTypeId).HasColumnName("AddTypeID");
            entity.Property(e => e.Address1).HasMaxLength(100);
            entity.Property(e => e.Address2).HasMaxLength(50);
            entity.Property(e => e.Address3).HasMaxLength(50);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Identifier).HasMaxLength(50);
            entity.Property(e => e.PostCode).HasMaxLength(50);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AddType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADDRESSES_ADDRESSTYPES");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADDRESSES_CITIES");

            entity.HasOne(d => d.Contact).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_ADDRESSES_CONTACTS");

            entity.HasOne(d => d.Region).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADDRESSES_REGIONS");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.AddTypeId).HasName("PK_AddressType");

            entity.Property(e => e.AddTypeId)
                .ValueGeneratedNever()
                .HasColumnName("AddTypeID");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Assest>(entity =>
        {
            entity.Property(e => e.AssestId).HasColumnName("AssestID");
            entity.Property(e => e.Amc)
                .HasMaxLength(255)
                .HasColumnName("AMC");
            entity.Property(e => e.AssestStatusId).HasColumnName("AssestStatusID");
            entity.Property(e => e.AssestTypeId).HasColumnName("AssestTypeID");
            entity.Property(e => e.Code).HasMaxLength(25);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.InsuranceDetails).HasMaxLength(255);
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(25)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LicenceDetails).HasMaxLength(255);
            entity.Property(e => e.LicenceExpiry).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(25);
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Memory).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.OperatingSystem).HasMaxLength(50);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.Processor).HasMaxLength(50);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.SerialNumber).HasMaxLength(25);
            entity.Property(e => e.Storage).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Warranty).HasMaxLength(255);

            entity.HasOne(d => d.AssestStatus).WithMany(p => p.Assests)
                .HasForeignKey(d => d.AssestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assests_AssestStatus");

            entity.HasOne(d => d.AssestType).WithMany(p => p.Assests)
                .HasForeignKey(d => d.AssestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assests_AssestTypes");

            entity.HasOne(d => d.Department).WithMany(p => p.Assests)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Assests_Departments");

            entity.HasOne(d => d.Owner).WithMany(p => p.Assests)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Assests_Owner");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Assests)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_Assests_Vendors");
        });

        modelBuilder.Entity<AssestStatus>(entity =>
        {
            entity.ToTable("AssestStatus");

            entity.Property(e => e.AssestStatusId).HasColumnName("AssestStatusID");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssestType>(entity =>
        {
            entity.Property(e => e.AssestTypeId).HasColumnName("AssestTypeID");
            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK_CITIES");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(128);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.PostCode).HasMaxLength(50);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.TimeZone).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CITIES_REGIONS");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_CONTACTS");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CreatedBy).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EMail)
                .HasMaxLength(150)
                .HasColumnName("eMail");
            entity.Property(e => e.Fax).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.HomePhone).HasMaxLength(100);
            entity.Property(e => e.Identifier).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.MobilePhone).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.PhoneAreaCode).HasMaxLength(10);
            entity.Property(e => e.PreferredContact).HasMaxLength(50);
            entity.Property(e => e.Salutation).HasMaxLength(50);
            entity.Property(e => e.Sex).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.WebSite).HasMaxLength(50);

            entity.HasOne(d => d.Membership).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("FK_Contacts_Memberships");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_Contacts_Vendors");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK_COUNTRY");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Capital).HasMaxLength(50);
            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.Country1)
                .HasMaxLength(128)
                .HasColumnName("Country");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.CurrencyCode).HasMaxLength(50);
            entity.Property(e => e.Elscode)
                .HasMaxLength(50)
                .HasColumnName("ELSCode");
            entity.Property(e => e.Fips104)
                .HasMaxLength(50)
                .HasColumnName("FIPS104");
            entity.Property(e => e.Internet).HasMaxLength(50);
            entity.Property(e => e.Iso2)
                .HasMaxLength(50)
                .HasColumnName("ISO2");
            entity.Property(e => e.Iso3)
                .HasMaxLength(50)
                .HasColumnName("ISO3");
            entity.Property(e => e.Ison)
                .HasMaxLength(50)
                .HasColumnName("ISON");
            entity.Property(e => e.MapReference).HasMaxLength(50);
            entity.Property(e => e.NationalityPlural).HasMaxLength(50);
            entity.Property(e => e.NationalitySingular).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<DevelopmentTool>(entity =>
        {
            entity.HasKey(e => e.ToolId);

            entity.Property(e => e.ToolId).HasColumnName("ToolID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Keys).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.AliasName).HasMaxLength(150);
            entity.Property(e => e.Comments).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(255);
            entity.Property(e => e.MembershipTypeCode).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PasswordAnswer).HasMaxLength(255);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(255);
            entity.Property(e => e.ProfileImage).HasColumnType("image");
            entity.Property(e => e.ProfileImageContentType).HasMaxLength(50);
            entity.Property(e => e.RegisteredDate).HasColumnType("datetime");
            entity.Property(e => e.TandCaccepted).HasColumnName("TandCAccepted");
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(150);
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<MembersinRole>(entity =>
        {
            entity.HasKey(e => e.MemberinRoleId).HasName("PK_MEMBERSINROLES");

            entity.Property(e => e.MemberinRoleId).HasColumnName("MemberinRoleID");
            entity.Property(e => e.CreatedBy).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Membership).WithMany(p => p.MembersinRoles)
                .HasForeignKey(d => d.MembershipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MEMBERSINROLES_ROLES");

            entity.HasOne(d => d.Role).WithMany(p => p.MembersinRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembersinRoles_Roles1");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK_REGION");

            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Adm1code)
                .HasMaxLength(50)
                .HasColumnName("ADM1Code");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.RegionName).HasMaxLength(128);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Country).WithMany(p => p.Regions)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGION_COUNTRY");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_ROLES");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.DisplayName).HasMaxLength(50);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(100);
            entity.Property(e => e.RoleCode).HasMaxLength(20);
            entity.Property(e => e.RoleLevel).HasMaxLength(20);
            entity.Property(e => e.RoleName).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ToolsinAssest>(entity =>
        {
            entity.Property(e => e.ToolsinAssestId).HasColumnName("ToolsinAssestID");
            entity.Property(e => e.AssestId).HasColumnName("AssestID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ToolId).HasColumnName("ToolID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Assest).WithMany(p => p.ToolsinAssests)
                .HasForeignKey(d => d.AssestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ToolsinAssests_Assests");

            entity.HasOne(d => d.Tool).WithMany(p => p.ToolsinAssests)
                .HasForeignKey(d => d.ToolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ToolsinAssests_DevelopmentTools");
        });

        modelBuilder.Entity<UserActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("UserActivityLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Host).HasMaxLength(50);
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.LoggedinTime).HasColumnType("datetime");
            entity.Property(e => e.LoggedoutTime).HasColumnType("datetime");
            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Membership).WithMany(p => p.UserActivityLogs)
                .HasForeignKey(d => d.MembershipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserActivityLog_Memberships");
        });

        modelBuilder.Entity<UserActivityLogDetail>(entity =>
        {
            entity.HasKey(e => e.LogDetailId);

            entity.Property(e => e.LogDetailId).HasColumnName("LogDetailID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.RequestMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestUrl).HasColumnName("RequestURL");

            entity.HasOne(d => d.Log).WithMany(p => p.UserActivityLogDetails)
                .HasForeignKey(d => d.LogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserActivityLogDetails_UserActivityLog");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.CreatedBy).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VendorName).HasMaxLength(150);
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

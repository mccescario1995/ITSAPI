using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITSAPI.Models;

public partial class ItsDbContext : DbContext
{
    public ItsDbContext()
    {
    }

    public ItsDbContext(DbContextOptions<ItsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoreSystem> CoreSystems { get; set; }

    public virtual DbSet<CoreUserMenuList> CoreUserMenuLists { get; set; }

    public virtual DbSet<CoreVAdminMenu> CoreVAdminMenus { get; set; }

    public virtual DbSet<CoreVCalendar> CoreVCalendars { get; set; }

    public virtual DbSet<CoreVDistrict> CoreVDistricts { get; set; }

    public virtual DbSet<CoreVEmployeeDetail> CoreVEmployeeDetails { get; set; }

    public virtual DbSet<CoreVParentMenu> CoreVParentMenus { get; set; }

    public virtual DbSet<CoreVSiteInfo> CoreVSiteInfos { get; set; }

    public virtual DbSet<CoreVUser> CoreVUsers { get; set; }

    public virtual DbSet<ItsGroup> ItsGroups { get; set; }

    public virtual DbSet<ItsGrouptype> ItsGrouptypes { get; set; }

    public virtual DbSet<ItsIssue> ItsIssues { get; set; }

    public virtual DbSet<ItsIssuebranch> ItsIssuebranches { get; set; }

    public virtual DbSet<ItsIssuethread> ItsIssuethreads { get; set; }

    public virtual DbSet<ItsIssuetype> ItsIssuetypes { get; set; }

    public virtual DbSet<ItsStatus> ItsStatuses { get; set; }

    public virtual DbSet<ItsVGroup> ItsVGroups { get; set; }

    public virtual DbSet<ItsVGroupType> ItsVGroupTypes { get; set; }

    public virtual DbSet<ItsVIssue> ItsVIssues { get; set; }

    public virtual DbSet<ItsVIssueBranch> ItsVIssueBranches { get; set; }

    public virtual DbSet<ItsVIssueThread> ItsVIssueThreads { get; set; }

    public virtual DbSet<ItsVIssueType> ItsVIssueTypes { get; set; }

    public virtual DbSet<ItsVStatus> ItsVStatuses { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source=core.private.fast.com.ph;initial catalog=ITSDB;user id=itsuser;password=itspassword1;MultipleActiveResultSets=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AI");

        modelBuilder.Entity<CoreSystem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_system");

            entity.Property(e => e.Debugpassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("debugpassword");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Mobadminpincode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("mobadminpincode");
            entity.Property(e => e.Pismutilizationmonth).HasColumnName("pismutilizationmonth");
            entity.Property(e => e.Pismutilizationyear).HasColumnName("pismutilizationyear");
        });

        modelBuilder.Entity<CoreUserMenuList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_UserMenuList");

            entity.Property(e => e.Canadd).HasColumnName("canadd");
            entity.Property(e => e.Candelete).HasColumnName("candelete");
            entity.Property(e => e.Canedit).HasColumnName("canedit");
            entity.Property(e => e.Canopen).HasColumnName("canopen");
            entity.Property(e => e.Canview).HasColumnName("canview");
            entity.Property(e => e.ChildIcon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Formobile).HasColumnName("formobile");
            entity.Property(e => e.Forweb).HasColumnName("forweb");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Istransaction).HasColumnName("istransaction");
            entity.Property(e => e.MenuId).HasColumnName("menuId");
            entity.Property(e => e.Menucode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menucode");
            entity.Property(e => e.Menuname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("menuname");
            entity.Property(e => e.Menuorder).HasColumnName("menuorder");
            entity.Property(e => e.Menuparent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MENUPARENT");
            entity.Property(e => e.Menutype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("menutype");
            entity.Property(e => e.Menutypedes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MENUTYPEDES");
            entity.Property(e => e.Nenunames)
                .HasMaxLength(304)
                .IsUnicode(false)
                .HasColumnName("nenunames");
            entity.Property(e => e.ParentIcon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prtmenucode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prtmenucode");
            entity.Property(e => e.Subtotal).HasColumnName("SUBTOTAL");
            entity.Property(e => e.SysId).HasColumnName("sysId");
            entity.Property(e => e.Syscode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("syscode");
            entity.Property(e => e.Sysdescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sysdescription");
            entity.Property(e => e.Sysname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sysname");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Viewtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("viewtype");
        });

        modelBuilder.Entity<CoreVAdminMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vAdminMenu");

            entity.Property(e => e.Menucode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menucode");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
            entity.Property(e => e.ParentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("parentName");
            entity.Property(e => e.Parenticon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("parenticon");
            entity.Property(e => e.Parentmenuorder).HasColumnName("parentmenuorder");
            entity.Property(e => e.SysId).HasColumnName("sysId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<CoreVCalendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vCalendar");

            entity.Property(e => e.AnalysisDateDisplay)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AnalysisMonthDisplay)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.AnalysisWeekDisplay)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MonthFormat).HasMaxLength(4000);
            entity.Property(e => e.QuarterFormat)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WeekFormat)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CoreVDistrict>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vDistrict");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.HeadContact)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.HeadEmail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HeadId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HeadName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusName)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CoreVEmployeeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vEmployeeDetails");

            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.Branch)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("branch");
            entity.Property(e => e.Brancharea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brancharea");
            entity.Property(e => e.Branchname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("branchname");
            entity.Property(e => e.Civilstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("civilstatus");
            entity.Property(e => e.Class)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Corporate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("corporate");
            entity.Property(e => e.CorporateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("corporateName");
            entity.Property(e => e.Datehired)
                .HasColumnType("datetime")
                .HasColumnName("datehired");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("departmentname");
            entity.Property(e => e.Districtcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("districtcode");
            entity.Property(e => e.Districtname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtname");
            entity.Property(e => e.Effectivitydate)
                .HasColumnType("datetime")
                .HasColumnName("effectivitydate");
            entity.Property(e => e.Emailadd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailadd");
            entity.Property(e => e.EmplId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("empl_id");
            entity.Property(e => e.Employeehomeaddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("employeehomeaddress");
            entity.Property(e => e.Employeename)
                .HasMaxLength(153)
                .IsUnicode(false)
                .HasColumnName("employeename");
            entity.Property(e => e.Employeename2)
                .HasMaxLength(108)
                .IsUnicode(false)
                .HasColumnName("employeename2");
            entity.Property(e => e.Employeename3)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("employeename3");
            entity.Property(e => e.Employeepresentaddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("employeepresentaddress");
            entity.Property(e => e.Employeepresentcontact)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeepresentcontact");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Homecontact)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("homecontact");
            entity.Property(e => e.ImmediateBday)
                .HasColumnType("datetime")
                .HasColumnName("ImmediateBDay");
            entity.Property(e => e.ImmediateBranch)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImmediateDepartment)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImmediateDhired)
                .HasColumnType("datetime")
                .HasColumnName("ImmediateDHired");
            entity.Property(e => e.ImmediateEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImmediateId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ImmediateID");
            entity.Property(e => e.ImmediateLevel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImmediateName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ImmediatePosition)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImmediateSbu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ImmediateSBU");
            entity.Property(e => e.ImmediateSection)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImmediateStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Joblevelgroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("joblevelgroup");
            entity.Property(e => e.Levelcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("levelcode");
            entity.Property(e => e.Levelname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("levelname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Mname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mname");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Position)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.Positionname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("positionname");
            entity.Property(e => e.Section)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("section");
            entity.Property(e => e.Sectionname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sectionname");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sex");
            entity.Property(e => e.Sss)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sss");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Typedescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typedescription");
        });

        modelBuilder.Entity<CoreVParentMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vParentMenu");

            entity.Property(e => e.Menucode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menucode");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
            entity.Property(e => e.ParentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("parentName");
            entity.Property(e => e.Parenticon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("parenticon");
            entity.Property(e => e.Parentmenuorder).HasColumnName("parentmenuorder");
            entity.Property(e => e.SysId).HasColumnName("sysId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<CoreVSiteInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vSiteInfo");

            entity.Property(e => e.Additives)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("additives");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BusinessUnit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DistrictEmailAdd)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DistrictHeadIdno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DistrictHeadIDNo");
            entity.Property(e => e.DistrictPhoneName)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Districtcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("districtcode");
            entity.Property(e => e.Districtheadname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtheadname");
            entity.Property(e => e.Districtname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtname");
            entity.Property(e => e.Hrisbranchcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hrisbranchcode");
            entity.Property(e => e.Isreportauto).HasColumnName("isreportauto");
            entity.Property(e => e.Matrix)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("matrix");
            entity.Property(e => e.Nonmatrix)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("nonmatrix");
            entity.Property(e => e.ProjbaseBill)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("projbase_bill");
            entity.Property(e => e.ProjbaseNotbill)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("projbase_notbill");
            entity.Property(e => e.RelieverAbsent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("reliever_absent");
            entity.Property(e => e.RelieverRd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("reliever_rd");
            entity.Property(e => e.SiteAlias)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SiteCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SiteEmailAdd)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SiteHeadIdno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SiteHeadIDNo");
            entity.Property(e => e.SiteHeadName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SiteLatitude)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SiteLongitude)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SiteMap).IsUnicode(false);
            entity.Property(e => e.SiteName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SitePhoneName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.SundayOps)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sunday_ops");
            entity.Property(e => e.Withpism).HasColumnName("withpism");
        });

        modelBuilder.Entity<CoreVUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("core_vUsers");

            entity.Property(e => e.Canaccessaquila).HasColumnName("canaccessaquila");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailaddress");
            entity.Property(e => e.EmplId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emplId");
            entity.Property(e => e.Employeename)
                .HasMaxLength(153)
                .IsUnicode(false)
                .HasColumnName("employeename");
            entity.Property(e => e.Employeename2)
                .HasMaxLength(104)
                .IsUnicode(false)
                .HasColumnName("employeename2");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Hashcode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hashcode");
            entity.Property(e => e.Ismailvalid).HasColumnName("ismailvalid");
            entity.Property(e => e.Isphonevalid).HasColumnName("isphonevalid");
            entity.Property(e => e.Isverify).HasColumnName("isverify");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middlename");
            entity.Property(e => e.Mobileno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("mobileno");
            entity.Property(e => e.Nickname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("userId");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Userpass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userpass");
            entity.Property(e => e.Userrole)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userrole");
            entity.Property(e => e.Usertype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("usertype");
        });

        modelBuilder.Entity<ItsGroup>(entity =>
        {
            entity.ToTable("its_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("code");
            entity.Property(e => e.Createdbyuserid).HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Grouptypeid).HasColumnName("grouptypeid");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Modifiedbyuserid).HasColumnName("modifiedbyuserid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ItsGrouptype>(entity =>
        {
            entity.ToTable("its_grouptype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdbyuserid).HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Modifiedbyuserid).HasColumnName("modifiedbyuserid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ItsIssue>(entity =>
        {
            entity.ToTable("its_issue");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actionplan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("actionplan");
            entity.Property(e => e.Createdbyuserid).HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Issuetypeid)
                .HasDefaultValue(1)
                .HasColumnName("issuetypeid");
            entity.Property(e => e.Isusedetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("isusedetails");
            entity.Property(e => e.Modifiedbyuserid).HasColumnName("modifiedbyuserid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Responsibleempid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("responsibleempid");
            entity.Property(e => e.Responsiblegroupid).HasColumnName("responsiblegroupid");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ItsIssuebranch>(entity =>
        {
            entity.ToTable("its_issuebranch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Branchcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("branchcode");
            entity.Property(e => e.Createdbyuserid).HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Issueid).HasColumnName("issueid");
            entity.Property(e => e.Modifiedbyuserid).HasColumnName("modifiedbyuserid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
        });

        modelBuilder.Entity<ItsIssuethread>(entity =>
        {
            entity.ToTable("its_issuethread");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdbyuserid)
                .HasComment("0 = System")
                .HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Issueid).HasColumnName("issueid");
            entity.Property(e => e.Messagedetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("messagedetail");
        });

        modelBuilder.Entity<ItsIssuetype>(entity =>
        {
            entity.ToTable("its_issuetype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdbyuserid).HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Modifiedbyuserid).HasColumnName("modifiedbyuserid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ItsStatus>(entity =>
        {
            entity.ToTable("its_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdbyuserid).HasColumnName("createdbyuserid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Modifiedbyuserid).HasColumnName("modifiedbyuserid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ItsVGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vGroup");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GroupType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusName)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItsVGroupType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vGroupType");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusName)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItsVIssue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vIssue");

            entity.Property(e => e.ActionPlan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.IssueType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ResponsibleEmployee)
                .HasMaxLength(108)
                .IsUnicode(false);
            entity.Property(e => e.ResponsibleEmployeeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ResponsibleGroupName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<ItsVIssueBranch>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vIssueBranch");

            entity.Property(e => e.BranchCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.BranchName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ItsVIssueThread>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vIssueThread");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MessageDetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<ItsVIssueType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vIssueType");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusName)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItsVStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("its_vStatus");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(104)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusName)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

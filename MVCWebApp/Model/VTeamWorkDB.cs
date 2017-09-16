namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VTeamWorkDB : DbContext
    {
        public VTeamWorkDB()
            : base("name=VTeamWorkDB")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_ANSWER> tbl_ANSWER { get; set; }
        public virtual DbSet<tbl_APPLICATION> tbl_APPLICATION { get; set; }
        public virtual DbSet<tbl_MENU_GROUP> tbl_MENU_GROUP { get; set; }
        public virtual DbSet<tbl_MODULE> tbl_MODULE { get; set; }
        public virtual DbSet<tbl_PAGE> tbl_PAGE { get; set; }
        public virtual DbSet<tbl_QUESTION> tbl_QUESTION { get; set; }
        public virtual DbSet<tbl_ROLE> tbl_ROLE { get; set; }
        public virtual DbSet<tbl_ROLE_PAGE> tbl_ROLE_PAGE { get; set; }
        public virtual DbSet<tbl_ROLE_RESTRICT> tbl_ROLE_RESTRICT { get; set; }
        public virtual DbSet<tbl_TEAM> tbl_TEAM { get; set; }
        public virtual DbSet<tbl_TEAM_MODULE> tbl_TEAM_MODULE { get; set; }
        public virtual DbSet<tbl_USER> tbl_USER { get; set; }
        public virtual DbSet<tbl_USER_ROLE> tbl_USER_ROLE { get; set; }
        public virtual DbSet<tbl_USER_TYPE> tbl_USER_TYPE { get; set; }
        public virtual DbSet<TeamReview> TeamReviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_ANSWER>()
                .Property(e => e.ANSWER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANSWER>()
                .Property(e => e.ANSWER_DESCRITION)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANSWER>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANSWER>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .Property(e => e.APPLICATION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .Property(e => e.APPLICATION_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .HasMany(e => e.tbl_PAGE)
                .WithRequired(e => e.tbl_APPLICATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_APPLICATION>()
                .HasMany(e => e.tbl_ROLE)
                .WithRequired(e => e.tbl_APPLICATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_MENU_GROUP>()
                .Property(e => e.MENU_GROUP_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MENU_GROUP>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MENU_GROUP>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MENU_GROUP>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MODULE>()
                .Property(e => e.MODULE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MODULE>()
                .Property(e => e.MODULE_DESCRITION)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MODULE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MODULE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MODULE>()
                .Property(e => e.IS_DEFAULT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MODULE>()
                .HasMany(e => e.tbl_MODULE1)
                .WithOptional(e => e.tbl_MODULE2)
                .HasForeignKey(e => e.PARENT_MODULE_ID);

            modelBuilder.Entity<tbl_MODULE>()
                .HasMany(e => e.tbl_TEAM_MODULE)
                .WithRequired(e => e.tbl_MODULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_PAGE>()
                .Property(e => e.PAGE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PAGE>()
                .Property(e => e.PAGE_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PAGE>()
                .Property(e => e.PAGE_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PAGE>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PAGE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PAGE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_QUESTION>()
                .Property(e => e.QUESTION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_QUESTION>()
                .Property(e => e.QUESTION_DESCRITION)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_QUESTION>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_QUESTION>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .Property(e => e.ROLE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .Property(e => e.ROLE_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .Property(e => e.IS_DELETED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE>()
                .HasMany(e => e.tbl_ROLE_RESTRICT)
                .WithRequired(e => e.tbl_ROLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_ROLE_PAGE>()
                .Property(e => e.CAN_ADD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_PAGE>()
                .Property(e => e.CAN_EDIT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_PAGE>()
                .Property(e => e.CAN_DELETE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_PAGE>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_PAGE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_PAGE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_RESTRICT>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_RESTRICT>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ROLE_RESTRICT>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TEAM>()
                .Property(e => e.TEAM_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TEAM>()
                .Property(e => e.TEAM_DESCRITION)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TEAM>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TEAM>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TEAM>()
                .HasMany(e => e.tbl_TEAM_MODULE)
                .WithRequired(e => e.tbl_TEAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_TEAM>()
                .HasMany(e => e.TeamReviews)
                .WithOptional(e => e.tbl_TEAM)
                .HasForeignKey(e => e.TeamID);

            modelBuilder.Entity<tbl_TEAM_MODULE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TEAM_MODULE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.LOGIN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.MOBILE_NO)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.PHONE_NUMBER_EXT)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.USER_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.IS_DELETED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.IS_ACTIVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.DEPT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.USER_CLASS)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.CNIC)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.DESIGNATION)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.MOTHER_MAIDEN_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.EMPLOYEE_NO)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .Property(e => e.SKYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER>()
                .HasMany(e => e.tbl_ANSWER)
                .WithOptional(e => e.tbl_USER)
                .HasForeignKey(e => e.COACH_ID);

            modelBuilder.Entity<tbl_USER>()
                .HasMany(e => e.tbl_ANSWER1)
                .WithOptional(e => e.tbl_USER1)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<tbl_USER>()
                .HasMany(e => e.TeamReviews)
                .WithOptional(e => e.tbl_USER)
                .HasForeignKey(e => e.CoachID);

            modelBuilder.Entity<tbl_USER_ROLE>()
                .Property(e => e.UPDATE_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER_ROLE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER_ROLE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER_TYPE>()
                .Property(e => e.USER_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER_TYPE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_USER_TYPE>()
                .Property(e => e.UPDATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<TeamReview>()
                .Property(e => e.TeamReviewComment)
                .IsUnicode(false);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoryBook.Models;

namespace StoryBook.Data 
{
    public class StoryBookDbContext(DbContextOptions<StoryBookDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Themes> Themes { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<PythonData> PythonData {get; set;}
        public DbSet<UserPreference> UserPreferences {get; set;}
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Images>()
               .HasKey(i => i.ImageId);
            
            modelBuilder.Entity<UserGroup>()
              .HasKey(ug => ug.UserGroupId);
            
             modelBuilder.Entity<Themes>()
              .HasKey(t => t.ThemeId);
            
            modelBuilder.Entity<AgeGroup>()
             .HasKey(ag => ag.AgeGroupId);
            
            modelBuilder.Entity<UserProfile>()
              .HasKey(up => up.UserId);
            
            modelBuilder.Entity<PythonData>()
              .HasKey(pd => pd.PythonDataId );

            modelBuilder.Entity<UserPreference>()
               .HasKey(p => p.UserPreferenceId );
            
           modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.PythonData)
                .WithOne(s => s.UserProfile)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

           modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.UserGroups)
                .WithOne(up => up.UserProfile)
                .HasForeignKey(up => up.UserId);
            
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.UserPreferences)
                .WithOne(up => up.UserProfile)
                .HasForeignKey(up => up.UserId);
          
            modelBuilder.Entity<Themes>()
                .HasMany(t => t.Images)
                .WithOne(i => i.Theme)
                .HasForeignKey(i => i.ThemeId);
            
            modelBuilder.Entity<UserProfile>()
               .HasOne(up => up.ApplicationUser)
               .WithOne(au => au.UserProfile)
               .HasForeignKey<UserProfile>(up => up.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserGroup>()
             .HasOne(ua => ua.AgeGroup)
             .WithMany(ag => ag.UserAgeGroups) 
             .HasForeignKey(ua => ua.AgeGroupId);
            
             modelBuilder.Entity<UserGroup>()
             .HasOne(ut => ut.Theme)
             .WithMany(t => t.UserThemeGroups)
             .HasForeignKey(ut => ut.ThemeId);

          
        }
    }
}
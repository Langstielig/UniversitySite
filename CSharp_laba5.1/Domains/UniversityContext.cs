using CSharp_laba5._1.Domains.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

public class UniversityContext : IdentityDbContext<IdentityUser>
{
    public UniversityContext(DbContextOptions options) : base(options) { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<StudentActivity> StudentActivities { get; set; }
    public DbSet<TextField> TextFields { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentActivity>()
            .HasOne(x => x.Student)
            .WithMany(x => x.StudentActivities)
            .HasForeignKey(x => x.StudentId);

        modelBuilder.Entity<StudentActivity>()
            .HasOne(x => x.Activity)
            .WithMany(x => x.StudentActivities)
            .HasForeignKey(x => x.ActivityId);
        
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab", //??
            Name = "admin",
            NormalizedName = "ADMIN"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "myMail@gmail.com",
            NormalizedEmail = "MYMAIL@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "12345"),
            SecurityStamp = string.Empty
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
            UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 1,
            CodeWord = "PageIndex",
            Name = "Главная страница"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 2,
            CodeWord = "PageStudents",
            Name = "Наши студенты"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 3,
            CodeWord = "PageGroups",
            Name = "Группы"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 4,
            CodeWord = "PageActivities",
            Name = "Студенческие группы"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 5,
            CodeWord = "PageStudentActivities",
            Name = "Таблица соответствий студентов и студенческих групп"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 6,
            CodeWord = "PageShowGroups",
            Name = "Группы"
        });

        modelBuilder.Entity<TextField>().HasData(new TextField
        {
            Id = 7,
            CodeWord = "PageContacts",
            Name = "Контакты"
        });



        //base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using Netcore.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.services.interfaces.Data
{
    public class DbFirstDbContext : DbContext
    {
        public DbFirstDbContext(DbContextOptions<DbFirstDbContext> options) : base(options)
        {

        }

        //DB테이블 리스트 지정
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserRolesByUser> UserRolesByUsers { get; set; }


        //virtual
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //4가지 작업
            //DB 테이블이름 변경및 매핑
            modelBuilder.Entity<User>().ToTable(name: "User");
            modelBuilder.Entity<UserRole>().ToTable(name: "UserRole");
            modelBuilder.Entity<UserRolesByUser>().ToTable(name: "UserRoleByUser");

            //복합키 지정
            modelBuilder.Entity<UserRolesByUser>().HasKey(c => new { c.UserId, c.RoleId });
        }



    }
}

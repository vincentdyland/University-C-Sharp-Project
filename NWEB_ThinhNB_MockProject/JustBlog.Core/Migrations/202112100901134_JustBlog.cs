namespace JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustBlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                create => new
                    {
                        Id = create.Int(nullable: false, identity: true),
                        Name = create.String(nullable: false, maxLength: 250),
                        Slug = create.String(nullable: false, maxLength: 150),
                        Status = create.Int(nullable: false),
                    })
                .PrimaryKey(temp => temp.Id);
            
            CreateTable(
                "dbo.PostCategory",
                create => new
                    {
                        PostID = create.Int(nullable: false),
                        CategoryID = create.Int(nullable: false),
                    })
                .PrimaryKey(temp => new { temp.PostID, temp.CategoryID })
                .ForeignKey("dbo.Categories", temp => temp.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", temp => temp.PostID, cascadeDelete: true)
                .Index(temp => temp.PostID)
                .Index(temp => temp.CategoryID);
            
            CreateTable(
                "dbo.Posts",
                create => new
                    {
                        Id = create.Int(nullable: false, identity: true),
                        Title = create.String(nullable: false, maxLength: 300),
                        Content = create.String(nullable: false),
                        Description = create.String(nullable: false),
                        Slug = create.String(),
                        AuthorId = create.String(),
                        DateCreated = create.DateTime(nullable: false),
                        DateUpdated = create.DateTime(nullable: false),
                        Status = create.Int(nullable: false),
                    })
                .PrimaryKey(temp => temp.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                create => new
                    {
                        Id = create.String(nullable: false, maxLength: 128),
                        Name = create.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(temp => temp.Id)
                .Index(temp => temp.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                create => new
                    {
                        UserId = create.String(nullable: false, maxLength: 128),
                        RoleId = create.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(temp => new { temp.UserId, temp.RoleId })
                .ForeignKey("dbo.AspNetRoles", temp => temp.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", temp => temp.UserId, cascadeDelete: true)
                .Index(temp => temp.UserId)
                .Index(temp => temp.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                create => new
                    {
                        Id = create.String(nullable: false, maxLength: 128),
                        Email = create.String(maxLength: 256),
                        EmailConfirmed = create.Boolean(nullable: false),
                        PasswordHash = create.String(),
                        SecurityStamp = create.String(),
                        PhoneNumber = create.String(),
                        PhoneNumberConfirmed = create.Boolean(nullable: false),
                        TwoFactorEnabled = create.Boolean(nullable: false),
                        LockoutEndDateUtc = create.DateTime(),
                        LockoutEnabled = create.Boolean(nullable: false),
                        AccessFailedCount = create.Int(nullable: false),
                        UserName = create.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(temp => temp.Id)
                .Index(temp => temp.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                create => new
                    {
                        Id = create.Int(nullable: false, identity: true),
                        UserId = create.String(nullable: false, maxLength: 128),
                        ClaimType = create.String(),
                        ClaimValue = create.String(),
                    })
                .PrimaryKey(temp => temp.Id)
                .ForeignKey("dbo.AspNetUsers", temp => temp.UserId, cascadeDelete: true)
                .Index(temp => temp.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                create => new
                    {
                        LoginProvider = create.String(nullable: false, maxLength: 128),
                        ProviderKey = create.String(nullable: false, maxLength: 128),
                        UserId = create.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(temp => new { temp.LoginProvider, temp.ProviderKey, temp.UserId })
                .ForeignKey("dbo.AspNetUsers", temp => temp.UserId, cascadeDelete: true)
                .Index(temp => temp.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PostCategory", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostCategory", "CategoryID", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PostCategory", new[] { "CategoryID" });
            DropIndex("dbo.PostCategory", new[] { "PostID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategory");
            DropTable("dbo.Categories");
        }
    }
}

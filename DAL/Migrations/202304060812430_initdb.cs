namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountCashIns",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.AccountCashOuts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryMen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        TotalDelivery = c.Int(nullable: false),
                        TotalEarning = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ProfilePicture = c.String(),
                        Address = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OderDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OrderedBy)
                .Index(t => t.OrderedBy);
            
            CreateTable(
                "dbo.DeliveryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Report = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        DeliveryManId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryMen", t => t.DeliveryManId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DeliveryManId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Due = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.ProductsOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.ProductsReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProfitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profits", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductsReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductsReviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductsOrders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductsOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.PaymentMethods", "UserId", "dbo.Users");
            DropForeignKey("dbo.PaymentMethods", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.DeliveryStatus", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.DeliveryStatus", "DeliveryManId", "dbo.DeliveryMen");
            DropForeignKey("dbo.DeliveryMen", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropForeignKey("dbo.AccountCashIns", "Id", "dbo.Products");
            DropForeignKey("dbo.Products", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AccountCashOuts", "Id", "dbo.Products");
            DropIndex("dbo.Profits", new[] { "ProductId" });
            DropIndex("dbo.ProductsReviews", new[] { "UserId" });
            DropIndex("dbo.ProductsReviews", new[] { "ProductId" });
            DropIndex("dbo.ProductsOrders", new[] { "OrderId" });
            DropIndex("dbo.ProductsOrders", new[] { "ProductId" });
            DropIndex("dbo.PaymentMethods", new[] { "OrderId" });
            DropIndex("dbo.PaymentMethods", new[] { "UserId" });
            DropIndex("dbo.DeliveryStatus", new[] { "DeliveryManId" });
            DropIndex("dbo.DeliveryStatus", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            DropIndex("dbo.DeliveryMen", new[] { "UserId" });
            DropIndex("dbo.AccountCashOuts", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "CompanyId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.AccountCashIns", new[] { "Id" });
            DropTable("dbo.Profits");
            DropTable("dbo.ProductsReviews");
            DropTable("dbo.ProductsOrders");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.DeliveryStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.Companies");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountCashOuts");
            DropTable("dbo.Products");
            DropTable("dbo.AccountCashIns");
        }
    }
}

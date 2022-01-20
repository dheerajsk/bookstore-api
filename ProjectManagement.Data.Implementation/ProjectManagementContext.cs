using Ehealthcare.Entities;
using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions options) : base(options)
        {

        }

        public void SeedInitialData()
        {
            User testUser1 = new User
            {
                FirstName = "Test",
                LastName = "User1",
                Password = "Password1",
                Email = "testuser1@test.com",
            };
            User adminUser = new User
            {
                FirstName = "Admin",
                LastName = "",
                Password = "Password1",
                Email = "admin@test.com",
                IsAdmin = true
            };

            User.Add(testUser1);
            User.Add(adminUser);

            Book testBook1 = new Book { Name = ".Net Core", Author = "Packt", Price = 525, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51MJ0oGsW8L._SX258_BO1,204,203,200_.jpg" };
            Book testBook2 = new Book {  Name = "Angular", Author = "Packt", Price = 374, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/718rCk+pGeL.jpg" };
            Book testBook3 = new Book {  Name = "C#", Author = "Gary Cornell", Price = 633, ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/5905/9781590594155.jpg" };
            Book testBook4 = new Book {  Name = "Entity Framework Core", Author = "Dustin Metzgar", Price = 8, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51j8Sl39eUS._SX258_BO1,204,203,200_.jpg" };
            Book testBook5 = new Book {  Name = "Python", Author = "O'really", Price = 310, ImageUrl = "https://images-eu.ssl-images-amazon.com/images/I/51XAhhJFDVL._SX198_BO1,204,203,200_QL40_FMwebp_.jpg" };
            Book testBook6 = new Book {  Name = "React", Author = "Manning", Price = 490, ImageUrl = "https://m.media-amazon.com/images/I/41IiBTZOGCL.jpg" };
            Book testBook7 = new Book {  Name = "MEAN Stack", Author = "Elad Eron", Price = 314, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41HM53OsvDL._SX348_BO1,204,203,200_.jpg" };
            Book testBook8 = new Book {  Name = "MERN Stack", Author = "V Subramaniyam", Price = 369, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/712vlTm1G1L.jpg" };
            Book testBook9 = new Book {  Name = "MongoDB", Author = "Manning", Price = 548, ImageUrl = "https://images.manning.com/360/480/resize/book/5/bea831b-6258-49d6-a2f3-c80233fccff1/Banker-MongoDB-2ed-HI.png" };

            Book.Add(testBook1); 
            Book.Add(testBook2);
            Book.Add(testBook3);
            Book.Add(testBook4);
            Book.Add(testBook5);
            Book.Add(testBook6);
            Book.Add(testBook7);
            Book.Add(testBook8);
            Book.Add(testBook9);
            this.SaveChanges();
        }

        public DbSet<User> User { get; set; }

        public DbSet<Account> Account { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}

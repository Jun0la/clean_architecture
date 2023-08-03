using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.entities
{
    public sealed class Product : Base
    {   
        public string Name { get; private set; }
        public string  Description { get; private set; }    
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID value");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }

        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Field is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimun 5 char.");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock values");

            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters");

            Name = name; 
            Description = description;
            Price = price;
            Stock = stock;
            Image = image; 

        }

        public Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        //navegation types 
        public int CategoryId {get; set;}
        public Category Category {get; set;}
    }
}
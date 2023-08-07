using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.entities
{
    public sealed class Category : Base
    {
        public int Id { get; private set; }    
        public string Name { get; private set; }
        public ICollection<Product> Products {get; set;}

        public Category(string name)
        {
            DomainExceptionValidation.When(Id < 0, "Name is required");
            Id = Id;
            ValidationDomain(name);
        }
        
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            ValidationDomain(name);
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name");

            DomainExceptionValidation.When(name.Length < 3, "Invalid Name is required");

            Name = name;
        }
    }
}
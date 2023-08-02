using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.entities
{
    public sealed class Category
    {
        public int Id { get; private set; }    
        public string Name { get; private set; }

        public Category(string name)
        {
            DomainExceptionValidation.When(Id < 0, "Name is required");
            Id = id;
            ValidationDomain(name);
        }
        
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public ICollection<Product> Products {get; set;}

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name");

            DomainExceptionValidation.When(name.Length < 3, "Invalid Name is required");

            Name = name;
        }
    }
}
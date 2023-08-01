public sealed class Client
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Endereco { get; private set; }

    public Client(int Id, string Name, string Endereco)
    {
        Validar(Id, Name, Endereco); 
        Id = id;
        Name = name;
        Endereco = endereço;
    }

    public void Update(int Id, string Name, string Endereco)
    {
        Validar(Id, Name, Endereco);
        Id = id;
        Name = name;
        Endereco = endereço;
    }
    
    public void Validar(int id, string name, string endereco)
    {
        if (id < 0)
        throw new InvalidOperationException("O Id tem que ser maior que 0");

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(endereco))
        throw new Exception("This field is required.");

        if (Name.Length < 3)
        {
            throw new ArgumentException ("O nome deve ter mais de 3 caracteres");
        }

        if (Name.Length > 100){
            throw new InvalidOperationException("O nome excede os caracteres");
        }
    }

}

using System;

namespace TestePostgres.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Altura { get; set; }
        public Guid Teste { get; set; }
        public Guid Teste1 { get; set; }
    }
}

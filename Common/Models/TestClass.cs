using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class TestClass
    {
        [Key]
        public int Id { get; set; }

        public bool IsSomething { get; set; }

        public string Name { get; set; }

        public int SomeValue { get; set; }


    }
}

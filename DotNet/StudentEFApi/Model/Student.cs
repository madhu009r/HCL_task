using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEFApi.Model
{

    [Table("student")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        Student() { }

        public Student(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}

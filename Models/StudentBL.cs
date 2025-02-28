namespace Eyouth1.Models
{
    public class StudentBL
    {
        List<Student> students;

        public StudentBL()
        {
            students = new List<Student>()
                {
            new Student { Id = 1, Name = "Alice Johnson", Age = 20, ImgUrl = "boy.jpg", DeptId = 101 },
            new Student { Id = 2, Name = "Bob Smith", Age = 22, ImgUrl = "girl.jpg", DeptId = 102 },
            new Student { Id = 3, Name = "Charlie Brown", Age = 19, ImgUrl = "girl.jpg", DeptId = 103 },
            new Student { Id = 4, Name = "David Williams", Age = 21, ImgUrl = "boy.jpg", DeptId = 104 },
            new Student { Id = 5, Name = "Emma Davis", Age = 23, ImgUrl = "girl.jpg", DeptId = 105 },
            new Student { Id = 6, Name = "Frank Miller", Age = 20, ImgUrl = "boy.jpg", DeptId = 101 },
            new Student { Id = 7, Name = "Grace Wilson", Age = 22, ImgUrl = "girl.jpg", DeptId = 102 },
            new Student { Id = 8, Name = "Henry Moore", Age = 24, ImgUrl = "boy.jpg", DeptId = 103 },
            new Student { Id = 9, Name = "Ivy Taylor", Age = 21, ImgUrl = "girl.jpg", DeptId = 104 },
            new Student { Id = 10, Name = "Jack White", Age = 22, ImgUrl = "boy.jpg", DeptId = 105 }
        }; 
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.Find(s => s.Id == id);
        }
    }
}

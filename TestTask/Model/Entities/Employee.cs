using System;

namespace TestTask.Model.Entities
{
    public enum Position { Manager, Worker }

    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual Position Position { get; set; }
        public virtual DateTime DateOfBirth { get; set; }

        public override string ToString() => FullName ?? string.Empty;
    }
}

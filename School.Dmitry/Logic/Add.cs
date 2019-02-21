using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace Logic
{
    public class Add
    {
        public Teacher AddTeacher(string name, int age, string direction, long phoneNumber)
        {
            return new Teacher() { Name = name, Age = age, Direction = direction, PhoneNumber = phoneNumber };
        }
        public Learner AddLearner(string name, int age, long phoneNumber)
        {
            return new Learner() { Name = name, Age = age, PhoneNumber = phoneNumber };
        }
        public StudyClass AddStudyClass(byte number, string title)
        {
            return new StudyClass() { Number = number, Title = title};
        }
    }
}

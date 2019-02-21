using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте");
            List<Learner> Learners = new List<Learner>();
            List<Teacher> Teachers = new List<Teacher>();
            List<StudyClass> StudyClasses = new List<StudyClass>();
            bool flag = true;
            while (flag)
            { 
                Console.WriteLine("\n\nВыберите действие");
                Console.WriteLine("1.Просмотреть список учащихся 2.Просмотреть список учителей 3.Просмотреть список классов");
                Console.WriteLine("4.Добавить ученика/учителя/класс");
                Console.WriteLine("5.Удалить ученика/учителя/класс");
                Console.WriteLine("6.Редактировать класс");
                Console.WriteLine("Для выхода из программы введите 0");

                string Key = Console.ReadLine();

                switch (Key)
                {
                    case "0":
                        Console.Clear();
                        flag = false;
                        break;
                    case "1":
                        Console.Clear();
                        showLearners(Learners);
                        break;
                    case "2":
                        Console.Clear();
                        showTeachers();
                        break;
                    case "3":
                        Console.Clear();
                        showStudyClasses();
                        break;
                    case "4":
                        Console.Clear();
                        Add();
                        break;
                    case "5":
                        Console.Clear();
                        Remove();
                        break;
                    case "6":
                        Console.Clear();
                        editClass();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка ввода. Требуется ввести номер действия");
                        break;
                }
            }

            void showLearners(List<Learner> learners)
            {
                if (learners.Count() > 0)
                {
                    int i = 0;
                    foreach (Learner learner in learners)
                    {
                        Console.WriteLine("{0}. {1}, {2}\n{3}", ++i, learner.Name, learner.Age, learner.PhoneNumber);
                    }
                }
                else { Console.WriteLine("Cписок учеников пуст\n\n"); }
            }

            void showTeachers()
            {
                if (Teachers.Count() > 0)
                {
                    int i = 0;
                    foreach (Teacher teacher in Teachers)
                    {
                        Console.WriteLine("{0}. {1}, Предмет: {2}  {3}\nНомер телефона: {4}", ++i, teacher.Name, teacher.Direction, teacher.Age, teacher.PhoneNumber);
                    }
                }
                else { Console.Clear(); Console.WriteLine("Cписок учителей пуст\n\n"); }
            }

            StudyClass selectClass(string text)
            {
                Console.WriteLine(text);
                int i = 0;
                foreach (StudyClass studyClass in StudyClasses)
                {
                    Console.WriteLine("{0}. {1}{2} Количество учеников: {3}", ++i, studyClass.Number, studyClass.Title, studyClass.TotalLearners);
                }
                SelectClass:
                string str = Console.ReadLine();
                try
                {
                    StudyClass Class = StudyClasses[int.Parse(str) - 1];
                    return Class;
                }
                catch { Console.WriteLine("Ошибка ввода. Выбрано несуществующее значение."); goto SelectClass; }
            }

            List<Learner> removeLearner(List<Learner> learners)
            {
                Console.WriteLine("Выберите ученка, которого хотите убрать из списка");
                Console.WriteLine("Для отмены нажмите Enter");
                showLearners(learners);
                SelectLearner:
                string strIndex = Console.ReadLine();
                try
                {
                    int index = int.Parse(strIndex);
                    learners.RemoveAt(index - 1);
                }
                catch
                {
                    if (strIndex != "")
                    {
                        Console.WriteLine("Ошибка ввода. Введено неправильное значение"); goto SelectLearner;
                    }
                }
                return learners;
            }
            List<Teacher> removeTeacher(List<Teacher> teachers)
            {
                Console.WriteLine("Выберите, какого учителя удалить");
                Console.WriteLine("Для отмены нажмите Enter");
                showTeachers();
                SelectTeacher:
                string strIndex = Console.ReadLine();
                try
                {
                    int index = int.Parse(strIndex);
                    teachers.RemoveAt(index - 1);
                }
                catch { Console.WriteLine("Ошибка ввода. Введено неправильное значение"); goto SelectTeacher; }
                return teachers;
            }
            List<StudyClass> removeStudyClass(List<StudyClass> studyClasses)
            {
                Console.WriteLine("Выберите, какой класс удалить");
                Console.WriteLine("Для отмены нажмите Enter");
                showStudyClasses();
                SelectClass:
                string strIndex = Console.ReadLine();
                try
                {
                    int index = int.Parse(strIndex);
                    studyClasses.RemoveAt(index - 1);
                }
                catch { Console.WriteLine("Ошибка ввода. Введено неправильное значение"); goto SelectClass; }
                return studyClasses;
            }

            List<Learner> editLearners(List<Learner> learners)
            {
                Console.Clear();
                if (learners.Count() == 0) { Console.WriteLine("Список учеников пуст"); }
                else
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1.Добавить ученика 2.Удалить ученика");

                    string str = Console.ReadLine();
                    switch (str)
                    {
                        case "1":
                            Console.WriteLine("Выберите ученика, которого хотите добавить");
                            Console.WriteLine("Для отмены нажмите Enter");

                            showLearners(Learners);

                            try { learners.Add(Learners[int.Parse(Console.ReadLine())]); }
                            catch { if (Console.ReadLine() != "") Console.WriteLine("Ошибка ввода. Введено неправильно значение"); goto case "1"; }

                            break;
                        case "2":
                            removeLearner(learners);
                            break;
                    }
                }
                return learners;
            }

            void editClass()
            {
                if (StudyClasses.Count() > 0)
                {
                    StudyClass selectedClass = selectClass("Выберите класс для редактирования");

                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1.Изменить классного руководителя 2.Изменить номер и название класса 3.Изменить список учеников класса");
                    Console.WriteLine("Для перехода в главное меню нажмите Enter");

                    string str = Console.ReadLine();
                    switch (str)
                    {
                        case "1":
                            Console.WriteLine("Выберите классного руководителя:");
                            showTeachers();
                            if (Teachers.Count() == 0) { break; }
                            try
                            {
                                selectedClass.Teacher = Teachers[int.Parse(Console.ReadLine()) - 1];
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка ввода. Выбрано несуществующее значение.");
                                goto case "1";
                            }
                            break;
                        case "2":
                            Console.WriteLine("Введите построчно номер и название класса");
                            try { selectedClass.Number = byte.Parse(Console.ReadLine()); }
                            catch { Console.WriteLine("Ошибка ввода. Номер класса введен неверно"); goto case "2"; }
                            selectedClass.Title = Console.ReadLine();
                            break;
                        case "3":
                            Console.Clear();
                            selectedClass.LearnerList = editLearners(selectedClass.LearnerList);
                            break;
                        default:
                            break;
                    }


                }
                else { Console.Clear(); Console.WriteLine("Классов пока что нет"); }
            }

            void showStudyClasses()
            {
                if (StudyClasses.Count() > 0)
                {
                    showClass(selectClass("Для более подробной информации о классе, введите номер класса в списке. Для выхода в главное меню нажмите Enter"));
                }
                else { Console.WriteLine("Список классов пуст\n\n"); }
            }

            void showClass(StudyClass studyClass)
            {
                Console.WriteLine("Класс: {0}{1}. Классный руководитель: {2}", studyClass.Number, studyClass.Title, studyClass.Teacher == null ? "Отсутствует" : studyClass.Teacher.Name);
                Console.WriteLine("Список учеников:");
                showLearners(studyClass.LearnerList);

            }

            void Remove()
            {
                Console.WriteLine("Выберите, что планируете удалять");
                Console.WriteLine("1.Ученика 2.Учителя 3.Класс");
                string key = Console.ReadLine();
                switch (key)
                {

                    case "1":
                        Learners = removeLearner(Learners);
                        Console.Clear();
                        break;
                    case "2":
                        Teachers = removeTeacher(Teachers);
                        Console.Clear();
                        break;
                    case "3":
                        StudyClasses = removeStudyClass(StudyClasses);
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
            void Add()
            {
                Console.WriteLine("Выберите, кого хотите добавить:");
                Console.WriteLine("1.Ученик 2.Учитель 3.Класс");
                string key = Console.ReadLine();
                switch (key)
                {

                    case "1":
                        try
                        {
                            Console.WriteLine("Введите построчно Имя, Возраст, Номер телефона ученика");
                            Learners.Add(new Learner { Name = Console.ReadLine(), Age = int.Parse(Console.ReadLine()), PhoneNumber = long.Parse(Console.ReadLine()) });
                        }
                        catch { Console.WriteLine("Неправильные данные"); goto case "1"; }
                        Console.Clear();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Введите построчно Имя, Возраст, Предметную область, Номер телефона учителя");
                            Teachers.Add(new Teacher { Name = Console.ReadLine(), Age = int.Parse(Console.ReadLine()), Direction = Console.ReadLine(), PhoneNumber = long.Parse(Console.ReadLine()) });
                        }
                        catch { Console.WriteLine("Неправильные данные"); goto case "1"; }
                        Console.Clear();
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Введите построчно номер и название класса");
                            StudyClasses.Add(new StudyClass { Number = byte.Parse(Console.ReadLine()), Title = Console.ReadLine(), LearnerList = new List<Learner>() });
                        }
                        catch { Console.WriteLine("Неправильные данные"); goto case "1"; }
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

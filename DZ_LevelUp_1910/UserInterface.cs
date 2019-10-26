using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_LevelUp_1910
{
    class UserInterface
    {
        static BusinessLogic BL = new BusinessLogic();

        /// <summary>   STUDENT     </summary>

        public string CreatFirstName()
        {
            Console.Write("Введите имя студента: ");

            string firstName = Console.ReadLine();

            return firstName;
        }

        public string CreatLastName()
        {
            Console.Write("Введите фамилию студента: ");

            string lastName = Console.ReadLine();

            return lastName;
        }

        public int CreatNumberRecordBook()
        {
            Console.Write("Введите номер зачетной книги студента: ");
            int number = 0;
            number = BL.DataInput(number);

            return number;
        }

        public Student CreatNewStudent(Student student)
        {
            student = new Student(CreatFirstName(), CreatLastName(), CreatNumberRecordBook());

            return student;
        }

        /// <summary>   GROUP   </summary>

        public Group CreatNewGroup(int standardPeopleInGroup = 30)
        {
            Console.WriteLine("Cоздание новой группы");
            Console.Write("Введите название группы: ");

            string name = Console.ReadLine();

            Group group = new Group() { groupName = name, Students = new Student[standardPeopleInGroup] };

            return group;
        }

        /// <summary>   CRUD   </summary>

        public void MassAddInGroup(Group group, int amount = 0)
        {
            Console.WriteLine($"Cколько студендов вы хотите добавить в группу: {group.groupName}");

            amount = BL.DataInput(amount);

            group = BL.MassAddingStudentsToGroup(group, amount);
        }

        public void GetStudentEditing(ref Student student) //Update
        {
            SelectionEditing selectionEditing = new SelectionEditing();

            string str = "Для выбора параметра редактирования нажмите любую кнопку (= \tДля выхода нажмите Esc\n";

            Console.WriteLine(@"Режим редактирования:
1 - Изменить Имя
2 - Изменить Фамилию
3 - Изменить Номер зачетной книги

Esc - Завершить редактирование
");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.Write("Выберите параметр для изменения:");

                selectionEditing = BL.DataInput(selectionEditing);

                switch (selectionEditing)
                {
                    case SelectionEditing.ChangeFirstName:
                        student = BL.ChangeFirstName(student);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(str);
                        Console.ResetColor();
                        break;

                    case SelectionEditing.ChangeLastName:
                        student = BL.ChangeLastName(student);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(str);
                        Console.ResetColor();
                        break;

                    case SelectionEditing.ChangeNumberRecordBook:
                        student = BL.ChangeNumberRecordBook(student);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(str);
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine("Esc - Завершить редактирование");
                        break;
                }
            }
        }

        public void SearchStudent(Group group) //Read 
        {
            Search search = new Search();

            string str = "Для выбора параметров поиска нажмите любую кнопку (= \tДля выхода нажмите Esc\n";

            Console.WriteLine(@"Режим поиска студента в группе:
1 - Найти студента по Имени
2 - Найти студента по Номеру зачетной книги

Esc - Завершить редактирование
");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.Write("Выберите параметр поиска:");

                search = BL.DataInput(search);

                switch (search)
                {
                    case Search.ByName:

                        Console.Write("Введите Имя для поиска: ");

                        Print(group, Console.ReadLine() );

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(str);
                        Console.ResetColor();
                        break;

                    case Search.ByNumberRecordBook:

                        Console.Write("Введите Номер зачетной книги для поиска: ");

                        int number = 0;

                        number = BL.DataInput(number);

                        Print(group, number);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(str);
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine("Esc - Завершить редактирование");
                        break;
                }
            }
        }

        public void ValidRecordBook(Group group)
        {
            if (BL.ComparisonNumberRecordBook(group))
            {
                Console.WriteLine("Зачетные книги одинаковые!!");
            }
        }

        public void CRUD() 
        {
            SelecnionActionInGroup selecnionActionInGroup = new SelecnionActionInGroup();

            string str = "Для выбора операций CRUD нажмите любую кнопку (= \tДля выхода нажмите Esc\n";

            Console.WriteLine(@"Операций CRUD:
1 - Добавить студента в группу
2 - Поиск студента в группе (по имени / по номеру зачетной книги)
3 - Редактирование данных студента
4 - Удаление студента с группы

Esc - Завершить редактирование
");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();

            selecnionActionInGroup = BL.DataInput(selecnionActionInGroup);
            switch (selecnionActionInGroup)
            {
                case SelecnionActionInGroup.Creat:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(str);
                    Console.ResetColor();
                    break;

                case SelecnionActionInGroup.Read:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(str);
                    Console.ResetColor();
                    break;

                case SelecnionActionInGroup.Update:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(str);
                    Console.ResetColor();
                    break;

                case SelecnionActionInGroup.Delete:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(str);
                    Console.ResetColor();
                    break;

                default:
                    Console.WriteLine("Esc - Завершить редактирование");
                    break;
            } // TODO: добавление методов!!!



        }



        public void Print(Group group, int search)
        {
            try
            {
                PrintInfo((Student)BL.SearchStudent(group, search));
            }
            catch (InvalidOperationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!! Cтудент НЕ найден !!");
                Console.ResetColor();
            }
        }

        public void Print(Group group, string search)
        {
            try
            {
                PrintInfo((Student)BL.SearchStudent(group, search));
            }
            catch (InvalidOperationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!! Cтудент НЕ найден !!");
                Console.ResetColor();
            }
        }

        public void PrintInfo(Student student)
        {
            Console.WriteLine($"Имя: {student.firstName}\nФамилия: {student.lastName}\nНомер зачетной книги: {student.numberRecordBook}");
        }



    }
}

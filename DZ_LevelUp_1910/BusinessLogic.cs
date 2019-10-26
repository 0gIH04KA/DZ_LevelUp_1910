using System;
using System.Collections.Generic;
using System.Text;

namespace DZ_LevelUp_1910
{
    class BusinessLogic
    {
        static UserInterface UI = new UserInterface();


        public int DataInput(int numbers)
        {
            while (!int.TryParse(Console.ReadLine(), out numbers))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ошибка ввода!!");
                Console.ResetColor();
            }

            return numbers;
        }

        public SelectionEditing DataInput(SelectionEditing selectionEditing)
        {
            while (!SelectionEditing.TryParse(Console.ReadLine(), out selectionEditing))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ошибка ввода!!");
                Console.ResetColor();
            }

            return selectionEditing;
        }

        public Search DataInput(Search search)
        {
            while (!SelecnionActionInGroup.TryParse(Console.ReadLine(), out search))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ошибка ввода!!");
                Console.ResetColor();
            }

            return search;
        }

        public SelecnionActionInGroup DataInput(SelecnionActionInGroup selecnionActionInGroup)
        {
            while (!SelecnionActionInGroup.TryParse(Console.ReadLine(), out selecnionActionInGroup))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ошибка ввода!!");
                Console.ResetColor();
            }

            return selecnionActionInGroup;
        }

        /// <summary>   STUDENT     </summary>

        public Student ChangeFirstName(Student student)
        {
            student.firstName = UI.CreatFirstName();

            return student;
        }

        public Student ChangeLastName(Student student)
        {
            student.lastName = UI.CreatLastName();

            return student;
        }

        public Student ChangeNumberRecordBook(Student student)
        {
            student.numberRecordBook = UI.CreatNumberRecordBook();

            return student;
        }




        /// <summary>   GROUP   </summary>

        public void AddToGroup(ref Group group, Student newStudent )
        {
            if (group.Students == null)
            {
                group.Students = new Student[] { newStudent };

                return;
            }

            Array.Resize(ref group.Students, group.Students.Length + 1);

            group.Students[group.Students.Length - 1] = newStudent;
        }

        public Group MassAddingStudentsToGroup(Group group, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"{i + 1}-й Студент:");
                AddToGroup(ref group, new Student(UI.CreatFirstName(), UI.CreatLastName(), UI.CreatNumberRecordBook()));
            }

            return group;
        }

        public int SearchByName(Student[] group, Student student, string search)
        {
            int indexInGroup = -1;

            for (int i = 0; i < group.Length; i++)
            {
                if (student.firstName == search)
                {
                    indexInGroup = i;
#if true
                    UI.PrintInfo(group[i]);
#endif
                }
            }

            return indexInGroup;
        }

        public Student? SearchStudent(Group group, string search)
        {
            Student? student = null;

            for (int i = 0; i < group.Students.Length; i++)
            {
                if (group.Students[i].firstName == search)
                {
                    student = group.Students[i];
                }
            }

            return student;
        }

        public Student? SearchStudent(Group group, int search)
        {
            Student? student = null;

            for (int i = 0; i < group.Students.Length; i++)
            {
                if (group.Students[i].numberRecordBook == search)
                {
                    student = group.Students[i];
                }
            }

            return student;
        }

        public bool ComparisonNumberRecordBook(Group group)
        {
            bool comparison = false;

            for (int i = 1; i < group.Students.Length; i++)
            {
                if (group.Students[i].numberRecordBook == group.Students[i-1].numberRecordBook)
                {
                    comparison = true;
                }
            }

            return comparison;
        }

    }
}

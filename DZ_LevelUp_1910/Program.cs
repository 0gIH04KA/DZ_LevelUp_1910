using System;

namespace DZ_LevelUp_1910
{
    class Program
    {
        static UserInterface UI = new UserInterface();
        static BusinessLogic BL = new BusinessLogic();

      


        static int standardPeopleInGroup = 30;


        static void Main(string[] args)
        {
            Student student = new Student("Artem", "Voroncov", 2333);


            Console.ReadKey();
        }

       

        //Student student1 = new Student("Artemm", "Voroncov", 2225);
        //Student student2 = new Student("Artemmm", "Voroncov", 2222);
        ////Student student1 = new Student(UI.CreatFirstName(), UI.CreatLastName(), UI.CreatNumberRecordBook());

        //UI.CreatNewGroup();
        //Group group = new Group() {groupName = "fff", Students = new Student[standardPeopleInGroup] };

        //group.Students[0] = student;

        //BL.AddToGroup(ref group, student1);
        //BL.AddToGroup(ref group, student2);


        //UI.MassAddInGroup(group);

        //UI.SearchStudent(group);


    }

}

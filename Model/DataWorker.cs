using ManageStaffDbApp.Model.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace ManageStaffDbApp.Model
{
    public static class DataWorker
    {
        static string resultOfWorkMethod = "";
        static bool checkIsExists;

        public static string CreateDepartment(string name)
        {
            resultOfWorkMethod = "The department already exists!";

            using (ApplicationContext db = new ApplicationContext())
            {
                checkIsExists = db.Departments.Any(el => el.Name == name);
                if (!checkIsExists)
                {
                    Department department = new Department { Name = name };
                    db.Departments.Add(department);
                    db.SaveChanges();
                    resultOfWorkMethod = "Department has been successfully created!";
                }
            }
            return resultOfWorkMethod;
        }

        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            resultOfWorkMethod = "The position already exists!";

            using (ApplicationContext db = new ApplicationContext())
            {
                checkIsExists = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExists)
                {
                    Position position = new Position { Name = name, Salary = salary, MaxNumber = maxNumber, DepartmentId = department.Id };
                    db.Positions.Add(position);
                    db.SaveChanges();
                    resultOfWorkMethod = "Position has been successfully created!";
                }
            }
            return resultOfWorkMethod;
        }

        public static string CreateUser(string name, string surname, string phone, Position position)
        {
            resultOfWorkMethod = "The user already exists!";

            using (ApplicationContext db = new ApplicationContext())
            {
                checkIsExists = db.Users.Any(el => el.Name == name);
                if (!checkIsExists)
                {
                    User user = new User { Name = name, Surname = surname, Phone = phone, Position = position };
                    db.Users.Add(user);
                    db.SaveChanges();
                    resultOfWorkMethod = "User has been successfully created!";
                }
            }
            return resultOfWorkMethod;
        }



        public static string RemoveDepartment(Department department)
        {
            resultOfWorkMethod = "The department does not exist!";

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                resultOfWorkMethod = $"Department {department.Name} successfully deleted!";
            }
            return resultOfWorkMethod;
        }

        public static string RemovePosition(Position position)
        {
            resultOfWorkMethod = "The position does not exist!";

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                resultOfWorkMethod = $"Position {position.Name} successfully deleted!";
            }
            return resultOfWorkMethod;
        }

        public static string RemoveUser(User user)
        {
            resultOfWorkMethod = "The user does not exist!";

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                resultOfWorkMethod = $"User {user.Name} successfully fired!";
            }
            return resultOfWorkMethod;
        }

        public static string EditDepartment(Department oldDepartment, string newName)
        {
            resultOfWorkMethod = "The department does not exist!";

            using (ApplicationContext db = new ApplicationContext())
            {
                Department? department = db.Departments.FirstOrDefault(el => el.Id == oldDepartment.Id);
                if (department is not null)
                {
                    department.Name = newName;
                    db.SaveChanges();
                    resultOfWorkMethod = $"Department {department.Name} successfully edited!";
                }
            }
            return resultOfWorkMethod;
        }

        public static string EditPositon(Position oldPosition, string newName, decimal newSalary, int newMaxNumber, Department newDepartment)
        {
            resultOfWorkMethod = "The position does not exist!";

            using (ApplicationContext db = new ApplicationContext())
            {
                Position? position = db.Positions.FirstOrDefault(el => el.Id == oldPosition.Id);
                if (position is not null)
                {
                    position.Name = newName;
                    position.Salary = newSalary;
                    position.MaxNumber = newMaxNumber;
                    position.DepartmentId = newDepartment.Id;
                    db.SaveChanges();
                    resultOfWorkMethod = $"Position {position.Name} successfully edited!";
                }
            }
            return resultOfWorkMethod;
        }
        public static string EditUser(User oldUser, string newName, string newSurname, string newPhone, Position newPosition)
        {
            resultOfWorkMethod = "The user does not exist!";

            using (ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault(el => el.Id == oldUser.Id);
                if (user is not null)
                {
                    user.Name = newName;
                    user.Surname = newSurname;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    db.SaveChanges();
                    resultOfWorkMethod = $"User {user.Name} successfully edited!";
                }
            }
            return resultOfWorkMethod;
        }

        public static List<Department> GetAllDepartments()
        {
            List<Department> resultOfAllDepartment;

            using (ApplicationContext db = new ApplicationContext())
                resultOfAllDepartment = db.Departments.ToList();
            
            return resultOfAllDepartment;
        }

        public static List<Position> GetAllPositions()
        {
            List<Position> resultOfAllPositions;

            using (ApplicationContext db = new ApplicationContext())
                resultOfAllPositions = db.Positions.ToList();

            return resultOfAllPositions;
        }

        public static List<User> GetAllUSers()
        {
            List<User> resultOfAllUsers;

            using (ApplicationContext db = new ApplicationContext())
                resultOfAllUsers = db.Users.ToList();

            return resultOfAllUsers;
        }
    }
}

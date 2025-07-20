using System;
using System.Collections.Generic;

namespace DormitoryManagementConsole
{
    class Program
    {
        static List<string> dormitories = new List<string>();
        static List<Block> blocks = new List<Block>();
        static List<Person> managers = new List<Person>();
        static List<Student> students = new List<Student>();
        static List<Asset> assets = new List<Asset>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("1. Modiriat Khabgah        ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("2. Modiriat Block          ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("3. Modiriat Masool Khabgah ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("4. Modiriat Daneshjo       ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("5. Modiriat Amval          ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("6. Gozareshat              ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("7. Khoroj                  ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("Yek ghesmat ra entekhab konid (1-7)");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                switch (Console.ReadLine())
                {
                    case "1": DormitoryMenu(); break;
                    case "2": BlockMenu(); break;
                    case "3": ManagerMenu(); break;
                    case "4": StudentMenu(); break;
                    case "5": AssetMenu(); break;
                    case "6": ReportsMenu(); break;
                    case "7":
                        Console.WriteLine("Khoroj az barname...");
                        return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region Dormitory Management
        static void DormitoryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Modiriat Khabgah ==");
                Console.WriteLine("1. Ezafe kardan Khabgah");
                Console.WriteLine("2. Virayesh Khabgah");
                Console.WriteLine("3. Hazf Khabgah");
                Console.WriteLine("4. List Khabgah ha");
                Console.WriteLine("5. Bargasht be menu asli");
                Console.Write("Yek gozine ra entekhab konid: ");

                switch (Console.ReadLine())
                {
                    case "1": AddDormitory(); break;
                    case "2": EditDormitory(); break;
                    case "3": DeleteDormitory(); break;
                    case "4": ListDormitories(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddDormitory()
        {
            Console.Write("Name khabgah ra vared konid: ");
            string name = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                dormitories.Add(name);
                Console.WriteLine("Khabgah ezafe shod.");
            }
            else
                Console.WriteLine("Name nemitavanad khali bashad.");
            Pause();
        }
        static void EditDormitory()
        {
            if (dormitories.Count == 0)
            {
                Console.WriteLine("Hich khabgahi baraye virayesh vojood nadarad.");
                Pause();
                return;
            }
            ListDormitories();
            Console.Write("Shomare khabgah baraye virayesh ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= dormitories.Count)
            {
                Console.Write("Name jadid ra vared konid: ");
                string newName = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(newName))
                {
                    dormitories[idx - 1] = newName;
                    Console.WriteLine("Khabgah be rooz shod.");
                }
                else
                    Console.WriteLine("Name nemitavanad khali bashad.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }
        static void DeleteDormitory()
        {
            if (dormitories.Count == 0)
            {
                Console.WriteLine("Hich khabgahi baraye hazf vojood nadarad.");
                Pause();
                return;
            }
            ListDormitories();
            Console.Write("Shomare khabgah baraye hazf ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= dormitories.Count)
            {
                string removed = dormitories[idx - 1];
                dormitories.RemoveAt(idx - 1);
                Console.WriteLine($"Khabgah '{removed}' hazf shod.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }
        static void ListDormitories()
        {
            Console.WriteLine("Khabgah ha:");
            if (dormitories.Count == 0) Console.WriteLine("Hich khabgahi vojood nadarad.");
            else
                for (int i = 0; i < dormitories.Count; i++)
                    Console.WriteLine($"{i + 1}. {dormitories[i]}");
            Pause();
        }
        #endregion

        #region Block Management
        class Block
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        static void BlockMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Modiriat Block ==");
                Console.WriteLine("1. Ezafe kardan Block");
                Console.WriteLine("2. Virayesh Block");
                Console.WriteLine("3. Hazf Block");
                Console.WriteLine("4. List Block ha");
                Console.WriteLine("5. Bargasht be menu asli");
                Console.Write("Yek gozine ra entekhab konid: ");

                switch (Console.ReadLine())
                {
                    case "1": AddBlock(); break;
                    case "2": EditBlock(); break;
                    case "3": DeleteBlock(); break;
                    case "4": ListBlocks(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void AddBlock()
        {
            Console.Write("Name Block ra vared konid: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Tozih Block ra vared konid: ");
            string desc = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                blocks.Add(new Block { Name = name, Description = desc });
                Console.WriteLine("Block ezafe shod.");
            }
            else
                Console.WriteLine("Name nemitavanad khali bashad.");
            Pause();
        }
        static void EditBlock()
        {
            if (blocks.Count == 0)
            {
                Console.WriteLine("Hich blocki baraye virayesh vojood nadarad.");
                Pause();
                return;
            }
            ListBlocks();
            Console.Write("Shomare block baraye virayesh ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= blocks.Count)
            {
                Console.Write("Name jadid ra vared konid: ");
                string newName = Console.ReadLine().Trim();
                Console.Write("Tozih jadid ra vared konid: ");
                string newDesc = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(newName))
                {
                    blocks[idx - 1].Name = newName;
                    blocks[idx - 1].Description = newDesc;
                    Console.WriteLine("Block be rooz shod.");
                }
                else
                    Console.WriteLine("Name nemitavanad khali bashad.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }
        static void DeleteBlock()
        {
            if (blocks.Count == 0)
            {
                Console.WriteLine("Hich blocki baraye hazf vojood nadarad.");
                Pause();
                return;
            }
            ListBlocks();
            Console.Write("Shomare block baraye hazf ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= blocks.Count)
            {
                string removed = blocks[idx - 1].Name;
                blocks.RemoveAt(idx - 1);
                Console.WriteLine($"Block '{removed}' hazf shod.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }
        static void ListBlocks()
        {
            Console.WriteLine("Block ha:");
            if (blocks.Count == 0) Console.WriteLine("Hich blocki vojood nadarad.");
            else
                for (int i = 0; i < blocks.Count; i++)
                    Console.WriteLine($"{i + 1}. {blocks[i].Name} - {blocks[i].Description}");
            Pause();
        }
        #endregion

        #region Manager Management
        class Person
        {
            public string Name { get; set; }
            public string Contact { get; set; }
        }

        static void ManagerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Modiriat Masool Khabgah ==");
                Console.WriteLine("1. Ezafe kardan Masool");
                Console.WriteLine("2. Virayesh Masool");
                Console.WriteLine("3. Hazf Masool");
                Console.WriteLine("4. List Masool ha");
                Console.WriteLine("5. Bargasht be menu asli");
                Console.Write("Yek gozine ra entekhab konid: ");

                switch (Console.ReadLine())
                {
                    case "1": AddManager(); break;
                    case "2": EditManager(); break;
                    case "3": DeleteManager(); break;
                    case "4": ListManagers(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddManager()
        {
            Console.Write("Name Masool ra vared konid: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Tamas ra vared konid: ");
            string contact = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(name))
            {
                managers.Add(new Person { Name = name, Contact = contact });
                Console.WriteLine("Masool ezafe shod.");
            }
            else
                Console.WriteLine("Name nemitavanad khali bashad.");
            Pause();
        }

        static void EditManager()
        {
            if (managers.Count == 0)
            {
                Console.WriteLine("Hich masooli baraye virayesh vojood nadarad.");
                Pause();
                return;
            }
            ListManagers();
            Console.Write("Shomare masool baraye virayesh ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= managers.Count)
            {
                Console.Write("Name jadid ra vared konid: ");
                string newName = Console.ReadLine().Trim();
                Console.Write("Tamas jadid ra vared konid: ");
                string newContact = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(newName))
                {
                    managers[idx - 1].Name = newName;
                    managers[idx - 1].Contact = newContact;
                    Console.WriteLine("Masool be rooz shod.");
                }
                else
                    Console.WriteLine("Name nemitavanad khali bashad.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }

        static void DeleteManager()
        {
            if (managers.Count == 0)
            {
                Console.WriteLine("Hich masooli baraye hazf vojood nadarad.");
                Pause();
                return;
            }
            ListManagers();
            Console.Write("Shomare masool baraye hazf ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= managers.Count)
            {
                string removed = managers[idx - 1].Name;
                managers.RemoveAt(idx - 1);
                Console.WriteLine($"Masool '{removed}' hazf shod.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }

        static void ListManagers()
        {
            Console.WriteLine("Masool ha:");
            if (managers.Count == 0) Console.WriteLine("Hich masooli vojood nadarad.");
            else
                for (int i = 0; i < managers.Count; i++)
                    Console.WriteLine($"{i + 1}. {managers[i].Name} - Contact: {managers[i].Contact}");
            Pause();
        }
        #endregion

        #region Student Management
        class Student
        {
            public string Name { get; set; }
            public string Dormitory { get; set; }
        }

        static void StudentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Modiriat Daneshjo ==");
                Console.WriteLine("1. Ezafe kardan Daneshjo");
                Console.WriteLine("2. Hazf Daneshjo");
                Console.WriteLine("3. Jostojo Daneshjo bar asas Name");
                Console.WriteLine("4. Moshahede Etelaat Kamel Daneshjo");
                Console.WriteLine("5. Sabt Name Daneshjo dar Khabgah");
                Console.WriteLine("6. Jabe Jayi Daneshjo be Khabgah Digar");
                Console.WriteLine("7. Bargasht be menu asli");
                Console.Write("Yek gozine ra entekhab konid: ");

                switch (Console.ReadLine())
                {
                    case "1": AddStudent(); break;
                    case "2": DeleteStudent(); break;
                    case "3": SearchStudent(); break;
                    case "4": ViewStudentDetails(); break;
                    case "5": RegisterStudentDormitory(); break;
                    case "6": TransferStudent(); break;
                    case "7": return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Name Daneshjo ra vared konid: ");
            string name = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                students.Add(new Student { Name = name, Dormitory = "" });
                Console.WriteLine("Daneshjo ezafe shod.");
            }
            else
                Console.WriteLine("Name nemitavanad khali bashad.");
            Pause();
        }

        static void DeleteStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Hich daneshjoyi baraye hazf vojood nadarad.");
                Pause();
                return;
            }
            ListStudents();
            Console.Write("Shomare daneshjo baraye hazf ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= students.Count)
            {
                string removed = students[idx - 1].Name;
                students.RemoveAt(idx - 1);
                Console.WriteLine($"Daneshjo '{removed}' hazf shod.");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }

        static void SearchStudent()
        {
            Console.Write("Name baraye jostojo ra vared konid: ");
            string searchName = Console.ReadLine().Trim().ToLower();
            var found = students.FindAll(s => s.Name.ToLower().Contains(searchName));
            if (found.Count == 0)
                Console.WriteLine("Daneshjoyi peyda nashod.");
            else
            {
                Console.WriteLine("Natayej jostojo:");
                for (int i = 0; i < found.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {found[i].Name}");
                }
            }
            Pause();
        }

        static void ViewStudentDetails()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Hich daneshjoyi vojood nadarad.");
                Pause();
                return;
            }
            ListStudents();
            Console.Write("Shomare daneshjo baraye moshahede etelaat ra vared konid: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= students.Count)
            {
                Student s = students[idx - 1];
                Console.WriteLine($"Name: {s.Name}");
                Console.WriteLine($"Khabgah: {(string.IsNullOrEmpty(s.Dormitory) ? "Ta'en nashode" : s.Dormitory)}");
            }
            else
                Console.WriteLine("Shomare ghalat ast.");
            Pause();
        }

        static void RegisterStudentDormitory()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Hich daneshjoyi baraye sabt name vojood nadarad.");
                Pause();
                return;
            }
            if (dormitories.Count == 0)
            {
                Console.WriteLine("Hich khabgahi vojood nadarad.");
                Pause();
                return;
            }
            ListStudents();
            Console.Write("Shomare daneshjo baraye sabt name ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int sIdx) || sIdx <= 0 || sIdx > students.Count)
            {
                Console.WriteLine("Shomare daneshjo ghalat ast.");
                Pause();
                return;
            }
            ListDormitories();
            Console.Write("Shomare khabgah baraye ta'en ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int dIdx) || dIdx <= 0 || dIdx > dormitories.Count)
            {
                Console.WriteLine("Shomare khabgah ghalat ast.");
                Pause();
                return;
            }
            students[sIdx - 1].Dormitory = dormitories[dIdx - 1];
            Console.WriteLine($"Daneshjo '{students[sIdx - 1].Name}' dar khabgah '{dormitories[dIdx - 1]}' sabt name shod.");
            Pause();
        }

        static void TransferStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Hich daneshjoyi baraye jabe jai vojood nadarad.");
                Pause();
                return;
            }
            ListStudents();
            Console.Write("Shomare daneshjo baraye jabe jai ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int sIdx) || sIdx <= 0 || sIdx > students.Count)
            {
                Console.WriteLine("Shomare daneshjo ghalat ast.");
                Pause();
                return;
            }
            ListDormitories();
            Console.Write("Shomare khabgah jadid ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int dIdx) || dIdx <= 0 || dIdx > dormitories.Count)
            {
                Console.WriteLine("Shomare khabgah ghalat ast.");
                Pause();
                return;
            }
            students[sIdx - 1].Dormitory = dormitories[dIdx - 1];
            Console.WriteLine($"Daneshjo '{students[sIdx - 1].Name}' be khabgah '{dormitories[dIdx - 1]}' enteghal yaft.");
            Pause();
        }

        static void ListStudents()
        {
            Console.WriteLine("Daneshjo ha:");
            if (students.Count == 0) Console.WriteLine("Hich daneshjoyi vojood nadarad.");
            else
                for (int i = 0; i < students.Count; i++)
                    Console.WriteLine($"{i + 1}. {students[i].Name} - Khabgah: {(string.IsNullOrEmpty(students[i].Dormitory) ? "Ta'en nashode" : students[i].Dormitory)}");
        }
        #endregion

        #region Asset Management
        class Asset
        {
            public string Name { get; set; }
            public string Section { get; set; }
            public string Location { get; set; }
        }

        static void AssetMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Modiriat Amval ==");
                Console.WriteLine("1. Sabt Amval Jadid");
                Console.WriteLine("2. Jabe jai Amval");
                Console.WriteLine("3. List Amval");
                Console.WriteLine("4. Bargasht be menu asli");
                Console.Write("Yek gozine ra entekhab konid: ");

                switch (Console.ReadLine())
                {
                    case "1": AddAsset(); break;
                    case "2": TransferAsset(); break;
                    case "3": ListAssets(); break;
                    case "4": return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddAsset()
        {
            Console.Write("Name Amval ra vared konid: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Bakhsh Amval ra vared konid: ");
            string section = Console.ReadLine().Trim();
            Console.Write("Makan فعلی Amval ra vared konid: ");
            string location = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(name))
            {
                assets.Add(new Asset { Name = name, Section = section, Location = location });
                Console.WriteLine("Amval sabt shod.");
            }
            else
                Console.WriteLine("Name nemitavanad khali bashad.");
            Pause();
        }

        static void TransferAsset()
        {
            if (assets.Count == 0)
            {
                Console.WriteLine("Hich amvali baraye jabe jai vojood nadarad.");
                Pause();
                return;
            }
            ListAssets();
            Console.Write("Shomare amval baraye jabe jai ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int idx) || idx <= 0 || idx > assets.Count)
            {
                Console.WriteLine("Shomare ghalat ast.");
                Pause();
                return;
            }
            Console.Write("Makan jadid ra vared konid: ");
            string newLocation = Console.ReadLine().Trim();
            assets[idx - 1].Location = newLocation;
            Console.WriteLine($"Amval '{assets[idx - 1].Name}' be makan '{newLocation}' enteghal yaft.");
            Pause();
        }

        static void ListAssets()
        {
            Console.WriteLine("Amval:");
            if (assets.Count == 0) Console.WriteLine("Hich amvali vojood nadarad.");
            else
                for (int i = 0; i < assets.Count; i++)
                    Console.WriteLine($"{i + 1}. {assets[i].Name} - Bakhsh: {assets[i].Section} - Makan: {assets[i].Location}");
            Pause();
        }
        #endregion

        #region Reports
        static void ReportsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== گزارشات ==");
                Console.WriteLine("1. List Kamel Amval");
                Console.WriteLine("2. List Daneshjo");
                Console.WriteLine("3. List Khabgah ha");
                Console.WriteLine("4. List Masoolan");
                Console.WriteLine("5. Bargasht be menu asli");
                Console.Write("Yek gozine ra entekhab konid: ");

                switch (Console.ReadLine())
                {
                    case "1": ListAssets(); break;
                    case "2": ListStudents(); break;
                    case "3": ListDormitories(); break;
                    case "4": ListManagers(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Entekhab ghalat ast. Yek kelid ra feshar dahid...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #endregion

        static void Pause()
        {
            Console.WriteLine("Baraye edame, yek kelid ra feshar dahid...");
            Console.ReadKey();
        }
    }
}

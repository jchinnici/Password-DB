using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordMngr
{
    class Program
    {
        
        static Dictionary<int, Record> database = new Dictionary<int, Record>();
        [STAThread]
        static void Main(string[] args)
        {
            Copy(1);
            var currentFileData = File.ReadAllText("database.txt");
            LoadDataBase(currentFileData);
            while (true)
            {
                Thread.Sleep(50);
                var record = new Record();
                Console.WriteLine("Type and enter 'Add', 'List' or 'Delete'");
                var input = Console.ReadLine();
                input = input.ToLower();
                if (input == "add")
                    AddRecord();
                else if (input == "list")
                    ListRecordByName();
                else if (input == "delete")
                     RemoveRecord();

                

            }
        }
        static void ListRecordByName()
        {
            Console.WriteLine(File.ReadAllText("database.txt"));
        }

        static void Copy(int id)
        {
            System.Windows.Forms.Clipboard.SetText("Penis");//can only paste penis copy the id 
        }
        //pass what you read from file and load it in the dictionary
        static void LoadDataBase(string text)
        {//text.Split(",")
            var lines = text.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                var details = line.Split(',');
                var newRecord = new Record();
                newRecord.Id = Int32.Parse(details[0]);
                newRecord.Name = details[1];
                newRecord.Password = details[2];
                newRecord.Tags = details[3].Split('|').ToList();
                database.Add(newRecord.Id, newRecord);
            }

        }

        private static void ToList()
        {
            throw new NotImplementedException();
        }

        static void AddRecord()
        {
            var record = new Record();
            Console.Write("Name: ");
            record.Name = Console.ReadLine();

            Console.Write("Password: ");
            record.Password = Console.ReadLine();

            

            int currentMaximumID = database.Max(x => x.Key);//takes largest id and creates new one in next number
            record.Id = currentMaximumID + 1;
            database.Add(record.Id, record);
            Savedatabase();
        }

        static void RemoveRecord()
        {
            
            Console.Write("ID num: ");
            database.Remove(Int32.Parse(Console.ReadLine()));
                Savedatabase();
        }

        static void Savedatabase()
        {
            string allTextinDB = "";
            foreach (var record in database)
                allTextinDB = allTextinDB + record.Value + Environment.NewLine;//Environment.NewLine same thing as \n
            File.WriteAllText("database.txt", allTextinDB);
        }
    } 
}

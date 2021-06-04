using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorkWFiles
{
    class Parser
    {
        // id name surname age regdate
        private string FileName { get; set; } // Pascal Style

        public Parser(string fileName = @"parse.txt")
        {
            FileName = fileName;
        }

        public void Write(int id, string name, string surname, int age, string regDate)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                string template = $"{id}|{name}|{surname}|{age}|{regDate}\n";
                byte[] buffer = Encoding.Default.GetBytes(template);
                fs.Seek(0, SeekOrigin.End);
                fs.Write(buffer, 0, buffer.Length);
            }
        }
        public void Write(UserModel obj)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(obj.ToString());
                fs.Seek(0, SeekOrigin.End);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public string[] Read()
        {
            StringBuilder builder = new StringBuilder();

            using(FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                byte[] buffer = new byte[2048];
                int count = 0;
                while ((count = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    builder.Append(Encoding.Default.GetString(buffer, 0, count));
                }
            }

            return builder.ToString().Split('\n');
        }

        public UserModel[] ReadModel()
        {
            string[] res = Read();
            List<UserModel> buffer = new List<UserModel>();
            foreach (string user in res)
            {
                if (string.IsNullOrEmpty(user)) continue;
                buffer.Add(UserModel.Parse(user));
            }

            return buffer.ToArray();
        }

        public string GetUser(int id)
        {
            string[] res = Read();

            for (int i = 0; i < res.Length; i++)
            {
                string[] temp = res[i].Split('|');
                if (int.Parse(temp[0]) == id) return res[i];
            }

            return null;
        }

        public UserModel GetUserModel(int id)
        {
            UserModel[] res = ReadModel();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Id == id) return res[i];
            }

            return null;
        }

        public int GetFreeId
        {
            get
            {
                UserModel[] res = ReadModel();
                if (res.Length == 0) return 1;
                return res[res.Length - 1].Id + 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WorkWFiles.Exceptions;

namespace WorkWFiles
{
    class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime RegDate { get; set; } 

        public override string ToString()
        {
            return $"{Id}|{Name}|{Surname}|{Age}|{RegDate}\n";
        }

        public static UserModel Parse(string sample)
        {
            UserModelParseException ex = new UserModelParseException("Not UserModel string was found");

            if (!sample.Contains('|')) throw ex;
            UserModel temp = new UserModel();
            string[] buffer = sample.Split('|');
            if (buffer.Length != 5) throw ex;

            temp.Id = int.Parse(buffer[0]);
            temp.Name = buffer[1];
            temp.Surname = buffer[2];
            temp.Age = int.Parse(buffer[3]);
            temp.RegDate = DateTime.Parse(buffer[4]);

            return temp;
        }
    }
}

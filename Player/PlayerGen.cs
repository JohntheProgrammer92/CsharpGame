using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class PlayerGen
    {
        private string _fName;
        private string _lName;
        private string _hist;
        private int _lvl;
        private int _hp;
        private int _atk;
        private int _def;

        

        public PlayerGen(int l = 5)
        {
            _fName = fNameGen();
            _lName = lNameGen();
            _hist = histGen();
            _lvl = l;
            _hp = 10 * l;
            _atk = 5 * l;
            _def = 4 * l;
            
        }

        public string fNameGen()
        {
            string[] options = System.IO.File.ReadAllLines(@"c:\users\lance\source\repos\Player\firstNames.txt");
            string name = options[StaticRandom.Instance.Next(1, options.Length+1)];
            return name;
        }
        public string lNameGen()
        {
            string[] options = System.IO.File.ReadAllLines(@"c:\users\lance\source\repos\Player\surnames.txt");
            string name = options[StaticRandom.Instance.Next(1, options.Length + 1)];
            return name;
        }
        public string histGen()
        {
            string[] city = System.IO.File.ReadAllLines(@"c:\users\lance\source\repos\Player\city.txt");
            string[] title = System.IO.File.ReadAllLines(@"c:\users\lance\source\repos\Player\title.txt");
            string history = "You are a "+ title[StaticRandom.Instance.Next(1, title.Length + 1)]+" from the city of "+ city[StaticRandom.Instance.Next(1, city.Length + 1)];
            return history;
        }
        public override string ToString()
        {
            string returnString = "";
            returnString += "First name: " + _fName + Environment.NewLine;
            returnString += "Last name: " + _lName + Environment.NewLine;
            returnString += "Level: " + _lvl + Environment.NewLine;
            returnString += "Helath points: " + _hp + Environment.NewLine;
            returnString += "Attack: " + _atk + Environment.NewLine;
            returnString += "Defense: " + _def + Environment.NewLine;
            returnString += "History: " + _hist + Environment.NewLine;
            return returnString;
        }


    }
}

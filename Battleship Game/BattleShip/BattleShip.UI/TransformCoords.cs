using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class TransformCoords
    {
        Dictionary<char,int> converter = new Dictionary<char, int>();
        private string a,b;
        private int x=0;

        //initializing dictionary
        public void InitializeDictionary()
        {
            
        }
        
    public int Conversion(string str,out int num)
        {
            // initializing the dictionary
            char c = 'a';
            for (int i = 1; i < 11; i++)
            {
                converter.Add(c, i);
                c++;
            }

            num = 0;

            //validate string input and converts "{letter}{number}" format into two seperate numbers
            if (!string.IsNullOrEmpty(str))
            {
                a = str.Substring(0, 1).ToLower();
                b = str.Substring(1);       


                //converts second part of string to in
                bool t = (int.TryParse(b, out num));

                //checking string against dictionary
                foreach (var key in converter.Keys)
                {
                    if (key.ToString() == a)
                        x = converter[key];
                }
            }            
            return x;
        }
    }
}

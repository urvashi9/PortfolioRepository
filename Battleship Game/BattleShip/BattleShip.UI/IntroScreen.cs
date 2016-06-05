using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class IntroScreen
    {
        public void IntroscreenBattle()
        {
            //fun stuff
            int count = 0;
            List<string> strList = new List<string>();
            strList.Add("");
            for (int i = 0; i < Console.WindowWidth-101; i++)
            {
                strList[0] = strList[0] + " ";
                count++;
                Thread.Sleep(50);
                Console.Clear();
                Console.Write(
                    $@"                                                                                                    
{strList[0]}                                  .'                                                                
{strList[0]}                                  ;c                       .;.                                      
{strList[0]}                                 .do                .;'  ..lXk,.                                    
{strList[0]}                                 '0o        ;dl.   .xMk. .cOWXd'                                    
{strList[0]}                                 lWo        dMX;   .xMk.  cXNNk.......                              
{strList[0]}              .'.        .,lololckX:       .dMX;   .kMk.  cNXXx.:KXKKO; .;;;,,.....;,.              
{strList[0]}             .....cooddc. cNWMWKxkk:...;dxxkKMW0xxxkXMXkxx0WWW0,:XMMMK; ,0WWWNx,..''..              
{strList[0]}  .''''''',',;;;;c0MMMM0c;dNMWXkk0KXKKKNMMMMMMMMMMMMMMMMMMMMMMWKKWMMMWKO0NMMMWXOOOOOOO00O00O00OOl.  
{strList[0]} .oXWNNWNWWWWWWWWWWMMMMMMMMMMMNKXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWk.   
{strList[0]}  .:xKNWMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMWx.    
{strList[0]}     .,cloooooooooooooooocloooooooooooooooooooolcloooooooooooooooooooolclooooooooooooooooooooc.     ");

                
            }
            string str1 =
                "                                  .'                                                                ";
            string str2 =
                "                                  ;c                       .;.                                      ";
            string str3 =
                "                                 .do                .;'  ..lXk,.                                    ";
            string str4 =
                "                                 '0o        ;dl.   .xMk. .cOWXd'                                    ";
            string str5 =
                "                                 lWo        dMX;   .xMk.  cXNNk.......                              ";
            string str7 =
                "              .'.        .,lololckX:       .dMX;   .kMk.  cNXXx.:KXKKO; .;;;,,.....;,.              ";
            string str8 =
                "             .....cooddc. cNWMWKxkk:...;dxxkKMW0xxxkXMXkxx0WWW0,:XMMMK; ,0WWWNx,..''..              ";
            string str9 =
                "  .''''''',',;;;;c0MMMM0c;dNMWXkk0KXKKKNMMMMMMMMMMMMMMMMMMMMMMWKKWMMMWKO0NMMMWXOOOOOOO00O00O00OOl.  ";
            string str10 =
                " .oXWNNWNWWWWWWWWWWMMMMMMMMMMMNKXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWk.   ";
            string str11 =
                "  .:xKNWMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMWx.    ";
            string str12 =
                "     .,cloooooooooooooooocloooooooooooooooooooolcloooooooooooooooooooolclooooooooooooooooooooc.     ";
            for (int i = 0; i < Console.WindowWidth - 68 && i <= str1.Length; i++)
            {
                strList[0] = strList[0] + " ";
                count++;
                Thread.Sleep(50);
                Console.Clear();
                Console.Write(
                    $@"
{strList[0]}{str1.Substring(0,str1.Length - i)}{strList[0]}{str2.Substring(0,str2.Length - i)}{strList[0]}{str3.Substring(0,str3.Length - i)}{strList[0]}{str4.Substring(0,str4.Length - i)}{strList[0]}{str5.Substring(0,str5.Length - i)}{strList[0]}{str7.Substring(0,str7.Length - i)}{strList[0]}{str8.Substring(0,str8.Length - i)}{strList[0]}{str9.Substring(0,str9.Length - i)}{strList[0]}{str10.Substring(0,str10.Length - i)}{strList[0]}{str11.Substring(0,str11.Length - i)}{strList[0]}{str12.Substring(0, str12.Length - i)}");
            }
            
        }
    }
}

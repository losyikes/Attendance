using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceClient.ServiceReference1;
using AttendanceClient.ServiceReference2;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;


namespace AttendanceClient
{
    class ClientMain
    {
        bool fakeUserChosen = false;
        UserAdressInfo userAdress = new UserAdressInfo();
        AttendanceToolsClient toolClient = new AttendanceToolsClient();
        Screen screen = new Screen();
        static void Main(string[] args)
        {
            ClientMain cm = new ClientMain();
            cm.Run();
            //EchoServiceClient client = new EchoServiceClient();
            
            //Console.WriteLine(client.EchoString("hello world"));
            
        }
        void Run()
        {
            
            bool keepGoing = true;
            bool keepMenuLevelGoing = true;
            int choice;
            string input = "";
            int menuLevel = 1;
            chooseFakeUserMenu();
            toolClient.LoginUser(userAdress.GetMacAddresse(), userAdress.GetLocalIPAddress());
            while (keepMenuLevelGoing)
            {
                menuLevel = toolClient.GetMenuLevel();
                screen.Clear();
                if(menuLevel == 0)
                {
                    keepMenuLevelGoing = false;
                }
                else if(menuLevel == 1)
                {
                   screen.PrintLine(toolClient.ShowStartMenu());
                }
                else if(menuLevel == 2)
                {
                    if (toolClient.GetCurrentUserTypeString() == "AttendanceLib.Teacher")
                    {
                        while (keepGoing == true)
                        {
                            if (int.TryParse(input, out choice))
                            {
                                screen.PrintLine(toolClient.ShowTeacherMenuChoice(choice));
                                keepGoing = false;
                            }
                            else
                            {
                                screen.PrintLine("invalid choice try again");
                            }
                        }
                    }
                }
                input = screen.ReadLine();
                keepGoing = true;
            }
            
            
            screen.PrintLine("press enter to exit");
            Console.ReadLine();
            toolClient.Close();
        }
        void chooseFakeUserMenu()
        {
            int choice;
            while(fakeUserChosen == false)
            {
                screen.PrintLine("Choose login role");
                screen.PrintLine("1. Student");
                screen.PrintLine("2. Teacher");

                if(int.TryParse(screen.ReadLine(), out choice)){
                    if (choice == 1)
                    {
                        toolClient.CreateFakeUser("student", userAdress.GetMacAddresse());
                        fakeUserChosen = true;
                    }
                    else if (choice == 2)
                    {
                        toolClient.CreateFakeUser("teacher", userAdress.GetMacAddresse());
                        fakeUserChosen = true;
                    }
                    else
                        screen.PrintLine("invalid input");
                }
            }
            

        }
        
    }
}

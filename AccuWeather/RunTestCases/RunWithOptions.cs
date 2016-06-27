using System;
using System.Diagnostics;
using System.Threading;

namespace RunTestCases
{
    class RunWithOptions
    {
        static void Main(string[] args)
        {
            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            
                Console.WriteLine("Select some option from menu.");
                Console.WriteLine("1. Execute all test cases.");
                Console.WriteLine("2. Execute Term And Conditions Testcases.");
                Console.WriteLine("3. Execute Menu Button And Menu Options Testcases.");
                Console.WriteLine("4. Execute Add Location Testcases.");
                Console.WriteLine("5. Execute Edit Location Testcases.");
                Console.WriteLine("6. Write command manually.");

                string option = Console.ReadLine();

                Process nunit3Console = new Process();
                nunit3Console.StartInfo.FileName = "nunit3-console.exe";
                if (option.ToLower().Equals("1"))
                {
                    nunit3Console.StartInfo.Arguments = "AccuWeather.dll --where \"class == AccuWeather.TestAddLocation || class == AccuWeather.TestEditLocation || class == AccuWeather.TestMenuButtonAndMenuOptions || class == AccuWeather.TestTermsConditions\" --work=\"Reports" + @"\" + timeStamp + "\" --wait";

                }
                else if (option.ToLower().Equals("2"))
                {
                    nunit3Console.StartInfo.Arguments = "AccuWeather.dll --where \"cat == TermsAndConditions\" --work=\"Reports" + @"\" + timeStamp + "\" --wait";
            }
                else if (option.ToLower().Equals("3"))
                {
                    nunit3Console.StartInfo.Arguments = "AccuWeather.dll --where \"cat == MenuButtonAndOptions\" --work=\"Reports" + @"\" + timeStamp + "\" --wait";
            }
                else if (option.ToLower().Equals("4"))
                {
                    nunit3Console.StartInfo.Arguments = "AccuWeather.dll --where \"cat == AddLocation\" --work=\"Reports" + @"\" + timeStamp + "\" --wait";
            }
                else if (option.ToLower().Equals("5"))
                {
                    nunit3Console.StartInfo.Arguments = "AccuWeather.dll --where \"cat == EditLocation\" --work=\"Reports" + @"\" + timeStamp + "\" --wait";
            }
                
                else if (option.ToLower().Equals("6"))
                {
                    Console.WriteLine("Write the arguments of nunit3-console manually. For example AccuWeather.dll --where \"cat == EditLocation\" --work=\"Reports" + "\"");
                    string parameterNubit3 = Console.ReadLine();
                    nunit3Console.StartInfo.Arguments = parameterNubit3;
                }
                nunit3Console.Start();
                nunit3Console.WaitForExit();
                nunit3Console.Close();
                Thread.Sleep(6000);
                Process reportProcess = new Process();
                reportProcess.StartInfo.FileName = "ReportUnit.exe";

                if (option.ToLower().Equals("6") == false)
                {
                    reportProcess.StartInfo.Arguments = @"Reports\" + timeStamp + @"\TestResult.xml";
                }
                else
                {
                    Console.WriteLine("Write the arguments of ReportUnit.exe manually. For example " + @"Reports\" + timeStamp + @"\TestResult.xml");
                    string parameterReport = Console.ReadLine();
                    nunit3Console.StartInfo.Arguments = parameterReport;
                }
                reportProcess.Start();
                reportProcess.WaitForExit();
                reportProcess.Close();
            
        }
    }
}

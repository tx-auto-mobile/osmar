using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadCsvFiles
{
    public class ReadCsvs
    {
        private static string capabilitiesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\Configurations\Capabilities.csv";
        private static string appiumConfiguration = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\Configurations\AppiumConfiguration.csv";
        private static string sauceLabsConfiguration = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\Configurations\SauceLabsConfiguration.csv";


        private static string addLocationScreen = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\AndroidComponentsByScreen\AddLocationScreen.csv";
        private static string editLocationScreen = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\AndroidComponentsByScreen\EditLocationScreen.csv";
        private static string menuOptionsScreen = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\AndroidComponentsByScreen\MenuOptionsScreen.csv";
        private static string termAndConditionsScreen = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\AndroidComponentsByScreen\TermAndConditionsScreen.csv";

        private static string androidActivities = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CsvFiles\AndroidActivities\Activities.csv";


        //@"C:\Users\osmar.garcia\Documents\Visual Studio 2015\Projects\AccuWeather\ReadCsvFiles\CsvFiles\Capabilities.csv";






        //read CSV data
        private List<string> readData(string path, int fila_start)
        {
            List<string> parsedData = new List<string>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;
                int cont = 0;

                while ((line = readFile.ReadLine()) != null)
                {
                    if (cont == fila_start) {
                        row = line.Split(',');
                        for (int i = 0; i < row.Length; i++)
                        {
                            parsedData.Add(row[i]);
                        }
                    }

                    if (cont == fila_start)
                    {
                        cont++;
                        fila_start++;

                    }
                    else
                    {
                        cont++;
                    }
                    
                }
            }
            return parsedData;
        }

        public List<string> readCapabilities()
        {
            return readData(capabilitiesPath, 1);
        }
        public List<string> readAppiumConfiguration()
        {
            return readData(appiumConfiguration, 1);
        }
        public List<string> readSauceLabsConfiguration()
        {
            return readData(sauceLabsConfiguration, 1);
        }
        
        public Dictionary<string, Dictionary<string, string>> read_android_components(string screenToRead)
        {
            Dictionary<string, string> id_components = new Dictionary<string, string>();
            Dictionary<string, string> class_components = new Dictionary<string, string>();
            Dictionary<string, string> xpath_components = new Dictionary<string, string>();

            List<string> readDataScreen = new List<string>();
            if (screenToRead.ToLower().Equals("addLocationScreen".ToLower()))
            {
                readDataScreen = readData(addLocationScreen, 1);
            }
            else if (screenToRead.ToLower().Equals("editLocationScreen".ToLower()))
            {
                readDataScreen = readData(editLocationScreen, 1);
            }
            else if (screenToRead.ToLower().Equals("menuOptionsScreen".ToLower()))
            {
                readDataScreen = readData(menuOptionsScreen, 1);
            }
            else if (screenToRead.ToLower().Equals("termAndConditionsScreen".ToLower()))
            {
                readDataScreen = readData(termAndConditionsScreen, 1);
            }

            

            for(int i=0; i< readDataScreen.Count; i = i+4)
            {
                id_components.Add(readDataScreen[i], readDataScreen[i+1]);
                class_components.Add(readDataScreen[i], readDataScreen[i + 2]);
                xpath_components.Add(readDataScreen[i], readDataScreen[i + 3]);
                
            }
            Dictionary<string, Dictionary<string, string>> resp = new Dictionary<string, Dictionary<string, string>>();
            resp.Add("ids", id_components);
            resp.Add("classes", class_components);
            resp.Add("xpaths", xpath_components);

            return resp;

        }

        public Dictionary<string, string> read_android_activities()
        {
            Dictionary<string, string> resp = new Dictionary<string, string>();
            List<string> readDataScreen = new List<string>();
            readDataScreen = readData(androidActivities, 1);
            for (int i=0; i < readDataScreen.Count; i=i+2)
            {
                resp.Add(readDataScreen[i], readDataScreen[i + 1]);
            }

            return resp;
        }


        static void Main() {
            ReadCsvs x = new ReadCsvs();
            List<string> parsedData = x.readData(capabilitiesPath, 1);
            for (int i= 0; i < parsedData.Count; i++)
            {
                System.Console.WriteLine(parsedData[i]);
            }
        }

    }

   




}

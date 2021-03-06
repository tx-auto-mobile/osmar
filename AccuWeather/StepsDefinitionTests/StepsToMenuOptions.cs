﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using ReadCsvFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsDefinitionTests
{
    public class StepsToMenuOptions
    {
        AppiumDriver<IWebElement> driver;
        ReadCsvs read_data;

        string menu_pane_id;// = "com.accuweather.android:id/drawer";

        string menu_button_xpath;// = "//android.view.View[@resource-id='com.accuweather.android:id/tool_bar']//android.widget.ImageButton[@index=0]";

        string menu_options_list_id;// = "com.accuweather.android:id/location_list";
        string menu_options_edit_icon_id;// = "com.accuweather.android:id/edit_icon";
        string menu_options_edit_label_id;// = "com.accuweather.android:id/location_edit_text";
        string menu_options_add_icon_id;//= "com.accuweather.android:id/add_icon";
        string menu_options_add_label_id;// = "com.accuweather.android:id/location_add_text";

        string list_location_id;// = "com.accuweather.android:id/current_conditions_ripple";
        string list_selection_bar_id;// = "com.accuweather.android:id/selection_bar";

        string tool_bar_id;// = "com.accuweather.android:id/tool_bar";
        string menu_button_class;// = "android.widget.ImageButton";


        string list_location_name_id;// = "com.accuweather.android:id/location_name";
        string list_location_whether_icon_id;// = "com.accuweather.android:id/weather_icon";
        string list_location_temp_id;// = "com.accuweather.android:id/current_temp";

       


        public StepsToMenuOptions(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            read_data = new ReadCsvs();

            Dictionary<string, Dictionary<string, string>> screenComponents = read_data.read_android_components("menuOptionsScreen");

            this.menu_pane_id = screenComponents["ids"]["menuPane"];

            this.menu_button_xpath = screenComponents["xpaths"]["menuButton"];

            this.menu_options_list_id = screenComponents["ids"]["menuOptionsList"];
            this.menu_options_edit_icon_id = screenComponents["ids"]["editIcon"];
            this.menu_options_edit_label_id = screenComponents["ids"]["editLabel"];
            this.menu_options_add_icon_id = screenComponents["ids"]["addIcon"];
            this.menu_options_add_label_id = screenComponents["ids"]["addLabel"];

            this.list_location_id = screenComponents["ids"]["location"];
            this.list_selection_bar_id = screenComponents["ids"]["selectionBar"];

            this.tool_bar_id = screenComponents["ids"]["toolBar"];
            this.menu_button_class = screenComponents["classes"]["menuButton"];


            this.list_location_name_id = screenComponents["ids"]["locationName"];
            this.list_location_whether_icon_id = screenComponents["ids"]["locationWhetherIcon"];
            this.list_location_temp_id = screenComponents["ids"]["locationTemp"];
        }

        public bool verify_menu_displayed()
        {
            try
            {
               return driver.FindElementById(menu_pane_id).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void click_back_android_button()
        {
            driver.Navigate().Back();
        }

        public bool verify_element_displayed_tool_bar_by_class(string element)
        {
            string path_element = element.ToLower().Equals("menu") ? menu_button_class
                             : "";
            try
            {
                return driver.FindElementById(tool_bar_id).FindElement(By.ClassName(menu_button_class)).Displayed;
            }
            catch
            {

                return false;
            }
        }

        public bool verify_element_displayed_localization_by_path(string element)
        {
            string path_element = element.ToLower().Equals("menu") ? menu_button_xpath
                             : "";
            try
            {
                return driver.FindElement(By.XPath(path_element)).Displayed;
            }
            catch
            {

                return false;
            }
        }



        public bool verify_element_displayed_menu_by_id(string element)
        {
            string id_element = element.ToLower().Equals("list") ? menu_options_list_id
                             : element.ToLower().Equals("addicon") ? menu_options_add_icon_id
                             : element.ToLower().Equals("addlabel") ? menu_options_add_label_id
                             : element.ToLower().Equals("editicon") ? menu_options_edit_icon_id
                             : menu_options_edit_label_id;

            try
            {
                return driver.FindElementById(id_element).Displayed;
            }
            catch
            {
                return false;
            }
        }
        public string get_element_text_menu_by_id(string element)
        {
            string id_element = element.ToLower().Equals("list") ? menu_options_list_id
                             : element.ToLower().Equals("addicon") ? menu_options_add_icon_id
                             : element.ToLower().Equals("addlabel") ? menu_options_add_label_id
                             : element.ToLower().Equals("editicon") ? menu_options_edit_icon_id
                             : menu_options_edit_label_id;

            try
            {
                return driver.FindElementById(id_element).GetAttribute("text").ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool click_menu_button_by_class()
        {
            try
            {
                if (verify_element_displayed_tool_bar_by_class(menu_button_xpath))
                {
                    driver.FindElementById(tool_bar_id).FindElement(By.ClassName(menu_button_class)).Click();
                    return true;
                }
                else
                    return false;
                
                
            }
            catch
            {
                return false;
            }


        }

        public bool touch_outside_element_by_id()
        {
            try
            {
                ITouchAction touch = new TouchAction(driver).Tap(driver.FindElementById(menu_pane_id).Size.Width + 1, (int)(driver.FindElementById(menu_pane_id).Size.Height / 2));
                touch.Perform();
                return true;


            }
            catch
            {
                return false;
            }


        }

        public bool click_add_location_button_by_id()
        {
            try
            {
                if (verify_element_displayed_menu_by_id("addIcon"))
                {
                    driver.FindElement(By.Id(menu_options_add_icon_id)).Click();
                    return true;
                }
                else if (verify_element_displayed_menu_by_id("addLabel"))
                {
                    driver.FindElement(By.Id(menu_options_add_label_id)).Click();
                    return true;
                }
                else
                    return false;


            }
            catch
            {
                return false;
            }


        }

        public bool click_edit_location_button_by_id()
        {
            try
            {
                if (verify_element_displayed_menu_by_id("editIcon"))
                {
                    driver.FindElement(By.Id(menu_options_edit_icon_id)).Click();
                    return true;
                }
                else if (verify_element_displayed_menu_by_id("editLabel"))
                {
                    driver.FindElement(By.Id(menu_options_edit_label_id)).Click();
                    return true;
                }
                else
                    return false;


            }
            catch
            {
                return false;
            }


        }

        public int get_amount_of_elements_location_list_by_id()
        {
            try
            {
                IList<IWebElement> list = driver.FindElementsById(list_location_id); 

                return list.Count;
            }
            catch
            {
                return 0;
            }
        }

        private int get_position_location_created_id()
        {

            int resp = -1;
            try
            {
                IList<IWebElement> list = driver.FindElementsById(list_location_id);
                
                for(int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        if (list[i].FindElement(By.Id(list_selection_bar_id)).Displayed)
                        {
                            resp= i;
                            break;
                        }
                    }
                    catch
                    {
                        resp = resp;
                    }
                    
                }

                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public bool menu_add_location()
        {
            bool resp = false;

            if (verify_menu_displayed() == false)
            {
                resp = click_menu_button_by_class();
            }


            resp = click_add_location_button_by_id();

            return resp;
        }

        



    }
}


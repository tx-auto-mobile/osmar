﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using ReadCsvFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsDefinitionTests
{
    public class StepsToTermsAndConditions
    {
        AppiumDriver<IWebElement> driver;
        ReadCsvs read_data;

        string title_id_term;// = "android:id/alertTitle";
        string message_id_term;// = "android:id/message";
        string agree_id_term;// = "android:id/button1";
        string disagree_id_term;// = "android:id/button2";

        string title_id_well;//= "android:id/alertTitle";
        string message_id_well;// = "android:id/message";
        string go_id_well;// = "android:id/button1";


        string element_menu;// = "com.accuweather.android:id/location_list";

        string allow_localization_id;// = "com.android.packageinstaller:id/permission_allow_button";

        static string app = "com.accuweather.android";


        public StepsToTermsAndConditions(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            read_data = new ReadCsvs();

            Dictionary<string, Dictionary<string, string>> screenComponents = read_data.read_android_components("termAndConditionsScreen");

            this.title_id_term = screenComponents["ids"]["titleTermAndConditions"];

            this.message_id_term = screenComponents["ids"]["messageTermAndConditions"];
            this.agree_id_term = screenComponents["ids"]["agreeButtonTermAndConditions"];
            this.disagree_id_term = screenComponents["ids"]["rejectButtonTermAndConditions"];

            this.title_id_well = screenComponents["ids"]["titleWellcome"];
            this.message_id_well = screenComponents["ids"]["messageWellcome"];
            this.go_id_well = screenComponents["ids"]["gobuttonWellcome"];

            this.element_menu = screenComponents["ids"]["menuLocationList"];
            this.allow_localization_id = screenComponents["ids"]["allowButtonLocalizationPermission"];

        }

        public bool verify_term_conditions_alert_displayed_by_id()
        {
            return verify_element_displayed_term_conditions_by_id(disagree_id_term);
        }

        public bool verify_element_displayed_term_conditions_by_id(string element)
        {
            string id_lement = element.ToLower().Equals("title") ? title_id_term
                             : element.ToLower().Equals("message") ? message_id_term
                             : element.ToLower().Equals("I Agree") ? agree_id_term
                             : disagree_id_term;

            try
            {
                return driver.FindElementById(id_lement).Displayed;
            }
            catch {
                return false;
            }
        }

        public string get_element_text_term_conditions_by_id(string element)
        {
            string id_lement = element.ToLower().Equals("title") ? title_id_term
                             : element.ToLower().Equals("message") ? message_id_term
                             : element.ToLower().Equals("i agree") ? agree_id_term
                             : disagree_id_term;

            try
            {
                return driver.FindElementById(id_lement).GetAttribute("text");
            }
            catch
            {
                return "";
            }
        }

        

        public bool click_reject_button_terms_conditions_by_id()
        {
            if (verify_element_displayed_term_conditions_by_id(disagree_id_term))
            {
                driver.FindElementById(disagree_id_term).Click();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool verify_app_is_closed()
        {
            return driver.PageSource.Contains(app);
        }


        public bool click_agree_button_terms_conditions_by_id()
        {
            if (verify_element_displayed_term_conditions_by_id(agree_id_term))
            {
                driver.FindElementById(agree_id_term).Click();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool verify_element_displayed_wellcome_by_id(string element)
        {
            string id_lement = element.ToLower().Equals("title") ? title_id_well
                             : element.ToLower().Equals("message") ? message_id_well
                             : go_id_well;

            try
            {
                return driver.FindElementById(id_lement).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public string get_element_text_Wellcome_by_id(string element)
        {
            string id_lement = element.ToLower().Equals("title") ? title_id_well
                             : element.ToLower().Equals("message") ? message_id_well
                             : go_id_well;

            try
            {
                return driver.FindElementById(id_lement).GetAttribute("text").ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool click_lets_go_button_wellcome_by_id()
        {
            click_allow_permission_location_message();
            
            if (verify_element_displayed_wellcome_by_id(go_id_well))
            {
                driver.FindElementById(go_id_well).Click();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool verify_lets_go_button_displays_application_opened_with_menu_displayed()
        {
            try
            {
                return driver.FindElementById(element_menu).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool accept_termns_and_conditions()
        {
            bool resp = false;
            resp = click_agree_button_terms_conditions_by_id();
            resp = click_lets_go_button_wellcome_by_id();
            return resp;
        }

        public bool verify_permission_location_message_is_displayed() {
            try
            {
                return driver.FindElementById(allow_localization_id).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool click_allow_permission_location_message()
        {
            try
            {
                if (verify_permission_location_message_is_displayed())
                {
                    driver.FindElementById(allow_localization_id).Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}

using System;
using System.Configuration;

namespace HomeTask8
{
    class Program
    {
        static void ReadSettings() // метод взят из Майкрософт докс
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("{0} {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
        static void AddUpdateAppSettings(string key, string value) // метод взят из Майкрософт докс
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }


        static void Main(string[] args)
        {
            AddUpdateAppSettings("Приветствую Вас!", "Сегодня " + DateTime.Now.ToString("D"));
            ReadSettings();
            Console.WriteLine("Пожалуйста представьтесь, чтобы при следующем запуске программа учитывала Ваши данные!");
            string UserName = Console.ReadLine();
            Console.WriteLine("Отлично, а теперь скажите, сколько Вам лет?");
            string UserAge = Console.ReadLine();
            Console.WriteLine("Также укажите Вашу специальность!");
            string UserSpecialty = Console.ReadLine();
            AddUpdateAppSettings("Вас зовут " + UserName, "Вам " + UserAge + " лет");
            AddUpdateAppSettings("Ваша специальность " + UserSpecialty, "");
            Console.WriteLine("А теперь перезапустите приложение для отображения введенной Вами информации из настроек приложения");
       }
    }
}

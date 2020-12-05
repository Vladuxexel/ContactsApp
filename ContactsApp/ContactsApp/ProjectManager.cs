using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс менеджера проекта.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Автосвойство для временного хранения манипулируемого контакта
        /// </summary>
        public static Contact TempContact { get; set; }

        /// <summary>
        /// Путь по умолчанию по которому сохраняется файл.
        /// </summary>
        public static string PathFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\ContactsApp\Contacts.json";
        }

        /// <summary>
        /// Путь по умолчанию по которому создается папка для файла.
        /// </summary>
        public static string PathDirectory()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\ContactsApp\";
        }

        /// <summary>
        /// Метод сохранения данных путем сериализации.
        /// </summary>
        /// <param name="project">Данные для сериализации.</param>
        /// <param name="filepath">Путь до файла</param>
        public static void SaveToFile(Project project, string filepath)
        {
            try
            {
                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter(filepath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, project);
                }
            }
            catch
            {
                Directory.CreateDirectory(PathDirectory());
                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter(filepath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, project);
                }
            }
        }

        /// <summary>
        /// Метод загрузки данных путем десериализации.
        /// </summary>
        public static Project LoadFromFile(string filepath)
        {
            Project project;
            if (!File.Exists(filepath))
            {
                return new Project();
            }
            var serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                using (JsonReader reader = new JsonTextReader(sr))
                    project = serializer.Deserialize<Project>(reader);
            }
            catch
            {
                return new Project();
            }
            return project;
        }
    }
}

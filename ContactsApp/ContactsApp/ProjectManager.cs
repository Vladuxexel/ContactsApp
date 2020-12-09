using Newtonsoft.Json;
using System;
using System.IO;

namespace ContactsApp
{
    /// <summary>
    /// Класс менеджера проекта.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь по умолчанию, по которому сохраняется файл.
        /// </summary>
        public static string PathFile()
        {
            return PathDirectory() + @"\Contacts.json";
        }

        /// <summary>
        /// Путь по умолчанию, по которому создается папка для файла.
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
            if (project.Contacts.Count >= 200)
            {
                throw new ArgumentException("Maximum number of contacts is exceeded");
            }

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

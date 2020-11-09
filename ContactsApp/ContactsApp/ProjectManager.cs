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
        /// Имя файла для сериализации/десериализации данных проекта.
        /// Путь для сериализации/десериализации данных проекта.
        /// </summary>
        private const string FileName = "ContactsApp.notes";

        /// <summary>
        /// Путь по умолчанию по которому сохраняется файл.
        /// </summary>
        public static string PathFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\ContactsApp\" + FileName;
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
        /// Метод сериализации данных проекта.
        /// </summary>
        public static void SerializeProject(Project project, string path)
        {
            if (path == null)
            {
                Directory.CreateDirectory(PathDirectory());
                path = PathFile();
            }
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных проекта.
        /// </summary>
        public static Project DeserializeProject(string path)
        {
            var serializer = new JsonSerializer();

            path += FileName;
            Project project;
            if (!File.Exists(path) || path == null)
            {
                return new Project();
            }
            
            try
            {
                using (StreamReader sr = new StreamReader(path))
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

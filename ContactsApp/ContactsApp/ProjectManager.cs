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
        /// Путь для сериализации/десериализации данных проекта.
        /// </summary>
        private const string FileName = "ContactsApp.notes";

        /// <summary>
        /// Метод сериализации данных проекта.
        /// </summary>
        public static void SerializeProject(Project project, string path)
        {
            path += FileName;

            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных проекта.
        /// </summary>
        public static Project DeserializeProject(string path)
        {
            path += FileName;

            Project project = null;

            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(path))
            using (var reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }

            return project;
        }
    }
}

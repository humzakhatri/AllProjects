using Framework.REST;
using Framework.REST.EndPoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Runtime.Persisters
{
    public class ApiConfigurationPersister : PersisterBase<ApiConfiguration>
    {
        private static string ConfigFilePath = @"C:\Data\Config.xml";
        private List<ApiConfiguration> _Configurations;
        public ApiConfigurationPersister()
        {
            LoadFromFile();
        }

        private void CreateNewIfDoesntExist()
        {
            if (File.Exists(ConfigFilePath) == false)
                File.Create(ConfigFilePath);
            else return;
            var serializer = new XmlSerializer(typeof(List<ApiConfiguration>));
            using (var writer = new StreamWriter(ConfigFilePath))
                serializer.Serialize(writer, BuildDummyObject());
        }

        private List<ApiConfiguration> BuildDummyObject()
        {
            var qp = new List<string>();
            qp.Add("param");
            return new List<ApiConfiguration>() { new ApiConfiguration() { Id = 0, Method = HttpMethod.Post, Path = "/api/whatever", QueryParameters = qp } };
        }

        private void LoadFromFile()
        {
            CreateNewIfDoesntExist();
            var serializer = new XmlSerializer(typeof(List<ApiConfiguration>));
            using (var reader = new StreamReader(ConfigFilePath))
                _Configurations = (List<ApiConfiguration>)serializer.Deserialize(reader);
        }

        private void SaveToFile()
        {
            var serializer = new XmlSerializer(typeof(List<ApiConfiguration>));
            using (var writer = new StreamWriter(ConfigFilePath))
                serializer.Serialize(writer, _Configurations);
        }

        public override ApiConfiguration Load(long id)
        {
            return _Configurations[(int)id];
        }

        public override IEnumerable<ApiConfiguration> Load()
        {
            return _Configurations;
        }

        public override void Save(ApiConfiguration obj)
        {
            if (_Configurations.Any(c => c.Id == obj.Id)) throw new Exception("Item Already exists.");
            _Configurations.Add(obj);
            SaveToFile();
        }

        public override void Update(ApiConfiguration obj)
        {
            var existing = _Configurations.FirstOrDefault(c => c.Id == obj.Id);
            if (existing == null) throw new Exception("Object does not exist.");
            _Configurations.Remove(existing);
            _Configurations.Add(obj);
        }

        public override void Delete(long id)
        {
            _Configurations.RemoveAll(c => c.Id == id);
        }
    }
}

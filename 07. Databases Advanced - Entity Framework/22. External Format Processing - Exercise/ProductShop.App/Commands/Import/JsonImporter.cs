using Newtonsoft.Json;
using System.IO;

namespace ProductShop.App.Commands.Import
{
    public class JsonImporter
    {
        public TModel[] Deserialize<TModel>(string path)
        {
            string modelString = File.ReadAllText(path);
            TModel[] models = JsonConvert.DeserializeObject<TModel[]>(modelString);

            return models;
        }
    }
}
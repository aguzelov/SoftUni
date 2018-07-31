using Newtonsoft.Json;
using ProductShop.App.Commands.Contracts;
using System.IO;

namespace ProductShop.App.Commands.Import
{
    public class JsonImporter : IImporter
    {
        public TModel[] Deserialize<TModel>(string path)
        {
            string modelString = File.ReadAllText(path);
            TModel[] models = JsonConvert.DeserializeObject<TModel[]>(modelString);

            return models;
        }
    }
}
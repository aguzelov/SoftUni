using Newtonsoft.Json;
using ProductShop.App.Commands.Contracts;
using System.IO;

namespace ProductShop.App.Commands.Export
{
    public class JsonExporter : IExporter
    {
        public void Export<TModel>(string filePath, TModel[] collection)
        {
            var jsonString = JsonConvert.SerializeObject(collection, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText(filePath, jsonString);
        }

        public void Export<TModel>(string filePath, TModel model)
        {
            var jsonString = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            File.WriteAllText(filePath, jsonString);
        }
    }
}
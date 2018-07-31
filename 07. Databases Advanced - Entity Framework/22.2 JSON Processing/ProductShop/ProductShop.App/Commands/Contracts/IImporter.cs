using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.App.Commands.Contracts
{
    public interface IImporter
    {
        TModel[] Deserialize<TModel>(string path);
    }
}
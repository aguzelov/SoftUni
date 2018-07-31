using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.App.Commands.Contracts
{
    public interface IExporter
    {
        void Export<TModel>(string filePath, TModel[] collection);

        void Export<TModel>(string filePath, TModel model);
    }
}
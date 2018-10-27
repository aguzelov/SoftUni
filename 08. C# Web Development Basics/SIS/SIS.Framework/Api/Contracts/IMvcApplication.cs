using System;
using System.Collections.Generic;
using System.Text;
using SIS.Framework.Services.Contracts;

namespace SIS.Framework.Api.Contracts
{
    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IDependencyContainer dependencyContainer);
    }
}
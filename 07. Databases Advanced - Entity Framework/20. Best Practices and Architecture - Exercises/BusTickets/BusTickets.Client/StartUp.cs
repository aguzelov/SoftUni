using BusTickets.Client.Core;
using BusTickets.Data;
using BusTickets.Services;
using BusTickets.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BusTickets.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IDatabaseService databaseService = serviceProvider.GetService<IDatabaseService>();
            ICommandDispatcher commandDispatcher = serviceProvider.GetService<ICommandDispatcher>();
            Engine engine = new Engine(databaseService, commandDispatcher);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<BusTicketsContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IBusStationService, BusStationService>();
            services.AddTransient<ITripService, TripService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IBusCompanyService, BusCompanyService>();
            services.AddTransient<IArrivedTripService, ArrivedTripService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
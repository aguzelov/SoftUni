using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new HospitalContext())
            {
                context.Database.EnsureDeleted();

                //context.Database.Migrate();
            }
        }
    }
}
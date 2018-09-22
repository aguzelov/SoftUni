﻿using HTTPServer.ByTheCakeApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HTTPServer.ByTheCakeApp.Data
{
    public class CakesData
    {
        private const string DatabaseFile = @"..\..\..\ByTheCakeApp\Data\database.csv";

        public void Add(string name, string price)
        {
            var streamReader = new StreamReader(DatabaseFile);
            var id = streamReader.ReadToEnd().Split(Environment.NewLine).Length;
            streamReader.Dispose();

            using (var writer = new StreamWriter(DatabaseFile, true))
            {
                writer.WriteLine($"{id},{name},{price}");
            }
        }

        public IEnumerable<Cake> All() => File
            .ReadAllLines(DatabaseFile)
            .Where(l => l.Contains(','))
            .Select(l => l.Split(','))
            .Select(l => new Cake
            {
                Id = int.Parse(l[0]),
                Name = l[1],
                Price = decimal.Parse(l[2])
            });

        public Cake Find(int id)
            => All().FirstOrDefault(c => c.Id == id);
    }
}
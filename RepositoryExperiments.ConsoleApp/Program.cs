﻿using System;
using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using RepositoryExperiments.Domain.DataAccess;
using RepositoryExperiments.Domain.Entities;
using RepositoryExperiments.Domain.Queries;

namespace RepositoryExperiments.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                InitializeNHibernate();
                InsertCustomers();
                var allCustomers = GetAllCustomers();

                Console.WriteLine("And here are the customers:");
                foreach (var customer in allCustomers)
                    Console.WriteLine("- Customer: {0}", customer.Name);

                Console.WriteLine("Wohoo!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

        private static IEnumerable<ICustomer> GetAllCustomers()
        {
            var repository = new NHibernateRepository();
            return repository.Query(new GetAll<ICustomer>()).List();
        }

        private static void InsertCustomers()
        {
            NHibernateHelper.BeginTransaction();
            try
            {
                var repository = new NHibernateRepository();
                repository.Add(new Customer("IKEA"));
                repository.Add(new Customer("Starbucks"));
                repository.Add(new Customer("Budweiser"));
                NHibernateHelper.CommitTransaction();
            }
            catch
            {
                NHibernateHelper.RollbackTransaction();
                throw;
            }
        }

        private static void InitializeNHibernate()
        {
            var configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Customer>())
                .BuildConfiguration();

            NHibernateHelper.Initialize(new SQLiteInMemorySessionFactory(configuration),
                                        new StaticStateHolder());
        }
    }
}
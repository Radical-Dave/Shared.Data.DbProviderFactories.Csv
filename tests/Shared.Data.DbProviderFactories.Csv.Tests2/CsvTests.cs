using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Data.DbProviderFactories;
using System.IO;

namespace Shared.Data.DbProviderFactoryCreateDataTable.Tests
{
    [TestClass]
    public class CsvTests
    {
        public CsvTests()
        {
            //var config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
              .AddXmlFile("App.config", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
        }

        [TestMethod]
        public void UnitTest()
        {
            var results = Csv.CreateDataTable();
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Columns.Count > 0 && results.Rows.Count > 0);
            var providerName = "";
            //DbProviderFactory factory = DbProviderFactories.GetDataTable("SELECT * FROM ITEMS");
            //var dataTable = DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            //var dataTable = DbProviderFactories.CreateDataTable("SELECT * FROM ITEMS");
        }
    }
}
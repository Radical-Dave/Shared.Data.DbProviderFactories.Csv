using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Shared.Data.DbProviderFactories
{
    public static class Csv
    {
        public static DataTable CreateDataTable(string? source = "", string? connectionString = null, string? providerName = null)
        {
            var dataTable = new DataTable();
            //_items = new ObservableCollection<Dictionary<string, object>>();

            if (source == null || string.IsNullOrEmpty(source)) { source = "default.csv"; }
            if (!source.StartsWith("http") && !source.Contains(':'))
            {
                //source = Path.Combine(Package.Current.InstalledLocation.Path, $"Assets/{source}");
            }
            var headers = new List<string>();
            var file = File.ReadAllText(source);
            foreach (var line in file.Split('\r'))
            {
                string[] values = line.Split(',');
                values[0] = values[0].Replace("\n", "");
                if (headers == null) { headers = new List<string>(); }
                if (headers.Count == 0)
                {
                    headers = values.ToList();
                    foreach (var header in headers)
                    {
                        dataTable.Columns.Add(new DataColumn(header, typeof(string)));
                    }
                    continue;
                }
                try
                {
                    //var item = new Dictionary<string, object>();
                    var row = dataTable.NewRow();
                    for (int i = 0; i <= headers.Count - 1; i++)
                    {
                        //Console.WriteLine($"Reading field:{i}");

                        if (i >= headers.Count || i >= values.Length) { break; }
                        try
                        {
                            row[headers[i]] = values[i];
                        }
                        catch (Exception exception)
                        {
                            //Console.WriteLine(exception);
                        }
                    }
                    dataTable.Rows.Add(row);
                }
                catch (Exception exception)
                {
                    //Console.WriteLine(exception);
                }
            }
            //Console.WriteLine($"done:{dataTable.Rows.Count}");
            return dataTable;
        }
    }
}
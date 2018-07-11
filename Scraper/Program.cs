using System;
using System.Data;
using System.Data.SqlClient;
using HtmlAgilityPack;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString =
                    "server=sql10.freesqldatabase.com;" +
                    "initial catalog=sql10247127;" +
                    "user id=sql10247127;" +
                    "password=Please wait";


                /* https://www.yellowpages.com/search?search_terms=software&geo_location_terms=Los+Angeles%2C+CA */
                /* "http://www.cbn.gov.ng/rates/exchratebycurrency.asp"; */
                
                var url = "https://www.xe.com/currency/ngn-nigerian-naira";
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var CurrencyName = doc.DocumentNode.SelectNodes("//a[@class='flagBoxiPAD']");
                var CurrencyID = doc.DocumentNode.SelectNodes("//a[@class='']");
                var CurrencyValue = doc.DocumentNode.SelectNodes("//td[@class='rateCell']");

                foreach (var name in CurrencyName)
                {
                    Console.WriteLine(name.InnerText);
                    using (SqlConnection conn =
                    new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd =
                            new SqlCommand("INSERT INTO EmployeeDetails VALUES(" +
                                "@Id, @Currency, @Value)", conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", CurrencyID);

                            //int rows = cmd.ExecuteNonQuery();

                            //rows number of record got inserted
                        }
                    }
                }


                foreach (var name in CurrencyName)
                {
                    Console.WriteLine(name.InnerText);
                    using (SqlConnection conn =
                    new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd =
                            new SqlCommand("INSERT INTO EmployeeDetails VALUES(" +
                                "@Id, @Currency, @Value)", conn))
                        {
                            cmd.Parameters.AddWithValue("@Currency", CurrencyName);
                            //int rows = cmd.ExecuteNonQuery();

                            //rows number of record got inserted
                        }
                    }
                }

                foreach (var name in CurrencyName)
                {
                    Console.WriteLine(name.InnerText);
                    using (SqlConnection conn =
                    new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd =
                            new SqlCommand("INSERT INTO EmployeeDetails VALUES(" +
                                "@Id, @Currency, @Value)", conn))
                        {                            
                            cmd.Parameters.AddWithValue("@Value", CurrencyValue);

                            //int rows = cmd.ExecuteNonQuery();

                            //rows number of record got inserted
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

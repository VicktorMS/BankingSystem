using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class DataFile
    {
        public static List<Customer> ReadCustomers(string path)
        {
            var data = File.ReadAllText("../../.." + path);
            List<Customer> customersList = new List<Customer>();

            string[] customerData = data.Split('\n');
            Array.ForEach(customerData, customer => customersList.Add(new Customer(customer)));
            return customersList;
        }

        public static void GenerateCustomerFile(object sender, TaxManager.SumFinishedEventArgs e)
        {
            string conteudoArquivo = $"{e.TotalBalance}|{e.TotalBalance}";
            try
            {
                File.WriteAllText("../../../Output" + $"/{e.Cpf}.txt", conteudoArquivo);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ocorreu um erro ao criar ou escrever no arquivo: " + ex.Message);
            }
        }
    }
}

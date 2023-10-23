// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using SistemaBancario.Models;


TaxManager taxManager = new TaxManager();

List<Customer> customers = DataFile.ReadCustomers("/Input/data.txt");
taxManager.SumFinished += DataFile.GenerateCustomerFile;

taxManager.CalculateSum(customers, SuccessMessage);

static void SuccessMessage(string cpf)
{
    Console.WriteLine($"O novo arquivo de saldo para o cpf {cpf} foi gerado!");
}



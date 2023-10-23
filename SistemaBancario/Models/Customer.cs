using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario.Models.Account;

namespace SistemaBancario.Models
{
    public class Customer
    {
        public string Cpf { get; private set; }
        public string Name { get; private set; }

        public Checking CheckingAcc { get; set; }
        public International InternationalAcc { get; set; }
        public Cripto CriptAcc { get; set; }    

        public Customer(string data) {
            string[] customerData = data.Split('|');

            if (customerData.Length != 5)
            {
                throw new ArgumentException("Dados do cliente não estão em um formato inválido.");
            }
            Cpf = customerData[0];
            Name = customerData[1];
            InitializeAccounts(customerData[2], customerData[3], customerData[4]);
        }

        private void InitializeAccounts(string checkingBalance, string internationalBalance, string criptoBalance)
        {
            CheckingAcc = new Checking(checkingBalance);
            InternationalAcc = new International(internationalBalance);
            CriptAcc = new Cripto(criptoBalance);
        }
        public override string ToString() => $"{Name}: {Cpf}";
    }
}

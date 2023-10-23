using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class TaxManager
    {
        public delegate void SumFinishedEventHandler(object sender, SumFinishedEventArgs e);

        public event SumFinishedEventHandler SumFinished;

        public void CalculateSum(List<Customer> customerList, Action<string> successMessage)
        {
            foreach(Customer customer in customerList)
            {
                double totalBalance = customer.CheckingAcc.Balance +
                    customer.InternationalAcc.BalanceReal + customer.CriptAcc.BalanceReal;
                totalBalance = Math.Round(totalBalance, 2);

                double totalTax = customer.CheckingAcc.CalculateTax() + 
                    customer.InternationalAcc.CalculateTaxReal();
                totalTax = Math.Round(totalTax, 2);

                OnSumFinished(new SumFinishedEventArgs(totalBalance, totalTax, customer.Cpf));
                successMessage(customer.Cpf);
            }
        }

        public virtual void OnSumFinished(SumFinishedEventArgs e)
        {
            SumFinished?.Invoke(this, e);
        }

        public class SumFinishedEventArgs : EventArgs
        {
            public string Cpf { get; }
            public double TotalBalance { get; }
            public double TotalTax { get; }

            public SumFinishedEventArgs(double totalBalance, double totalTax, string cpf)
            {
                Cpf = cpf;
                TotalBalance = totalBalance;
                TotalTax = totalTax;
            }
        }

    }
}

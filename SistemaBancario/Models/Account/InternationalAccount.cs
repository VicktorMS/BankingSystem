using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario.Models.Interfaces;
using SistemaBancario.Utils;

namespace SistemaBancario.Models.Account
{
    public class International : Account, ITax
    {
        public double BalanceReal { get; private set; }

        public International(double saldo) : base(saldo)
        {
            UpdateBalanceInReal();
        }

        public International(string saldo) : base(saldo)
        {
            UpdateBalanceInReal();
        }

        private void UpdateBalanceInReal()
        {
            BalanceReal = AccountHelper.DolarToReal(Balance);
        }

        // Calcula a Tarifa
        public double CalculateTax() => Math.Round((Balance * 0.025), 2);
        public double CalculateTaxReal() => Math.Round((BalanceReal * 0.025), 2);
    }
}

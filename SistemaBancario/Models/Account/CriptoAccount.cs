using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario.Utils;

namespace SistemaBancario.Models.Account
{
    public class Cripto : Account
    {
        public double BalanceReal { get; private set; }

        public Cripto(double balance) : base(balance)
        {
            UpdateBalanceInReal();
        }

        public Cripto(string balance) : base(balance)
        {
            UpdateBalanceInReal();
        }

        private void UpdateBalanceInReal()
        {
            BalanceReal = AccountHelper.DolarToReal(Balance);
        }

    }
    
}


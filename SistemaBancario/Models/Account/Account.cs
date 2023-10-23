using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario.Utils;

namespace SistemaBancario.Models.Account
{
    public abstract class Account
    {
        public virtual double Balance { get; set; }
        public Account(string balance)
        {
            Balance = AccountHelper.StringToDouble(balance);
        }

        public Account(double balance)
        {
            Balance = balance;
        }
    }
}

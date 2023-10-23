using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario.Models.Interfaces;

namespace SistemaBancario.Models.Account
{
    public class Checking : Account, ITax
    {
        public Checking(string balance) : base(balance) { }
        public Checking(double balance) : base(balance) { }

        public double CalculateTax() => Math.Round((Balance * 0.025), 2);
    }
}

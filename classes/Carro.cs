using System;
using System.Collections.Generic;

namespace Estacionamento.classes
{
    class Carro
    {
        public string placa { get; set; }
        public int horas { get; set; }
        public decimal preço { get; set; }
        public Carro(string placa)
        {
            this.placa = placa;
        }
    }
}
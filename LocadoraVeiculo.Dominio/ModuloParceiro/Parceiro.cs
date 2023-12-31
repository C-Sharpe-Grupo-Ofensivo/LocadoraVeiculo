﻿using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public override void Atualizar(Parceiro registro)
        {
            Nome = registro.Nome;
        }
        public Parceiro()
        {
            
        }

        public Parceiro(Guid id, string nome) : this(nome)
        {
            Id = id;
        }
        public string Nome { get; set; }

        public Parceiro(string Nome) 
        {

            this.Nome = Nome;
        }
        public override bool Equals(object obj)
        {
            return obj is Parceiro parceiro &&
                   Id == parceiro.Id &&
                   Nome == parceiro.Nome;
        }

        public override string? ToString()
        {
            return Nome;
        }
    }
}

﻿using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {

        public List<PlanoCobranca> SelecionarTodos(bool incluirGrupoAutomoveis = false);
    }
}

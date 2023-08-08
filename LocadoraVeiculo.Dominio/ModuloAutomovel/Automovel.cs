using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase<Automovel>
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public TipoCombustivelEnum TipoCombustivel { get; set; }
        public int CapacidadeLitros { get; set; }
        public int Quilometragem { get; set; }
        public int Ano { get; set; }
        public byte[] Foto { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }


        public Automovel() { }

        public Automovel(string placa, string modelo, string marca, string cor, TipoCombustivelEnum tipoCombustivel, int capacidadeLitros, int quilometragem, int ano, GrupoAutomovel grupoAutomovel)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            TipoCombustivel = tipoCombustivel;
            CapacidadeLitros = capacidadeLitros;
            Quilometragem = quilometragem;
            Ano = ano;
            GrupoAutomovel = grupoAutomovel;
        }

        public Automovel(string placa, string modelo, string marca, string cor, TipoCombustivelEnum tipoCombustivel, int capacidadeLitros, int quilometragem, int ano, byte[] foto, GrupoAutomovel grupoAutomovel)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            TipoCombustivel = tipoCombustivel;
            CapacidadeLitros = capacidadeLitros;
            Quilometragem = quilometragem;
            Ano = ano;
            Foto = foto;
            GrupoAutomovel = grupoAutomovel;
        }
        public Automovel(int id, string placa, string modelo, string marca, string cor, TipoCombustivelEnum tipoCombustivel, int capacidadeLitros, int quilometragem, int ano, GrupoAutomovel grupoAutomovel)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            TipoCombustivel = tipoCombustivel;
            CapacidadeLitros = capacidadeLitros;
            Quilometragem = quilometragem;
            Ano = ano;
            GrupoAutomovel = grupoAutomovel;
        }

        public override void Atualizar(Automovel registro)
        {
            Placa = registro.Placa;
            Modelo = registro.Modelo;
            Marca = registro.Marca;
            Cor = registro.Cor;
            TipoCombustivel = registro.TipoCombustivel;
            CapacidadeLitros = registro.CapacidadeLitros;
            Quilometragem = registro.Quilometragem;
            Ano = registro.Ano;
            GrupoAutomovel = registro.GrupoAutomovel;
            Foto = registro.Foto;
        }

        public override string ToString()
        {
            return Modelo + " " + Cor + " " + Placa + " " + Ano;
        }
    }
}

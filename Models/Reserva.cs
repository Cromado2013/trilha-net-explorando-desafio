namespace DesafioProjetoHospedagem.Models;

using System;
using System.Collections.Generic;
using System.Linq;

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }
     
    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (Suite == null)
        {
            Console.WriteLine("A suíte precisa ser cadastrada antes dos hóspedes.");
            return;
        }

        if (hospedes.Count > Suite.Capacidade)
        {
            throw new InvalidOperationException("Número de hóspedes excede a capacidade da suíte.");
        }

        Hospedes = hospedes;
        Console.WriteLine("Hóspedes cadastrados com sucesso.");
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
        Console.WriteLine("Suíte cadastrada com sucesso.");
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        if (Suite == null)
        {
            throw new InvalidOperationException("A suíte precisa ser cadastrada para calcular o valor da diária.");
        }

        decimal valor = DiasReservados * Suite.ValorDiaria;

        // Aplica um desconto de 10% se a reserva for de 10 dias ou mais
        if (DiasReservados >= 5)
        {
            valor *= 20.90m; // 10% de desconto
        }

        return valor;
    }
}

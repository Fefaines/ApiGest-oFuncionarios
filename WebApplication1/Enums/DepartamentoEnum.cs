//Nessa parte do projeto é onde fica a classe DepartamentoEnum, para ser relacionada com a classe funcionarioModel, para que o funcionario tenha um departamento.

using System.Text.Json.Serialization;

namespace WebApplication1.Enums
{
    //Convertendo números em strings
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
        {
        TI,
        RH,
        Financeiro,
        Compras,
        Vendas,
        Marketing,
        Producao,
        Logistica,
        Administracao,
    }
}


﻿namespace WebApplication1.Models
{
    public class ServiceResponse<T> //<T>= Significa o Service Respomse pode receceber qualquer tipo de objeto, e não só o dos funcionários//
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}

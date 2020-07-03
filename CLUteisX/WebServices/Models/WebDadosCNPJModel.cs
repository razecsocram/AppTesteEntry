﻿using System.Collections.Generic;

namespace CLUteisX.WebServices.Models
{
    public class WebDadosCNPJModel
    {
        public string  Status { get; set; }
        public string Message { get; set; }
        public Billing Billing { get; set; }
        public string Cnpj { get; set; }
        public string Tipo { get; set; }
        public string Abertura { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public List<Atividade_principal> Atividade_principal { get; set; }
        public List<Atividades_secundarias> Atividades_secundarias { get; set; }
        public string NaturezaJuridica { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Efr { get; set; }
        public string Situacao { get; set; }
        public string DataSituacao { get; set; }
        public string MotivoSituacao { get; set; }
        public string SituacaoEspecial { get; set; }
        public string  DataSituacaoEspecial { get; set; }
        public string CapitalSocial { get; set; }
        public List<Qsa> Qsa { get; set; }
        public Extra Extra { get; set; }

    }
}

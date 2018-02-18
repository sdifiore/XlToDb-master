using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    [Table("CubosTrabalhados")]
    public class CuboTrabalhado
    {
        public int Id { get; set; }

        [StringLength(16)]
        [Display(Name = "Nº Pedido")]
        public string Pedido { get; set; }

        [Display(Name = "Data Pedido")]
        public DateTime DataPedido { get; set; }

        [StringLength(256)]
        public string Cliente { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        [StringLength(64)]
        public string Cidade { get; set; }

        [StringLength(32)]
        public string Regiao { get; set; }

        [StringLength(6)]
        public string Codigo { get; set; }

        [StringLength(128)]
        public string Produto { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        [Display(Name = "Família")]
        public int FamiliaId { get; set; }

        [Display(Name = "Família")]
        public Familia Familia { get; set; }

        [Display(Name = "Linha")]
        public int LinhaId { get; set; }

        public Linha Linha { get; set; }

        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }

        [StringLength(128)]
        public string Vendedor { get; set; }

        [StringLength(32)]
        [Display(Name = "Forma Pagamento")]
        public string FormaPagamento { get; set; }

        [Display(Name = "Data Validade")]
        public DateTime DataValidade { get; set; }

        [Display(Name = "Tipo Venda")]
        public int TipoVendaId { get; set; }

        [Display(Name = "Tipo Venda")]
        public TipoVenda TipoVenda { get; set; }

        [Display(Name = "Data Faturamento")]
        public DateTime DataFaturamento { get; set; }

        [StringLength(16)]
        [Display(Name = "Nota Fiscal")]
        public string NotaFiscal { get; set; }

        public float Quantidade { get; set; }

        [Display(Name = "Valor Unitário")]
        public float ValorUnitario { get; set; }

        [Display(Name = "Receita Bruta")]
        public float ReceitaBruta { get; set; }

        [Display(Name = "Valor IPI")]
        public float ValorIpi { get; set; }

        [Display(Name = "Valor Subst. Tributária")]
        public float ValorST { get; set; }

        [Display(Name = "Prazo Pag. Médio")]
        public int PrazoPagMedio { get; set; }

        [Display(Name = "Fat. Bruto")]
        public float FatuBruto { get; set; }

        [Display(Name = "Mês Cadastro")]
        public string MesCadastro { get; set; }

        [Display(Name = "Mês Fatura")]
        public string MesFatura { get; set; }

        public bool Faturado { get; set; }

        [Display(Name = "Mês Entregue")]
        public string MesEntregue { get; set; }

        [StringLength(256)]
        [Display(Name = "Cliente NF DataFat")]
        public string ClienteNfDataFat { get; set; }

        [StringLength(6)]
        [Display(Name = "Cód Prod Ajustado")]
        public string CodigoAjustado { get; set; }

        [StringLength(256)]
        [Display(Name = "Cod - Nome Produto - Unidade")]
        public string CodNomeProdutoUnidade { get; set; }

        [Display(Name = "Unidade")]
        public int UnidadeId { get; set; }

        public Unidade Unidade { get; set; }

        [Display(Name = "Quant AJustada")]
        public float QuantAjustada { get; set; }

        [Display(Name = "Peso")]
        public float PesoProduto { get; set; }

        [Display(Name = "Pessoa Juridica?")]
        public bool Juridico { get; set; }

        [Display(Name = "Tipo Cliente")]
        public int TipoClienteId { get; set; }

        [Display(Name = "Tipo Cliente")]
        public TipoCliente TipoCliente { get; set; }

        [Display(Name = "Categoria Cliente")]
        public int CategoriaClienteId { get; set; }

        [Display(Name = "Categoria Cliente")]
        public CategoriaCliente CategoriaCliente { get; set; }

        [StringLength(256)]
        [Display(Name = "Segmento Cliente")]
        public string SegmentoCliente { get; set; }

        [StringLength(256)]
        public string Grupo { get; set; }

        [Display(Name = "Prazo Entrega")]
        public int PrazoEntrega { get; set; }

        [Display(Name = "Tx Dólar")]
        public float TaxaDolar { get; set; }

        [Display(Name = "Fat Bruto USD")]
        public float FatBrutoUsd { get; set; }

        [Display(Name = "Preço Individual")]
        public float PrecoIndividual { get; set; }

        [Display(Name = "Receita Líquida")]
        public float ReceitaLiquida { get; set; }

        [Display(Name = "Comissão")]
        public float Comissao { get; set; }

        public float Frete { get; set; }

        [Display(Name = "Cst Financ Cobrança")]
        public float CustoFinancCobranca { get; set; }

        [Display(Name = "Grupo Rateio")]
        public int GrupoRateioId { get; set; }

        public GrupoRateio GrupoRateio { get; set; }

        [Display(Name = "Ano Faturamento")]
        public int AnoFaturamento { get; set; }

        [Display(Name = "Tem peso?")]
        public bool TemPeso { get; set; }

        [Display(Name = "PV R$/kg")]
        public float PvRsKg { get; set; }

        [StringLength(7)]
        [Display(Name = "Trimestre")]
        public string Trimestre { get; set; }

        [Display(Name = "M2 Fitas")]
        public float M2Fitas { get; set; }

        [Display(Name = "Rec Bruta USD")]
        public float RecBrutaUsd { get; set; }

        [Display(Name = "Categ Prod Ajustado")]
        public int CategoProdAjustadaId { get; set; }

        [Display(Name = "Categ Prod Ajustado")]
        public Categoria CategoProdAjustada { get; set; }

        [StringLength(9)]
        [Display(Name = "Período Estatístico")]
        public string PeriodoEstatistico { get; set; }

        [Display(Name = "Quant Individual Ajustada")]
        public float QuantIndividualAjustada { get; set; }

        [StringLength(256)]
        public string IdVend { get; set; }

        [Display(Name = "Cod Região original")]
        public string CodRegiaoOriginal { get; set; }

        public float VlIcms { get; set; }

        public string VlCom { get; set; }

        [StringLength(256)]
        [Display(Name = "Cod - Prod Original")]
        public string CodProdOriginal { get; set; }

    }
}

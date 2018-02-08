using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XlToDb.Model
{
    public class Estrutura
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        [Display(Name = "Unidade Produto")]
        public int UnidadeId { get; set; }

        public virtual Unidade Unidade { get; set; }

        [Display(Name = "Quantidade para Custo")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float QtdCusto { get; set; }

        [Display(Name = "Sequência")]
        public int SequenciaId { get; set; }

        public Sequencia Sequencia { get; set; }

        [StringLength(10)]
        [Display(Name = "Código Compra")]
        public string Item { get; set; }

        [StringLength(256)]
        [Display(Name = "Descrição Componente / Processo")]
        public string DescCompProc { get; set; }

        [Display(Name = "Unidade de Compra")]
        public int UnidadeCompraId { get; set; }

        public virtual Unidade UnidadeCompra { get; set; }

        [Display(Name = "Custo unit compra")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float CustoUnitCompra { get; set; }

        [Display(Name = "Onera")]
        public bool Onera { get; set; }

        [Display(Name = "Lote")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float Lote { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Perdas")]
        public float Perda { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Parte no Custo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PartCusto { get; set; }

        [Display(Name = "Qt Eff unit comp")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float QtEftvUntrCmpnt { get; set; }

        [Display(Name = "Cst Compr Un Prod")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float CstCmprUndPrd { get; set; }

        [Display(Name = "Custo Individual")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float CustoIndividual { get; set; }

        [Display(Name = "Qtd por  Unidade")]
        public int QtdUndd { get; set; }

        [StringLength(16)]
        [Display(Name = "Ref Auxiliar Produto")]
        public string RefAuxiliarProduto { get; set; }

        [Display(Name = "Tipo Item Custo")]
        public string TpItmCst { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }

        [Display(Name = "Família")]
        public int FamiliaId { get; set; }

        [Display(Name = "Família")]
        public Familia Familia { get; set; }

        [Display(Name = "Linha")]
        public int LinhaId { get; set; }

        [Display(Name = "Linha")]
        public Linha Linha { get; set; }

        [Display(Name = "Alerta SubProduto")]
        public string AlrtSbPrdt { get; set; }

        [Display(Name = "Tempo máquina")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float TempMaq { get; set; }

        [StringLength(128)] // Left Over?
        [Display(Name = "Tipo Item Custo")]
        public string TipoItemCusto { get; set; }

        [Display(Name = "Peso Liq Final")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float PsLiqdFnl { get; set; }

        [Display(Name = "Peso Liq Precedente")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float PsLiqdPrcdt { get; set; }

        [Display(Name = "Horas Mod Final")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float HrsModFnl { get; set; }

        [Display(Name = "Horas Mod Prec 1")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float HrsModPrec1 { get; set; }

        [Display(Name = "Horas Mod Prec 2")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float HrsModPrec2 { get; set; }

        [StringLength(256)]
        [Display(Name = "Id Produto")]
        public string IdProd { get; set; }

        [StringLength(256)]
        [Display(Name = "Id Componente")]
        public string IdCmpnt { get; set; }

        [Display(Name = "Prod Horária")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float PdrHoraria { get; set; }

        [Display(Name = "Prod-comp")]
        [StringLength(24)]
        public string ProdComp { get; set; }

        [Display(Name = "Custo Individual")]
        [DisplayFormat(DataFormatString = "{0:N5}")]
        public float CstIndividual { get; set; }

        [Display(Name = "Cust Material Direto")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CstMtrlDrt { get; set; }

        [Display(Name = "Cust Material Prec 1")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CstMtrlPrcd1 { get; set; }

        [Display(Name = "Cust Material Prec 2")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CstMtrlPrcd2 { get; set; }

        [Display(Name = "Cust Material Prec 3")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CstMtrlPrcd3 { get; set; }

        public bool Header { get; set; }

        [StringLength(128)]
        [Display(Name = "Setor Produção")]
        public string SetorProducao { get; set; }

        [Display(Name = "Lista Planej Produção")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float ListaPlanejProducao { get; set; }

        [Display(Name = "Necessid Compon p/ Produção")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float NeedComponProducao { get; set; }

        [Display(Name = "Lista Necessidade Prod Nivel 1")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float ListaNecessProdNivel1 { get; set; }

        [Display(Name = "Nec Compon p/ Lista P-1")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float NecCompListaP1 { get; set; }

        [Display(Name = "Lista Necessidade Prod Nivel 2")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float ListaNecessProdNivel2 { get; set; }

        [Display(Name = "Nec Compon p/ Lista P-2")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float NecCompListaP2 { get; set; }

        [Display(Name = "Lista Necessidade Prod Nivel 3")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float ListaNecessProdNivel3 { get; set; }

        [Display(Name = "Nec Compon p/ Lista P-3")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float NecCompListaP3 { get; set; }

        [Display(Name = "Lista Necessidade Prod Nivel 4")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float ListaNecessProdNivel4 { get; set; }

        [Display(Name = "Nec Compon p/ Lista P-4")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float NecCompListaP4 { get; set; }

        [Display(Name = "Necessidade Total Componente")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float NecTotalComponente { get; set; }

        [Display(Name = "1º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes1 { get; set; }

        [Display(Name = "2º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes2 { get; set; }

        [Display(Name = "3º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes3 { get; set; }

        [Display(Name = "4º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes4 { get; set; }

        [Display(Name = "5º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes5 { get; set; }

        [Display(Name = "6º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes6 { get; set; }

        [Display(Name = "7º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes7 { get; set; }

        [Display(Name = "8º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes8 { get; set; }

        [Display(Name = "9º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes9 { get; set; }

        [Display(Name = "10º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes10 { get; set; }

        [Display(Name = "11º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes11 { get; set; }

        [Display(Name = "12º Mês")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Mes12 { get; set; }

        [StringLength(10)]
        public string Input { get; set; }

    }
}

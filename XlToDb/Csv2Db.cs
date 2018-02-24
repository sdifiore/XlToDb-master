using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlToDb.Model;

namespace XlToDb
{
    public static class Csv2Db
    {
        public static void Vendedor()
        {
            var db = new EntityContext();
            var vendedores = db.Vendedores;
            string[] lines = File.ReadAllLines(Files.vendedor, Encoding.Default);
            bool header = true;

            foreach (string line in lines)
            {
                if (header) header = false;
                else
                {
                    var reg = line.Split(';');

                    Vendedor vendedor = new Vendedor();
                    vendedor.Representante = reg[0];
                    string comissao = reg[1].Substring(0, reg[1].Length - 1);
                    vendedor.PctComissao = float.Parse(comissao) / 100;
                    vendedor.Cidade = reg[2];
                    vendedor.Estado = reg[3];

                    vendedores.Add(vendedor);
                }
            }

            db.SaveChanges();
        }

        public static void FatHistorico()
        {
            using (var db = new EntityContext())
            {
                var cubos = db.CubosTrabalhados;
                string[] lines = File.ReadAllLines(Files.cuboHistorico, Encoding.Default);
                bool header = true;
                int i = 2;

                foreach (string line in lines)
                {
                    if (header) header = false;
                    else
                    {
                        var reg = line.Split(';');
                        var cubo = new CuboTrabalhado();
                        cubo.Pedido = reg[0];
                        cubo.DataPedido = Select.ParseDate(reg[3]);
                        cubo.Cliente = reg[4];
                        cubo.UF = Select.Uf(reg[5]);
                        cubo.Cidade = reg[6];
                        cubo.Regiao = reg[7];
                        cubo.Codigo = reg[8];
                        cubo.Produto = reg[9];
                        cubo.CategoriaId = Select.Categoria(reg[10]);
                        cubo.FamiliaId = Select.Familia(reg[11]);
                        cubo.LinhaId = Select.Linha(reg[12]);
                        cubo.MarcaId = Select.Marca(reg[13]);
                        cubo.Vendedor = reg[14];
                        cubo.FormaPagamento = reg[15];
                        cubo.DataValidade = Select.ParseDate(reg[16]);
                        cubo.TipoVendaId = Select.TipoVenda(reg[17]);
                        cubo.DataFaturamento = Select.ParseDate(reg[18]);
                        cubo.NotaFiscal = reg[19];
                        cubo.Quantidade = Select.ParseFloat(reg[20]);
                        cubo.ValorUnitario = Select.ParseFloat(reg[21]);
                        cubo.ReceitaBruta = Select.ParseFloat(reg[22]);
                        cubo.ValorIpi = Select.ParseFloat(reg[23]);
                        cubo.ValorST = Select.ParseFloat(reg[24]);
                        cubo.PrazoPagMedio = Select.ParseInt(reg[25]);
                        cubo.FatuBruto = Select.ParseFloat(reg[26]);
                        cubo.MesCadastro = reg[27];
                        cubo.MesFatura = reg[28];
                        cubo.Faturado = Select.Faturado(reg[29]);
                        cubo.MesEntregue = reg[30];
                        cubo.ClienteNfDataFat = reg[31];
                        cubo.CodigoAjustado = reg[32];
                        cubo.CodNomeProdutoUnidade = reg[33];
                        cubo.UnidadeId = Select.Unidade(reg[34]);
                        cubo.QuantAjustada = Select.ParseFloat(reg[35]);
                        cubo.PesoProduto = Select.ParseFloat(reg[36]);
                        cubo.Juridico = Select.Juridico(reg[37]);
                        cubo.TipoClienteId = Select.TipoCliente(reg[38]);
                        cubo.CategoriaClienteId = Select.CategoriaCliente(reg[39]);
                        cubo.SegmentoCliente = reg[40];
                        cubo.Grupo = reg[41];
                        cubo.PrazoEntrega = Select.ParseInt(reg[42]);
                        cubo.TaxaDolar = Select.ParseFloat(reg[43]);
                        cubo.FatBrutoUsd = Select.ParseFloat(reg[44]);
                        cubo.PrecoIndividual = Select.ParseFloat(reg[45]);
                        cubo.ReceitaLiquida = Select.ParseFloat(reg[46]);
                        cubo.Comissao = Select.ParseFloat(reg[47]);
                        cubo.Frete = Select.ParseFloat(reg[48]);
                        cubo.CustoFinancCobranca = Select.ParseFloat(reg[49]);
                        cubo.GrupoRateioId = Select.GrupoRateio(reg[50]);
                        cubo.AnoFaturamento = Select.ParseInt(reg[51]);
                        cubo.TemPeso = Select.TemPeso(reg[52]);
                        cubo.PvRsKg = Select.ParseFloat(reg[53]);
                        cubo.Trimestre = reg[54];
                        cubo.M2Fitas = Select.ParseFloat(reg[55]);
                        cubo.RecBrutaUsd = Select.ParseFloat(reg[56]);
                        cubo.CategoProdAjustadaId = Select.Categoria(reg[57]);
                        cubo.PeriodoEstatistico = reg[58];
                        cubo.QuantIndividualAjustada = Select.ParseFloat(reg[59]);
                        cubo.IdVend = reg[60];
                        cubo.CodRegiaoOriginal = reg[61];
                        cubo.VlIcms = Select.ParseFloat(reg[62]);
                        cubo.VlCom = Select.ParseFloat(reg[63]);
                        cubo.Cnpj = reg[64];
                        cubo.CodProdOriginal = reg[65];

                        cubos.Add(cubo);
                        Console.WriteLine(i++);
                    }
                }

                db.SaveChanges();
            }
        } 
    }
}

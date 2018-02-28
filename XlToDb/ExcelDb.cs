﻿using System;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using XlToDb.Model;
using XlToDb.Models;
using System.Data.Entity;

namespace XlToDb
{
    public class ExcelDb
    {
        public void Produto()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Produtos);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

                for (int i = 2; i <= 1032; i++)
                {
                    var data = new Produto();

                    int j = 1;

                data.Apelido = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null
                    ? range.Cells[i, 1].Value2.ToString()
                    : "999999";
                data.Descricao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? range.Cells[i, j].Value2.ToString()
                    : "--";
                data.UnidadeId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.Unidade(range.Cells[i, j].Value2.ToString())
                    : 8;
                data.TipoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.Tipo(range.Cells[i, j].Value2.ToString())
                    : 4;
                data.ClasseCustoId =
                    range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.ClasseCusto(range.Cells[i, j].Value2.ToString())
                        : 9;
                data.CategoriaId =
                    range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.Categoria(range.Cells[i, j].Value2.ToString())
                        : 12;
                data.FamiliaId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.Familia(range.Cells[i, j].Value2.ToString())
                    : 15;
                data.LinhaId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.Linha(range.Cells[i, j].Value2.ToString())
                    : 12;
                data.GrupoRateioId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.GrupoRateio(range.Cells[i, j].Value2.ToString())
                    : 18;
                data.PesoLiquido = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? (float) range.Cells[i, j].Value2
                    : 0;
                data.Ativo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.Status(range.Cells[i, j].Value2.ToString())
                    : false;
                data.Ipi = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? (float) range.Cells[i, j].Value2
                    : 0;
                data.QtdUnid = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? (float) range.Cells[i, j].Value2
                    : 0;
                data.DominioId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.Dominio(range.Cells[i, j].Value2.ToString())
                    : 1;
                data.TipoProdId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? Select.TipoProducao(range.Cells[i, j].Value2.ToString())
                    : 3;
                data.RefAuxiliarProduto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? range.Cells[i, j].Value2.ToString()
                    : "--";
                data.QtUnPorUnArmz = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null 
                    ? (int)range.Cells[i, j].Value2 
                    : 0;
                data.MedidaFitaId = 32;

                j = 40;

                data.Acoes = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? range.Cells[i, j].Value2.ToString()
                    : "--";
                data.EventosAgVendasHistorico = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? (int)range.Cells[i, j].Value2
                    : 0;
                data.Acao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? range.Cells[i, j].Value2.ToString()
                    : "--";
                data.Codigo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                    ? range.Cells[i, j].Value2.ToString()
                    : "999999";


                db.Produtos.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i);
            }
             
        }

        public void ParteProduto()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.ParteProduto);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            try
            {
                for (int i = 2; i < range.Rows.Count + 1; i++)
                {
                    int j = 8;
                    var data = new ParteProduto
                    {
                        GrupoRateioId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.GrupoRateio(range.Cells[i, j].Value2.ToString()) : 18,
                        Peso = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        Status = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Status(range.Cells[i, j].Value2.ToString()) : false,
                        Ipi = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        QtdUndd = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        DominioId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Dominio(range.Cells[i, j].Value2.ToString()) : 1,
                        TipoProducaoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.TipoProducao(range.Cells[i, j].Value2.ToString()) : 3,
                        PcpId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Pcp(range.Cells[i, j].Value2.ToString()) : 1,
                        QtdUndArmz = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        ProdutoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? Select.Produto(range.Cells[i, 1].Value2.ToString()) : 4642
                    };

                    db.ParteProdutos.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, ex.Message);
            }
            finally
            {
                xlApp.Quit();
                workbook = null;
                worksheet = null;
                range = null;
            }
        }

        public void Estrutura()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Estrutura);
            Excel._Worksheet worksheet = workbook.Sheets[4];
            Excel.Range range = worksheet.UsedRange;

            
                for (int i = 2; i < 4826; i++)
                {

                    var data = new Estrutura();

                    data.ProdutoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null
                        ? Select.Produto(range.Cells[i, 1].Value2.ToString())
                        : 26470;
                    data.UnidadeId = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null
                        ? Select.Unidade(range.Cells[i, 3].Value2.ToString())
                        : 8;
                    data.QtdCusto = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null
                        ? (float) range.Cells[i, 4].Value2
                        : 0;
                    data.SequenciaId = range.Cells[i, 5] != null && range.Cells[i, 5].Value2 != null
                        ? Select.Sequencia(range.Cells[i, 5].Value2.ToString())
                        : 9;
                    data.Item = range.Cells[i, 6] != null && range.Cells[i, 6].Value2 != null
                        ? range.Cells[i, 6].Value2.ToString()
                        : "999999";
                    data.UnidadeCompraId = range.Cells[i, 8] != null && range.Cells[i, 8].Value2 != null
                        ? Select.Unidade(range.Cells[i, 8].Value2.ToString())
                        : 8;
                    data.Onera = range.Cells[i, 10] != null && range.Cells[i, 10].Value2 != null
                        ? Select.Onera(range.Cells[i, 10].Value2.ToString())
                        : false;
                    data.Lote = range.Cells[i, 11] != null && range.Cells[i, 11].Value2 != null
                        ? (float) range.Cells[i, 11].Value2
                        : 0;
                    data.Perda = range.Cells[i, 12] != null && range.Cells[i, 12].Value2 != null
                        ? (float) range.Cells[i, 12].Value2
                        : 0;
                    data.Observacao = range.Cells[i, 13] != null && range.Cells[i, 13].Value2 != null
                        ? range.Cells[i, 13].Value2.ToString()
                        : "--";
                    data.CategoriaId = range.Cells[i, 21] != null && range.Cells[i, 21].Value2 != null
                        ? Select.Categoria(range.Cells[i, 21].Value2.ToString())
                        : 12;
                    data.FamiliaId = range.Cells[i, 22] != null && range.Cells[i, 22].Value2 != null
                        ? Select.Familia(range.Cells[i, 22].Value2.ToString())
                        : 15;
                    data.LinhaId = range.Cells[i, 23] != null && range.Cells[i, 23].Value2 != null
                        ? Select.Linha(range.Cells[i, 23].Value2.ToString())
                        : 15;

                db.Estruturas.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            
            
        }

        public void QtdLoteComp()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Estrutura);
            Excel._Worksheet worksheet = workbook.Sheets[4];
            Excel.Range range = worksheet.UsedRange;
            int i = 1;
            var db = new EntityContext();
            var model = db.Estruturas;

            foreach (var register in model)
            {
                register.Lote = range.Cells[++i, 11] != null && range.Cells[i, 11].Value2 != null
                    ? (float) range.Cells[i, 11].Value2
                    : 0;
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void Perdas()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Estrutura);
            Excel._Worksheet worksheet = workbook.Sheets[4];
            Excel.Range range = worksheet.UsedRange;
            int i = 1;
            var db = new EntityContext();
            var model = db.Estruturas;

            foreach (var register in model)
            {
                register.Perda = range.Cells[++i, 12] != null && range.Cells[i, 12].Value2 != null
                    ? (float)range.Cells[i, 12].Value2
                    : 0;
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void Operacao()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Operacao);
            Excel._Worksheet worksheet = workbook.Sheets[5];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 53; i++)
            {
                var operacao = new Operacao
                {
                    CodigoOperacao = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? range.Cells[i, 1].Value2.ToString() : "999999",
                    SetorProducao = range.Cells[i, 2] != null && range.Cells[i, 2].Value2 != null ? range.Cells[i, 2].Value2.ToString() : "--",
                    Descricao = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null ? range.Cells[i, 3].Value2.ToString() : "--",
                    TaxaOcupacao = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null ? (float)range.Cells[i, 4].Value2 : 0,
                    Comentario = range.Cells[i, 5] != null && range.Cells[i, 5].Value2 != null ? range.Cells[i, 5].Value2.ToString() : "--",
                    QtdMaquinas = range.Cells[i, 6] != null && range.Cells[i, 6].Value2 != null ? (int)range.Cells[i, 6].Value2 : 1,
                    Custo = range.Cells[i, 7] != null && range.Cells[i, 7].Value2 != null ? (float)range.Cells[i, 7].Value2 : 0,
                    SetorId = range.Cells[i, 8] != null && range.Cells[i, 8].Value2 != null ? Select.Setor(range.Cells[i, 8].Value2.ToString()) : 22
                };

                db.Operacoes.Add(operacao);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void Folha()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Folha);
            Excel._Worksheet worksheet = workbook.Sheets[9];
            Excel.Range range = worksheet.UsedRange;

            var stack = new Stack<int>();
            stack.Push(15);
            stack.Push(14);
            stack.Push(13);
            stack.Push(12);
            stack.Push(11);
            stack.Push(9);
            stack.Push(8);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);

            try
            {
                for (int i = 1; i < 13; i++)
                {
                    int j = 21;
                    int k = (int)stack.Pop();
                    var data = new CustoFolha
                    {
                        Data = DateTime.Now,
                        Salario = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        Ferias = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        DecimoTerceiro = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        Plr = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        Fgts = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        Inss = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        DespAgencia = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        ConvMedico = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        VAlimentacao = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        VTransporte = range.Cells[++j, k] != null && range.Cells[j, k].Value2 != null ? (float)range.Cells[j, k].Value2 : 0,
                        AreaId = range.Cells[19, k] != null && range.Cells[19, k].Value2 != null ? Select.Area(range.Cells[19, k].Value2.ToString()) : 22
                    };

                    db.CustoFolhas.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, ex.Message);
            }
            finally
            {
                xlApp.Quit();
                workbook = null;
                worksheet = null;
                range = null;
            }
        }

        public void QtdEmbalagem()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.QtdEmbalagem);
            Excel._Worksheet worksheet = workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;

            try
            {
                for (int i = 3; i < 27; i++)
                {
                    int j = 13;

                    var data = new QtdEmbalagem
                    {
                        CartuchoRolCx = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        CartuchoCxPlt = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        DisplayRolCx = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        CarretelRolCx = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        CarretelCxPlt = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        MedidaFitasId = Select.MedidaFita(range.Cells[i, ++j].Value2.ToString(), range.Cells[i, ++j].Value2.ToString())
                    };

                    db.QtdEmbalagems.Add(data);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, ex.Message);
            }
            finally
            {
                xlApp.Quit();
                workbook = null;
                worksheet = null;
                range = null;
            }
        }

        public void Cotacao()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Cotacao);
            Excel._Worksheet worksheet = workbook.Sheets[2];
            Excel.Range range = worksheet.UsedRange;

            {
                for (int i = 2; i < range.Rows.Count + 1; i++)
                {
                    var data = new Cotacao
                    {
                        DateTime = DateTime.Now,
                        Descricao = range.Cells[i, 10] != null && range.Cells[i, 10].Value2 != null
                            ? range.Cells[i, 10].Value2.ToString()
                            : "--",
                        ProdutoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null
                            ? Select.Produto(range.Cells[i, 1].Value2.ToString())
                            : 4642
                    };

                    db.Cotacoes.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }
        }

        public void  Insumo()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Insumos);
            Excel._Worksheet worksheet = workbook.Sheets[2];
            Excel.Range range = worksheet.UsedRange;


                for (int i = 2; i < 502; i++)
                {
                    int j = 0;
                    var data = new Insumo();

                   data.Apelido = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? range.Cells[i, j].Value2.ToString()
                        : "999999";
                    data.Descricao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? range.Cells[i, j].Value2.ToString()
                        : "--";
                    data.UnidadeId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.Unidade(range.Cells[i, j].Value2.ToString())
                        : 8;
                    data.TipoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.Tipo(range.Cells[i, j].Value2.ToString())
                        : 4;
                    data.ClasseCustoId =
                        range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                            ? Select.ClasseCusto(range.Cells[i, j].Value2.ToString())
                            : 9;
                    data.CategoriaId =
                        range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                            ? Select.Categoria(range.Cells[i, j].Value2.ToString())
                            : 12;
                    data.FamiliaId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.Familia(range.Cells[i, j].Value2.ToString())
                        : 15;
                    data.LinhaId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.Linha(range.Cells[i, j].Value2.ToString())
                        : 12;
                    data.Peso = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? (float) range.Cells[i, j].Value2
                        : 0;
                    data.Cotacao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? range.Cells[i, j].Value2.ToString()
                        : "--";
                    data.PrecoUsd = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.PrecoRs = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Icms = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Ipi = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Pis = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Cofins = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.DespExtra = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.DespImport = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Ativo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Select.Status(range.Cells[i, j].Value2.ToString())
                        : false;
                    data.FinalidadeId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Finalidade(range.Cells[i, j].Value2.ToString()) : 4;
                    data.UnidadeConsumoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Unidade(range.Cells[i, j].Value2.ToString()) : 8;
                    data.QtdUnddConsumo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.QtdMltplCompra = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.FormaPgto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.Prazo1 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                    data.Prazo2 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                    data.PctPgto1 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.ImportPzPagDesp = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;

                    db.Insumos.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
        }

        public void Alteracao()
        {
            var db = new EntityContext();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Alteracao);
            Excel._Worksheet worksheet = workbook.Sheets[6];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 275; i++)
            {
                var data = new Ajuste();
                data.CodigoOriginal = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null
                    ? range.Cells[i, 1].Value2.ToString()
                    : "999999";
                data.DescricaoOriginal = range.Cells[i, 2] != null && range.Cells[i, 2].Value2 != null
                    ? range.Cells[i, 2].Value2.ToString()
                    : "--";
                data.UnidadeDeId = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null 
                    ? Select.Unidade(range.Cells[i, 3].Value2.ToString()) 
                    : 8;
                data.AtualId = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null 
                    ? Select.Produto(range.Cells[i, 4].Value2.ToString()) 
                    : 26470;
                data.UnidadeParaId = range.Cells[i, 6] != null && range.Cells[i, 6].Value2 != null
                    ? Select.Unidade(range.Cells[i, 6].Value2.ToString())
                    : 8;
                data.Fator = range.Cells[i, 7] != null && range.Cells[i, 7].Value2 != null 
                    ? (float)range.Cells[i, 7].Value2 
                    : 0;
                data.TipoAlteracaoId = range.Cells[i, 8] != null && range.Cells[i, 8].Value2 != null 
                    ? Select.TipoAlteracao(range.Cells[i, 8].Value2.ToString()) 
                    : 4;
                data.Medida = range.Cells[i, 9] != null && range.Cells[i, 9].Value2 != null 
                    ? (float)range.Cells[i, 9].Value2 
                    : 0;

                db.Ajustes.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void UpdateTipo()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Produtos);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Count + 1; i++)
            {
                string comp = range.Cells[i, 1].Value2.ToString();
                var data = db.Produtos.Single(p => p.Apelido == comp);
                data.TipoId = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null
                    ? Select.Tipo(range.Cells[i, 4].Value2.ToString())
                    : 4;
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void EncapTubos()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.EncapTubos);
            Excel._Worksheet worksheet = workbook.Sheets[12];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 9; i++)
            {
                int j = 2;
                var data = new EncapTubo();

                data.ProdutoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? Select.Produto(range.Cells[i, 1].Value2.ToString()) : 26470;
                data.UnidadeId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Unidade(range.Cells[i, j].Value2.ToString()) : 8;
                data.DextRevest = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.DintRevest = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.ResinaBase = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Aditivo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.DenRev = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.PesoRevest = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.VelRevest = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.PctCarga = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                

                db.EncapTubos.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void Graxas()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Graxas);
            Excel._Worksheet worksheet = workbook.Sheets[11];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 3; i < 31; i++)
            {
                var data = new Graxa();

                data.Apelido = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? range.Cells[i, 1].Value2.ToString() : "999999";
                data.Descricao = range.Cells[i, 2] != null && range.Cells[i, 2].Value2 != null ? range.Cells[i, 2].Value2.ToString() : "--";
                data.EmbalagemId = 18;
                data.Peso = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null ? (float)range.Cells[i, 4].Value2 : 0;
                data.PctSilicone = range.Cells[i, 5] != null && range.Cells[i, 5].Value2 != null ? (float)range.Cells[i, 5].Value2 : 0;
                data.PctSilica = range.Cells[i, 6] != null && range.Cells[i, 6].Value2 != null ? (float)range.Cells[i, 6].Value2 : 0;
                data.ResinaId = range.Cells[i, 8] != null && range.Cells[i, 8].Value2 != null ? Select.Resina(range.Cells[i, 8].Value2.ToString()) : 3;
                data.EmbalagemMedida = range.Cells[i, 11] != null && range.Cells[i, 11].Value2 != null ? (float)range.Cells[i, 11].Value2 : 0;
                data.Rotulagem = range.Cells[i, 12] != null && range.Cells[i, 12].Value2 != null ? (float)range.Cells[i, 12].Value2 : 0;

                db.Graxas.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void AjusteProdutos()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.AjusteProduto);
            Excel._Worksheet worksheet = workbook.Sheets[6];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Rows.Count + 1; i++)
            {
                int id = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? Select.Produto(range.Cells[i, 1].Value2.ToString()) : 14844;
                var data = db.Produtos.SingleOrDefault(p => p.Id == id);
                if (data != null)
                {
                    data.MedidaFitaId = range.Cells[i, 31] != null && range.Cells[i, 31].Value2 != null ? Select.MedidaFita(range.Cells[i, 31].Value2.ToString()) : 32;
                }

                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void PadraoFixo()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PadraoFixo);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 3; i < 38; i++)
            {
                var data = new PadraoFixo
                {
                    Descricao = range.Cells[i, 17] != null && range.Cells[i, 17].Value2 != null ? range.Cells[i, 17].Value2.ToString() : "--",
                    Valor = range.Cells[i, 18] != null && range.Cells[i, 18].Value2 != null ? (float)range.Cells[i, 18].Value2 : 0
                };

                db.PadroesFixos.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void PreForma()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PreForma);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 3; i < 11; i++)
            {
                int j = 0;
                var data = new PreForma();
                data.PreFormaNum = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.FormaDiamE = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.VaretaDiamI = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.Medidas = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Comprimento = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.Tup = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.PrensaPreFormaId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Prensa(range.Cells[i, j].Value2.ToString()) : 4;
                data.Preparo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.TrocaPf = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.ExtrusoraId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Extrusora(range.Cells[i, j].Value2.ToString()) : 3;
                data.DiamPistaoHidraulico = range.Cells[i, 14] != null && range.Cells[i, 14].Value2 != null ? (float)range.Cells[i, 14].Value2 : 0;

                db.PreFormas.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void ResinaPtfe()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Resina);
            Excel._Worksheet worksheet = workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Rows.Count + 1; i++)
            {
                int j = 0;
                var data = new ResinaPtfe();
                data.Ref = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.Referencia = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.FabricanteId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Fabricante(range.Cells[i, j].Value2.ToString()) : 5;
                data.ResinaBaseId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.ResinaBase(range.Cells[i, j].Value2.ToString()) : 4;
                data.InsumoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Insumo(range.Cells[i, j].Value2.ToString()) : 2450;
                data.Custo = range.Cells[i, 11] != null && range.Cells[i, 11].Value2 != null ? (float)range.Cells[i, 11].Value2 : 0;
                data.MaxRr = range.Cells[i, 12] != null && range.Cells[i, 12].Value2 != null ? (int)range.Cells[i, 12].Value2 : 0;
                data.Classificacao = range.Cells[i, 13] != null && range.Cells[i, 13].Value2 != null ? range.Cells[i, 13].Value2.ToString() : "--";
                data.MaxRrAntiga = range.Cells[i, 14] != null && range.Cells[i, 14].Value2 != null ? (int)range.Cells[i, 14].Value2 : 0;

                db.ResinasPtfe.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void ProcTubo()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.ProcTubo);
            Excel._Worksheet worksheet = workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Rows.Count + 1; i++)
            {
                var data = new ProcTubo();

                data.ProdutoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? Select.Produto(range.Cells[i, 1].Value2.ToString()) : 16895;
                data.ResinaBaseId = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null ? Select.ResinaBase(range.Cells[i, 3].Value2.ToString()) : 4;
                data.DiamExterno = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null ? (float)range.Cells[i, 4].Value2 : 0;
                data.DiamInterno = range.Cells[i, 5] != null && range.Cells[i, 5].Value2 != null ? (float)range.Cells[i, 5].Value2 : 0;
                data.SerieId = range.Cells[i, 6] != null && range.Cells[i, 6].Value2 != null ? Select.Serie(range.Cells[i, 6].Value2.ToString()) : 17;
                data.Carga1Id = range.Cells[i, 7] != null && range.Cells[i, 7].Value2 != null ? Select.Carga(range.Cells[i, 7].Value2.ToString()) : 15;
                data.PctCarga1 = range.Cells[i, 8] != null && range.Cells[i, 8].Value2 != null ? (float)range.Cells[i, 8].Value2 : 0;
                data.Carga2Id = range.Cells[i, 9] != null && range.Cells[i, 9].Value2 != null ? Select.Carga(range.Cells[i, 9].Value2.ToString()) : 15;
                data.PctCarga2 = range.Cells[i, 10] != null && range.Cells[i, 10].Value2 != null ? (float)range.Cells[i, 10].Value2 : 0;
                data.Sinterizado = range.Cells[i, 11] != null && range.Cells[i, 11].Value2 != null ? Select.Sinterizado(range.Cells[i, 11].Value2.ToString()) : true;
                data.FatorMultiplQtde = range.Cells[i, 26] != null && range.Cells[i, 26].Value2 != null ? (int)range.Cells[i, 26].Value2 : 0;
                data.EmbalagemId = range.Cells[i, 28] != null && range.Cells[i, 28].Value2 != null ? Select.Embalagem(range.Cells[i, 28].Value2.ToString()) : 16;
                data.QuantEmbalagem = range.Cells[i, 29] != null && range.Cells[i, 29].Value2 != null ? (int)range.Cells[i, 29].Value2 : 0;
                data.ProcessoContinuo = range.Cells[i, 30] != null && range.Cells[i, 30].Value2 != null ? Select.ProcessoContinuo(range.Cells[i, 30].Value2.ToString()) : true;
                data.FatorMultiplVExter = range.Cells[i, 32] != null && range.Cells[i, 32].Value2 != null ? (int)range.Cells[i, 32].Value2 : 0;
                data.FatorMultiplVelSint = range.Cells[i, 34] != null && range.Cells[i, 34].Value2 != null ? (int)range.Cells[i, 34].Value2 : 0;
                data.TesteEstqEsto = range.Cells[i, 36] != null && range.Cells[i, 36].Value2 != null ? Select.TesteEstqEstoq(range.Cells[i, 36].Value2.ToString()) : true;
                data.Cadastro = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? range.Cells[i, 1].Value2.ToString() : "--";

                db.ProcTubos.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void CustoCargosDiretos()
        {
            using (var db = new EntityContext())
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Cargos);
                Excel._Worksheet worksheet = workbook.Sheets[13];
                Excel.Range range = worksheet.UsedRange;

                for (int i = 4; i < 15; i++)
                {
                    int j = 1;

                    var data = new CustoCargoDireto
                    {
                        SetorId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Setor(range.Cells[i, j].Value2.ToString()) : 22,
                        Operadores = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0,
                        MoDireta = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        CodigoLiderApoio = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--",
                        MoDiretaLiderApoio = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        HorasModOperadores = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        HorasModTotal = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        CustoUnitario = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        RateioSetor20 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        RateioSetor40 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        RateioSetor50 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        RateioSetor60 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        SomaIndiretos = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        SomaDiretoIndireto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0,
                        RateioCustoUnitario = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0
                    };

                    db.CustoCargoDiretos.Add(data);
                    db.SaveChanges();
                    Console.WriteLine(i); 
                }
            }
        }

        public void DespesaFixa()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.DespFixa);
            Excel._Worksheet worksheet = workbook.Sheets[2];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 201; i++)
            {
                int j = 0;
                var data = new DespesaFixa();

                data.Despesa = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.ValorTotal = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.Comentario = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.CodCrit = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.CriterioRateio = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.RateioFitas = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioTuboCordaoPerfil = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioFioGaxPtfePuro = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioFioGaxPtfeGraf = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioGraxa = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioSucatas = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioRevenda = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.Somas = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;


                db.DespesasFixas.Add(data);
                db.SaveChanges();
                Console.WriteLine(i); ;
            }
        }

        public void PrecoNacional()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PrecoNacional);
            Excel._Worksheet worksheet = workbook.Sheets[2];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 8; i < 388; i++)
            {
                int j = 0;
                var data = new PrecoNacional();

                data.LinhaUn = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Descricao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Apelido = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Ipi = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.QtUnid = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.TipoProducaoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.TipoProducao(range.Cells[i, j].Value2.ToString()) : 3;
                j = 15;
                data.Com = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.LlMin = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.PrecoRefer = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.AplicRoteiro = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.CustoDireto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioCustoFixo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.Aumento = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;

                db.PrecosNacionais.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void PrecoExportacao()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PrecoExportacao);
            Excel._Worksheet worksheet = workbook.Sheets[4];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 9; i < 778; i++)
            {
                int j = 0;
                bool ok;
                string x;
                float temp;
                var data = new PrecoExportacao();
                data.LinhaUn = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Descricao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                data.Apelido = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                x = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "0";
                ok = float.TryParse(x, out temp);
                data.PesoLiquido = ok ? temp : 0;
                data.QtUnid = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.De2A5 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.De5A10 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.De10A20 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.Acima20 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.Com = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.LlMin = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.CondicaoPrecoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.CondicaoPreco(range.Cells[i, j].Value2.ToString()) : 4;
                data.PctRateio = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.CondPag = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.IEfetiva = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.PctEspecFrete = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.DespExpPadrao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.DespesaPadrao(range.Cells[i, j].Value2.ToString()) : true;
                data.PctDespExportEspec = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                x = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "0";
                ok = float.TryParse(x, out temp);
                data.PvFobMax = ok ? temp : 0;
                data.CustoDireto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.RateioCustoFixo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                x = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "0";
                ok = float.TryParse(x, out temp);
                data.PvFobMin = ok ? temp : 0;
                data.ValorCifPtfe = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                x = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "0";
                ok = float.TryParse(x, out temp);
                data.RelPtfeSobrePv = ok ? temp : 0;

                db.PrecosExportacao.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void AddPtfe2Produto()
        {
            var db = new EntityContext();
            var produtos = db.Produtos;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PctPtfe);
            Excel._Worksheet worksheet = workbook.Sheets[6];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Rows.Count + 1; i++)
            {
                string apelido = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null
                        ? range.Cells[i, 1].Value2.ToString()
                        : "999999";
                var produto = produtos.Single(p => p.Apelido == apelido);
                produto.PctPtfePeso = range.Cells[i, 23] != null && range.Cells[i, 23].Value2 != null ? (float)range.Cells[i, 23].Value2 : 0;
                db.SaveChanges();
                Console.WriteLine(i);
            }

        }

        public void TipoProducaoProduto()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Produtos);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Rows.Count + 1; i++)
            {
                string apelido = range.Cells[i, 1].Value2.ToString();
                var produto = db.Produtos.Single(p => p.Apelido == apelido);
                string tipoProducao = range.Cells[i, 15] != null && range.Cells[i, 15].Value2 != null ? range.Cells[i, 15].Value2.ToString() : "ND";
                produto.TipoProdId = Select.TipoProducao(tipoProducao);
                Console.WriteLine(i);
            }

            db.SaveChanges();
        }

        public void DfxProdRev()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.DfxProdRev);
            Excel._Worksheet worksheet = workbook.Sheets[4];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 15; i++)
            {
                int j = 3;
                var data = new DfxProdRev();
                data.ProdutoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? Select.Produto(range.Cells[i, 1].Value2.ToString()) : 26470;
                data.UnidadeId = 1;
                data.QtdUnidade = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.QtdCompra = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                data.PrecoCompra = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;

                db.DfxProdRevs.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void GrupoRateioProduto()
        {
            var db = new EntityContext();


            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Produtos);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 1025 ; i++)
            {
                string apelido = range.Cells[i, 1].Value2.ToString();
                var data = db.Produtos.Single(p => p.Apelido == apelido);

                data.GrupoRateioId = range.Cells[i, 9] != null && range.Cells[i, 9].Value2 != null
                    ? Select.GrupoRateio(range.Cells[i, 9].Value2.ToString())
                    : 18;

                Console.WriteLine(i);
            }

            db.SaveChanges();
        }

        public void PlanejMod()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejMod);
            Excel._Worksheet worksheet = workbook.Sheets[4];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 6; i < 59; i++)
            {
                int j = 4;
                var data = new PlanejMod();
                data.OperacaoId = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? Select.Operacao(range.Cells[i, 1].Value2.ToString()) : 583;
                data.UnidadeId = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null ? Select.Unidade(range.Cells[i, 3].Value2.ToString()) : 8;
                data.SomaDe1 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe2 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe3 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe4 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe5 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe6 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe7 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe8 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe9 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe10 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe11 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe12 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SetorId = range.Cells[i, 29] != null && range.Cells[i, 29].Value2 != null ? Select.Setor(range.Cells[i, 29].Value2.ToString()) : 22;
                data.MediaMensal = range.Cells[i, 30] != null && range.Cells[i, 30].Value2 != null ? (float)range.Cells[i, 30].Value2 : 0;

                db.PlanejMods.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void CuboEstoque()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.CuboEstoque);
            Excel._Worksheet worksheet = workbook.Sheets[8];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < range.Rows.Count + 1; i++)
            {
                var data = new CuboEstoque();

                data.Apelido = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? range.Cells[i, 1].Value2.ToString() : "--";
                data.Descricao = range.Cells[i, 2] != null && range.Cells[i, 2].Value2 != null ? range.Cells[i, 2].Value2.ToString() : "--";
                data.ClasseCusto = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null ? range.Cells[i, 3].Value2.ToString() : "--";
                data.Quantidade = range.Cells[i, 4] != null && range.Cells[i, 4].Value2 != null ? (float)range.Cells[i, 4].Value2 : 0;

                db.CubosEstoque.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void PlanejCompra()
        {
            var db = new EntityContext();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejCompra);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 6; i < 277; i++)
            {
                var data = new PlanejCompra();
                int j = 4;

                data.InsumoId = range.Cells[i, 2] != null && range.Cells[i, 2].Value2 != null ? Select.Insumo(range.Cells[i, 2].Value2.ToString()) : 6229;
                data.SomaDe1 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe2 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe3 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe4 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe5 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe6 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe7 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe8 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe9 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe10 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe11 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.SomaDe12 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                data.UnidadeId = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null ? Select.Unidade(range.Cells[i, 3].Value2.ToString()) : 8;

                db.PlanejCompras.Add(data);
                db.SaveChanges();
                Console.WriteLine(i);
            }
        }

        public void PlanejNecessid()
        {
            var db = new EntityContext();
            var estruturas = db.Estruturas.ToList();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejNecessid);
            Excel._Worksheet worksheet = workbook.Sheets[2];
            Excel.Range range = worksheet.UsedRange;
            int i = 0;

            foreach (var stru in estruturas)
            {
                var plan = new PlanejNecessid
                {
                    EstruturaId = stru.Id
                };

                db.PlanejNecessides.Add(plan);
                db.SaveChanges();
                Console.WriteLine(i++);
            }
        }

        public void PlanejVendas()
        {
            using (var db = new EntityContext())
            {
                var produtos = db.Produtos.ToList();
                int i = 0;

                foreach (var produto in produtos)
                {
                    var data = new PlanejVenda
                    {
                        ProdutoId = produto.Id,
                        RefAno = DateTime.Parse("15/12/2017")
                    };

                    db.PlanejVendas.Add(data);
                    Console.WriteLine(i++); 
                }
                db.SaveChanges();
            }
        }

        public void FatHistorico()
        {
            using (var db = new EntityContext())
            {
                var produtos = db.FatHistoricos.ToList();
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook workbook = xlApp.Workbooks.Open(Files.FatHistorico);
                Excel._Worksheet worksheet = workbook.Sheets[2];
                Excel.Range range = worksheet.UsedRange;

                for (int i = 2; i < 21980; i++)
                {
                    int j = 3;
                    var data = new FatHistorico();
                    data.NumeroPedido = range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null ? range.Cells[i, 1].Value2.ToString() : "--";
                    data.DataPedido = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Function.ExcelToDate(range.Cells[i, j].Value2.ToString())
                        : DateTime.Parse("01/01/2018");
                    data.Cliente = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.Estado = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.Cidade = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.Regiao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.ProdutoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Produto(range.Cells[i, j].Value2.ToString()) : 26470;
                    j = 14;
                    data.Vendedor = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.FormaPagamento = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.DataValidade = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Function.ExcelToDate(range.Cells[i, j].Value2.ToString())
                        : DateTime.Parse("01/01/2018");
                    data.TipoVenda = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.DataFaturamento = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null
                        ? Function.ExcelToDate(range.Cells[i, j].Value2.ToString())
                        : DateTime.Parse("01/01/2018");
                    data.NotaFiscal = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)Select.QuantAjustada(range.Cells[i, j].Value2.ToString()) : 0;
                    data.Quantidade = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.ValorUnitario = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.ValorMercadoria = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.ValorIpi = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.ValorSubstTributaria = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.PrazoMedioRecebimento = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                    //data.RecBruta = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0; // **** Removido dac Jan/2018
                    data.FaturBruto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.MesCadastro = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.AnoMesFatura = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.Situacao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.MesEntrega = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.ClientePedido = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.ProdutoAjustadoId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Produto(range.Cells[i, j].Value2.ToString()) : 26470;
                    j = 34;
                    data.UnidAjustadaId = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.Unidade(range.Cells[i, j].Value2.ToString()) : 8;
                    data.QuantAjustada = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.QuantAjustada(range.Cells[i, j].Value2.ToString()) : 0;
                    data.PesoProduto = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.QuantAjustada(range.Cells[i, j].Value2.ToString()) : 0;
                    data.NaturCli = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "-";
                    data.TipoCliente = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.CategoriaCliente = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.SegmentoCliente = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.Grupo = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";
                    data.PrazoEntrega = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                    data.TxDolar = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.FatBrutoUsd = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.PrecoIndividual = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.ReceitaLiquida = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Comissao = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Frete = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.CstFinBobranca = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? Select.QuantAjustada(range.Cells[i, j].Value2.ToString()) : 0;
                    j++;
                    data.QtUnidIndividual = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.Icms = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.PrazoFatur = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    data.HorasMod = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    //data.ComGvComacs = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                    //data.DescrProdAjustado = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "-";
                    //data.ProdCategoriaAjustado = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "-";
                    j++;
                    j++;
                    data.ProdCategoriaAjustado = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString() : "--";

                    db.FatHistoricos.Add(data);
                    Console.WriteLine(i); 
                }

                db.SaveChanges();
            }
        }

        public void AnoPlanejVendas()
        {
            var db = new EntityContext();
            var plan = db.PlanejVendas.ToList();
            int i = 0;

            foreach (var pv in plan)
            {
                pv.RefAno = DateTime.Parse("01/01/2018");
                Console.WriteLine(i++);
            }

            db.SaveChanges();
        }

        public void VarsPlanejVendas()
        {
            var db = new EntityContext();
            var plan = db.PlanejVendas;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejVendas);
            Excel._Worksheet worksheet = workbook.Sheets[5];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 6; i < 269; i++)
            {
                int j = 61;
                string apelido = range.Cells[i, 5].Value2.ToString();
                var planej = plan.SingleOrDefault(p => p.Produto.Apelido == apelido);
                planej.Criterio = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString().ToLower() : "-";
                planej.VartC1 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.VarTc2 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.VartC3 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.VartC4 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;

                Console.WriteLine(i);
            }

            db.SaveChanges();
        }

        public void PlanejVendasVpVarPv()
        {
            var db = new EntityContext();
            var plan = db.PlanejVendas;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejVendas);
            Excel._Worksheet worksheet = workbook.Sheets[5];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 6; i < 269; i++)
            {
                int j = 92;
                string apelido = range.Cells[i, 5].Value2.ToString();
                var planej = plan.SingleOrDefault(p => p.Produto.Apelido == apelido);
                planej.PvvpvaVarPvAnoMenos12 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos11 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos10 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos9 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos8 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos7 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos6 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos5 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos4 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos3 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAnoMenos2 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;
                planej.PvvpvaVarPvAno = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;

                Console.WriteLine(i);
            }

            db.SaveChanges();
        }

        public void VarPvPlanejVendas()
        {
            var db = new EntityContext();
            var plan = db.PlanejVendas;
            int i = 0;

            foreach (var planej in plan)
            {

                planej.PvvpvaVarPvAnoMenos12 = 0;
                planej.PvvpvaVarPvAnoMenos12 = 0.15f;
                planej.PvvpvaVarPvAnoMenos10 = 0.15f;
                planej.PvvpvaVarPvAnoMenos9 = 0.15f;
                planej.PvvpvaVarPvAnoMenos8 = 0.15f;
                planej.PvvpvaVarPvAnoMenos7 = 0.15f;
                planej.PvvpvaVarPvAnoMenos6 = 0.15f;
                planej.PvvpvaVarPvAnoMenos5 = 0.15f;
                planej.PvvpvaVarPvAnoMenos4 = 0.15f;
                planej.PvvpvaVarPvAnoMenos3 = 0.15f;
                planej.PvvpvaVarPvAnoMenos2 = 0.15f;
                planej.PvvpvaVarPvAno = 0.15f;

                Console.WriteLine(i++);
            }

            db.SaveChanges();
        }

        public void PqeCriterioPlanejVendas()
        {
            var db = new EntityContext();
            var plan = db.PlanejVendas;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejVendas);
            Excel._Worksheet worksheet = workbook.Sheets[5];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 6; i < 269; i++)
            {
                int j = 180;
                string apelido = range.Cells[i, 5].Value2.ToString();
                var planej = plan.SingleOrDefault(p => p.Produto.Apelido == apelido);
                planej.PqeCriterio = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? range.Cells[i, j].Value2.ToString().ToLower() : "-";
                planej.PqeAumDim = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (int)range.Cells[i, j].Value2 : 0;

                Console.WriteLine(i);
            }

            db.SaveChanges();
        }

        public void PvppaVPVexPlanejVendas()
        {
            var db = new EntityContext();
            var plan = db.PlanejVendas;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.PlanejVendas);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 6; i < 269; i++)
            {
                int j = 208;
                string apelido = range.Cells[i, 5].Value2.ToString();
                var planej = plan.SingleOrDefault(p => p.Produto.Apelido == apelido);
                planej.PvppvaVPVexAnoMenos12 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos11 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos10 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos9 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos8 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos7 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos6 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos5 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos4 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos3 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAnoMenos2 = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;
                planej.PvppvaVPVexAno = range.Cells[i, ++j] != null && range.Cells[i, j].Value2 != null ? (float)range.Cells[i, j].Value2 : 0;

                Console.WriteLine(i);
            }

            db.SaveChanges();
        }

        public void PlanejProducao()
        {
            var db = new EntityContext();
            var produtos = db.Produtos.ToList();
            int i = 0;

            foreach (var item in produtos)
            {
                var pp = new PlanejProducao();
                pp.ProdutoId = item.Id;
                db.PlanejProducoes.Add(pp);
                db.SaveChanges();

                Console.WriteLine(i++);
            }
        }

        public void Recorrencia()
        {
            var db = new EntityContext();
            var produtos = db.Produtos;
            int i = 0;

            foreach (var produto in produtos)
            {
                produto.CustODirTotal = 0;
                Console.WriteLine(i++);
            }

            var estruturas = db.Estruturas;

            foreach (var estrutura in estruturas)
            {
                estrutura.CustoUnitCompra = 0;
                estrutura.CstCmprUndPrd = 0;
                Console.WriteLine(i++);
            }

            db.SaveChanges();
        }

        public void SetLinhaInsumo()
        {
            var db = new EntityContext();
            var insumos = db.Insumos;

            //for (int i = 2; i < 502; i++)
            //{
            //    int codigo = int.Parse(range.Cells[i, 1].Value2.ToString());
            //    var linha = range.Cells[i, 8] != null && range.Cells[i, 8].Value2 != null ? range.Cells[i, 8].Value2.ToString() : "----";
            //    Insumo insumo = insumos.Find(codigo);
            //    var LinhaId = Select.Linha(linha);
            //    insumo.LinhaId = LinhaId;
            //    db.SaveChanges();
            //    Console.WriteLine(i);
            //}
        }

        public void SetProductUnity()
        {
            var db = new EntityContext();
            var produtos = db.Produtos;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.Produtos);
            Excel._Worksheet worksheet = workbook.Sheets[3];
            Excel.Range range = worksheet.UsedRange;

            for (int i = 2; i < 1032; i++)
            {
                int codigo = int.Parse(range.Cells[i, 1].Value2.ToString());
                var produto = produtos.Find(codigo);
                produto.UnidadeId = range.Cells[i, 3] != null && range.Cells[i, 3].Value2 != null
                        ? Select.Unidade(range.Cells[i, 3].Value2.ToString())
                        : 8;
                Console.WriteLine(i);
            }

            db.SaveChanges();
        }
    }
}

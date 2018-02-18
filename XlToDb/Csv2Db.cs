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
            var db = new EntityContext();
            var cubos = db.CubosTrabalhados;
            string[] lines = File.ReadAllLines(Files.cuboTeste, Encoding.Default);
            bool header = true;

            foreach (string line in lines)
            {
                if (header) header = false;
                else
                {
                    var reg = line.Split(';');
                    var cubo = new CuboTrabalhado();
                    cubo.Pedido = reg[0];
                    cubo.DataPedido = DateTime.Parse(reg[3]);
                    cubo.Cliente = reg[4];
                    cubo.UF = Select.Uf(reg[5]);
                    cubo.Cidade = reg[6];
                    cubo.Regiao = reg[7];
                    cubo.Codigo = reg[8];
                    cubo.Produto = reg[9];


                }
            }
        }
    }
}

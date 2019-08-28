using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Models
{
    public class ProdutosRepository
    {
        public readonly ProdutosContext conn;

        public ProdutosRepository()
        {
            this.conn = new ProdutosContext();
        }

        public List<Produtos> ListProdutos()
        {
            return conn.Produtos.ToList();
        }

        public Produtos ListProdutoId(int id)
        {
            return conn.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Produtos produtos)
        {
            Produtos produto = new Produtos();

            produto.Produto = produtos.Produto;
            produto.Preco = produtos.Preco;
            produto.Sku = produtos.Sku;

            conn.Produtos.Add(produto);
            conn.SaveChanges();
        }

        public void Update(int id, Produtos produto)
        {
            Produtos produtos = conn.Produtos.Where(x => x.Id == id).FirstOrDefault();
            produtos.Produto = produto.Produto;
            produtos.Preco = produto.Preco;
            produtos.Sku = produto.Sku;
            
            conn.Entry(produtos).State = EntityState.Modified;
            conn.SaveChanges();
        }

        public void DeleteProdutos(int id) // delete the client from table
        {
            Produtos produtos = conn.Produtos.Where(x => x.Id == id).FirstOrDefault();

            conn.Produtos.Remove(produtos);
            conn.SaveChanges();
        }
    }
}

using MongoAPI.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Controllers
{
    public class ProdutosService
    {
        private readonly IMongoCollection<Produtos> _produtos;

        public ProdutosService(IProdutosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<Produtos>(settings.ProdutoCollectionName);
        }

        public List<Produtos> Get()
        {
             _produtos.Find(produto => true).ToList();
        }

        public Produtos Get(string id) =>
            _produtos.Find<Produtos>(produtos => produtos.Id == id).FirstOrDefault();

        public Produtos Create(Produtos produtos)
        {
            _produtos.InsertOne(produtos);
            return produtos;
        }

        public void Update(string id, Produtos produtosIn) =>
            _produtos.ReplaceOne(produtos => produtos.Id == id, produtosIn);

        public void Remove(Produtos produtosIn) =>
            _produtos.DeleteOne(produtos => produtos.Id == produtosIn.Id);

        public void Remove(string id) =>
            _produtos.DeleteOne(produtos => produtos.Id == id);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Model
{
        public class ProdutosDatabaseSettings : IProdutosDatabaseSettings
        {
            public string ProdutoCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IProdutosDatabaseSettings
        {
            string ProdutoCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
}

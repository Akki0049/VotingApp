using MongoDB.Driver;
using Voting.API.Models;

namespace Voting.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertMany(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    CandidateName = "Sunil Tatkare",
                    Party = "Shivsena Shinde Gat",
                    PartyImage = "product-1.png",
                    WardNo = 1,
                    City = "South Mumbai"
                },
                new Product
                {
                    CandidateName = "Rajan Vichare",
                    Party = "Shivsena Thakare Gat",
                    PartyImage = "product-2.png",
                    WardNo = 147,
                    City = "Thane"
                },
                new Product
                {
                    CandidateName = "Manoj Kotak",
                    Party = "BJP",
                    PartyImage = "product-3.png",
                    WardNo = 145,
                    City = "Mulund"
                },
                new Product
                {
                    CandidateName = "Prashant Thakur",
                    Party = "BJP",
                    PartyImage = "product-4.png",
                    WardNo = 188,
                    City = "Panvel"
                },
                new Product
                {
                    CandidateName = "Ganesh Naik",
                    Party = "NCP",
                    PartyImage = "product-5.png",
                    WardNo = 151,
                    City = "Belapur"
                },
                new Product
                {
                    CandidateName = "Rajesh More",
                    Party = "Shivsena",
                    PartyImage = "product-6.png",
                    WardNo = 144,
                    City = "Kalyan"
                },
                new Product
                {
                    CandidateName = "Sharad Pawar",
                    Party = "NCP",
                    PartyImage = "product-7.png",
                    WardNo = 38,
                    City = "Baramati"
                }
            };
        }
    }
}
using Voting.Client.Models;

namespace Voting.client.Data
{
    public static class ProductContext
    {
        public static readonly List<Product> Products = new List<Product>
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
        }
    };
    }
}
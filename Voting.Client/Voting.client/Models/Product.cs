namespace Voting.Client.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string CandidateName { get; set; }
        public string Party { get; set; }
        public string City { get; set; }
        public string PartyImage { get; set; }
        public decimal WardNo { get; set; }
    }
}
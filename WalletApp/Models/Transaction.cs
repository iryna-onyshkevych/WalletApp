namespace WalletApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; } //foreign key
        public string Type { get; set; } //options
        public string Sum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; } //options
        public bool Pending { get; set; } //options
        public string? AuthorizedUser { get; set; }
        //public ImageSource Icon { get; set; }
    }
}

namespace granthum_api.Models
{
    public class InvoiceRecord
    {
        public int Id { get; set; }

        public bool importedSuccessfully { get; set; }

        public string name { get; set; }

        public DateTime Time { get; set; }
    }
}

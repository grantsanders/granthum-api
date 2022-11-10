namespace granthum_api.Models
{
    public class InvoiceRecord
    {
        public InvoiceRecord() { }

        public int Id { get; set; }

        public bool importedSuccessfully { get; set; }

        public string name { get; set; }

        public DateTime time = DateTime.Now;
    }
}

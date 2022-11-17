namespace granthum_api.Models
{
    public class InvoiceRecord
    {
        public InvoiceRecord() {

        }
        public string? Id { get; set; }
        public bool? ImportedSuccessfully { get; set; }
        public string? NumberOfInvoices { get; set; }
        public string? Created { get; set; }
        public string? Note { get; set; }

    }
}

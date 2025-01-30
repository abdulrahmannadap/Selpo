namespace Selpo.Models
{
    public class BillingViewModel
    {
        // For multiple records
        public IEnumerable<Company>? CompanyList { get; set; }
        public IEnumerable<InvoicePrint>? InvoiceList { get; set; }
        public IEnumerable<Receipt>? ReceiptList { get; set; }
        public IEnumerable<Sender>? SenderList { get; set; }
        public IEnumerable<TransactionDetail>? TransactionList { get; set; }

        // For single records
        public Company? Company { get; set; }
        public InvoicePrint? Invoice { get; set; }
        public Receipt? Receipt { get; set; }
        public Sender? Sender { get; set; }
        public TransactionDetail? Transaction { get; set; }
    }
}

using Solution.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Services.InvoiceItem.Model
{
    public partial class InvoiceItemModel : ObservableObject
    {
        [ObservableProperty]
        [JsonPropertyName("id")]
        private int id;

        [ObservableProperty]
        [JsonPropertyName("account_number")]
        private string accountnumber; 

        [ObservableProperty]
        [JsonPropertyName("appelation")]
        private string appelation;

        [ObservableProperty]
        [JsonPropertyName("unit_price")]
        private double unitprice;

        [ObservableProperty]
        [JsonPropertyName("unit_quantity")]
        private int unitquantity;
        public InvoiceItemModel() { }
        public InvoiceItemModel(InvoiceItemEntity entity)
        {
            this.Id = entity.Id;
            this.Accountnumber = entity.AccountNumber;
            this.Appelation = entity.Appelation;
            this.Unitprice = entity.UnitPrice;
            this.Unitquantity = entity.UnitQuantity;
        }
        public InvoiceItemEntity ToEntity()
        {
            return new InvoiceItemEntity
            {
                Id = this.Id,
                AccountNumber = this.Accountnumber,
                Appelation = this.Appelation,
                UnitPrice = this.Unitprice,
                UnitQuantity = this.Unitquantity
            };
        }
        public void ToEntity(InvoiceItemEntity entity)
        {
            entity.Id = this.Id;
            entity.AccountNumber = this.Accountnumber;
            entity.Appelation = this.Appelation;
            entity.UnitPrice = this.Unitprice;
            entity.UnitQuantity = this.Unitquantity;
        }
    }
}

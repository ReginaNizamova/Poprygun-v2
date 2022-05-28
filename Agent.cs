//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Poprygunchic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            this.AgentPriorityHistories = new HashSet<AgentPriorityHistory>();
            this.ProductSales = new HashSet<ProductSale>();
            this.Shops = new HashSet<Shop>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int AgentTypeID { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string DirectorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public int Priority { get; set; }

        static DateTime firstDate = Convert.ToDateTime("2019.01.01");
        static DateTime lastDate = Convert.ToDateTime("2019.12.31");

        public int ProductCountForLastYear
        {
            get
            {
                return PoprygunchicEntities.GetContext().ProductSales.Where(x => x.SaleDate > firstDate && x.SaleDate < lastDate && x.AgentID == this.ID).Select(x => x.ProductCount).FirstOrDefault();
            }

            set
            {

            }
        }

        public int PersentCount
        { 
            get
            {
                var sum = Convert.ToInt32(this.ProductSales.Select(x => x.ProductCount).FirstOrDefault() * this.ProductSales.Select(x => x.Product.MinCostForAgent).FirstOrDefault());
                int percent = 0;

                if (sum >= 0 && sum < 10000)
                    percent = 0;
                else if (sum >= 10000 && sum < 50000)
                    percent = 5;
                else if (sum >= 50000 && sum < 150000)
                    percent = 10;
                else if (sum >= 150000 && sum < 500000)
                    percent = 20;
                else if (sum >= 500000)
                    percent = 25;
                return percent;
            }

            set
            {

            }
        }


        public virtual AgentType AgentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shops { get; set; }
    }
}

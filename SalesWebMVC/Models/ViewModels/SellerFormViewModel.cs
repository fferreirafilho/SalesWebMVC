using System.Collections.Generic;

namespace SalesWebMVC.Models.ViewModels {
    public class SellerFormViewModel {
        public Seller Seller { get; set; }
        public ICollection<Department> Department { get; set; }
    }
}

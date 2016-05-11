using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(MetadataProduct))]
    public partial class Product
    {
    }

    public class MetadataProduct
    {
        [Display(Name = "Category")]
        public int CategoryId;
    }
}

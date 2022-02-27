using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YaBao.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    [Table("Продукты")]
    public class Product
    {

        /// <summary>
        /// integer primal Key 
        /// </summary>
        [Key]
        public int? Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>        
        public string Name { get; set; }
        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Product prewiev image Name
        /// </summary>
        /// <remarks>Image are found in url/source/{Image Name}</remarks>
        public string Image { get; set; }
        /// <summary>
        /// integer Foregin Key for Product Type
        /// </summary>
        public int? ProductTypeId { get; set; }
        /// <summary>
        /// Mark product is New
        /// </summary>
        public bool IsNew { get; set; }
        /// <summary>
        /// Connections with Stocks
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Stock>? Stocks { get; set; }
    }

}
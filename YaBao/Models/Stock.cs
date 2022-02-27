using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YaBao.Models
{
    /// <summary>
    /// Stock model
    /// </summary>
    [Table("Акции")]
    public class Stock
    {
        /// <summary>
        /// Stock primal key
        /// </summary>
        [Key]
        public int? Id { get; set; }
        /// <summary>
        /// Stock name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Stock desctiption
        /// </summary>
        public string Desctiption { get; set; }
        /// <summary>
        /// Stock terms
        /// </summary>
        public string Terms { get; set; }
        /// <summary>
        /// Stock price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Stock Image Name
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Products List from many-to-many connection in database
        /// </summary>
        [JsonIgnore]
        public List<Product>? Products { get; set; }
        /// <summary>
        /// a Field that allows you to add and remove promotions by Id
        /// </summary>
        private IEnumerable<int?>? productsIds;
        /// <summary>
        /// Proprty for interact with productIds field
        /// </summary>
        [NotMapped]
        public IEnumerable<int?> ProductsIds
        {
            get
            {
                if (productsIds != null)
                {
                    return productsIds;
                }
                return Products.Select(x => x.Id);
            }
            set
            {
                productsIds = value;
            }
        }
        /// <summary>
        /// one-to-one connection
        /// </summary>
        [JsonIgnore]
        public Slide? Slide { get; set; }
    }
}

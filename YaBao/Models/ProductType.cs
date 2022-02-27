using System.ComponentModel.DataAnnotations.Schema;

namespace YaBao.Models
{
    /// <summary>
    /// ProductType model
    /// </summary>
    [Table("Типы товаров")]
    public class ProductType
    {
        /// <summary>
        /// integer Primal key
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Product Type Name
        /// </summary>
        public string Name { get; set; }

    }
}

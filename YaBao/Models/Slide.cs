
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YaBao.Models
{
    /// <summary>
    /// Slide model
    /// </summary>
    [Table("Слайды")]
    public class Slide
    {
        /// <summary>
        /// Primal key for slide model
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Slide image name 
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// one-to-one connection 
        /// </summary>
        [JsonIgnore]
        public Stock? Stock { get; set; }
        /// <summary>
        /// Show which Slide is topical now
        /// </summary>
        public bool IsTopical { get; set; } = true;

        /// <summary>
        /// Stock foregin key for return result
        /// </summary>
        private int? stockId;
        /// <summary>
        /// Properties to interact with output StockId and Set Object
        /// </summary>
        [NotMapped]
        public int? StockId
        {
            get
            {
                if (stockId != null)
                {
                    return stockId;
                }
                return Stock.Id;
            }
            set
            {
                stockId = value;
            }
        }

    }
}
//При удалении акции isTopical становится false
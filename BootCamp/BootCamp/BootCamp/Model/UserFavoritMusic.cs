using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class UserFavoritMusic
    {
        public Guid Id { get; set; }

        public Guid MusicId { get; set; }

        public Music Music { get; set; }
        /// <summary>
        /// Exemplo do problema de reference loop. O JsonEgnore evita ele 
        /// this example creates a reference loop
        ///     var p = new Product()
        ///     {
        ///            ProductCategory = new ProductCategory()
        ///         { 
        ///         products = new List<Product>() 
        ///         }
        ///      };
        ///     p.ProductCategory.products.Add(p); // <- this create the loop
        ///     Explicação que encontrei no StackOverFloo:
        ///     You can not handle the reference loop situation in the new System.Text.Json
        ///     yet (netcore 3.1.1) unless you completely ignore a reference and its not a 
        ///     good idea always. (using [JsonIgnore] attribute)
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }
    }
}

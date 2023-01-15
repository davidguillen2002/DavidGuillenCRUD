using SQLite;

namespace DavidGuillenCRUD.Models
{
    [Table("burger12345")]
    public class DGBurger
    {
        [PrimaryKey, AutoIncrement]
        public int DGId { get; set; }

        [MaxLength(250)]
        public string DGName { get; set; }
        public string DGDescripcion { get; set; }
        public bool DGWithExtraCheese { get; set; }
    }
}

using SQLite;

namespace FlashStudy.Models
{
    [Table("Deck")]
    public sealed class Deck
    {
        [PrimaryKey, AutoIncrement]
        public int Id {get; set;}

        [Indexed, NotNull]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int? Count { get; set; }
    }
}
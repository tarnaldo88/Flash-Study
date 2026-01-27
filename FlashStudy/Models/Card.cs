using SQLite;

namespace FlashStudy.Models
{
    [Table("Cards")]
    public sealed class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int DeckId { get; set; }

        [NotNull]
        public string Front { get; set; } = "";

        [NotNull]
        public string Back { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
namespace SiteWeb_ISN
{
    public class Chanteur
    {
        public int IdChanteur { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string nationaliteChanteur { get; set; } = string.Empty;
        public byte[] Image { get; set; }
    }
}

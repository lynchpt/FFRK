namespace FFRKApi.Dto.Api.Banners
{
    public class PullResultRow
    {
        public int BannerSlot { get; set; }
        public int RelicId { get; set; }
        public string RelicName { get; set; }
        public string CategoryName { get; set; }
        public int SelectedCount { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int SoulBreakId { get; set; }
        public string SoulBreakName { get; set; }
        public int LegendMateriaId { get; set; }
        public string LegendMateriaName { get; set; }
        public int SoulBreakTierType { get; set; }
        public string SoulBreakTierName { get; set; }
    }
}

namespace FFRKApi.Dto.Api.CharacterRating
{
    public class LegendMateriaSummaryInfo
    {
        public int LegendMateriaId { get; set; }
        public string LegendMateriaName { get; set; }
        public string Effect { get; set; }
        public int RelicId { get; set; } //0 = LM1 or LM2
    }
}

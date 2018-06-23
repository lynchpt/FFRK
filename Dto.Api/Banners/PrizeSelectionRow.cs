namespace FFRKApi.Dto.Api.Banners
{
    public class PrizeSelectionRow
    {
        public int PrizeIndex { get; set; } //starting from 1
        public double PrizeProbabilityLowerBound { get; set; }
        public string PrizeCategoryName { get; set; }
        public string PrizeName { get; set; }

        public override string ToString()
        {
            return $"{PrizeIndex,-8}{PrizeProbabilityLowerBound,-25}{PrizeCategoryName,-20}{PrizeName,-50}";
        }
    }
}

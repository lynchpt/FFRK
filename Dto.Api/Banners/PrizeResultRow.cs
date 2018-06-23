namespace FFRKApi.Dto.Api.Banners
{
    public class PrizeResultRow
    {
        public int PrizeIndex { get; set; } //starting from 1
        public string PrizeCategoryName { get; set; }
        public string PrizeName { get; set; }
        public int PrizeSelectedCount { get; set; }

        public override string ToString()
        {
            return $"{PrizeIndex,-8}{PrizeSelectedCount,-8}{PrizeCategoryName,-25}{PrizeName,-50}";
        }
    }
}

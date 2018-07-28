namespace FFRKApi.Dto.Api
{
    public class LegendMateria
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string LegendMateriaName { get; set; }
        public string JapaneseName { get; set; }
        public int Realm { get; set; }
        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase
        public string ImagePath { get; set; }

        public string Effect { get; set; }
        public string MasteryBonus { get; set; }
        public string RelicName { get; set; }
        public int RelicId { get; set; }//filled in during merge phase
        public bool IsInGlobal { get; set; }
        public bool IsChecked { get; set; }
    }
}

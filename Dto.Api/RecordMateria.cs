namespace FFRKApi.Dto.Api
{
    public class RecordMateria
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string RecordMateriaName { get; set; }
        public string JapaneseName { get; set; }

        public string ImagePath { get; set; }


        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase
        public int Realm { get; set; }


        public string Effect { get; set; }
        public string UnlockCriteria { get; set; }
        public string EnlirId { get; set; }
        public bool IsInGlobal { get; set; }
        public bool IsChecked { get; set; }
    }
}

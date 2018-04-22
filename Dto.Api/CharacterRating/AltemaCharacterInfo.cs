using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Dto.Api.CharacterRating
{
    public class AltemaCharacterInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public string JapaneseRoleSummary { get; set; }
        public string RoleSummary { get; set; }
        public IList<string> Roles { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            string rolesText = String.Empty;
            StringBuilder rolesBuilder = new StringBuilder();

            foreach (string role in Roles)
            {
                rolesBuilder.Append(role);
                rolesBuilder.Append("; ");
            }
            rolesText = rolesBuilder.ToString();

            return $"{Id, -25}{Name, -23}{Rating,-6}{rolesText, -50}{JapaneseName, -30}{JapaneseRoleSummary, -25}{ImageUrl, -40}";
            //return $"{PrizeIndex}\t\t{PrizeSelectedCount}\t\t{PrizeCategoryName}\t\t{PrizeName}";
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.Api.CharacterRating;
using HtmlAgilityPack;

namespace FFRKApi.Logic.Api.CharacterRating
{
    public interface IAltemaCharacterNodeInterpreter
    {
        AltemaCharacterInfo ConvertCharacterNodeToCharacterInfo(AltemaCharacterNodeComponents characterNodeComponents);
    }

    public class AltemaCharacterNodeInterpreter : IAltemaCharacterNodeInterpreter
    {
        #region Class Variables

        private readonly IAltemaCharacterJapaneseTextMapper _altemaCharacterJapaneseTextMapper;
        #endregion

        #region Constructors

        public AltemaCharacterNodeInterpreter(IAltemaCharacterJapaneseTextMapper altemaCharacterJapaneseTextMapper)
        {
            _altemaCharacterJapaneseTextMapper = altemaCharacterJapaneseTextMapper;
        }
        #endregion

        public AltemaCharacterInfo ConvertCharacterNodeToCharacterInfo(AltemaCharacterNodeComponents characterNodeComponents)
        {
            AltemaCharacterInfo characterInfo = null;


            if (characterNodeComponents.IsRatedCharacter)
            {
                characterInfo = new AltemaCharacterInfo()
                                {
                                    Id = characterNodeComponents.CharacterIdAttribute.Value,
                                    ImageUrl = GetImageUrl(characterNodeComponents),
                                    JapaneseName = characterNodeComponents.NameNode.InnerText.Trim(),
                                    Rating = System.Convert.ToInt32(characterNodeComponents.RatingNode.InnerText.Trim()),
                                    JapaneseRoleSummary = characterNodeComponents.RoleNode.InnerText.Trim(),
                                    Name = _altemaCharacterJapaneseTextMapper.GetCharacterNameFromId(characterNodeComponents.CharacterIdAttribute.Value) ?? characterNodeComponents.NameNode.InnerText.Trim(),
                                    RoleSummary = _altemaCharacterJapaneseTextMapper.GetRoleSummaryFromJapaneseRoleSummary(characterNodeComponents.RoleNode.InnerText.Trim())                                    
                                };

                characterInfo.Roles = _altemaCharacterJapaneseTextMapper.GetRolesFromJapaneseRoleSummary(characterInfo.JapaneseRoleSummary);
            }

            return characterInfo;
        }


        private string GetImageUrl(AltemaCharacterNodeComponents characterNodeComponents)
        {
            string imageUrl = String.Empty;

            if (characterNodeComponents.IsRatedCharacter)
            {
                if (characterNodeComponents.ImageLazyLoadedAttribute != null && characterNodeComponents.ImageLazyLoadedAttribute.Value == "true")
                {
                    imageUrl = characterNodeComponents.ImageSourceAttribute.Value;
                }
                else
                {
                    imageUrl = characterNodeComponents.ImageLazySourceAttribute.Value;
                }
            }


            return imageUrl;
        }
    }
}

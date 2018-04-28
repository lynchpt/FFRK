using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.Api.CharacterRating;
using HtmlAgilityPack;

namespace FFRKApi.Logic.Api.CharacterRating
{
    public interface IAltemaCharacterNodeParser
    {
        AltemaCharacterNodeComponents ParseCharacterNode(HtmlNode characterNode);
    }

    public class AltemaCharacterNodeParser : IAltemaCharacterNodeParser
    {
        private const string ImageSourceAttributeName = "src";
        private const string ImageLazySourceAttributeName = "data-lazy-src";
        private const string ImageLazyLoadedAttributeName = "data-lazy-loaded";


        public AltemaCharacterNodeComponents ParseCharacterNode(HtmlNode characterNode)
        {
            AltemaCharacterNodeComponents components = new AltemaCharacterNodeComponents();

            components.CharacterNode = characterNode;
            components.NameNode = characterNode.SelectSingleNode(@"./td[1]/a[1]");
            components.ImageNode = characterNode.SelectSingleNode(@"./td[1]/a[1]/img[1]");
            components.RoleNode = characterNode.SelectSingleNode(@"./td[2]/span[@class='b']");
            components.RatingNode = characterNode.SelectSingleNode(@"./td[3]/span[@class='redtxt']");

            components.CharacterIdAttribute = components.NameNode.Attributes.FirstOrDefault();
            components.ImageLazyLoadedAttribute = components.ImageNode?.Attributes.FirstOrDefault(a => a.Name == ImageLazyLoadedAttributeName);
            components.ImageLazySourceAttribute = components.ImageNode?.Attributes.FirstOrDefault(a => a.Name == ImageLazySourceAttributeName);
            components.ImageSourceAttribute = components.ImageNode?.Attributes.FirstOrDefault(a => a.Name == ImageSourceAttributeName);

            return components;
        }

    }
}

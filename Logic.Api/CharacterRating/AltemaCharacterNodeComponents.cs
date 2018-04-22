using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace FFRKApi.Logic.Api.CharacterRating
{
    public class AltemaCharacterNodeComponents
    {
        public HtmlNode CharacterNode { get; set; }

        public HtmlNode NameNode { get; set; }
        public HtmlNode ImageNode { get; set; }
        public HtmlNode RoleNode { get; set; }
        public HtmlNode RatingNode { get; set; }

        public HtmlAttribute CharacterIdAttribute { get; set; }
        public HtmlAttribute ImageLazyLoadedAttribute { get; set; }
        public HtmlAttribute ImageLazySourceAttribute { get; set; }
        public HtmlAttribute ImageSourceAttribute { get; set; }

        public bool IsRatedCharacter =>
            CharacterNode != null &&
            NameNode != null &&
            ImageNode != null &&
            RoleNode != null &&
            RatingNode != null &&
            CharacterIdAttribute != null &&
            (
                ImageLazySourceAttribute != null ||
                ImageSourceAttribute != null
            );
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace BasicFacebookFeatures.CustomeData
{
    public class LikedPageData
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<string> Posts { get; set; }

        public class Root
        {
            public List<LikedPageData> LikedPages { get; set; }
        }

        public static List<LikedPageData> LoadPagesData()
        {
            string fileNameContent = Properties.Resources.Liked_Pages;
            Root likedPages = JsonConvert.DeserializeObject<Root>(fileNameContent);

            return likedPages.LikedPages;
        }
    }
}

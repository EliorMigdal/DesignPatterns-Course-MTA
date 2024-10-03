using Newtonsoft.Json;
using System.Collections.Generic;

namespace Model.CustomeData
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
            string fileNameContent = string.Empty;
            Root likedPages = JsonConvert.DeserializeObject<Root>(fileNameContent);

            return likedPages.LikedPages;
        }
    }
}
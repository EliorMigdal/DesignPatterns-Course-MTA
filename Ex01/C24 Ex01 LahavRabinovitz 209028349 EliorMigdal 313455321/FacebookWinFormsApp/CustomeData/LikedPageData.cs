using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.CustomeData
{
    public class LikedPageData
    {
        public string Name { get; set; }

        public string PagePicture { get; set; }

        public List<string> Posts { get; set; }

        public class Root
        {
            public List<LikedPageData> Pages { get; set; }
        }

        public static List<LikedPageData> LoadPagesData()
        {
            string fileNameContent = Properties.Resources.Liked_Pages;
            Root likedPages = JsonConvert.DeserializeObject<Root>(fileNameContent);

            return likedPages.Pages;
        }
    }
}

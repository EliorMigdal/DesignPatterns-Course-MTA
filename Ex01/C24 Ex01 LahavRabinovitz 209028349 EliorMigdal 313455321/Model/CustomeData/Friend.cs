using Newtonsoft.Json;
using System.Collections.Generic;

namespace Model.CustomeData
{
    public class Friend
    {
        public string Name { get; set; }

        public string ProfilePicture {  get; set; }

        public List<string> Posts { get; set; }

        public List<string> Friends { get; set; }

        public List<string> Pictures { get; set; }
        public bool IsCloseFriend { get; set; }

        public class Root
        {
            public List<Friend> Friends { get; set; }
        }

        public static List<Friend> LoadFriends()
        {
            string jsonContents = string.Empty;
            Root root = JsonConvert.DeserializeObject<Root>(jsonContents);

            return root.Friends;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.CustomeData
{
    public class Friend
    {
        public string Name { get; set; }

        public string ProfilePicture {  get; set; }

        public List<string> Posts { get; set; }

        public List<Friend> Friends { get; set; }

        public List<string> Pictures { get; set; }
    }
}

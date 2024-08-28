using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class PostWrapper : IUserItemWrapper
    {
        public enum ePostType
        {
            Text,
            Image,
            CheckIn,
            CloseFriends
        }

        public string Name {  get; set; }
        public string Picture {  get; set; }
        private Post Post { get; set; }
        public int Likes { get; set; }
        public bool CloseFriendsOnly { get; set; } = true;
        public string Message { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public DateTime? CreationDate { get; set; }
        public ePostType PostType { get; set; } = ePostType.Text;

        public PostWrapper(Post i_Post)
        {
            Post = i_Post;
            Name = i_Post.Name;
            Picture = i_Post.PictureURL;
            Message = i_Post.Message;
            CreationDate = i_Post.CreatedTime;

            initializeProperties();
        }

        public PostWrapper(string i_Message)
        {
            Message = i_Message;
            CreationDate = DateTime.Now;

            initializeProperties();
        }

        private void initializeProperties()
        {
            Likes = Message.Length;
            CloseFriendsOnly = Message.Length < 3;
            PostType = Message.Length > 10 ? ePostType.CloseFriends : ePostType.Text;
        }
    }
}

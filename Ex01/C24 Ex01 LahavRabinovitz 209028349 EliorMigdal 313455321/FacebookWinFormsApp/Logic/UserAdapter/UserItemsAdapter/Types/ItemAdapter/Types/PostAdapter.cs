﻿using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types
{
    public class PostAdapter : IUserItemAdapter
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
        public Post Post { get; set; }
        public int Likes { get; set; }
        public bool CloseFriendsOnly { get; set; } = true;
        public string Message { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public DateTime? CreationDate { get; set; }
        public ePostType PostType { get; set; } = ePostType.Text;

        public PostAdapter(Post i_Post)
        {
            Post = i_Post;
            Name = i_Post.Name;
            Picture = i_Post.PictureURL;
            Message = i_Post.Message;
            CreationDate = i_Post.CreatedTime;

            initializeProperties();
        }

        public PostAdapter(string i_Message)
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
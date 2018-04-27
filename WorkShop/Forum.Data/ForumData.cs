using System.Collections.Generic;
using System.Data.Common;

namespace Forum.Data
{
    public class ForumData
    {
        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
        public List<Reply> Replies { get; set; }
        public List<Post> Posts { get; set; }

        public ForumData()
        {
            Users = DataMapper.LoadUsers();
            Categories = DataMapper.LoadCateogries();
            Replies = DataMapper.LoadReplies();
            Posts = DataMapper.LoadPosts();
        }

        public void SaveChanges()
        {
            DataMapper.SaveCategories(Categories);
            DataMapper.SaveUsers(Users);
            DataMapper.SavePosts(Posts);
            DataMapper.SaveReplies(Replies);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.UserInterface.ViewModels;
using Forum.Data;

namespace Forum.App.Services
{
    public class PostService
    {
        public static Category GetCategory(int id)
        {
            var forumData = new ForumData();
            var category = forumData.Categories.SingleOrDefault(c => c.Id == id);

            return category;
        }

        public static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            var forumData = new ForumData();
            var post = forumData.Posts.SingleOrDefault(p => p.Id == postId);

            var replies = new List<ReplyViewModel>();

            foreach (var replyId in post.Reply)
            {
                var reply = forumData.Replies.First(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();
            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        public static IEnumerable<Post> GetPostByCategory(int categoryId)
        {
            var forumData = new ForumData();
            var postIds = forumData.Categories.SingleOrDefault(c => c.Id == categoryId).Posts;
            return forumData.Posts
                .Where(p => postIds.Contains(p.Id));
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);

            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.LastOrDefault().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }
            
            ForumData forumData = new ForumData();
            Category category = EnsureCategory(postView, forumData);
            int postId = forumData.Posts.Any() ? forumData.Posts.LastOrDefault().Id + 1 : 1;

            var authorId = forumData.Users.SingleOrDefault(u => u.Username == postView.Author).Id;

            User author = UserService.GetUser(authorId);

            string content = string.Join("", postView.Content);

            Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }

        internal static bool TryAddReply(int postId, ReplyViewModel replyViewModel)
        {
            var forumData = new ForumData();

            var emptyReply = !replyViewModel.Content.Any();

            if (emptyReply) return false;

            var replyId = forumData.Replies.Any() ? forumData.Replies.Last().Id + 1 : 1;

            var content = string.Join("", replyViewModel.Content);

            var authorId = forumData.Users.SingleOrDefault(u => u.Username == replyViewModel.Author).Id;

            var reply = new Reply(replyId, content, authorId, postId);

            var post = forumData.Posts.FirstOrDefault(p => p.Id == postId);

            forumData.Replies.Add(reply);
            post.Reply.Add(replyId);
            forumData.SaveChanges();

            return true;
        }
    }
}

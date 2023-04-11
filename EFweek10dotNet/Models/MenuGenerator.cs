namespace EFweek10dotNet.Models;

public class MenuGenerator
{
    
    public void AppMenu()
    {
        char menuAnswer = 'a';
        while (menuAnswer != 'q')
        {
            Console.WriteLine("Program Start");
            Console.WriteLine("1. Enter 1 to Display Blogs");
            Console.WriteLine("2. Enter 2 to Add Blog");
            Console.WriteLine("3. Enter 3 to Display Posts");
            Console.WriteLine("4. Enter 4 to Add Post");
            Console.WriteLine(".........................................");
            Console.Write("Please Enter Menu Number (q for quit): ");
                
            try
            {
                menuAnswer = Console.ReadLine().ToLower()[0];
                if (menuAnswer == '1')
                {
                    try
                    {
                        DisplayBlog();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine($"Try again");
                    }  
                    
                    
                }

                else if (menuAnswer == '2')
                {
                    
                    try
                    {
                        CreateBlog();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine($"Try again");
                    }  
                
                }
                else if (menuAnswer == '3')
                {
                    
                    try
                    {
                        DisplayPost();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine($"Try again");
                    }  
                
                }
                else if (menuAnswer == '4')
                {
                    
                    try
                    {
                        CreatePost();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine($"Try again");
                    }  
                
                }
                else if (menuAnswer == 'q')
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Try again\n\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Pick a valid key");
                        
            }
                    
                    
        }
    }

    private static void Exit()
    {
        Console.WriteLine("Good-Bye");
    }

    private static void DisplayBlog()
    {
        //Display the blogs
        using (var context = new BlogContext()) //recommend using using. automatically disposes
        {

            var blogsList = context.Blogs.ToList();

            Console.WriteLine("The blogs are: ");
            foreach (var blog in blogsList)
            {
                Console.WriteLine($"{blog.Name}");
            }
        }
    }

    private static void CreateBlog()
    {
        //CREATE a blog name
        using (var context = new BlogContext()) //recommend using using. automatically disposes
        {
            Console.WriteLine("enter a blog name");
            var blogName = Console.ReadLine();

            var blog = new Blog();
            blog.Name = blogName; //not setting ID

            context.Blogs.Add(blog);
            context.SaveChanges(); //we must commit by saving the changes
        }


            
    }

    private static void UpdateBlog()
    {
        //Update the blog
        using (var context = new BlogContext()) //recommend using using. automatically disposes
        {
            var blogToUpdate =
                context.Blogs.Where(b => b.BlogId == 1)
                    .FirstOrDefault(); //IQueryable type. needs told to be executed. more performable. add tolist, and is a list and holding memory
            Console.WriteLine($"Your choice is {blogToUpdate.Name}");
            Console.WriteLine("What do you what to rename to");
            var updatedName = Console.ReadLine();
            blogToUpdate.Name = updatedName;
            //context.Remove(blogToUpdate); to remove
            context.SaveChanges();
        }

    }

    private static void CreatePost()
    {
        //Create a Post
        using (var context = new BlogContext()) //recommend using using. automatically disposes
        {
            
            /*Console.WriteLine("Which blog?");
            var blogId = Console.ReadLine();*/
            var blogList = context.Blogs.ToList(); //convert to a list or not, it provides some behavior.

            Console.WriteLine("Select Blog to create post (enter blog ID): ");
            foreach (var blog in blogList)
            {
                Console.WriteLine(
                    $"Blog {blog.BlogId}: {blog.Name}"); //this errors w/o tolist. So .UseLazyLoadingProxies() to blog context. uses eager loading otherwise by default. OK, it didn't like that we had an open connection.  Go back to ToList!
            }  
   

            int blogId = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("enter a post title");
            var title = Console.ReadLine();
            Console.WriteLine("enter post content");
            var content = Console.ReadLine();



            var post = new Post();
            post.Title = title;
            post.Content = content;
            post.BlogId = Convert.ToInt32(blogId);

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }

    private static void DisplayPost()
    {
        //read posts
        using (var context = new BlogContext()) //recommend using using. automatically disposes
        {
            int postCount = 0;
            
            var blogList = context.Blogs.ToList(); //convert to a list or not, it provides some behavior.

            Console.WriteLine("Select Blog to view posts (enter blog ID): ");
            foreach (var blog in blogList)
            {
                Console.WriteLine(
                    $"Blog {blog.BlogId}: {blog.Name}"); //this errors w/o tolist. So .UseLazyLoadingProxies() to blog context. uses eager loading otherwise by default. OK, it didn't like that we had an open connection.  Go back to ToList!
            }  
   

            int blogId = Convert.ToInt32(Console.ReadLine());
            
            var postsList =
                context.Posts.Where(p => p.BlogId == blogId)
                    .ToList(); //convert to a list or not, it provides some behavior.

            Console.WriteLine("The posts are: ");
            foreach (var post in postsList)
            {
                Console.WriteLine(
                    $"Blog: {post.Blog.Name}"); //this errors w/o tolist. So .UseLazyLoadingProxies() to blog context. uses eager loading otherwise by default. OK, it didn't like that we had an open connection.  Go back to ToList!
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Content: {post.Content}");
                postCount++;
            }

            Console.WriteLine($"Number of posts: {postCount}");
        }
    }
}
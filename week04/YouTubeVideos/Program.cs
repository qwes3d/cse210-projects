using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor to initialize a comment
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    // Override ToString to display comment details
    public override string ToString()
    {
        return $"{CommenterName}: {CommentText}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    // Constructor to initialize video details
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to return the number of comments
    public int NumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display the video information and comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {NumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create some video objects
        Video video1 = new Video("How to Python", "John Doe", 120);
        Video video2 = new Video("Cooking 101", "Jane Smith", 150);
        Video video3 = new Video("Travel Vlog: Paris", "Mike Johnson", 200);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "This is amazing, learned a lot!"));

        // Add comments to video2
        video2.AddComment(new Comment("Dave", "I need to try this recipe!"));
        video2.AddComment(new Comment("Eve", "The instructions were clear, thanks!"));
        video2.AddComment(new Comment("Frank", "Can't wait to cook this!"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Paris looks beautiful!"));
        video3.AddComment(new Comment("Hank", "I want to visit this place someday!"));
        video3.AddComment(new Comment("Ivy", "Great vlog, very inspiring!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information about each video and its comments
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine("\n" + new string('-', 40) + "\n");
        }
    }
}

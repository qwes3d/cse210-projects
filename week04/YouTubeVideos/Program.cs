using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.\n");

        // Create video objects
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

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video's details
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine(new string('-', 40));
        }
    }
}

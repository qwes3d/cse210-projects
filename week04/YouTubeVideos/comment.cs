using System;

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

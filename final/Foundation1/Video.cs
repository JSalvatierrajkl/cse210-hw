class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _length { get; set; }
    public List<Comment> _comments { get; set; }

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(string userName, string text)
    {
        Comment comment = new Comment(userName, text);
        _comments.Add(comment);
    }

    public int GetTotalComments()
    {
        return _comments.Count;
    }

    internal void jkl()
    {
        throw new NotImplementedException();
    }
}
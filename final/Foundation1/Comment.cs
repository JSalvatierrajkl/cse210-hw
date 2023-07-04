class Comment
{
    public string _userName { get; set; }
    public string _text { get; set; }

    public Comment(string userName, string text)
    {
        _userName = userName;
        _text = text;
    }
}
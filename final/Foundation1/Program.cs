using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to use C# Efectivily", "Edward Jones", 240);
        Video video2 = new Video("What is a class", "Learining with Patrick", 120);
        Video video3 = new Video("How get a right diagram", "Logic Teacher Williams", 180);
        Video video4 = new Video("Practice classes interactions", "TechnoMichael", 580);

        // Create a list of videos
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Add comments to videos
        video1.AddComment("Luke Fernandez", "It seems to be a good lenguage to learn object-oriented developing.");
        video1.AddComment("Gerald Rivia", "Wow! it is really nice, I was thinking what lenguage should I start to learn, now I know!");
        video1.AddComment("Mandragon Wheasley", "I hope this won't be as hard as everyone says.");
        video1.AddComment("Juan Perez", "What a video! Thanks.");
        video2.AddComment("Mike Morales", "Great explanation, good job.");
        video2.AddComment("Joshua Curiel", "How can I know more about methods and its applications?");
        video2.AddComment("Lili Denkers", "This is really usefull, keep doing this!");
        video3.AddComment("Jarom Price", "Thanks! Now I think I can make a correct diagram from my programs");
        video3.AddComment("Nick Hass", "This helps a lot! ");
        video3.AddComment("Sidney Withworth", "What should I do if I dont even now how to separate classes?");
        video3.AddComment("Elizabeth Santillan", "Great job! keep sharing this!");
        video4.AddComment("Jose Muriel", "Good practice, now I get clear about the application of interaction among classes");
        video4.AddComment("John Morales", "What should I do if I have this error 'csharp(CS1061)'?");
        video4.AddComment("Lionel Massa", "Thanks for all the help!!!");


        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video._title);
            Console.WriteLine(" Author: " + video._author);
            Console.WriteLine(" Length: " + video._length + " seconds");
            Console.WriteLine(" Number of Comments: " + video.GetTotalComments());

            Console.WriteLine("Comments:");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine(" User: " + comment._userName);
                Console.WriteLine("  Comment: " + comment._text);
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}

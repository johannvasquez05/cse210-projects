using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        Console.WriteLine();
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
        "AMD Ryzen 9 7950X3D Review — Best Gaming CPU 2024?", "Linus Tech Tips", 1180);
        video1.AddComment(new Comment("GamerGuy", "This absolutely crushes gaming workloads!"));
        video1.AddComment(new Comment("Techie", "Impressed by the temps under load."));
        video1.AddComment(new Comment("BuildMaster", "Finally a reason to upgrade!"));
        videos.Add(video1);

        Video video2 = new Video(
            "Ryzen 7000 Series Explained: AM5, DDR5 & What You Need to Know", "JayzTwoCents", 720);
        video2.AddComment(new Comment("PCNewbie", "Thanks — this cleared up so many questions."));
        video2.AddComment(new Comment("OC_Addict", "Good breakdown of memory bandwidth."));
        video2.AddComment(new Comment("FutureBuilder", "Now I’m convinced to go AM5!"));
        videos.Add(video2);

        Video video3 = new Video(
            "Ryzen vs Intel 2025: Which CPU Should You Buy?", "Hardware Unboxed", 1350);
        video3.AddComment(new Comment("StudentCoder", "Great comparison — budget vs high end."));
        video3.AddComment(new Comment("Enthusiast", "Intel still strong in single-core but Ryzen wins multicore."));
        video3.AddComment(new Comment("CasualUser", "Stopped watching Intel ads after this."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
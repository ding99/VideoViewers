namespace TitleViewer
{
    public class Content
    {
        public string title { get; set; }
        public string bulletText { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public int runningTime { get; set; }

        public Content(string title, string bulletText, string description, string id, int runningTime)
        {
            this.title = title;
            this.bulletText = bulletText;
            this.description = description;
            this.id = id;
            this.runningTime = runningTime;
        }
    }
}

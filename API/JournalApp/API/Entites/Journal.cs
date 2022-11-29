namespace API.Entites
{
    public class Journal : BaseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatedOn { get; set; }
    }
}

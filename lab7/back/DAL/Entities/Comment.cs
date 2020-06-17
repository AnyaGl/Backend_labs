namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Bike Bike { get; set; }
    }
}
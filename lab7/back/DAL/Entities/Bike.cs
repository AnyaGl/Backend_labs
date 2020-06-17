namespace DAL.Entities
{
    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Person Person { get; set; }
        public Brand Brand { get; set; }
        public Photo Photo { get; set; }
        public Type Type { get; set; }
    }
}

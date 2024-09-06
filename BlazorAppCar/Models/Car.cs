public class Car
{
    public int Id { get; set; }  // Primary key
    public string Name { get; set; }
    public int EngineId { get; set; }  // Foreign key
    public Engine Eng { get; set; }  // Navigation property
}
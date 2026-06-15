namespace Lesson_8.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; } // Stores relative path to image
        public List<string> ImagePaths { get; set; } = new List<string>(); // For multiple images
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

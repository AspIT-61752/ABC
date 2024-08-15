using System.Text.Json.Serialization;

namespace ABC.Entity
{
    public class Category
    {
        private int categoryId;
        private string categoryName;
        private string categoryDescription;

        [JsonConstructor]
        public Category() { }

        public Category(int id, string categoryName, string categoryDescription)
        {
            CategoryId = id;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string CategoryDescription { get => categoryDescription; set => categoryDescription = value; }
    }
}

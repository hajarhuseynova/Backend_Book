namespace Book.Client.Dtos.Categories
{
        public class CategoryGetDto
        {
            public string? name { get; set; }
         
        }

        public class GetItem<T>
        {
            public List<T> Items { get; set; }
        }
    
}

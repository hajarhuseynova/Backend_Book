namespace Book.Client.Dtos
{
    public class CategoryGetInfoDto
    {
        public string Name { get; set; } = null!;

    }

    public class GetItems<T>
    {
        public List<T>? Items { get; set; }
    }
}

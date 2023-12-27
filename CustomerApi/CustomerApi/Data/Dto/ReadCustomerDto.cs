namespace CustomerApi.Data.Dto
{
    public class ReadCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime ConsultTime { get; set; } = DateTime.Now;
    }
}

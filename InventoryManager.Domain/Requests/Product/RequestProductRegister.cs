using System.Text.Json.Serialization;

public class RequestProductRegister
{
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    [JsonIgnore]
    public Guid StoreId { get; set; }
}
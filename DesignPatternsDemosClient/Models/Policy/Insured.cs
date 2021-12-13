namespace DesignPatternsDemosClient.Models.Policy;

public class Insured
{
    //ToDoL Review Better name?
    public string? FullName { get; set; }
    public string? PhoneHome { get; set; }
    public string? PhoneWork { get; set; }
    public string? EmailAddress { get; set; }
    public Address? Address { get; set; }
}
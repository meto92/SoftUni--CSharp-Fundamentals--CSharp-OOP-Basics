public class Robot : Identifiable
{
    private string model;

    public Robot(string model, string id)
        : base(id)
    {
        this.Model = model;
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }    
}
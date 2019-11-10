public class Cymric : Cat
{
    public Cymric(string name, double furLength)
        : base(name, furLength)
    { }

    public override string ToString()
    {
        return $"{this.GetType()} {base.Name} {base.Parameter:f2}";
    }
}
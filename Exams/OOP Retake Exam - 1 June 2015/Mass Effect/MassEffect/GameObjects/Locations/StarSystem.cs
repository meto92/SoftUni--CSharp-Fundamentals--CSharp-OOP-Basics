namespace MassEffect.GameObjects.Locations
{
    using MassEffect.Interfaces;
    using System.Collections.Generic;

    public class StarSystem
    {
        private List<IStarship> starships;
        
        public StarSystem(string name)
        {
            this.Name = name;
            this.NeighbourStarSystems = new Dictionary<StarSystem, double>();
            this.starships = new List<IStarship>();
        }

        public string Name { get; set; }

        public IDictionary<StarSystem, double> NeighbourStarSystems { get; set; }

        public IList<IStarship> Starships => this.starships;
    }
}
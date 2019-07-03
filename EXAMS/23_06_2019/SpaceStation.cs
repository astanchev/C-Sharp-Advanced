using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astronautToRemove = this.data.FirstOrDefault(a => a.Name == name);

            if (astronautToRemove != null)
            {
                this.data.Remove(astronautToRemove);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.FirstOrDefault(a => a.Name == name);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                result.AppendLine(astronaut.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
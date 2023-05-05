using System;

namespace SkillUp.Models
{
	public class Manager
	{
		public Manager()
		{
		}
        public int Id { get; set; }
        public string Name { get; set; }
		public IEnumerable<TrainingCenter>? trainingCenters { get; set; }
    }
}


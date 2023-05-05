using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SkillUp.Models
{
	public class Training
	{
		public Training()
		{
		}

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Achat>? achats { get; set; }
        //public int trainingCenterId { get; set; }
        public TrainingCenter? trainingCenter { get; set; }
    }
}


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
        [Display(Name = "Nom de la formation")]
        public string Name { get; set; }
		public List<Candidat> candidats { get; set; }
		public TrainingCenter trainingcenter { get; set; } 
		
    }
	
}


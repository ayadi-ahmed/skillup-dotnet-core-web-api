using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SkillUp.Models
{
	public class TrainingCenter
	{
		public TrainingCenter()
		{
		}

        public int Id { get; set; }
        [Display(Name = "Nom du centre de formation")]
        public string Name { get; set; }
    }
}


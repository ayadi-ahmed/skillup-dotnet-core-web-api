using System;

namespace SkillUp.Models
{
	public class Achat
	{
		public Achat()
		{
		}
        public int Id { get; set; }
        public string Name { get; set; }
        public Training? training { get; set; }
        public Candidat? candidat { get; set; }
    }
}


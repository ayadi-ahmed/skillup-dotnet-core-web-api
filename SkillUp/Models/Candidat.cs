using System;
using System.Xml.Linq;

namespace SkillUp.Models
{
	public class Candidat
	{
		public Candidat()
		{
		}
        public int Id { get; set; }
        public string Name { get; set; }
		//public int[] achatsId { get; set; }
		public IEnumerable<Achat>? achats { get; set; } 
    }
}


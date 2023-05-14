using System;

namespace SkillUp.Models
{
	public class Manager
	{
        public Manager()
        {
        }
        public int id { get; set; }
        public string email { get; set; }
        public string mdp { get; set; }
        public string nom { get; set; }
        public Role role { get; set; }
        public string prenom { get; set; }
        public DateTime dateNaissance { get; set; }
        public string tel { get; set; }
       



        public IEnumerable<TrainingCenter>? trainingCenters { get; set; }

    }
}


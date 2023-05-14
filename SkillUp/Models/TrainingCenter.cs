using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SkillUp.Models
{
	public class TrainingCenter
	{
        public TrainingCenter()
        {
        }

        public int id { get; set; }
        public string nom { get; set; }
        public string addresse { get; set; }
        public string email { get; set; }
        public string dateCreation { get; set; }
        public string matriculeFiscale { get; set; }
        public string description { get; set; }
        public long rib { get; set; }
        public string logo { get; set; }
        public int tel { get; set; }

        public TrainingCenter(int id, string nom, string addresse, string email, string dateCreation, string matriculeFiscale, string description, long rib, string logo, int tel, EtatDemandeInscription etatDemandeInscription, int? managerId, Manager? manager, IEnumerable<Training>? training, string name, IEnumerable<TrainingCenter>? trainingCenters)
        {

            this.nom = nom;
            this.addresse = addresse;
            this.email = email;
            this.dateCreation = dateCreation;
            this.matriculeFiscale = matriculeFiscale;
            this.description = description;
            this.rib = rib;
            this.logo = logo;
            this.tel = tel;
            this.etatDemandeInscription = etatDemandeInscription;
            this.managerId = managerId;
            this.managerId = managerId;
            this.training = training;
            this.id = id;


            this.trainingCenters = trainingCenters;
        }

        public EtatDemandeInscription etatDemandeInscription { get; set; }
        [ForeignKey("manager")]
        public int? managerId { get; set; }
        public Manager? manager { get; set; }


        public IEnumerable<Training>? training { get; set; }


        public IEnumerable<TrainingCenter>? trainingCenters { get; set; }
    }
}


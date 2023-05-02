namespace SkillUp.Models
{
    public class Candidat:User
    {
        public long Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string dateNaissance { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string fonction { get; set; }

        public List<Training> trainings { get; set; }
        public Candidat()
        {

        }

    }
}

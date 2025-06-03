using EasyTask.Model;
using EasyTask.Model.Repository;
using System.Collections.Generic;

namespace EasyTask.ViewModel
{
    internal class ProjetViewModel
    {
        private ProjetRepository projetRepository;

        public List<Projet> Projets { get; set; }
        public Projet? SelectedProjet { get; set; }

        public ProjetViewModel()
        {
            projetRepository = new ProjetRepository();
            Projets = projetRepository.GetAllProjects();
        }

        public Projet GetProjetById(int id)
        {
            // À implémenter si besoin dans ProjetRepository
            return Projets.Find(p => p.Id == id);
        }

        public void AddProjet()
        {
            projetRepository.AddProject(SelectedProjet);
            Projets = projetRepository.GetAllProjects();
            SelectedProjet = null;
        }

        public void UpdateProjet(Projet projet)
        {
            projetRepository.UpdateProject(projet);
            Projets = projetRepository.GetAllProjects();
            SelectedProjet = null;
        }

        public void DeleteProjet(int projetId)
        {
            SelectedProjet = Projets.Find(p => p.Id == projetId);
            projetRepository.DeleteProject(projetId);
            Projets = projetRepository.GetAllProjects();
            SelectedProjet = null;
        }
    }
}
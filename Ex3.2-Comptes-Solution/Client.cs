using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3._2_Comptes_Solution
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Employeur { get; private set; }
        private string _nas;
        private string _nip;
        private List<Compte> _comptes;

        public Client(string nom, string prenom, string employeur, string nas, string nip)
        {
            Nom = nom;
            Prenom = prenom;
            Employeur = employeur;
            _nas = nas;
            _nip = nip;
            _comptes = new List<Compte>();
        }

        public bool Authentifier(string nip)
        {
            return _nip == nip;
        }

        public void ChangerNIP(string ancienNIP, string nouveauNIP)
        {
            if (_nip == ancienNIP)
            {
                _nip = nouveauNIP;
                Console.WriteLine("NIP modifié avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur : l'ancien NIP est incorrect.");
            }
        }

        public Compte OuvrirCompte()
        {
            Compte compte = new Compte(this);
            _comptes.Add(compte);
            return compte;
        }
    }
}

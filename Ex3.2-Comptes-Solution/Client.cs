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
        public string NAS { get; private set; }
        private string _nip;

        public Client(string nom, string prenom, string employeur, string nas, string nip)
        {
            Nom = nom;
            Prenom = prenom;
            Employeur = employeur;
            NAS = nas;
            _nip = nip;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3._2_Comptes_Solution
{
    public class CompteBancaire
    {
        public int NumeroCompte { get; private set; }
        public Client Proprietaire { get; private set; }
        public decimal Solde { get; private set; }
        private List<string> _transactions;

        public CompteBancaire(int numeroCompte, Client proprietaire)
        {
            NumeroCompte = numeroCompte;
            Proprietaire = proprietaire;
            Solde = 0.0m;
            _transactions = new List<string>();
        }

        public void Deposer(decimal montant)
        {
            if (montant > 0)
            {
                Solde += montant;
                string transaction = $"Dépôt : +{montant:C} dans {NumeroCompte}";
                _transactions.Add(transaction);
                EnregistrerTransaction(transaction);
                Console.WriteLine($"Dépôt de {montant:C} réussi. Nouveau solde : {Solde:C}");
            }
            else
            {
                Console.WriteLine("Montant invalide pour un dépôt.");
            }
        }

        public void Retirer(decimal montant)
        {
            if (montant > 0 && montant <= Solde)
            {
                Solde -= montant;
                string transaction = $"Retrait : -{montant:C} de {NumeroCompte}";
                _transactions.Add(transaction);
                EnregistrerTransaction(transaction);
                Console.WriteLine($"Retrait de {montant:C} réussi. Nouveau solde : {Solde:C}");
            }
            else
            {
                Console.WriteLine("Montant invalide ou fonds insuffisants.");
            }
        }

        public void AfficherSolde()
        {
            Console.WriteLine($"Solde actuel : {Solde:C}");
        }

        public void AfficherTransactions()
        {
            Console.WriteLine("Dernières transactions :");
            foreach (var transaction in _transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        /// <summary>
        /// Écrire une transaction dans un fichier
        /// </summary>
        /// <param name="transaction">La transaction à écire</param>
        public void EnregistrerTransaction(string transaction)
        {
            try
            {
                FileStream fs = new FileStream("Transactions.txt", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine(transaction);

                writer.Flush();
                writer.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

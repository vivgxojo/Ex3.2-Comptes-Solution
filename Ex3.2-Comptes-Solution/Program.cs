using Ex3._2_Comptes_Solution;

// Création d'un client et d'un compte
Console.WriteLine("Bienvenue dans votre banque !");
Client client = new Client("Dupont", "Jean", "TechCorp", "123456789", "1234");
CompteBancaire compte = new CompteBancaire(1001, client);

bool continuer = true;

while (continuer)
{
    Console.WriteLine("\nQue voulez-vous faire ?");
    Console.WriteLine("1. Déposer de l'argent");
    Console.WriteLine("2. Retirer de l'argent");
    Console.WriteLine("3. Connaître votre solde");
    Console.WriteLine("4. Voir les transactions récentes");
    Console.WriteLine("5. Changer votre NIP");
    Console.WriteLine("6. Quitter");

    Console.Write("\nVotre choix : ");
    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            Console.Write("Entrez le montant à déposer : ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montantDepot))
            {
                compte.Deposer(montantDepot);
            }
            else
            {
                Console.WriteLine("Montant invalide.");
            }
            break;

        case "2":
            Console.Write("Entrez le montant à retirer : ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montantRetrait))
            {
                compte.Retirer(montantRetrait);
            }
            else
            {
                Console.WriteLine("Montant invalide.");
            }
            break;

        case "3":
            compte.AfficherSolde();
            break;

        case "4":
            compte.AfficherTransactions();
            break;

        case "5":
            Console.Write("Entrez votre ancien NIP : ");
            string ancienNIP = Console.ReadLine();
            Console.Write("Entrez votre nouveau NIP : ");
            string nouveauNIP = Console.ReadLine();
            client.ChangerNIP(ancienNIP, nouveauNIP);
            break;

        case "6":
            continuer = false;
            Console.WriteLine("Merci d'avoir utilisé nos services. Au revoir !");
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}

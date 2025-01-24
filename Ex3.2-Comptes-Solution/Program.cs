using Ex3._2_Comptes_Solution;

List<Client> _clients = new List<Client>();
List<Compte> _comptes = new List<Compte>();
Client client = null;
Compte compte = null;
Console.WriteLine("Bienvenue dans votre banque !");
while (true) {
    Console.WriteLine("1. Créer compte");
    Console.WriteLine("2. Se connecter");
    string choix = Console.ReadLine();
    switch (choix)
    {
        case "1":
            Console.WriteLine("Entrez votre nom");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez votre prénom");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrez votre employeur");
            string employeur = Console.ReadLine();
            Console.WriteLine("Entrez votre NAS");
            string nas = Console.ReadLine();
            string nip, nip2;
            do
            {
                Console.WriteLine("Choisissez votre NIP");
                nip = Console.ReadLine();
                Console.WriteLine("Entrez à nouveau votre NIP");
                nip2 = Console.ReadLine();
            } while (nip != nip2);
            client = new Client(nom, prenom, employeur, nas, nip);
            _clients.Add(client);
            compte = client.OuvrirCompte();
            _comptes.Add(compte);
            Console.WriteLine($"Votre numéro de compte est {compte.NumeroCompte}.");
            break;

        case "2":
            long no;
            do
            {
                Console.WriteLine("Entrez votre numéro de compte");
                no = long.Parse(Console.ReadLine());
                Console.WriteLine("Entrez votre NIP");
                nip = Console.ReadLine();
                compte = _comptes.Find(c => c.NumeroCompte == no);
                client = compte.Proprietaire;
            } while (client._nip != nip);
            break;
    }

    bool continuer = true;

    while (continuer)
    {
        Console.WriteLine("\nVous êtes maintenant connectés, que voulez-vous faire ?");
        Console.WriteLine("1. Déposer de l'argent");
        Console.WriteLine("2. Retirer de l'argent");
        Console.WriteLine("3. Connaître votre solde");
        Console.WriteLine("4. Voir les transactions récentes");
        Console.WriteLine("5. Changer votre NIP");
        Console.WriteLine("6. Quitter");

        Console.Write("\nVotre choix : ");
        choix = Console.ReadLine();

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
}
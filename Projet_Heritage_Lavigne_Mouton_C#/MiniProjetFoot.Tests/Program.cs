using MiniProjetFoot.Metier;

static void Verifier(bool condition, string message)
{
    if (!condition)
        throw new InvalidOperationException($"Échec du test : {message}");
}

static void TesterAgeInvalide()
{
    try
    {
        _ = new Joueur("Nom", "Prenom", 12, "Attaquant", 1);
    }
    catch (ArgumentOutOfRangeException)
    {
        return;
    }

    throw new InvalidOperationException("Le test de l’âge invalide a échoué.");
}

static void TesterPosteInvalide()
{
    try
    {
        _ = new Joueur("Nom", "Prenom", 20, "Arriere", 1);
    }
    catch (ArgumentException)
    {
        return;
    }

    throw new InvalidOperationException("Le test du poste invalide a échoué.");
}

static void TesterButsNegatifs()
{
    try
    {
        _ = new Attaquant("Nom", "Prenom", 20, 1, -1);
    }
    catch (ArgumentOutOfRangeException)
    {
        return;
    }

    throw new InvalidOperationException("Le test des buts négatifs a échoué.");
}

static void TesterTaclesNegatifs()
{
    try
    {
        _ = new Defenseur("Nom", "Prenom", 20, 1, -1);
    }
    catch (ArgumentOutOfRangeException)
    {
        return;
    }

    throw new InvalidOperationException("Le test des tacles négatifs a échoué.");
}

static void TesterJoueurDansMauvaiseEquipe(Equipe equipe, Joueur joueur)
{
    try
    {
        equipe.AjouterJoueur(joueur);
    }
    catch (ArgumentException)
    {
        return;
    }

    throw new InvalidOperationException("Le test du joueur dans la mauvaise équipe a échoué.");
}

static void TesterJoueurBlesse()
{
    var joueur = new Joueur("Nom", "Prenom", 20, "Milieu", 1)
    {
        Blesse = true
    };

    try
    {
        joueur.Jouer();
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine("Exception levée : un joueur blessé ne peut pas jouer.");
        return;
    }

    throw new InvalidOperationException("Le test du joueur blessé a échoué.");
}

static void TesterMatchAvecJoueurBlesse(Equipe equipe, Equipe adversaire)
{
    Joueur joueur = equipe.Joueurs[0];
    joueur.Blesse = true;

    try
    {
        _ = equipe.JouerMatch(adversaire);
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine("Exception levée : une équipe avec un joueur blessé ne peut pas jouer.");
        joueur.Blesse = false;
        return;
    }

    joueur.Blesse = false;
    throw new InvalidOperationException("Le test du match avec un joueur blessé a échoué.");
}

var equipe = new Equipe(1, "Les Aigles");
var autreEquipe = new Equipe(2, "Les Lions");
List<Joueur> joueurs =
[
    new Attaquant("Martin", "Lucas", 22, 1, 8),
    new Defenseur("Petit", "Noah", 28, 1, 14),
    new Joueur("Lefevre", "Enzo", 24, "Milieu", 1),
];

foreach (Joueur joueur in joueurs)
    equipe.AjouterJoueur(joueur);

var joueurAutreEquipe = new Defenseur("Roux", "Adam", 23, 2, 10);
autreEquipe.AjouterJoueur(joueurAutreEquipe);
autreEquipe.AjouterJoueur(new Attaquant("Moreau", "Jules", 21, 2, 6));
autreEquipe.AjouterJoueur(new Joueur("Diallo", "Sami", 24, "Milieu", 2));

Verifier(equipe.Joueurs.Count == 3, "la collection contient trois joueurs");
Verifier(equipe.Joueurs[0] is Attaquant, "l’attaquant est conservé dans la collection polymorphe");
Verifier(equipe.Joueurs[1] is Defenseur, "le défenseur est conservé dans la collection polymorphe");
Console.WriteLine(equipe);
foreach (Joueur joueur in equipe.Joueurs)
    Console.WriteLine($" - {joueur}");
Console.WriteLine(autreEquipe);
foreach (Joueur joueur in autreEquipe.Joueurs)
    Console.WriteLine($" - {joueur}");

Console.WriteLine($"Match : {equipe.JouerMatch(autreEquipe)}");

TesterAgeInvalide();
TesterPosteInvalide();
TesterButsNegatifs();
TesterTaclesNegatifs();
TesterJoueurDansMauvaiseEquipe(equipe, joueurAutreEquipe);
TesterJoueurBlesse();
TesterMatchAvecJoueurBlesse(equipe, autreEquipe);

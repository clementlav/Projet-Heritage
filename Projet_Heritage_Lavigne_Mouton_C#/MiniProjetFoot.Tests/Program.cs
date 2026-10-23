using MiniProjetFoot.Metier;


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
        return;
    }

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
        joueur.Blesse = false;
        return;
    }

    joueur.Blesse = false;
}

static void TesterIdentifiantJoueurInvalide()
{
    try
    {
        _ = new Joueur("Nom", "Prenom", 20, "Milieu", 1, 0);
    }
    catch (ArgumentException)
    {
        return;
    }

}

static void TesterEquipeIdJoueurInvalide()
{
    try
    {
        _ = new Joueur("Nom", "Prenom", 20, "Milieu", 0);
    }
    catch (ArgumentOutOfRangeException)
    {
        return;
    }

}

static void TesterNomJoueurVide()
{
    try
    {
        _ = new Joueur("", "Prenom", 20, "Milieu", 1);
    }
    catch (ArgumentException)
    {
        return;
    }

}

static void TesterPrenomJoueurVide()
{
    try
    {
        _ = new Joueur("Nom", "", 20, "Milieu", 1);
    }
    catch (ArgumentException)
    {
        return;
    }

}

static void TesterIdentifiantEquipeInvalide()
{
    try
    {
        _ = new Equipe(0, "Equipe");
    }
    catch (ArgumentOutOfRangeException)
    {
        return;
    }

}

static void TesterNomEquipeVide()
{
    try
    {
        _ = new Equipe(1, "");
    }
    catch (ArgumentException)
    {
        return;
    }

}

static void TesterMatchContreSoiMeme(Equipe equipe)
{
    try
    {
        _ = equipe.JouerMatch(equipe);
    }
    catch (InvalidOperationException)
    {
        return;
    }

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


Console.WriteLine(equipe);
foreach (Joueur joueur in equipe.Joueurs)
    Console.WriteLine($" - {joueur}");
Console.WriteLine(autreEquipe);
foreach (Joueur joueur in autreEquipe.Joueurs)
    Console.WriteLine($" - {joueur}");

Console.WriteLine($"Match : {equipe.JouerMatch(autreEquipe)}");

TesterAgeInvalide();
TesterIdentifiantJoueurInvalide();
TesterEquipeIdJoueurInvalide();
TesterNomJoueurVide();
TesterPrenomJoueurVide();
TesterPosteInvalide();
TesterButsNegatifs();
TesterTaclesNegatifs();
TesterJoueurDansMauvaiseEquipe(equipe, joueurAutreEquipe);
TesterIdentifiantEquipeInvalide();
TesterNomEquipeVide();
TesterMatchContreSoiMeme(equipe);
TesterJoueurBlesse();
TesterMatchAvecJoueurBlesse(equipe, autreEquipe);

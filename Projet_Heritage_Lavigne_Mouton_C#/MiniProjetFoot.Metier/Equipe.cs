namespace MiniProjetFoot.Metier;

public class Equipe
{
    #region Champs privés
    private int _id;
    private string _nom = string.Empty;
    private readonly List<Joueur> _joueurs = [];
    #endregion

    #region Propriétés
    public int Id
    {
        get => _id;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "L’identifiant de l’équipe doit être positif.");
            _id = value;
        }
    }

    public string Nom
    {
        get => _nom;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Le nom de l’équipe ne peut pas être vide.");
            _nom = value.Trim();
        }
    }

    public IReadOnlyList<Joueur> Joueurs => _joueurs;
    #endregion

    #region Constructeurs
    public Equipe(int id, string nom)
    {
        Id = id;
        Nom = nom;
    }
    #endregion

    #region Méthodes
    public void AjouterJoueur(Joueur joueur)
    {
        ArgumentNullException.ThrowIfNull(joueur);
        if (joueur.EquipeId != Id)
            throw new ArgumentException("Ce joueur appartient à une autre équipe.", nameof(joueur));
        _joueurs.Add(joueur);
    }

    public string JouerMatch(Equipe adversaire)
    {
        ArgumentNullException.ThrowIfNull(adversaire);
        if (adversaire.Id == Id)
            throw new ArgumentException("Une équipe ne peut pas jouer contre elle-même.", nameof(adversaire));

        foreach (Joueur joueur in Joueurs)
            joueur.Jouer();

        foreach (Joueur joueur in adversaire.Joueurs)
            joueur.Jouer();

        int butsEquipe = Random.Shared.Next(0, 6);
        int butsAdversaire = Random.Shared.Next(0, 6);
        string resultat = $"{Nom} {butsEquipe} - {butsAdversaire} {adversaire.Nom}";

        if (butsEquipe > butsAdversaire)
            return $"{resultat} : {Nom} gagne !";

        if (butsAdversaire > butsEquipe)
            return $"{resultat} : {adversaire.Nom} gagne !";

        return $"{resultat} : match nul.";
    }

    public override string ToString() => $"{Nom} ({Joueurs.Count} joueur(s))";
    #endregion
}

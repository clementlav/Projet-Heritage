namespace MiniProjetFoot.Metier;

public class Joueur
{
    #region Champs privés
    private int? _id;
    private string _nom = string.Empty;
    private string _prenom = string.Empty;
    private int _age;
    private string _poste = string.Empty;
    private int _equipeId;
    private bool _blesse;
    #endregion

    #region Propriétés
    public int? Id
    {
        get => _id;
        set
        {
            if (value.HasValue && value.Value <= 0)
                throw new ArgumentException("L’identifiant doit être positif.");
            _id = value;
        }
    }

    public string Nom
    {
        get => _nom;
        set => _nom = ValiderTexte(value, "Le nom");
    }

    public string Prenom
    {
        get => _prenom;
        set => _prenom = ValiderTexte(value, "Le prénom");
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value is < 15 or > 50)
                throw new ArgumentOutOfRangeException(nameof(value), "L’âge doit être compris entre 15 et 50 ans.");
            _age = value;
        }
    }

    public string Poste
    {
        get => _poste;
        set
        {
            string[] postes = ["Defenseur", "Milieu", "Attaquant"];
            if (!postes.Contains(value, StringComparer.Ordinal))
                throw new ArgumentException("Le poste doit être Defenseur, Milieu ou Attaquant.");
            _poste = value;
        }
    }

    public int EquipeId
    {
        get => _equipeId;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "L’identifiant de l’équipe doit être positif.");
            _equipeId = value;
        }
    }

    public bool Blesse
    {
        get => _blesse;
        set => _blesse = value;
    }
    #endregion

    #region Constructeurs
    public Joueur(string nom, string prenom, int age, string poste, int equipeId, int? id = null)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Age = age;
        Poste = poste;
        EquipeId = equipeId;
    }
    #endregion

    #region Méthodes
    public override string ToString() => $"{Prenom} {Nom} — {Poste}, {Age} ans";

    public void Jouer()
    {
        if (Blesse)
            throw new InvalidOperationException("Un joueur blessé ne peut pas jouer.");
    }

    private static string ValiderTexte(string valeur, string libelle)
    {
        if (string.IsNullOrWhiteSpace(valeur))
            throw new ArgumentException($"{libelle} ne peut pas être vide.");
        return valeur.Trim();
    }
    #endregion
}

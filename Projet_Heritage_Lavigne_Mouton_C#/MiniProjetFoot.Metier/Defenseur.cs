namespace MiniProjetFoot.Metier;

public class Defenseur : Joueur
{
    #region Champs privés
    private int _tacles;
    #endregion

    #region Propriétés
    public int Tacles
    {
        get => _tacles;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Le nombre de tacles ne peut pas être négatif.");
            _tacles = value;
        }
    }
    #endregion

    #region Constructeurs
    public Defenseur(string nom, string prenom, int age, int equipeId, int tacles = 0, int? id = null)
        : base(nom, prenom, age, "Defenseur", equipeId, id)
    {
        Tacles = tacles;
    }
    #endregion

    #region Méthodes
    public override string ToString() => $"{base.ToString()} — {Tacles} tacle(s)";
    #endregion
}

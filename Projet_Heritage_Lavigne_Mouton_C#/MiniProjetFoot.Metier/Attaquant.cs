namespace MiniProjetFoot.Metier;

public class Attaquant : Joueur
{
    #region Champs privés
    private int _buts;
    #endregion

    #region Propriétés
    public int Buts
    {
        get => _buts;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Le nombre de buts ne peut pas être négatif.");
            _buts = value;
        }
    }
    #endregion

    #region Constructeurs
    public Attaquant(string nom, string prenom, int age, int equipeId, int buts = 0, int? id = null)
        : base(nom, prenom, age, "Attaquant", equipeId, id)
    {
        Buts = buts;
    }
    #endregion

    #region Méthodes
    public override string ToString() => $"{base.ToString()} — {Buts} but(s)";
    #endregion
}

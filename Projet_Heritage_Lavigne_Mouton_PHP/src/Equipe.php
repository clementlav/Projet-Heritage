<?php

require_once __DIR__ . '/Joueur.php';

class Equipe
{
    private int $id;
    private string $nom;
    private array $joueurs = [];

    public function __construct(int $id, string $nom)
    {
        $this->setId($id);
        $this->setNom($nom);
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function setId(int $id): void
    {
        if ($id <= 0) {
            throw new InvalidArgumentException('L’identifiant de l’équipe doit être positif.');
        }

        $this->id = $id;
    }

    public function getNom(): string
    {
        return $this->nom;
    }

    public function setNom(string $nom): void
    {
        if ($nom === '') {
            throw new InvalidArgumentException('Le nom de l’équipe ne peut pas être vide.');
        }

        $this->nom = $nom;
    }

    public function ajouterJoueur(Joueur $joueur): void
    {
        if ($joueur->getEquipeId() !== $this->id) {
            throw new InvalidArgumentException('Ce joueur appartient à une autre équipe.');
        }

        $this->joueurs[] = $joueur;
    }

    public function getJoueurs(): array
    {
        return $this->joueurs;
    }

    public function jouerMatch(Equipe $adversaire): string
    {
        if ($adversaire->getId() === $this->id) {
            throw new InvalidArgumentException('Une équipe ne peut pas jouer contre elle-même.');
        }

        foreach ($this->joueurs as $joueur) {
            $joueur->jouer();
        }

        foreach ($adversaire->getJoueurs() as $joueur) {
            $joueur->jouer();
        }

        $butsEquipe = random_int(0, 5);
        $butsAdversaire = random_int(0, 5);
        $resultat = $this->nom . ' ' . $butsEquipe . ' - ' . $butsAdversaire . ' ' . $adversaire->getNom();

        if ($butsEquipe > $butsAdversaire) {
            return $resultat . ' : ' . $this->nom . ' gagne !';
        }

        if ($butsAdversaire > $butsEquipe) {
            return $resultat . ' : ' . $adversaire->getNom() . ' gagne !';
        }

        return $resultat . ' : match nul.';
    }

    public function __toString(): string
    {
        return $this->nom . ' (' . count($this->joueurs) . ' joueur(s))';
    }
}

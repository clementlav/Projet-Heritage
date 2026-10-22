<?php
declare(strict_types=1);

class Joueur
{
    private ?int $id;
    private string $nom;
    private string $prenom;
    private int $age;
    private string $poste;
    private int $equipeId;
    private bool $blesse = false;

    public function __construct(
        string $nom,
        string $prenom,
        int $age,
        string $poste,
        int $equipeId,
        ?int $id = null
    ) {
        $this->setId($id);
        $this->setNom($nom);
        $this->setPrenom($prenom);
        $this->setAge($age);
        $this->setPoste($poste);
        $this->setEquipeId($equipeId);
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function setId(?int $id): void
    {
        if ($id !== null && $id <= 0) {
            throw new InvalidArgumentException('L’identifiant doit être positif.');
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
            throw new InvalidArgumentException('Le nom ne peut pas être vide.');
        }

        $this->nom = $nom;
    }

    public function getPrenom(): string
    {
        return $this->prenom;
    }

    public function setPrenom(string $prenom): void
    {
        if ($prenom === '') {
            throw new InvalidArgumentException('Le prénom ne peut pas être vide.');
        }

        $this->prenom = $prenom;
    }

    public function getAge(): int
    {
        return $this->age;
    }

    public function setAge(int $age): void
    {
        if ($age < 15 || $age > 50) {
            throw new InvalidArgumentException('L’âge doit être compris entre 15 et 50 ans.');
        }

        $this->age = $age;
    }

    public function getPoste(): string
    {
        return $this->poste;
    }

    public function setPoste(string $poste): void
    {
        if ($poste !== 'Defenseur' && $poste !== 'Milieu' && $poste !== 'Attaquant') {
            throw new InvalidArgumentException('Le poste doit être Defenseur, Milieu ou Attaquant.');
        }

        $this->poste = $poste;
    }

    public function getEquipeId(): int
    {
        return $this->equipeId;
    }

    public function setEquipeId(int $equipeId): void
    {
        if ($equipeId <= 0) {
            throw new InvalidArgumentException('L’identifiant de l’équipe doit être positif.');
        }

        $this->equipeId = $equipeId;
    }

    public function getBlesse(): bool
    {
        return $this->blesse;
    }

    public function setBlesse(bool $blesse): void
    {
        $this->blesse = $blesse;
    }

    public function jouer(): void
    {
        if ($this->blesse) {
            throw new LogicException('Un joueur blessé ne peut pas jouer.');
        }
    }

    public function __toString(): string
    {
        return $this->prenom . ' ' . $this->nom . ' — ' . $this->poste . ', ' . $this->age . ' ans';
    }
}

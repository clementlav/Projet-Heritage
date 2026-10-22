<?php
declare(strict_types=1);

require_once __DIR__ . '/Joueur.php';

class Attaquant extends Joueur
{
    private int $buts;

    public function __construct(
        string $nom,
        string $prenom,
        int $age,
        int $equipeId,
        int $buts = 0,
        ?int $id = null
    ) {
        parent::__construct($nom, $prenom, $age, 'Attaquant', $equipeId, $id);
        $this->setButs($buts);
    }

    public function getButs(): int
    {
        return $this->buts;
    }

    public function setButs(int $buts): void
    {
        if ($buts < 0) {
            throw new InvalidArgumentException('Le nombre de buts ne peut pas être négatif.');
        }

        $this->buts = $buts;
    }

    public function __toString(): string
    {
        return parent::__toString() . ' — ' . $this->buts . ' but(s)';
    }
}

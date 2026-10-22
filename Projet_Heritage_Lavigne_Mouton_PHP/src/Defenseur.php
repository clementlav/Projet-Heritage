<?php
declare(strict_types=1);

require_once __DIR__ . '/Joueur.php';

class Defenseur extends Joueur
{
    private int $tacles;

    public function __construct(
        string $nom,
        string $prenom,
        int $age,
        int $equipeId,
        int $tacles = 0,
        ?int $id = null
    ) {
        parent::__construct($nom, $prenom, $age, 'Defenseur', $equipeId, $id);
        $this->setTacles($tacles);
    }

    public function getTacles(): int
    {
        return $this->tacles;
    }

    public function setTacles(int $tacles): void
    {
        if ($tacles < 0) {
            throw new InvalidArgumentException('Le nombre de tacles ne peut pas être négatif.');
        }

        $this->tacles = $tacles;
    }

    public function __toString(): string
    {
        return parent::__toString() . ' — ' . $this->tacles . ' tacle(s)';
    }
}

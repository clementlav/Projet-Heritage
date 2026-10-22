<?php
declare(strict_types=1);

require_once __DIR__ . '/../src/Equipe.php';
require_once __DIR__ . '/../src/Attaquant.php';
require_once __DIR__ . '/../src/Defenseur.php';

function testerAgeInvalide(): void
{
    try {
        new Joueur('Nom', 'Prenom', 12, 'Attaquant', 1);
    } catch (InvalidArgumentException) {
        echo "Exception levée : l'âge invalide.\n";
        return;
    }

    throw new RuntimeException('Le test de l’âge invalide a échoué.');
}

function testerPosteInvalide(): void
{
    try {
        new Joueur('Nom', 'Prenom', 20, 'Arriere', 1);
    } catch (InvalidArgumentException) {
        echo "Exception levée : le poste invalide.\n";
        return;
    }

    throw new RuntimeException('Le test du poste invalide a échoué.');
}

function testerButsNegatifs(): void
{
    try {
        new Attaquant('Nom', 'Prenom', 20, 1, -1);
    } catch (InvalidArgumentException) {
        echo "Exception levée : nombre de buts négatif.\n";
        return;
    }

    throw new RuntimeException('Le test des buts négatifs a échoué.');
}

function testerTaclesNegatifs(): void
{
    try {
        new Defenseur('Nom', 'Prenom', 20, 1, -1);
    } catch (InvalidArgumentException) {
        echo "Exception levée : nombre de tacles négatif.\n";
        return;
    }

    throw new RuntimeException('Le test des tacles négatifs a échoué.');
}

function testerJoueurDansMauvaiseEquipe(Equipe $equipe, Joueur $joueur): void
{
    try {
        $equipe->ajouterJoueur($joueur);
    } catch (InvalidArgumentException) {
        echo "Exception levée : joueur d'une autre équipe.\n";
        return;
    }

    throw new RuntimeException('Le test du joueur dans la mauvaise équipe a échoué.');
}

function testerJoueurBlesse(): void
{
    $joueur = new Joueur('Nom', 'Prenom', 20, 'Milieu', 1);
    $joueur->setBlesse(true);

    try {
        $joueur->jouer();
    } catch (LogicException) {
        echo "Exception levée : un joueur blessé ne peut pas jouer.\n";
        return;
    }

    throw new RuntimeException('Le test du joueur blessé a échoué.');
}






$equipe = new Equipe(1, 'Les Aigles');
$autreEquipe = new Equipe(2, 'Les Lions');
$joueurs = [
    new Attaquant('Martin', 'Lucas', 22, 1, 8),
    new Defenseur('Bernard', 'Hugo', 25, 1, 14),
    new Joueur('Lefevre', 'Enzo', 24, 'Milieu', 1),
];

foreach ($joueurs as $joueur) {
    $equipe->ajouterJoueur($joueur);
}

$joueurAutreEquipe = new Defenseur('Roux', 'Adam', 23, 2, 10);
$autreEquipe->ajouterJoueur($joueurAutreEquipe);
$autreEquipe->ajouterJoueur(new Attaquant('Moreau', 'Jules', 21, 2, 6));
$autreEquipe->ajouterJoueur(new Joueur('Diallo', 'Sami', 24, 'Milieu', 2));

echo $equipe . "\n";
foreach ($equipe->getJoueurs() as $joueur) {
    echo ' - ' . $joueur . "\n";
}

echo $autreEquipe . "\n";
foreach ($autreEquipe->getJoueurs() as $joueur) {
    echo ' - ' . $joueur . "\n";
}

echo "Match : " . $equipe->jouerMatch($autreEquipe) . "\n";

testerAgeInvalide();
testerPosteInvalide();
testerButsNegatifs();
testerTaclesNegatifs();
testerJoueurDansMauvaiseEquipe($equipe, $joueurAutreEquipe);
testerJoueurBlesse();

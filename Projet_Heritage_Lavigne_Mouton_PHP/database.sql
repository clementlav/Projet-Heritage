
CREATE TABLE IF NOT EXISTS equipe (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS joueur (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(80) NOT NULL,
    prenom VARCHAR(80) NOT NULL,
    age TINYINT UNSIGNED NOT NULL,
    poste ENUM('Defenseur', 'Milieu', 'Attaquant') NOT NULL,
    blesse BOOLEAN NOT NULL DEFAULT FALSE,
    equipe_id INT NOT NULL,
    CONSTRAINT ck_joueur_age CHECK (age BETWEEN 15 AND 50),
    CONSTRAINT fk_joueur_equipe FOREIGN KEY (equipe_id) REFERENCES equipe(id)
);

CREATE TABLE IF NOT EXISTS attaquant (
    joueur_id INT PRIMARY KEY,
    buts INT UNSIGNED NOT NULL DEFAULT 0,
    CONSTRAINT fk_attaquant_joueur FOREIGN KEY (joueur_id)
        REFERENCES joueur(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS defenseur (
    joueur_id INT PRIMARY KEY,
    tacles INT UNSIGNED NOT NULL DEFAULT 0,
    CONSTRAINT fk_defenseur_joueur FOREIGN KEY (joueur_id)
        REFERENCES joueur(id) ON DELETE CASCADE
);

INSERT INTO equipe (id, nom) VALUES
    (1, 'Les Aigles'),
    (2, 'Les Lions');

INSERT INTO joueur (id, nom, prenom, age, poste, equipe_id) VALUES
    (1, 'Martin', 'Lucas', 22, 'Attaquant', 1),
    (2, 'Bernard', 'Hugo', 25, 'Defenseur', 1),
    (3, 'Lefevre', 'Enzo', 24, 'Milieu', 1),
    (4, 'Roux', 'Adam', 23, 'Defenseur', 2),
    (5, 'Moreau', 'Jules', 21, 'Attaquant', 2),
    (6, 'Diallo', 'Sami', 24, 'Milieu', 2);

INSERT INTO attaquant (joueur_id, buts) VALUES
    (1, 8),
    (5, 6);

INSERT INTO defenseur (joueur_id, tacles) VALUES
    (2, 14),
    (4, 10);

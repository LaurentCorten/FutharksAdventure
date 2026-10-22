# FUTHARK'S ADVENTURE - Roadmap Vertical Slice (v2)

Base : GDD octobre 2026 (chapitre 12).
Echeance : slice fonctionnelle le 01/12/2026, produit fini le 15/12/2026.
Budget : ~10-15 h/semaine jusqu'au 22/11, ~30 h/semaine du 23/11 au 15/12.

Legende :
[ ] a faire | [x] fait
(T) test unitaire EditMode | (V) verification visuelle en Play mode | (D) decision a prendre
(+) "si le temps le permet" : hors noyau garanti, reporte sans regret

## Regles de travail

- Chaque phase produit quelque chose de JOUABLE avant de passer a la suivante.
- Pas d'anticipation : une interface n'est creee que quand un besoin reel apparait
  (deux implementations, ou un faux necessaire pour un test). Chaque decision est
  expliquee et validee avant d'etre codee.
- Regles du jeu en C# pur (Core) testees ; MonoBehaviours = colle fine ; donnees dans des ScriptableObjects.
- Communication logique -> affichage par evenements (pas de dependance directe).
- Point d'entree unique : scene Bootstrap + Composition Root (seul endroit qui fait les new).
- Les [A DEFINIR] du GDD sont tranches au moment ou ils deviennent necessaires, ou au playtest.
- Checkpoint : si J2 n'est pas atteint le 15/11, on revoit le perimetre.

---

## Planning

| Semaine | Dates | Heures | Phases visees | Jalon |
|---|---|---|---|---|
| S1 | 22/10 - 01/11 | ~12 h | Phase 2 | J1 |
| S2 | 02/11 - 08/11 | ~12 h | Phase 3 | |
| S3 | 09/11 - 15/11 | ~12 h | Phase 4 | J2 |
| S4 | 16/11 - 22/11 | ~12 h | Phases 5-6 | J3 |
| S5 | 23/11 - 01/12 | ~40 h | Phases 7-8-9 + debut 10 | J4 = SLICE |
| S6 | 02/12 - 08/12 | ~30 h | Phase 10 + playtests | J5 |
| S7 | 09/12 - 15/12 | ~30 h | Phase 11 + paliers si temps | J6 = FINI |

Tache de fond des S1 (peu d'heures) : chercher et choisir le pack d'assets externe
(il fixe la taille de tuile et la DA, mieux vaut le savoir tot).

---

## Phase 1 - Setup du projet [quasi termine]

- [x] Projet Unity 6, Git, packages, arborescence, Assembly Definitions FutharksAdventure.{Core, Game, Tests}
- [x] (T) Les tests EditMode se lancent
- [ ] Scene Bootstrap + script Bootstrap (Composition Root minimal) -> fait en Phase 2.4

---

## Phase 2 - Grille, affichage et tour par tour (S1) -> J1

Objectif : un carre qui se deplace sur une grille, un tour a la fois, camera qui le suit.

### 2.1 Modele de grille (Core) [termine]
- [x] GridPosition, TileType, FloorGrid
- [x] (T) Tests verts

### 2.2 Vue de grille (Game)
- [ ] GridView : dessine TOUTE la FloorGrid dans un Tilemap (placeholders carres de couleur)
- [ ] Etage de test code en dur (en attendant la generation procedurale de la Phase 5)
- [ ] Convention : 1 case = 1 unite Unity (conversion GridPosition <-> monde triviale)
- [ ] Camera fixe cadrant l'etage de test (le suivi du joueur arrive en 2.4)
- [ ] Hors grille : fond uni (case Empty)
- [ ] (V) L'etage s'affiche, la camera reste centree sur le joueur, y compris pres des bords

### 2.3 Systeme de tours (Core)
- [ ] (D) Seance de conception : tours, actions, deplacement, occupation des cases (avant tout code)
- [ ] Implementation selon les decisions prises
- [ ] (T) Tests definis a l'issue de la seance de conception

### 2.4 Input, affichage des entites, camera, Bootstrap
- [ ] Input Actions asset : Move, RangedAttack, UseItem, Pause, Confirm, Cancel
- [ ] Lecture de l'input (clavier : fleches / ZQSD / WASD / pave num) ; la logique ne connait que des actions abstraites
- [ ] EntityView : composant generique d'affichage d'une entite (joueur pour l'instant), deplacement instantane
- [ ] Camera qui suit le joueur ; Orthographic Size dans une config (fixe en jeu, ajustable aux playtests)
- [ ] Bootstrap : cree la grille, le joueur, l'input, le TurnManager, les vues, et les relie
- [ ] (V) Le carre se deplace case par case, bloque par les murs, la camera le suit

---

## Phase 3 - Le joueur (S2)

### 3.1 Stats et ressources
- [ ] PlayerStats (Core) : PV, PV max, nourriture, hachettes, VisionRange
- [ ] Config de depart (SO) : PV 17, nourriture 150, hachettes 3, VisionRange (D valeur)
- [ ] Cout du tour : -1 nourriture ; a 0 : -1 PV par tour
- [ ] Evenement PlayerDied
- [ ] (T) Consommation, famine, mort par famine sans ennemi

### 3.2 Combat
- [ ] Sante (TakeDamage, IsDead) partagee joueur / ennemis
- [ ] Attaque melee : MoveAction vers une case ennemie => AttackAction
- [ ] Degats fixes, toujours touche (le test de touche est un ajout de palier)
- [ ] ThrowAction + selection automatique de cible (regles GDD 6.6) :
      alignement 4 axes, portee = VisionRange (carre), ligne de visee non bloquee par un mur,
      pas de case adjacente, plus proche, egalite -> cible precedente, sinon moins de PV
      (D) egalite de PV aussi : premier de la liste en attendant
- [ ] Aucune cible ou stock vide : action refusee, aucun tour, aucune hachette perdue
- [ ] (T) Un test par regle du tableau 6.6

### 3.3 Potion et inventaire (logique seule)
- [ ] Inventaire en file : 3 emplacements, rempli de droite a gauche, sans trou
- [ ] Ajout : case libre la plus a droite ; plein : ejection de l'item le plus a droite, decalage, ajout a gauche
- [ ] Utilisation : consommation puis decalage vers la droite des items a gauche
- [ ] Potion de vie : soin moyen plafonne aux PV max
- [ ] (T) Ajout, ejection quand plein (l'item ejecte est renvoye), decalage apres utilisation, potion plafonnee

### Fin de S2
- [ ] Choisir et acheter / telecharger le pack d'assets (au plus tard le 08/11) : fixe la taille de tuile

---

## Phase 4 - Ennemis (S3) -> J2

- [ ] (D) Algorithme de deplacement vers le joueur (a discuter : BFS ou plus simple)
- [ ] Cerveau d'ennemi (strategie par comportement) : Chaser, Wanderer ; Ranged (+)
- [ ] EnemyData (SO) : nom, PV, degats, detectionDistance, randomStepChance, score, drop
- [ ] 2 types de monstres garantis aux stats distinctes ; 3e type (+)
- [ ] 1 action par tour : deplacement OU attaque ; conflit de case : premier de la liste gagne
- [ ] Mort : retire de la grille, evenement (score plus tard)
- [ ] EntityView reutilisee pour les ennemis (apparition, deplacement, disparition)
- [ ] (T) Detection, poursuite, attaque, mort ; aucun ennemi ne traverse un mur ou un autre ennemi
- [ ] (V) Combat jouable a l'ecran, famine fonctionnelle

---

## Phase 5 - Generation procedurale et brouillard (S4)

### 5.1 Generation (Core)
- [ ] (D) Taille de l'etage et des pieces (idee : 21x21, pieces 5x5 max, 1 case de mur autour)
- [ ] 9 pieces en 3x3, couloirs entre voisines, fusion possible (probabilite parametrable)
- [ ] Entree et sortie dans deux pieces differentes
- [ ] Placement des monstres selon une config de densite
- [ ] Seed de run ; seed d'etage derivee de (seed de run, numero d'etage)
- [ ] Affichage ASCII de debug
- [ ] (T) 1000 seeds : 100 % des etages completables, sortie != entree

### 5.2 Brouillard
- [ ] Etat par case (Core) : jamais vue / deja vue / visible
- [ ] Mise a jour a chaque tour : zone carree de rayon VisionRange autour du joueur (murs ignores)
- [ ] Affichage : noir si jamais vue, assombri si deja vue, normal si visible ; ennemis caches hors vue
- [ ] (T) Etats corrects apres deplacements ; (V) rendu a l'ecran

---

## Phase 6 - Items au sol et ramassage (S4) -> J3
- [ ] Donnees d'item (SO) : nom, icone, actif/passif, occupe une place, consommable
- [ ] (D) Affichage des items au sol : EntityView ou affichage dedie
- [ ] Loot au sol : nourriture (petite/moyenne/grosse), hachettes (3/5), potion de vie
- [ ] Ramassage automatique en marchant dessus ; item ejecte depose sur la case du joueur
- [ ] Placement du loot a la generation (config de densite)
- [ ] Drops de monstres (+)
- [ ] (T) Ramassage, ressources mises a jour, item ejecte present au sol

---

## Phase 7 - Progression et boss (S5)

- [ ] RunManager : seed, etage courant, etat (en cours / victoire / defaite)
- [ ] Sortie : etage suivant genere, stats du joueur conservees
- [ ] Nombre d'etages normaux parametrable (3 a 5) + etage de boss
- [ ] Difficulte croissante simple via config
- [ ] Etage de boss : une grande piece, le boss garde la sortie
- [ ] Boss : 1 pattern garanti ; 2e et 3e patterns (+)
- [ ] Victoire = boss mort ; defaite = PV a 0
- [ ] (V) Une run complete se joue du premier etage a la victoire ou la mort

---

## Phase 8 - Score et leaderboard (S5)

- [ ] Score : etage atteint + monstres tues ; ponderation dans une config (SO)
- [ ] Leaderboard local JSON, top 10
- [ ] Nom par defaut ; saisie du nom (+)
- [ ] (T) Tri, limite top 10, fichier absent ou corrompu ne plante pas

---

## Phase 9 - Interface et flux de jeu (S5) -> J4 = SLICE

- [ ] State Machine : Bootstrap -> Menu -> Run -> FinDeRun -> Menu ; (D) pause = etat ou sous-etat
- [ ] HUD abonne aux evenements : PV, nourriture, hachettes, inventaire, score ; zone reservee monnaie
- [ ] Utilisation d'item par clic, description au survol
- [ ] Menu principal : Nouvelle run, Leaderboard, Quitter
- [ ] Menu pause : reprendre, abandonner, quitter
- [ ] Ecran de fin : resultat, cause, score, position au leaderboard, rejouer / menu
- [ ] (V) Plusieurs runs enchainees sans relancer le jeu, tout est remis a zero

---

## Phase 10 - Assets, animations, audio (S5-S6) -> J5

- [ ] Integration du pack d'assets : tuiles, joueur, monstres, boss, sortie, loot, icones HUD
- [ ] Taille de tuile et Pixels Per Unit regles selon le pack ; Pixel Perfect Camera
- [ ] Animations de deplacement / attaque ; ennemis animes ensemble apres resolution du tour
- [ ] Blocage de l'input pendant les animations
- [ ] Retours visuels : degats, mort, ramassage
- [ ] Sons minimum : pas, coup porte, coup recu, ramassage, mort, musique ; (+) ambiances
- [ ] Police et cadres (verifier les licences)
- [ ] (V) Le jeu est lisible : joueur, ennemis, loot, sortie identifiables d'un coup d'oeil

---

## Phase 11 - Playtests, equilibrage, build (S6-S7) -> J6 = FINI

- [ ] Build PC teste (pas seulement l'editeur)
- [ ] Playtests : 20 runs completes, noter les points bloquants
- [ ] Equilibrage via les SO : nourriture, PV, hachettes, VisionRange, densites, stats monstres/boss, nombre d'etages
- [ ] Objectif : la famine met la pression sans etre injuste, le boss est un vrai pic
- [ ] Corriger les bugs bloquants ; definir la configuration minimale
- [ ] (V) Criteres du GDD 12.6 tous valides

---

## Paliers apres la slice (GDD 12.4, seulement si temps restant en S7)

- Palier 1 : arme, armure, item nourriture -> PV, quelques runes, ceinture (+)
- Palier 2 : monnaie, marchands
- Palier 3 : lootables de score
- Palier 4 : grandes potions, plus de sorts
- Palier 5 : familiers
- Palier a definir : test de touche (Dex), support manette

## Hors scope de la slice

Monnaie, marchands, equipement, bijoux, runes, grandes potions, item de transformation,
familiers, artefacts, autres biomes, Odin, tactile, manette, mecaniques de biome, test de touche.
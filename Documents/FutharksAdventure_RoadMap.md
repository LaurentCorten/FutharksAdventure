# FUTHARK'S ADVENTURE - Roadmap Vertical Slice

Base : GDD octobre 2026 (chapitre 12, MVP palier 0).
Legende : [ ] a faire | [x] fait | (D) decision a prendre | (T) test de validation

Regle d'or : chaque phase doit produire quelque chose de JOUABLE avant de passer a la suivante.
Ne jamais commencer une phase tant que la precedente n'est pas validee par ses tests (T).

Points non tranches du GDD (royaume du 1er biome, comportement des monstres hors detection, etc.) :
non bloquants pour le moment, a rouvrir quand ils deviennent necessaires.

---

## Phase 1 - Setup du projet

- [x] Creer le projet Unity 6 (template 2D URP)
- [x] Initialiser Git + .gitignore Unity (+ Git LFS si assets lourds)
- [x] Installer packages : Input System, Tilemap, TextMeshPro, Cinemachine
- [x] Arborescence :
      Assets/_Project/{Scripts, ScriptableObjects, Prefabs, Scenes, Art, Audio, UI}
- [x] Assembly Definitions pour separer les couches :
      - Futhark.Core (C# pur, zero UnityEngine) : regles du jeu, grille, tours
      - Futhark.Game (Unity) : MonoBehaviours, vues, prefabs
      - Futhark.Tests (EditMode)
- [ ] Scenes : Bootstrap, MainMenu, Game
- [ ] Convention de nommage + 1 page de regles d'architecture (voir annexe SOLID)
- [x] (T) Le projet compile, les tests EditMode se lancent (un test vide vert)

---

## Phase 2 - Fondations : grille et tour par tour

Objectif : un carre qui se deplace sur une grille, un tour a la fois.

### 2.1 Modele de grille (Core, C# pur)
- [x] struct GridPosition (x, y) + operateurs
- [ ] enum TileType (Floor, Wall, Exit...)
- [ ] class Grid : taille, acces aux cases, IsWalkable, IsInside
- [ ] Interface IOccupant (entite posee sur une case) et registre des occupants par case
- [ ] (T) Tests unitaires : IsWalkable, limites, case occupee

### 2.2 Vue de grille (Game)
- [ ] GridView : dessine la Grid dans un Tilemap (placeholders carres de couleur)
- [ ] Conversion GridPosition <-> position monde
- [ ] ViewportConfig (ScriptableObject) : nombre de colonnes et de lignes affichees, **valeurs impaires** pour que le joueur soit exactement au centre
- [ ] GridView affiche uniquement la fenetre de cases autour du joueur (le joueur reste toujours au centre)
- [ ] Camera centree sur le joueur, avec Pixel Perfect Camera (resolution de reference = colonnes x lignes x taille de tuile)
- [ ] Comportement aux bords de l'etage : choisir une case de remplissage pour les cases hors grille (mur ou vide) [a regarder au premier test]
- [ ] Interface IVisibleArea (Core) : "cette case est-elle affichee a l'ecran ?" ; sert a la portee des hachettes
- [ ] Interface IVisibilityRule (Core) avec une seule implementation pour l'instant : AllDisplayedCellsVisible  (permet d'ajouter plus tard un brouillard a portee fixe ou en ligne de vue sans toucher au reste)
- [ ] Taille de tuile : parametre unique (16 px par defaut, a confirmer selon les assets) ; regler le Pixels Per Unit des sprites en consequence
- [ ] (T) Test visuel : le joueur reste centre en traversant l'etage, y compris pres des bords

### 2.3 Systeme de tours (Core)
- [ ] Interface IActor : TakeTurn()
- [ ] TurnManager : le joueur agit -> chaque ennemi agit -> cout du tour -> attente
- [ ] Interface IAction (Command pattern) : CanExecute() / Execute() / ConsumesTurn
- [ ] Actions : MoveAction, WaitAction (interne), plus tard AttackAction, ThrowAction, UseItemAction
- [ ] Evenements (C# events ou petit EventBus) : TurnStarted, TurnEnded, ActorMoved...
- [ ] (T) Tests : une action valide avance d'un tour ; une action invalide ne consomme rien ; Les ennemis agissent dans l'ordre de leur liste (sequentiel), mais le joueur ne voit qu'un seul tour global ; animations jouees ensemble apres la resolution.

### 2.4 Input
- [ ] Input Actions asset : Move, RangedAttack, UseItem, Pause, Confirm, Cancel
- [ ] Interface IPlayerInput + implementation clavier (fleches / ZQSD / WASD / pave num)
- [ ] La logique ne connait JAMAIS une touche, seulement une action abstraite
- [ ] (T) Le carre se deplace case par case, bloque par les murs, 1 deplacement = 1 tour

---

## Phase 3 - Le joueur

### 3.1 Stats et ressources
- [ ] PlayerStats (PV, PV max, nourriture, hachettes) en classe C# pure
- [ ] Valeurs de depart dans un PlayerStatsConfig (ScriptableObject) : PV 17, nourriture 150, hachettes 3 (provisoires)
- [ ] Systeme de cout de tour : -1 nourriture par tour
- [ ] Famine : nourriture a 0 -> -1 PV par tour
- [ ] Mort : evenement PlayerDied
- [ ] (T) Tests : consommation, famine, mort par famine sans ennemi

### 3.2 Combat
- [ ] Interface IDamageable (TakeDamage, IsDead) et composant Health
- [ ] Attaque melee : se deplacer vers une case occupee par un ennemi => AttackAction
- [ ] Formule de degats simple et isolee (IDamageCalculator) : degats fixes pour la slice
- [ ] Attaque a distance : ThrowAction, decremente les hachettes, projectile instantane sur la ligne
- [ ] Attaque a distance : ThrowAction, decremente les hachettes, cible choisie par un ITargetSelector (visee automatique)
- [ ] Implementation AutoTargetSelector (classe dediee, testable en C# pur), regles du GDD 6.6 :
  - candidats : monstres alignes sur l'un des 4 axes, dans la zone affichee (IVisibleArea), ligne de visee non interrompue
  - exclusion : monstre en case adjacente
  - choix : le plus proche ; a egalite, la cible du coup precedent si elle est candidate ; sinon le moins de PV
  - [a confirmer dans le GDD] egalite de PV aussi : choix temporaire = premier de la liste
- [ ] LastTargetMemory : memorise la derniere cible ; une cible morte n'est simplement plus candidate
- [ ] Aucune cible ou stock vide : action refusee, aucun tour, aucune hachette perdue
- [ ] (T) Tests : melee tue un ennemi, un test par ligne du tableau 6.6 (alignement, adjacence, mur qui bloque, plus proche, egalite avec memoire, egalite sans memoire, aucune cible, stock vide)

### 3.3 Potion de vie
- [ ] Interface IUsable (Use(user)) ; PotionDeVie : rend une quantite moyenne de PV (plafonnee au max)
- [ ] Inventaire minimal : 3 emplacements, ajout/retrait, utilisation
- [ ] (T) Tests : inventaire plein refuse l'ajout, potion plafonne aux PV max

---

## Phase 4 - Ennemis

Objectif : des monstres qui bougent, poursuivent et attaquent.

- [ ] Pathfinding BFS sur la grille (4 directions) en Core [A DISCUTER]
- [ ] Interface IEnemyBrain (DecideAction) : une strategie par comportement
- [ ] Comportements de base :
      - Chaser : detecte puis poursuit le joueur
      - Wanderer : errance, poursuit si detecte
      - Ranged : tire a distance dans l'alignement (si temps)
- [ ] Donnees : EnemyData (ScriptableObject) : nom, PV, degats, rayon de detection, chance d'arreter de poursuivre, brain, score, table de drop
- [ ] Creer 3 types de monstres aux stats distinctes (ex. rapide fragile / lent costaud / a distance)
- [ ] Regle 1 action par tour : deplacement OU attaque
- [ ] Gestion des conflits : deux ennemis visent la meme case, le premier de la liste gagne
- [ ] Mort d'un ennemi : retire de la grille, score, drop eventuel
- [ ] (T) Un ennemi detecte, poursuit, attaque et meurt ; aucun ennemi ne traverse un mur ni un autre ennemi

---

## Phase 5 - Generation procedurale d'un etage

Objectif : un etage jouable, different a chaque run. A faire en C# pur pour tout tester sans Unity.

- [ ] Generer 9 pieces en matrice 3x3, chaque piece 1 a 7 cases de cote, placees dans sa cellule
- [ ] Creer les couloirs (1 case de large, au milieu de chaque cote) entre pieces voisines (12 connexions)
- [ ] Fusion possible de 2 pieces voisines (regle a simple : probabilite parametrable)
- [ ] Validation : BFS entree -> sortie, regenerer si echec
- [ ] Choix aleatoire de la piece d'entree, puis sortie dans une autre piece (distance minimale parametrable)
- [ ] Placement du contenu : monstres, loot (selon regles de densite dans un LevelConfig SO)
- [ ] Seed : Une seed par run ; la seed de chaque etage est derivee de (seed de run, numero d'etage) => meme seed = meme deroulement (IRandomProvider injectable)
- [ ] Structure : FloorGenerator = orchestrateur ; RoomGenerator, CorridorGenerator, ContentPlacer = classes separees
- [ ] Outil de debug : afficher l'etage en ASCII dans la console / fenetre editeur
- [ ] (T) Tests : 1000 seeds, 100% des etages completables, aucune piece isolee, sortie != entree

---

## Phase 6 - Loot et items

- [ ] ItemData (ScriptableObject) : nom, icone, actif/passif, occupe une place, consommable
- [ ] Loot au sol : nourriture (petite/moyenne/grosse), hachettes (3/5), potion de vie
- [ ] Ramassage automatique en marchant sur la case (sans cout de tour supplementaire)
- [ ] Table de loot simple par etage (LootTable SO)
- [ ] Drops de monstres (optionnel, selon tables)
- [ ] (T) Ramasser nourriture/hachettes met a jour le HUD ; inventaire plein laisse l'item au sol

---

## Phase 7 - Progression : etages, boss, fin de run

- [ ] RunManager : seed de run, etage courant, etat de run (en cours / victoire / defaite)
- [ ] Prise de la sortie : generation de l'etage suivant, joueur place a l'entree
- [ ] Conservation des stats du joueur d'un etage a l'autre
- [ ] Courbe de difficulte simple par etage (plus de monstres / stats multipliees via config)
- [ ] Etage de boss : arene simple (une grande piece) ; le boss garde la sortie
- [ ] Boss : EnemyData dedie + 2 ou 3 patterns (ex. charge, attaque de zone, invocation de petits monstres) en strategies IEnemyBrain
- [ ] Victoire : boss mort -> fin de run victoire
- [ ] Defaite : PV a 0 -> fin de run defaite
- [ ] (T) Une run complete se joue du premier etage jusqu'a la victoire ou la mort

---

## Phase 8 - Score et leaderboard

- [ ] ScoreService : etage atteint + monstres tues (+ bonus de loot plus tard, palier 3)
- [ ] Ponderation dans un ScoreConfig SO (modifiable sans recompiler)
- [ ] Interface ILeaderboardRepository + implementation JsonLeaderboardRepository (fichier local, top 10)
- [ ] Entree : saisie d'un nom (ou nom par defaut) a la fin de run
- [ ] (T) Tests : tri correct, limite top 10, fichier absent ou corrompu ne plante pas

---

## Phase 9 - Interface et flux de jeu

### 9.1 HUD (vue etage)
- [ ] Barre de vie (ex. 17/34), nourriture, hachettes, score, emplacements d'inventaire
- [ ] Zones reservees (invisibles) pour monnaie, pour accueillir le palier 2 sans refonte
- [ ] HUD abonne aux evenements (pattern Observer), jamais d'appel direct depuis la logique
- [ ] Utilisation d'un item par clic sur l'emplacement, description au survol

### 9.2 Ecrans
- [ ] Menu principal : Nouvelle run, Leaderboard, Quitter
- [ ] Menu pause (Echap) : reprendre, abandonner, quitter ; le temps de jeu ne progresse pas
- [ ] Ecran de fin de run : resultat, cause, score detaille, position au leaderboard, rejouer / menu
- [ ] Machine a etats de flux (GameStateMachine) : Menu -> Run -> FinDeRun -> Menu
- [ ] (T) On enchaine plusieurs runs sans relancer le jeu, tout est remis a zero correctement

---

## Phase 10 - Manette (optionnel dans la slice, "clavier/souris ou/et manette")

- [ ] Ajouter le schema manette aux Input Actions (aucun changement dans la logique)
- [ ] Navigation d'inventaire a la croix directionnelle
- [ ] (T) Une run complete jouable a la manette

---

## Phase 11 - Direction artistique et audio (minimum)

- [ ] Tileset sol/murs du biome choisi (16x16), sprite joueur, 3 monstres, boss, sortie, loot
- [ ] Icones HUD, cadres a bords casses (octogonaux), police viking (verifier la licence)
- [ ] Retours visuels : degats, mort, ramassage
- [ ] Sons minimum : pas, coup porte, coup recu, ramassage, mort, musique du biome
- [ ] Decision : production interne ou assets externes (licences a verifier)

---

## Phase 12 - Equilibrage, stabilite, build

- [ ] Equilibrer via les ScriptableObjects : nourriture de depart (150), PV (17), hachettes (3), nombre d'etages normaux (3 a 5), densite de loot, stats monstres/boss, ViewportConfig (taille de la fenetre)
- [ ] Objectif : la famine met la pression sans etre injuste, le boss est un vrai pic de difficulte
- [ ] Jouer 20 runs completes et noter les points bloquants
- [ ] Decider si on garde "tout affiche" ou si on active un brouillard (portee fixe ou ligne de vue)
- [ ] Corriger les bugs bloquants, tester le build PC (pas seulement l'editeur)
- [ ] Definir la configuration minimale PC
- [ ] (T) Criteres de reussite du GDD 12.6 tous valides

---

## Jalons suggeres

| Jalon | Contenu | Ce qu'on voit |
|---|---|---|
| J1 | Phases 1-2 | Un carre qui se deplace au tour par tour |
| J2 | Phases 3-4 | On se bat contre des monstres, la famine fonctionne |
| J3 | Phases 5-6 | Etages aleatoires avec loot |
| J4 | Phases 7-8 | Run complete jouable (moche mais complete) + leaderboard |
| J5 | Phase 9 | Menus, HUD, flux complet |
| J6 | Phases 11-12 | Art, son, equilibrage, build |

---

## Annexe - Garde-fous SOLID pour ce projet

- S : une classe = une responsabilite (TurnManager ne calcule pas les degats, le HUD ne modifie pas les stats)
- O : nouveau comportement ennemi, nouvel item ou nouvelle action = nouvelle classe, sans modifier l'existant
- L : tout IEnemyBrain / IUsable / IAction doit etre utilisable sans cas particulier chez l'appelant
- I : petites interfaces (IDamageable, IUsable, IActor...) plutot qu'une grosse interface unique
- D : la logique depend d'abstractions (IPlayerInput, ILeaderboardRepository, IRandomProvider), jamais de Unity ou d'un fichier concret
- Donnees dans des ScriptableObjects, regles de jeu dans du C# pur testable, MonoBehaviours = colle fine entre les deux
- Communication par evenements entre logique et UI
- Eviter les singletons : injection manuelle via un point d'entree unique (Bootstrap / Composition Root)

## Annexe - Hors scope de la slice (a ne PAS coder maintenant)

Monnaie, marchands, equipement (arme, armure, ceinture), bijoux, runes, grandes potions, item de transformation, familiers, artefacts, autres biomes, Odin, tactile, mecaniques de biome.
(Prevoir seulement des points d'extension propres : interfaces, zones de HUD, tables de loot.)
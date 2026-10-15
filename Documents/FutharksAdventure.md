# FUTHARK'S ADVENTURE - *A Motion Twin Tribute*



Octobre 2026

**Auteur :** [A COMPLETER]

**Engine :** Unity 6 (C#)

**Support :** PC (vertical slice) - extension possible sur console ou/et téléphone

**Genre :** Roguelike - Tour par tour - Grid based

**USP :**

*Un **roguelike** pur au tour par tour, ou chaque pas coute de la bouffe et chaque choix compte.*

*Une descente a travers les **neuf royaumes** de la mythologie nordique, un biome et un boss par royaume.*

*Une course au score : la vraie victoire est la premiere place du leaderboard.*

---
## Table des matières

1. Profil du jeu
2. Univers et recit
3. Boucle de gameplay
4. Conditions de victoire / defaite
5. Vues, interface et HUD
6. Controles et verbes
7. Le personnage
8. Items et equipement
9. Ennemis, boss et obstacles
10. Niveaux (etages, generation, biomes)
11. Direction artistique et audio
12. Vertical slice et roadmap


---

## 1. Profil du jeu

### Introduction

Futhark's Adventure est un roguelike en 2D vue du dessus, au tour par tour, dans l'univers de la mythologie nordique. Le joueur incarne Futhark, un.e guerrier.e mort.e au combat et accueilli.e au Valhalla, qui doit relever un defi lance par Odin : traverser les autres royaumes, y vaincre des figures notoires, puis affronter Odin lui-meme.

L'experience visee est celle d'une tension permanente de gestion de ressources. Dans la lignee de Rogue, le temps ne s'arrete jamais : chaque action du joueur declenche un tour de jeu, les ennemis jouent en meme temps que lui, et chaque tour consomme une unite de bouffe. Rester immobile ou hesiter a un cout, tout comme foncer sans preparation. Le joueur doit en permanence arbitrer entre explorer pour looter et avancer vers la sortie avant d'etre a court de ressources.

Le jeu se veut lisible, rejouable et competitif : chaque run repart de zero, et l'objectif ultime est de faire le meilleur score possible pour grimper au leaderboard. Les details du recit, des royaumes et des systemes sont decrits dans les chapitres suivants.

### Resume du flux de jeu (Game Flow)

Le joueur demarre une run au Valhalla. Il descend ensuite d'etage en etage. Chaque etage est genere procedurellement : le joueur y entre par une piece, fouille l'etage pour looter et rencontrer des marchands ou des monstres, puis trouve la sortie pour passer a l'etage suivant. Un groupe d'etages forme un biome (un royaume), qui se termine par un boss. Apres le dernier royaume, le joueur retourne en Asgard pour affronter Odin.

La run se termine par la mort du personnage, ou par la victoire contre Odin. Dans les deux cas, le score est enregistre dans le leaderboard, puis une nouvelle run peut commencer. La mort n'est pas un echec narratif : Futhark est deja mort, heros du Valhalla, ce qui justifie la resurrection entre les runs.

### Parametres generaux

| Element | Choix |
|---|---|
| Perspective / camera | 2D, vue du dessus (type minimap), grid based |
| Direction artistique | Pixel art, ambiance nordique |
| Controles | Clavier, manette ou tactile en fonction du support |
| Rythme | Tour par tour : 1 action du joueur = 1 tour de jeu = 1 action de chaque ennemi |
| Duree d'une run | [A DEFINIR] |
| Format d'ecran | 16:9 (paysage), variante portrait envisagee pour le tactile [A VERIFIER] |

### Jeux de reference

- **Rogue** - A.I. Design
- **Kanji's Adventure** - Motion Twin
- **OneBit Adventure** - Galactic Slice

## 2. Univers et recit

### Contexte narratif

Futhark est un.e guerrier.e mort.e au combat. Son genre n'est volontairement pas defini : le texte du jeu utilise une ecriture epicene afin que chaque joueur puisse s'identifier au personnage. Digne d'un trepas glorieux, iel est accueilli.e au Valhalla, le grand hall d'Asgard, ou reposent les heros.

Futhark etant deja mort, la mort n'est pas une fin definitive : c'est ce qui justifie, dans l'univers, qu'une nouvelle run puisse recommencer apres chaque defaite. Chaque run est une nouvelle tentative de relever le defi.

### Le defi d'Odin

Odin lance a Futhark un defi dont la forme exacte reste [A DEFINIR] (concours, epreuve initiatique, ou autre). Son principe est fixe :

- aller dans chacun des **8 autres royaumes** ;
- y recuperer un **objet unique** (artefact) ;
- y vaincre une **personne notoire**, qui joue le role de boss du royaume ;
- puis revenir en **Asgard** et affronter **Odin** lui-meme, boss final du jeu.

### Structure de la progression

Les neuf royaumes de la mythologie nordique, relies par l'arbre-monde Yggdrasil, structurent le jeu. Chaque royaume correspond a un **groupe d'etages** (nombre d'etages par royaume : [A DEFINIR]) et possede :

- un **biome propre** (decor, ambiance, mecaniques de biome eventuelles : [A DEFINIR]) ;
- un **set de monstres endemiques** ;
- un **boss**, la personne notoire du royaume, affrontee a la fin du dernier etage du groupe ;
- un **artefact** a recuperer.

L'ordre dans lequel les royaumes sont traverses est [A DEFINIR]. Asgard est a la fois le point de depart (Valhalla) et le point d'arrivee (combat contre Odin).

### Les neuf royaumes

*Les descriptions ci-dessous sont issues des notes de conception. Les mentions [A VERIFIER] signalent un passage illisible ou incomplet.*

**Asgard**
Royaume des dieux Ases, lieu de grandeur et de splendeur. On y trouve le Valhalla (le hall des heros) et Bifrost, le pont arc-en-ciel garde par Heimdall. Boss final : **Odin**, dieu des Ases. Artefact : [A DEFINIR].

**Alfheim**
Royaume des Elfes, associe a la lumiere. Ambiance de douceur, de cosmos, de sagesse, de beaute et de magie. Boss : **Freyr** (dieu Vane). Artefact : [A DEFINIR].

**Vanaheim**
Royaume des dieux Vanes, fertile et paisible, tourne vers la nature et la magie. Boss : **Njord**. Artefact : [A DEFINIR].

**Muspelheim**
Monde primordial du feu. Boss : **Surtur** (geant). Artefact : [A DEFINIR].

**Midgard**
Royaume des humains, entoure d'un ocean infini. Boss : **Jormungandr** (le serpent). Artefact : [A DEFINIR].

**Niflheim**
Monde primordial de glace, de froid extreme et de brumes. Y figurent les rivieres Elivagar, la source Hvergelmir, l'obscurite et le froid. Ambiance de force primordiale, de purete et de danger. [A VERIFIER : fin de la description coupee dans les notes]. Boss : **Nidhogg** (dragon). Artefact : [A DEFINIR].

**Jotunheim**
Royaume des geants, sauvage et rocheux, fait de forets et de montagnes. Boss : [A DEFINIR]. Artefact : [A DEFINIR].

**Helheim**
Royaume souterrain des morts de causes naturelles ou de vieillesse. Boss : **Hel** (deesse). Artefact : [A DEFINIR].

**Svartalfheim (Nidavellir)**
Royaume souterrain des Nains. Ambiance artisanale et obscure, tournee vers la forge, la magie et les armes puissantes [A VERIFIER : fin de la description coupee dans les notes]. Boss : **Alberich** [A VERIFIER : orthographe et role]. Artefacts associes : **Mjolnir** et **Brisingamen**.

*Note : les notes marquent aussi des reperes de position (N, W, SE, centre) a cote de certains royaumes, probablement pour leur placement autour d'Yggdrasil. [A VERIFIER]*

### Mythes et artefacts

**Ymir et la creation de Midgard.** Ymir est l'ancetre des geants, ne de la rencontre des glaces de Niflheim et des flammes de Muspelheim. Son corps a servi a creer Midgard (tue par Odin : [A VERIFIER]). Sa chair est devenue la terre, son sang les mers, et ses sourcils une barriere protectrice. Cette barriere protege les humains des geants et explique la relation conflictuelle entre les deux peuples.

**Artefacts et reliques envisages** (leur attribution aux royaumes est [A DEFINIR]) :

| Artefact | Origine / effet envisage |
|---|---|
| Mjolnir | Marteau magique de Thor |
| Brisingamen | Collier de Freyja : charme et soutien d'armee |
| Ceinture de force | [A DEFINIR] |

Les artefacts recuperes sont des objets uniques lies a un royaume. Leur effet en jeu et leur lien avec le systeme d'equipement sont detailles au chapitre 8.

## 3. Boucle de gameplay

Le jeu repose sur trois boucles imbriquees : le **tour de jeu** (quelques secondes), l'**etage** (quelques minutes) et la **run** (session complete). Un lecteur qui comprend ces trois niveaux comprend le jeu.

### 3.1 Boucle du tour (boucle principale)

Le jeu est un roguelike au sens de *Rogue* : il n'y a pas de temps reel ni de combat automatique. Le temps ne progresse que lorsque le joueur agit.

1. Le joueur choisit une action (se deplacer, attaquer au corps a corps, attaquer a distance, utiliser un item...).
2. L'action est executee : c'est le **tour de jeu**.
3. Chaque ennemi concerne accomplit alors **un tour** : un deplacement **ou** une attaque.
4. Le cout du tour est preleve sur les ressources du joueur (voir 3.2).
5. Le jeu attend la prochaine action du joueur.

Un tour de jeu correspond donc a une action du joueur et a une action de chaque ennemi actif. L'ordre de resolution entre ennemis, et la distance a partir de laquelle un ennemi est actif, sont [A DEFINIR].

### 3.2 Economie du tour : la bouffe

Chaque tour de jeu coute **1 unite de bouffe**. La bouffe est la ressource qui limite le temps d'exploration : elle empeche le joueur d'attendre ou de fouiller indefiniment.

- Si le joueur n'a plus de bouffe, chaque tour coute **1 point de vie (PV)** a la place.
- La bouffe se recupere en la trouvant (loot, marchands). Le stock de depart est [A DEFINIR].
- Un item peut convertir de la bouffe en PV ou inversement ([A VERIFIER] : item de transformation note dans les premieres notes, ratio envisage 1 pour 1).

| Action | Consomme un tour | Autre cout |
|---|---|---|
| Deplacement d'une case | Oui | - |
| Attaque au corps a corps | Oui | - |
| Attaque a distance (hachette) | Oui | 1 hachette (stock limite) |
| Utilisation d'un item | [A VERIFIER] | Selon l'item |
| Ouverture du menu / de l'inventaire | Non [A VERIFIER] | - |

### 3.3 Boucle de l'etage

Chaque etage est genere procedurellement. Il est compose de **9 pieces disposees en matrice carree (3 x 3)**, chacune faisant de 1 a 7 cases de cote (limite exacte et forme des pieces : [A DEFINIR]).

```
Entree -> Visite (loot) -> Rencontres -> Sortie
```

1. **Entree** : le joueur arrive par une case d'une piece.
2. **Visite** : il fouille l'etage pour trouver du loot (bouffe, items, equipement, monnaie).
3. **Rencontres** : il croise des **monstres** (combat) ou des **marchands** (achat d'items contre de la monnaie).
4. **Sortie** : il localise la sortie de l'etage et la prend pour passer a l'etage suivant.

La tension centrale est un arbitrage permanent : fouiller plus (plus de loot, donc plus de score et de survie) coute de la bouffe et expose a plus de combats, alors qu'avancer vite economise des ressources mais laisse du loot derriere.

### 3.4 Boucle du biome

Les etages sont regroupes en biomes, un biome par royaume. Le joueur enchaine les etages du biome, puis affronte le **boss** du royaume au dernier etage. Vaincre le boss permet de recuperer l'**artefact** du royaume et d'ouvrir l'acces au biome suivant. Le nombre d'etages par biome est [A DEFINIR].

### 3.5 Boucle de la run

```
Valhalla -> Biome 1 -> Boss -> Biome 2 -> Boss -> ... -> Biome 8 -> Boss -> Asgard -> Odin
```

- La run commence au Valhalla et se termine soit par la mort du personnage, soit par la victoire contre Odin.
- Dans les deux cas, le **score** est calcule et enregistre au **leaderboard** (s'il est suffisant).
- Tout est ensuite remis a zero : une nouvelle run recommence sans progression conservee. La resurrection est justifiee par le fait que Futhark est deja mort, heros du Valhalla.

### 3.6 Score

Le score mesure la performance d'une run et determine le classement au leaderboard. Il se compose de :

| Source | Detail |
|---|---|
| Etage atteint | Points fixes ou incrementaux selon l'etage [A DEFINIR] |
| Monstres tues | Points selon le type de monstre |
| Bonus de loot | Points selon la valeur du loot (petit / moyen / gros) [A VERIFIER : formule exacte illisible dans les notes] |

La valeur brute du loot croit avec sa taille (petit < moyen < gros). Les formules et la ponderation entre ces trois sources sont [A DEFINIR].

## 4. Conditions de victoire / defaite

### 4.1 Principe general

Une run se termine toujours de l'une des deux facons suivantes : le personnage meurt, ou il bat Odin. Dans les deux cas, le score est calcule et soumis au leaderboard, puis une nouvelle run peut commencer. Aucune progression n'est conservee d'une run a l'autre.

Le jeu distingue deux niveaux de victoire :

| Niveau | Definition |
|---|---|
| Victoire de run | Vaincre Odin en Asgard, apres avoir traverse les 8 autres royaumes |
| Victoire ultime | Obtenir la premiere place du leaderboard |

Terminer le jeu n'est donc pas le but final : c'est la qualite de la run (le score) qui compte. Une run qui bat Odin avec un score faible reste "gagnee", mais ne constitue pas la victoire ultime.

### 4.2 Defaite

Le joueur perd la run lorsque ses **points de vie (PV) tombent a 0**. Les causes possibles sont :

- les degats infliges par un monstre ou un boss ;
- la **famine** : lorsque la bouffe est a 0, chaque tour coute 1 PV, ce qui peut mener a la mort sans qu'aucun ennemi n'intervienne ;
- les autres sources de degats (pieges, mecaniques de biome) [A DEFINIR].

La mort n'est pas une fin narrative : Futhark est deja mort, heros du Valhalla, et une nouvelle run commence apres l'ecran de fin. Le score de la run interrompue est enregistre au leaderboard comme celui d'une run reussie, s'il est suffisant.

### 4.3 Victoire

La run est gagnee lorsque le joueur **vainc Odin**, boss final, en Asgard. Cette victoire suppose d'avoir battu les boss des 8 autres royaumes et recupere leurs artefacts. Une cinematique ou un ecran de conclusion special est [A DEFINIR]. Apres la victoire, le score est enregistre et une nouvelle run peut commencer.

### 4.4 Ecran de fin de run

A la fin de chaque run (victoire ou defaite), le jeu affiche un ecran de fin avec :

- le resultat (victoire / defaite) et la cause de la fin de run ;
- le **score** detaille (etage atteint, monstres tues, bonus de loot) ;
- le classement au **leaderboard** ;
- les actions disponibles : recommencer une run, quitter le jeu.

Le contenu exact de l'ecran, son ton visuel (differenciation entre victoire et defaite) et le fonctionnement du leaderboard (local ou en ligne, nombre d'entrees, anti-triche) sont [A DEFINIR].

### 4.5 Limites du jeu

- Pas de sauvegarde en cours de run [A VERIFIER].
- Pas de progression persistante entre les runs.
- Pas de "mauvaise fin" ni de fin alternative : seuls comptent la mort ou la victoire sur Odin, et le score obtenu.

## 5. Vues, interface et HUD

### 5.1 Liste des vues

| Vue | Description | Camera |
|---|---|---|
| Menu principal | Point d'entree du jeu : lancer une run, options, leaderboard, quitter [A DEFINIR : existence et contenu] | Fixe |
| Vue etage (vue principale) | Vue 2D du dessus, sur grille, dans laquelle le joueur se deplace, combat et loote | [A DEFINIR : fixe sur l'etage ou centree sur le joueur] |
| Interface marchand | Ecran d'achat ouvert lors d'une rencontre avec un marchand (4 items aleatoires proposes [A VERIFIER]) | Fixe (superposee a la vue etage) |
| Inventaire / equipement | Consultation et gestion des items et de l'equipement du personnage | Fixe (superposee a la vue etage) |
| Menu pause | Menu accessible en cours de run | Fixe (superposee a la vue etage) |
| Ecran de fin de run | Resultat, score detaille et leaderboard (voir chapitre 4) | Fixe |

Le combat se deroule directement dans la vue etage : il n'y a pas de scene de combat separee, car le jeu est un roguelike au tour par tour dans lequel monstres et joueur evoluent sur la meme grille.

### 5.2 Enchainement des vues

```
Menu principal -> Vue etage <-> Interface marchand
                     |      <-> Inventaire / equipement
                     |      <-> Menu pause
                     v
              Ecran de fin de run -> Menu principal ou nouvelle run
```

- L'inventaire, le menu pause et l'interface marchand s'ouvrent par-dessus la vue etage et s'y referment sans la quitter.
- L'ouverture de ces ecrans ne fait pas avancer le temps de jeu [A VERIFIER].
- Le passage d'un etage a l'autre se fait par la case de sortie, sans ecran intermediaire [A DEFINIR : ecran de transition ou chargement].
- Le passage d'un biome a l'autre (apres un boss) peut etre marque par un ecran dedie [A DEFINIR].

### 5.3 HUD de la vue etage

Le HUD affiche en permanence les informations vitales de la run. Il est concu en **16:9 (paysage)** pour le PC, avec une variante **portrait** envisagee pour le tactile [A VERIFIER].

| Element | Description | Position (paysage) |
|---|---|---|
| Barre de vie | Barre de PV avec valeur numerique (ex. 17/34) | Haut gauche |
| Reserve de bouffe | Compteur de bouffe restante (ex. 320) | Sous la barre de vie |
| Monnaie | Compteur de monnaie (ex. 64) | Sous la barre de vie |
| Objets lancables | Nombre de hachettes disponibles pour l'attaque a distance (ex. 5) | Sous la barre de vie |
| Inventaire | Emplacements d'items utilisables (jusqu'a 5 affiches) | Haut droite, en ligne |
| Score | Score courant de la run (ex. 1.320.000) | Bas droite |
| Mana | Jauge de mana [A DEFINIR : le systeme de mana n'est pas confirme] | - |

Notes de conception :

- **Inventaire** : le personnage dispose de 3 emplacements de base, extensibles par l'equipement (voir chapitre 8). Le HUD prevoit jusqu'a 5 emplacements affiches [A VERIFIER].
- **Variante portrait (tactile)** : barre de vie et compteurs en haut, colonne d'emplacements d'inventaire sur le cote droit, croix directionnelle virtuelle en bas a gauche, score en bas [A VERIFIER : disposition issue d'un croquis a confirmer ; une mention "GSM ?" figure dans les notes].
- Les etats de la run (monstres, boss) peuvent necessiter des elements de HUD supplementaires, par exemple une barre de vie de boss [A DEFINIR].

### 5.4 Menu pause

Le menu pause est accessible a tout moment pendant la vue etage :

- **Clavier** : Echap
- **Manette** : bouton Start
- **Tactile** : bouton menu a l'ecran (type "burger") [A VERIFIER]

Contenu du menu : reprendre, options, abandonner la run, quitter le jeu [A DEFINIR]. Les controles associes a chaque support sont detailles au chapitre 6.

### 5.5 Interface d'inventaire

L'ouverture et la navigation dans l'inventaire dependent du support :

- **Souris** : clic gauche sur un emplacement pour utiliser l'item, survol pour afficher sa description [A VERIFIER].
- **Manette** : onglet d'items, navigation a la croix directionnelle, confirmation et annulation par les boutons de face.
- **Tactile** : bouton d'inventaire a l'ecran, puis appui sur l'item [A VERIFIER].

Le detail du contenu de l'inventaire (items, equipement, runes) est decrit au chapitre 8.

## 6. Controles et verbes

### 6.1 Principe general

Le jeu est controle a l'aide du **nouvel Input System d'Unity**. Les actions du joueur (les "verbes") sont definies une seule fois sous forme d'actions abstraites, puis associees a chaque support (clavier/souris, manette, tactile). Aucune logique de jeu ne depend d'une touche precise.

Supports vises : **clavier/souris** (vertical slice), **manette** et **tactile** (description complete, implementation ulterieure).

Chaque verbe qui fait avancer le temps de jeu declenche un **tour** (voir chapitre 3) : les ennemis jouent apres le joueur et la bouffe est consommee.

### 6.2 Liste des verbes

| Verbe | Description | Consomme un tour |
|---|---|---|
| Se deplacer | Deplacement d'une case sur la grille, dans l'une des 4 directions [A DEFINIR : deplacement en diagonale ?] | Oui |
| Attaquer au corps a corps | S'obtient en se deplacant vers une case occupee par un ennemi (pas de touche dediee) | Oui |
| Attaquer a distance | Lance une hachette (stock limite) [A DEFINIR : visee, portee, direction] | Oui |
| Utiliser un item | Utilise un item de l'inventaire (potion, etc.) | [A VERIFIER] |
| Ouvrir l'inventaire / equipement | Consulte et gere les items et l'equipement | Non [A VERIFIER] |
| Ouvrir le menu pause | Accede au menu pause | Non |
| Confirmer / annuler | Valide ou annule dans les menus et l'interface marchand | Non |
| Interagir (marchand, coffre, sortie) | [A DEFINIR : automatique en marchant sur la case, ou action dediee] | [A DEFINIR] |
| Passer son tour (attendre) | [A DEFINIR : verbe non confirme] | Oui |

### 6.3 Clavier / souris

| Verbe | Controle |
|---|---|
| Se deplacer | Fleches directionnelles, ou ZQSD, ou WASD, ou pave numerique (8 haut, 2 bas, 4 gauche, 6 droite) |
| Attaquer au corps a corps | Se deplacer vers l'ennemi |
| Attaquer a distance | Barre d'espace, ou 5 du pave numerique |
| Utiliser un item | Clic gauche sur l'item dans l'inventaire (survol : affiche la description) [A VERIFIER] |
| Menu pause | Echap |

### 6.4 Manette

| Verbe | Controle |
|---|---|
| Se deplacer | Stick gauche ou croix directionnelle |
| Attaquer au corps a corps | Se deplacer vers l'ennemi |
| Attaquer a distance | Un bouton de face ou une gachette [A VERIFIER : Y ou RT] |
| Utiliser un item | Ouvrir l'onglet d'items, naviguer a la croix directionnelle, confirmer [A VERIFIER : bouton d'ouverture de l'onglet] |
| Confirmer / annuler | Bouton A pour confirmer, bouton B pour annuler [A VERIFIER] |
| Menu pause | Bouton Start |

### 6.5 Tactile

| Verbe | Controle |
|---|---|
| Se deplacer | Croix directionnelle virtuelle a l'ecran (bas gauche) |
| Attaquer au corps a corps | Se deplacer vers l'ennemi |
| Attaquer a distance | Bouton virtuel a l'ecran [A DEFINIR : position] |
| Utiliser un item | Appui sur l'emplacement d'item dans le HUD ou l'inventaire [A VERIFIER] |
| Menu pause | Bouton menu de type "burger" a l'ecran [A VERIFIER] |

### 6.6 Regles d'interaction

- **Une action par tour** : le joueur ne peut effectuer qu'une action par tour de jeu.
- **Entree bloquante** : pendant la resolution d'un tour (animations, tour des ennemis),


## 7. Le personnage

### 7.1 Futhark

Futhark est le personnage jouable unique. C'est un.e guerrier.e viking mort.e au combat et accueilli.e au Valhalla. Son genre est volontairement non defini et son apparence reste neutre afin que chaque joueur puisse s'y identifier (ecriture epicene dans tous les textes du jeu).

Le personnage n'a **pas de progression permanente** : tout est remis a zero a chaque run. Son evolution au cours d'une run vient uniquement de ce qu'il trouve (items, equipement, artefacts) et non d'un systeme de niveaux ou d'experience [A VERIFIER].

### 7.2 Statistiques et ressources

| Element | Role | Valeur de depart |
|---|---|---|
| Points de vie (PV) | Vitalite : a 0, la run est perdue. Affiches sous la forme actuel/max (ex. 17/34) | [A DEFINIR] |
| Bouffe | Ressource consommee a chaque tour. A 0, chaque tour coute 1 PV | [A DEFINIR] |
| Monnaie | Sert a acheter des items aupres des marchands | [A DEFINIR] (probablement 0) |
| Hachettes | Munitions de l'attaque a distance, en stock limite | [A DEFINIR] |
| Degats | Degats infliges par les attaques, modifies par l'arme et les bijoux | [A DEFINIR] |
| Reduction de degats | Degats recus, modifies par l'armure | [A DEFINIR] |
| Dexterite (Dex) | Statistique evoquee pour les bijoux, effet exact non precise | [A DEFINIR] |
| Mana | Ressource de capacites magiques | [A DEFINIR] : systeme non confirme |

Les PV maximum peuvent etre augmentes par certains items (voir chapitre 8). Le PV de depart, la bouffe de depart et les formules de degats sont a calibrer lors de l'integration.

### 7.3 Capacites

Le personnage dispose d'emblee de trois capacites de base. Il n'en acquiert pas de nouvelles par niveau ; ses options s'etendent via les items, les runes et les artefacts.

| Capacite | Description | Consomme un tour |
|---|---|---|
| Se deplacer | Deplacement d'une case sur la grille | Oui |
| Attaque au corps a corps | Obtenue en se deplacant vers un ennemi. Degats selon l'arme equipee (et les bijoux) | Oui |
| Attaque a distance | Lance une hachette. Limitee par le stock de hachettes | Oui |

Capacites additionnelles possibles, issues des items :

- **Soins** : potions de vie (voir chapitre 8).
- **Conversion** : transformer de la bouffe en PV [A VERIFIER].
- **Runes** : effets elementaires (feu, glace, tonnerre, chaos...) lies a la mythologie nordique [A DEFINIR : effets coherents a explorer].

### 7.4 Inventaire et equipement

L'inventaire contient **3 emplacements de base**, auxquels s'ajoutent des emplacements supplementaires donnes par l'equipement (la ceinture en ajoute 2). Chaque item est soit **actif** (utilise puis consomme ou active), soit **passif** (effet permanent tant qu'il est possede ou equipe), et occupe ou non une place [A VERIFIER : regle exacte d'occupation par item].

Quatre emplacements d'equipement existent :

| Emplacement | Effet |
|---|---|
| Arme | Augmente les degats infliges |
| Armure | Reduit les degats recus |
| Ceinture | Augmente l'inventaire (+2 emplacements, une seule ceinture) |
| Bijoux | Modifient la Dex et/ou les degats |

Le detail des items et de l'equipement est au chapitre 8.

### 7.5 Artefacts

A chaque royaume vaincu, Futhark recupere un **artefact** unique lie a ce royaume (voir chapitre 2). La nature de ces artefacts (equipement, relique passive, capacite, etc.) et leur effet en jeu sont [A DEFINIR]. Mjolnir, Brisingamen et la ceinture de force sont des candidats evoques dans les notes.

### 7.6 Elements a trancher

- Compagnons ou familiers (pets) : evoques dans les notes, non confirmes [A DEFINIR].
- Systeme de glyphes ou de runes : [A DEFINIR].
- Differences de personnage (classes, apparence selectionnable) : aucune prevue pour le moment [A VERIFIER].

## 8. Items et equipement

### 8.1 Principe general

Tout ce que le joueur trouve ou achete est un **item** ou une ressource. Chaque item possede deux proprietes de conception :

- **Actif / Passif** : un item *actif* est utilise volontairement par le joueur (puis consomme ou declenche) ; un item *passif* agit en permanence tant qu'il est equipe ou possede.
- **Occupe une place** : indique si l'item prend un emplacement de l'inventaire (oui / non).

L'inventaire contient **3 emplacements de base**, auxquels s'ajoutent **2 emplacements** donnes par la ceinture (voir 8.3). Il peut donc contenir jusqu'a 5 items qui occupent une place. Le HUD affiche jusqu'a 5 emplacements (voir chapitre 5).

Les valeurs chiffrees (soin, degats, prix, raretes) sont [A DEFINIR] : elles seront calibrees lors de l'integration.

### 8.2 Ressources

Les ressources ne sont pas des items d'inventaire : elles sont stockees dans des compteurs du HUD.

| Ressource | Role | Sources | Remarques |
|---|---|---|---|
| Bouffe | Consommee a chaque tour (voir chapitre 3) | Loot, marchands | Plusieurs valeurs de bouffe trouvables, de type petite / moyenne / grosse portion (idee de valeurs : 1 / 3 / 10) [A VERIFIER] |
| Monnaie | Achats chez les marchands | Loot, monstres [A DEFINIR] | Valeur du loot croissante : petit < moyen < gros |
| Hachettes | Munitions de l'attaque a distance | Loot, marchands [A DEFINIR] | Stock limite |

### 8.3 Equipement

Quatre emplacements d'equipement existent. Les items d'equipement sont **passifs**.

| Emplacement | Effet | Actif / Passif | Occupe une place |
|---|---|---|---|
| Arme | Augmente les degats infliges | Passif | [A VERIFIER] (probablement non) |
| Armure | Reduit les degats recus | Passif | [A VERIFIER] (probablement non) |
| Ceinture | Ajoute 2 emplacements d'inventaire. Une seule ceinture a la fois | Passif | [A VERIFIER] (probablement non) |
| Bijoux | Modifient la Dex et/ou les degats | Passif | [A VERIFIER] (probablement oui) |

Nombre de bijoux equipables simultanement : [A DEFINIR]. Le remplacement d'un equipement (que devient l'ancien item) est [A DEFINIR].

### 8.4 Consommables

| Item | Effet | Actif / Passif | Occupe une place |
|---|---|---|---|
| Potion de vie | Rend une quantite moyenne de PV | Actif | Oui |
| Grande potion de vie | Rend tous les PV et augmente un peu les PV maximum | Actif | [A VERIFIER] |
| Item de transformation (nom [A DEFINIR]) | Transforme de la bouffe en PV (ratio 1 pour 1 envisage) | Actif | Oui |

Note de conception : si l'item de transformation permet d'obtenir beaucoup de PV d'un coup, une limite par utilisation est a prevoir [A VERIFIER : mention partiellement illisible dans les notes].

### 8.5 Runes

Les runes sont des items porteurs d'effets elementaires et magiques, inspires de la mythologie nordique. Les effets doivent rester coherents avec cette mythologie (travail d'exploration mythologique a faire).

Pistes d'effets : feu, glace, tonnerre, chaos, peur [A VERIFIER : un mot illisible dans les notes, possiblement "fire"].

Fonctionnement (actif ou passif, usage unique ou permanent, place occupee) : [A DEFINIR].

### 8.6 Artefacts

Chaque royaume vaincu donne un **artefact** unique (voir chapitres 2 et 7). Un artefact est un item special, non achetable. Sa nature et son effet sont [A DEFINIR]. Candidats evoques : Mjolnir, Brisingamen, ceinture de force.

### 8.7 Sources d'items

| Source | Description |
|---|---|
| Loot dans l'etage | Items et ressources dissemines dans les pieces de l'etage (generation procedurale) |
| Marchands | Rencontres aleatoires dans l'etage. Proposent 4 items aleatoires contre de la monnaie [A VERIFIER] |
| Monstres | Drop eventuel a la mort [A DEFINIR] |
| Boss | Artefact du royaume + recompense eventuelle [A DEFINIR] |

### 8.8 Elements a trancher

- Familiers (pets) : evoques dans les notes, non confirmes [A DEFINIR].
- Rarete des items et tables de loot par biome : [A DEFINIR].
- Items maudits, pieges ou a risque : non prevus pour le moment [A VERIFIER].

## 9. Ennemis, boss et obstacles

### 9.1 Principe general

Les ennemis sont les principales sources d'opposition du jeu. Chaque ennemi obeit aux regles du tour par tour (voir chapitre 3) : a chaque tour de jeu declenche par le joueur, **chaque ennemi actif accomplit un tour**, c'est-a-dire **soit un deplacement, soit une attaque**.

Les ennemis evoluent sur la meme grille que le joueur, dans la vue etage (voir chapitre 5). Il n'y a pas de scene de combat separee.

Les valeurs de statistiques (PV, degats, vitesse) sont [A DEFINIR] et seront calibrees lors de l'integration.

### 9.2 Comportement des ennemis

| Element | Regle |
|---|---|
| Tour de jeu | 1 action par tour : deplacement **ou** attaque |
| Attaque au corps a corps | Un ennemi attaque le joueur lorsqu'il se trouve sur une case adjacente [A VERIFIER : adjacence diagonale] |
| Attaque a distance | Certains ennemis peuvent attaquer de loin [A DEFINIR] |
| Deplacement | Vers le joueur lorsqu'il est detecte [A DEFINIR : rayon de detection, pathfinding, comportement hors detection] |
| Ordre de resolution | [A DEFINIR] : tous en meme temps ou un par un |
| Apparition | Placement procedural lors de la generation de l'etage (voir chapitre 10) |

### 9.3 Types d'ennemis

Chaque biome possede un **set de monstres endemiques**, propre au royaume et coherent avec son ambiance et la mythologie nordique. Un meme monstre peut appartenir a plusieurs biomes [A DEFINIR].

| Role | Description | Exemples |
|---|---|---|
| Monstre de base | Ennemi commun du biome, faible mais present en nombre | [A DEFINIR] |
| Monstre a distance | Attaque de loin, oblige le joueur a se rapprocher ou a se mettre a couvert | [A DEFINIR] |
| Monstre d'elite | Version plus resistante ou plus dangereuse, drop meilleur | [A DEFINIR] |

Le nombre de monstres par type et par biome, ainsi que leur description detaillee, seront ajoutes dans une version ulterieure de ce document. Chaque monstre devra y etre decrit avec : nom, biome, comportement, statistiques, drop, moyen d'en venir a bout.

Pour la vertical slice, un seul biome est concerne : le jeu devra proposer le set de monstres correspondant (voir chapitre 12).

### 9.4 Score et recompenses

Chaque monstre tue rapporte des points au score de la run (voir chapitre 3). Le montant depend du type de monstre [A DEFINIR]. Les monstres peuvent laisser du loot a leur mort [A DEFINIR].

### 9.5 Boss

Un boss garde la sortie de chaque biome. C'est la **personne notoire** du royaume (voir chapitre 2). Vaincre un boss permet de recuperer l'**artefact** du royaume et d'acceder au biome suivant.

| Royaume | Boss | Remarque |
|---|---|---|
| Midgard | Jormungandr (le serpent) | |
| Alfheim | Freyr | |
| Vanaheim | Njord | |
| Muspelheim | Surtur (geant) | |
| Niflheim | Nidhogg (dragon) | |
| Jotunheim | [A DEFINIR] | |
| Helheim | Hel (deesse) | |
| Svartalfheim (Nidavellir) | Alberich [A VERIFIER] | |
| Asgard | Odin | Boss final du jeu |

Regles generales des boss :

- Chaque boss est affronte une seule fois par run, a la fin du dernier etage de son biome.
- Les boss suivent le meme systeme de tour par tour que les monstres, mais avec des comportements et des attaques propres [A DEFINIR].
- Le combat contre Odin conclut la run (voir chapitre 4).
- L'ordre de rencontre des boss est [A DEFINIR] (voir chapitre 2).

Fiche detaillee par boss (PV, patterns d'attaque, phases, recompense) : [A DEFINIR].

### 9.6 Autres obstacles

Au-dela des ennemis, le joueur doit surmonter plusieurs contraintes :

| Obstacle | Description | Moyen d'en venir a bout |
|---|---|---|
| Famine | La bouffe baisse a chaque tour ; a 0, chaque tour coute 1 PV | Trouver ou acheter de la bouffe, ne pas gaspiller les tours |
| Ressources limitees | Hachettes et items en nombre restreint, inventaire limite | Choisir quoi garder, quoi acheter, quand utiliser |
| Murs et geometrie des pieces | Les murs bloquent le deplacement et la vue ; le joueur doit trouver son chemin dans l'etage | Exploration, choix d'itineraire |
| Sortie a decouvrir | L'etage est genere procedurellement, la sortie n'est pas connue au depart | Exploration, qui coute de la bouffe |
| Mecaniques de biome | Contraintes propres a chaque royaume (froid, feu, obscurite...) | [A DEFINIR] |
| Pieces


## 10. Niveaux (etages, generation, biomes)

### 10.1 Principe general

Le jeu ne comporte pas de niveaux dessines a la main : chaque **etage** est genere procedurellement a chaque run. Les etages sont regroupes en **biomes**, un biome par royaume (voir chapitre 2). Le joueur parcourt les biomes les uns apres les autres, chaque biome se terminant par un boss.

```
Run
 +-- Biome 1 (royaume) : etage 1, etage 2, ... etage n, boss
 +-- Biome 2 (royaume) : etage 1, etage 2, ... etage n, boss
 +-- ...
 +-- Asgard : etage(s), Odin
```

Le nombre d'etages par biome est [A DEFINIR], de meme que la progression de la difficulte d'un etage a l'autre.

### 10.2 Structure d'un etage

Un etage est compose de **9 pieces disposees en matrice carree 3 x 3**. Chaque piece mesure de **1 a 7 cases de cote** (forme carree ou rectangulaire, limite exacte du rapport largeur / hauteur : [A DEFINIR]). Les pieces sont reliees entre elles par des **couloirs**, comme dans *Rogue*.

```
[ P1 ]--[ P2 ]--[ P3 ]
  |       |       |
[ P4 ]--[ P5 ]--[ P6 ]
  |       |       |
[ P7 ]--[ P8 ]--[ P9 ]
```

*(Schema indicatif : toutes les liaisons ne sont pas forcement presentes.)*

| Element | Regle |
|---|---|
| Disposition | Matrice carree de 9 pieces (3 x 3) |
| Taille des pieces | 1 a 7 cases de cote, variable d'une piece a l'autre |
| Liaison | Couloirs entre pieces voisines (nombre et trace des couloirs : [A DEFINIR]) |
| Connexite | Toutes les pieces utiles doivent etre atteignables depuis l'entree [A VERIFIER] |
| Entree | Le joueur arrive par une case d'une piece (choix de la piece : [A DEFINIR]) |
| Sortie | Une case de sortie placee dans une piece de l'etage (position : [A DEFINIR], distance minimale avec l'entree : [A DEFINIR]) |

### 10.3 Contenu d'un etage

Le contenu est place **de maniere procedurale** lors de la generation :

| Contenu | Description | Detail |
|---|---|---|
| Monstres | Rencontres de combat | Selon le set endemique du biome (chapitre 9) |
| Marchands | Rencontres d'achat | Proposent 4 items aleatoires (chapitre 8) |
| Loot | Items et ressources au sol | Bouffe, monnaie, hachettes, items (chapitre 8) |
| Sortie | Passage a l'etage suivant | Toujours presente |
| Boss | Present uniquement au dernier etage d'un biome | Chapitre 9 |

Les regles de repartition (nombre de monstres, de marchands et de loot par etage, probabilites, tables de loot par biome) sont [A DEFINIR]. Le meme jeu de regles est applique a chaque run, avec des graines aleatoires differentes.

### 10.4 Generation procedurale

Principes a respecter par l'algorithme :

1. **Aleatoire** : la disposition, les tailles de pieces, le contenu et la position de la sortie changent a chaque run.
2. **Jouable** : chaque etage doit etre completable (entree reliee a la sortie par un chemin praticable).
3. **Lisible** : la grille doit rester simple a lire dans la vue 2D du dessus (voir chapitre 5).
4. **Reproductible** : une graine (seed) permet de regenerer le meme etage [A VERIFIER : utile pour le debug et le leaderboard].

L'algorithme exact de generation est [A DEFINIR] (conception technique).

### 10.5 Etage de boss

Le dernier etage d'un biome est consacre au boss de ce royaume. Sa structure (arene unique, plusieurs pieces, couloirs) est [A DEFINIR]. Le boss garde la sortie : le joueur doit le vaincre pour recuperer l'artefact et acceder au biome suivant.

### 10.6 Biomes

Chaque biome correspond a un royaume. Les elements communs a tous les biomes : decor propre, set de monstres endemiques, boss, artefact, mecaniques de biome eventuelles.

Palette visuelle generale evoquee dans les notes : bois, pierre, froid, neige, tonnerre, mer (voir chapitre 11).

| Royaume | Ambiance | Pistes de decor | Boss |
|---|---|---|---|
| Midgard | Monde des humains, entoure d'un ocean infini | Mer, rivages, terres humaines [A DEFINIR] | Jormungandr |
| Alfheim | Royaume des Elfes : lumiere, douceur, sagesse, beaute, magie | [A DEFINIR] | Freyr |
| Vanaheim | Royaume des Vanes : fertile, paisible, nature, magie | [A DEFINIR] | Njord |
| Muspelheim | Monde primordial du feu | [A DEFINIR] | Surtur |
| Niflheim | Monde primordial de glace, de froid extreme et de brumes ; force primordiale, purete, danger | Glace, neige, brumes, rivieres gelees [A DEFINIR] | Nidhogg |
| Jotunheim | Royaume des geants : sauvage, rocheux | Forets, montagnes [A DEFINIR] | [A DEFINIR] |
| Helheim | Royaume souterrain des morts de causes naturelles ou de vieillesse | [A DEFINIR] | Hel |
| Svartalfheim (Nidavellir) | Royaume souterrain des Nains : forge, magie, armes puissantes | Souterrains, forges [A DEFINIR] | Alberich [A VERIFIER] |
| Asgard | Royaume des dieux Ases : grandeur, splendeur | Valhalla, pont Bifrost [A DEFINIR] | Odin |

Les **mecaniques de biome** (regles specifiques a chaque royaume, par exemple le froid a Niflheim ou le feu a Muspelheim) sont [A DEFINIR] pour tous les biomes. Elles sont decrites ici comme piste de conception, pas comme fonctionnalite confirmee.

### 10.7 Elements a trancher

- Ordre de passage des biomes : [A DEFINIR] (voir chapitre 2).
- Nombre d'etages par biome et nombre total d'etages d'une run : [A DEFINIR].
- Taille de la grille d'un etage (nombre de cases total) : [A DEFINIR].
- Visibilite : le joueur voit-il tout l'etage, ou une partie seulement (brouillard, vision limitee) ? [A DEFINIR]

## 11. Direction artistique et audio

### 11.1 Intention generale

L'identite visuelle de Futhark's Adventure s'inspire de la culture nordique : materiaux bruts, climats rudes, ornements tribaux. Le style doit rester **lisible** : le jeu est un roguelike sur grille ou chaque case compte, le joueur doit identifier d'un coup d'oeil le terrain, les ennemis, le loot et les dangers.

Le jeu est concu comme un hommage au studio Motion Twin (voir chapitre 1). [A VERIFIER : degre d'inspiration visuelle des jeux du studio]

### 11.2 Style visuel

| Element | Choix |
|---|---|
| Rendu | **Pixel art** |
| Perspective | **2D, vue du dessus**, sur grille (type minimap) |
| Univers visuel | Bois, pierre, froid, neige, tonnerre, mer |
| Texture / materiaux | Aspect brut [A VERIFIER : mots illisibles dans les notes] |
| Resolution de reference des sprites | [A DEFINIR] (taille de tuile, ex. 16 x 16 ou 32 x 32) |
| Palette | [A DEFINIR] : une palette generale, declinee par biome |
| Animations | [A DEFINIR] : deplacement, attaque, degats, mort |

### 11.3 Identite graphique de l'interface

L'interface reprend les codes de la culture nordique, tout en restant sobre pour ne pas gener la lecture de la grille.

| Element | Choix |
|---|---|
| Police de caractere | Police d'inspiration viking de type "Viking Normal" [A VERIFIER : nom exact et licence] |
| Forme des cadres et boutons | Bords **"casses"** : rectangles dont les angles sont coupes (formes octogonales) |
| Ornements | **Motifs tribaux** : entrelacs, noeuds, frises geometriques repetees |
| Format | 16:9 en paysage ; variante portrait pour le tactile (voir chapitre 5) |

Les ecrans de fin de run (victoire / defaite, voir chapitre 4) reprendront cette identite. Leur traitement visuel est [A DEFINIR].

### 11.4 Identite visuelle par biome

Chaque biome (royaume) possede une ambiance, des couleurs et des elements de decor propres, tout en respectant le style general ci-dessus. Les pistes sont donnees au chapitre 10. La palette, les tuiles de sol et de murs, les ornements et les eclairages de chaque royaume sont [A DEFINIR].

| Element a produire par biome | Statut |
|---|---|
| Tuiles de sol et de murs | [A DEFINIR] |
| Objets de decor | [A DEFINIR] |
| Monstres endemiques | [A DEFINIR] |
| Boss | [A DEFINIR] |
| Effets lies aux mecaniques de biome | [A DEFINIR] |

### 11.5 Assets importants pour le gameplay

Certains assets ont un role de lisibilite directe pour le joueur et doivent etre traites en priorite :

- **Joueur et ennemis** : distinguables immediatement des tuiles de decor.
- **Sortie de l'etage** : doit etre identifiable clairement.
- **Loot et marchands** : apparence distincte (bouffe, monnaie, hachettes, items) [A DEFINIR].
- **Indicateurs de combat** : degats subis et infliges, mort des ennemis [A DEFINIR].
- **Icones du HUD** : barre de vie, bouffe, monnaie, hachettes, emplacements d'inventaire (chapitre 5).

### 11.6 Audio

L'ensemble du design sonore est [A DEFINIR].

| Categorie | Statut |
|---|---|
| Musique | [A DEFINIR] (style, une piste par biome ou non, musique de boss, de menu et de fin de run) |
| Effets sonores | [A DEFINIR] (deplacement, attaque, degats, mort, loot, achat, interface) |
| Ambiances | [A DEFINIR] (ambiance propre a chaque biome) |
| Voix | [A DEFINIR] (aucune prevue pour le moment) |

Role du son dans le gameplay : les retours sonores doivent confirmer chaque action du tour (deplacement, coup porte, coup recu) afin de renforcer la lisibilite. [A VERIFIER]

### 11.7 Elements a trancher

- Choix et licence de la police et des assets graphiques (production interne ou assets externes) : [A DEFINIR].
- Nombre d'assets a produire pour la vertical slice : voir chapitre 12.
- Options d'accessibilite visuelle (contraste, taille du texte, daltonisme) : [A DEFINIR].


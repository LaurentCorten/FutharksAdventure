# FUTHARK'S ADVENTURE - *A Motion Twin Tribute*

Octobre 2026

**Auteur :** Laurent Corten

**Engine :** Unity 6 (C#)

**Support :** PC (vertical slice) - expansion possible sur console et/ou telephone

**Genre :** Roguelike - Tour par tour - Grid based

**USP :** [TBA]

---

## Table des matieres

1. Profil du jeu
2. Univers et recit
3. Gameplay
4. Personnage et controles
5. Items et inventaire
6. Ennemis et obstacles
7. Niveaux et generation
8. Interface
9. Direction artistique et audio
10. Vertical slice

---

## 1. Profil du jeu

### 1.1 Introduction

Futhark's Adventure est un roguelike en 2D vue du dessus, au tour par tour, dans l'univers de la mythologie nordique. Le joueur incarne Futhark, un.e guerrier.e mort.e au combat et accueilli.e au Valhalla, qui doit relever un defi lance par Odin : traverser les autres royaumes, y vaincre des figures notoires, puis affronter Odin lui-meme.

L'experience visee est celle d'une tension permanente de gestion de ressources. Dans la lignee de Rogue, le temps ne s'arrete jamais : chaque action du joueur declenche un tour de jeu, les ennemis jouent en meme temps que lui, et chaque tour consomme une unite de nourriture. Le joueur doit en permanence arbitrer entre explorer pour looter et avancer vers la sortie avant d'etre a court de ressources.

Le jeu se veut lisible, rejouable et competitif : chaque run repart de zero, et l'objectif ultime est de faire le meilleur score possible pour grimper au leaderboard.

### 1.2 Resume du flux de jeu

Le joueur demarre une run au Valhalla, puis descend d'etage en etage. Les etages, generes procedurellement, sont regroupes en biomes (un par royaume), chacun termine par un boss. Apres le dernier royaume, le joueur retourne en Asgard pour affronter Odin. La run se termine par la mort du personnage ou par la victoire contre Odin ; le score est alors enregistre au leaderboard et une nouvelle run peut commencer.

Le detail des boucles de jeu est au chapitre 3.

### 1.3 Parametres generaux

| Element | Choix |
|---|---|
| Perspective / camera | 2D, vue du dessus, grid based |
| Direction artistique | Pixel art, ambiance nordique, une tonalite adaptee a chaque biome |
| Controles | Clavier/souris (vertical slice) ; manette et tactile ensuite selon le support |
| Rythme | Tour par tour : 1 action du joueur = 1 tour de jeu = 1 action de chaque ennemi |
| Duree d'une run | [A DEFINIR] |
| Format d'ecran | 16:9 (paysage), variante portrait envisagee pour le telephone |

### 1.4 Jeux de reference

- **Rogue** - A.I. Design
- **Kanji's Adventure** - Motion Twin
- **OneBit Adventure** - Galactic Slice

## 2. Univers et recit

### 2.1 Contexte narratif

Futhark est un.e guerrier.e mort.e au combat. Son genre n'est volontairement pas defini : le texte du jeu utilise une ecriture epicene afin que chaque joueur puisse s'identifier au personnage. Digne d'un trepas glorieux, iel est accueilli.e au Valhalla, le grand hall d'Asgard, ou reposent les heros.

Futhark etant deja mort, la mort n'est pas une fin definitive : c'est ce qui justifie, dans l'univers, qu'une nouvelle run puisse recommencer apres chaque defaite. Chaque run est une nouvelle tentative de relever le defi.

### 2.2 Le defi d'Odin

Odin lance a Futhark un defi dont la forme exacte reste [A DEFINIR] (concours, epreuve initiatique, ou autre). Son principe est fixe :

- aller dans chacun des **8 autres royaumes** ;
- y vaincre une **personne notoire**, qui joue le role de boss du royaume ;
- y recuperer un **objet unique** (artefact) ;
- puis revenir en **Asgard** et affronter **Odin** lui-meme, boss final du jeu.

### 2.3 Structure de la progression

Les neuf royaumes de la mythologie nordique, relies par l'arbre-monde Yggdrasil, structurent le jeu. Chaque royaume correspond a un **groupe d'etages** et possede :

- un **biome propre** (decor, ambiance, mecaniques de biome eventuelles : [A DEFINIR]) ;
- un **set de monstres endemiques** (chapitre 6) ;
- un **boss**, la personne notoire du royaume, affronte au dernier etage du biome ;
- un **artefact** a recuperer (chapitre 5) ;

L'ordre dans lequel les royaumes sont traverses est [A DEFINIR]. Asgard est a la fois le point de depart (Valhalla) et le point d'arrivee (combat contre Odin).

### 2.4 Les neuf royaumes

Ce tableau est la reference unique pour les royaumes, leurs boss et leurs artefacts.

| Royaume | Ambiance | Pistes de decor | Boss | Artefact |
|---|---|---|---|---|
| Asgard | Royaume des dieux Ases : grandeur, splendeur | Valhalla (hall des heros), Bifrost (pont arc-en-ciel garde par Heimdall) [A DEFINIR] | **Odin** (dieu Ase), boss final | - |
| Alfheim | Royaume des Elfes, associe a la lumiere : douceur, cosmos, sagesse, beaute, magie | [A DEFINIR] | **Freyr** (dieu Vane) | [A DEFINIR] |
| Vanaheim | Royaume des dieux Vanes : fertile, paisible, nature, magie | [A DEFINIR] | **Njord** | [A DEFINIR] |
| Muspelheim | Monde primordial du feu | [A DEFINIR] | **Surtur** ("geant") | [A DEFINIR] |
| Midgard | Royaume des humains, entoure d'un ocean infini | Mer, rivages, terres humaines [A DEFINIR] | **Jormungandr** (le serpent) | [A DEFINIR] |
| Niflheim | Monde primordial de glace, de froid extreme et de brumes : force primordiale, purete, danger, "epreuves" et "metamorphoses" | Glace, neige, brumes, rivieres Elivagar, source Hvergelmir, obscurite [A DEFINIR] | **Nidhogg** (dragon) | [A DEFINIR] |
| Jotunheim | Royaume des "geants" : sauvage, rocheux | Forets, montagnes [A DEFINIR] | [A DEFINIR] - candidats : Thrym, Hrungnir, Utgarda-Loki, Thjazi | [A DEFINIR] |
| Helheim | Royaume souterrain des morts de causes naturelles ou de vieillesse | [A DEFINIR] | **Hel** (deesse) | [A DEFINIR] |
| Svartalfheim (Nidavellir / Myrkheim) | Royaume souterrain des Nains et des elfes noirs : artisanal, obscur, forge, magie, armes puissantes | Souterrains, forges [A DEFINIR] | **Andvari** (roi sorcier) | Associes : Mjolnir, Brisingamen |

Notes :
- Svartalfheim : [TODO: A approfondir quel nom, quelles differences ?]

### 2.5 Mythes et artefacts [WIP - TODO: approfondire le lore pour en tirer un arc narratif]

**Ymir et la creation de Midgard.** Ymir est l'ancetre des geants, ne de la rencontre des glaces de Niflheim et des flammes de Muspelheim. Son corps a servi a creer Midgard (tue par Odin et ses adelphes). Sa chair est devenue la terre, son sang les mers, et ses sourcils une barriere protectrice. Cette barriere protege les humains des "geants" et explique la relation conflictuelle entre les deux peuples.

**Artefacts et reliques envisages** (leur attribution aux royaumes est [A DEFINIR]) :

| Artefact | Origine / effet envisage |
|---|---|
| Mjolnir | Marteau magique de Thor |
| Brisingamen | Collier de Freyja : charme et soutien d'armee |
| Ceinture de force | [A DEFINIR] |

L'effet en jeu des artefacts est traite au chapitre 5.

## 3. Gameplay

Le jeu repose sur trois boucles imbriquees : le **tour de jeu** (quelques secondes), l'**etage** (quelques minutes) et la **run** (session complete).

### 3.1 Boucle du tour (boucle principale)

Le jeu est un roguelike au sens de *Rogue* : le temps ne progresse que lorsque le joueur agit.

1. Le joueur choisit une action (se deplacer, attaquer, utiliser un item...). La liste des verbes et leur cout sont au chapitre 4.
2. L'action est executee : c'est le **tour de jeu**.
3. Chaque ennemi actif accomplit alors **un tour** : un deplacement **ou** une attaque (chapitre 6).
4. Le cout du tour est preleve sur les ressources du joueur (voir 3.2).
5. Le jeu attend la prochaine action du joueur.

Dans l'univers du jeu, tout le monde agit **en meme temps**. Pour le calcul, les actions sont resolues dans un ordre etabli (voir chapitre 6).

### 3.2 Economie du tour : la nourriture

Chaque tour de jeu coute **1 unite de nourriture**. La nourriture est la ressource qui limite le temps d'exploration : elle empeche le joueur de fouiller indefiniment.

- Si le joueur n'a plus de nourriture, chaque tour coute **1 point de vie (PV)** a la place : c'est la **famine**.
- La nourriture se recupere en la trouvant (loot, marchands). Le stock de depart est donne au chapitre 4.
- Un item peut convertir de la nourriture en PV (chapitre 5).

### 3.3 Boucle de l'etage

```
Entree -> Visite (loot) -> Rencontres -> Sortie
```

1. **Entree** : le joueur arrive par une case d'une piece.
2. **Visite** : il fouille l'etage pour trouver du loot (nourriture, items, equipement, monnaie).
3. **Rencontres** : il croise des **monstres** (combat) ou des **marchands** (achat d'items contre de la monnaie).
4. **Sortie** : il localise la sortie de l'etage et la prend pour passer a l'etage suivant.

La tension centrale est un arbitrage permanent : fouiller plus (plus de loot, donc plus de score et de survie) coute de la nourriture et expose a plus de combats, alors qu'avancer vite economise des ressources mais laisse du loot derriere.

La structure d'un etage et sa generation sont decrites au chapitre 7.

### 3.4 Boucle du biome

Le joueur enchaine les etages du biome, puis affronte le **boss** du royaume au dernier etage. Vaincre le boss permet de recuperer l'**artefact** du royaume et d'ouvrir l'acces au biome suivant. Un biome compte **3 a 5 etages normaux + 1 etage de boss** [A Confirmer].

### 3.5 Boucle de la run

```
Valhalla -> Biome 1 -> Boss -> Biome 2 -> Boss -> ... -> Biome 8 -> Boss -> Asgard -> Odin
```

- La run commence au Valhalla et se termine soit par la mort du personnage, soit par la victoire contre Odin.
- Dans les deux cas, le **score** est calcule et soumis au **leaderboard**.
- Tout est ensuite remis a zero : une nouvelle run recommence sans progression conservee.

### 3.6 Victoire et defaite

Le jeu distingue deux niveaux de victoire :

| Niveau | Definition |
|---|---|
| Victoire de run | Vaincre Odin en Asgard, apres avoir battu les boss des 8 autres royaumes et recupere leurs artefacts |
| Victoire ultime | Obtenir la premiere place du leaderboard |

Terminer le jeu n'est donc pas le but final : c'est la qualite de la run (le score) qui compte. Une run qui bat Odin avec un score faible reste "gagnee", mais ne constitue pas la victoire ultime.

**Defaite** : le joueur perd la run lorsque ses **PV tombent a 0**. Causes possibles :

- les degats infliges par un monstre ou un boss ;
- la **famine** (3.2), qui peut mener a la mort sans qu'aucun ennemi n'intervienne ;
- les autres sources de degats (pieges, mecaniques de biome) [A DEFINIR].

La mort n'est pas une fin narrative (voir 2.1). Le score d'une run interrompue est enregistre comme celui d'une run reussie, s'il est suffisant.

**Limites** :

- Pas de sauvegarde en cours de run [A Confirmer].
- Pas de progression persistante entre les runs.
- Pas de "mauvaise fin" ni de fin alternative : seuls comptent la mort ou la victoire sur Odin, et le score obtenu.

### 3.7 Score

| Source | Detail |
|---|---|
| Etage atteint | Points fixes ou incrementaux selon l'etage [A DEFINIR] |
| Monstres tues | Points selon le type de monstre |
| Bonus de loot | Points selon la valeur du loot (petit / moyen / gros) |

La valeur brute du loot croit avec sa taille (petit < moyen < gros). Les formules et la ponderation entre ces trois sources sont [A DEFINIR].

Le leaderboard est enregistre en **local** (fichier JSON) et comprend le **Top 10** des meilleurs scores.

### 3.8 Ecran de fin de run

A la fin de chaque run (victoire ou defaite), le jeu affiche un ecran de fin avec :

- le resultat (victoire / defaite) et la cause de la fin de run ;
- le **score** detaille (etage atteint, monstres tues, bonus de loot) [A Confirmer] ;
- le classement au **leaderboard** ;
- les actions disponibles : recommencer une run, quitter le jeu.

Le contenu exact de l'ecran et son ton visuel (differenciation entre victoire et defaite) sont [A DEFINIR] (voir chapitre 9).

## 4. Personnage et controles

### 4.1 Futhark

Futhark est le personnage jouable unique (voir 2.1). Son apparence reste neutre afin que chaque joueur puisse s'y identifier.

Le personnage n'a **pas de progression permanente** : tout est remis a zero a chaque run. Son evolution au cours d'une run vient uniquement de ce qu'iel trouve (items, equipement, artefacts) et non d'un systeme de niveaux ou d'experience.

### 4.2 Statistiques et ressources

| Element | Role | Valeur de depart |
|---|---|---|
| Points de vie (PV) | Vitalite : a 0, la run est perdue. Affiches sous la forme actuel/max (ex. 17/34) | 17* |
| Nourriture | Ressource consommee a chaque tour. A 0, chaque tour coute 1 PV | 150* |
| Monnaie | Sert a acheter des items aupres des marchands | 0* |
| Hachettes | Munitions de l'attaque a distance | 3* |
| Portee de vision (VisionRange) | Rayon, en cases, de la zone de vision carree autour du joueur (chapitre 8) et portee de l'attaque a distance (4.5) | [A DEFINIR] |
| Degats | Degats infliges par les attaques, modifies par l'arme et le bijou de Force | [A DEFINIR] |
| Reduction de degats | Diminue les degats recus, modifiee par l'armure | 0* |
| Dexterite (Dex) | Aptitude au touche et aux esquives | [A DEFINIR] |

\*Valeurs provisoires (variables serialisees) a calibrer lors de l'equilibrage.

Les PV maximum peuvent etre augmentes par certains items (chapitre 5).

**Combat** : Chaque attaque passe par un test de touche (Dex) ; les degats ne sont appliques qu'en cas de touche, diminues par la reduction de degats (calcul [A DEFINIR]).

### 4.3 Verbes

Les verbes sont les capacites du personnage. Il dispose d'emblee de toutes les capacites de base ; ses options s'etendent via les items, les runes et les artefacts.

| Verbe | Description | Consomme un tour | Autre cout |
|---|---|---|---|
| Se deplacer | Deplacement d'une case sur la grille, dans l'une des 4 directions cardinales | Oui | - |
| Attaquer au corps a corps | S'obtient en se deplacant vers une case occupee par un ennemi | Oui | - |
| Attaquer a distance | Lance une hachette sur une cible choisie automatiquement (voir 4.5) | Oui | 1 hachette |
| Interagir (marchand, coffre, sortie) | Automatique en marchant sur la case | Non | - |
| Acheter un item | Achete un item dans la bulle du marchand | Oui | Monnaie |
| Utiliser un item | Utilise un item de l'inventaire | Selon l'item | Selon l'item |
| Ouvrir le menu pause | Accede au menu pause | Non | - |
| Confirmer / annuler | Valide ou annule dans les menus et la bulle du marchand | Non | - |
| Passer son tour (attendre) | [A DEFINIR : verbe non confirme] | Oui | - |

Capacites additionnelles possibles, issues des items (chapitre 5) :
- **Soins** : potions de vie.
- **Conversion** : transformer de la nourriture en PV.
- **Runes** : effets elementaires (feu, glace, tonnerre, chaos...) lies a la mythologie nordique [A DEFINIR].

### 4.4 Controles

| Verbe | Clavier / souris | Manette | Tactile |
|---|---|---|---|
| Se deplacer | Fleches, ZQSD, WASD, ou pave numerique (8 haut, 2 bas, 4 gauche, 6 droite) | Stick gauche ou croix directionnelle | Croix directionnelle virtuelle a l'ecran |
| Attaquer au corps a corps | Se deplacer vers l'ennemi | Se deplacer vers l'ennemi | Se deplacer vers l'ennemi |
| Attaquer a distance | Barre d'espace, ou 5 du pave numerique | Bouton de face droit (B) [ou Y ou RT?] | Bouton au centre de la croix virtuelle |
| Utiliser un item | Clic gauche sur l'emplacement dans l'inventaire | Passer a la selection d'item avec le bouton de face gauche (X), naviguer a la croix directionnelle, confirmer | lache Appui sur l'emplacement  |
| Voir la description d'un item | Survol de l'emplacement | Emplacement selectionne | Appui non lache sur l'emplacement |
| Confirmer / annuler | NA./NA. | Bouton de face bas (A) / bouton de face droit (B) | NA. / glisser hors de l'item avant de lacher |
| Menu pause | Echap | Bouton Start | Bouton menu a l'ecran [A DEFINIR] |

La selection d'une proposition dans la bulle du marchand fonctionne comme la selection dans l'inventaire.

### 4.5 Regles de l'attaque a distance

L'attaque a distance (hachette) utilise une **visee automatique** : le joueur ne choisit pas sa cible.

| Regle | Detail |
|---|---|
| Condition de tir | Au moins un monstre **aligne** sur l'une des 4 directions cardinales |
| Portee | Les cases de la zone de vision (rayon **VisionRange**) avec une ligne de visee **non interrompue** par un mur |
| Case adjacente | Impossible de lancer une hachette sur un monstre en case adjacente (c'est du corps a corps) |
| Cible multiple | Le monstre **le plus proche** est vise |
| Egalite de distance | Meme cible qu'au coup precedent si elle fait partie des candidats |
| Egalite sans coup precedent | Le monstre ayant **le moins de PV** parmi les plus proches [A DEFINIR : si egalite de PV aussi] |
| Aucune cible valide | L'action est refusee : aucun tour consomme, aucune hachette perdue |
| Stock vide | L'action est refusee : aucun tour consomme |

## 5. Items et inventaire

### 5.1 Principe general

Tout ce que le joueur trouve ou achete est un **item** ou une **ressource**. Chaque item possede trois proprietes de conception :

- **Actif / Passif** : un item *actif* est utilise volontairement par le joueur ; un item *passif* agit en permanence tant qu'il est equipe ou possede.
- **Occupe une place** : indique si l'item prend un emplacement de l'inventaire (oui / non).
- **Consommable** : indique si l'item est consomme a l'utilisation ou reste utilisable.

Les valeurs chiffrees (soin, degats, prix, raretes) sont [A DEFINIR] : elles seront calibrees lors de l'integration.

### 5.2 Inventaire

L'inventaire contient **3 emplacements de base**, auxquels la ceinture ajoute **2 emplacements** (une seule ceinture). Il peut donc contenir jusqu'a 5 items qui occupent une place. Il n'existe que dans le HUD (chapitre 8) : il n'y a pas d'ecran d'inventaire dedie.

L'inventaire fonctionne comme une file, rempli de **droite a gauche**, sans jamais laisser de case vide entre deux items :

- **Ramassage** : marcher sur un item le ramasse automatiquement. Il est place dans la case libre la plus a droite.
- **Inventaire plein** : l'item le plus a droite (le plus ancien) est depose au sol sur la case du joueur, tous les autres items se decalent d'une case vers la droite, et le nouvel item prend la case la plus a gauche.
- **Utilisation** : quand un item est consomme, les items situes a sa gauche se decalent d'une case vers la droite pour combler le vide.

En sus, trois **emplacements caches** existent pour l'equipement. Ils ne sont pas accessibles au joueur et ne font pas partie des 3 a 5 emplacements de l'inventaire :

| Emplacement | Effet |
|---|---|
| Arme | Augmente les degats infliges |
| Armure | Reduit les degats recus |
| Ceinture | Augmente l'inventaire (+2 emplacements) |

### 5.3 Ressources

Les ressources ne sont pas des items d'inventaire : elles sont stockees dans des compteurs du HUD.

| Ressource | Role | Sources | Remarques |
|---|---|---|---|
| Nourriture | Consommee a chaque tour (chapitre 3) | Loot, marchands | Plusieurs valeurs trouvables, de type petite / moyenne / grosse portion [A DEFINIR] |
| Monnaie | Achats chez les marchands | Loot | Plusieurs valeurs trouvables, de type petite / moyenne / grosse portion (idee de valeurs : 1 / 3 / 10) [A Confirmer] |
| Hachettes | Munitions de l'attaque a distance | Loot, marchands | Plusieurs valeurs trouvables, de type moyenne / grosse portion (idee de valeurs : 3 / 5) [A Confirmer] |

### 5.4 Equipements et consommables

| Item | Effet | Actif / Passif | Occupe une place | Consommable |
|---|---|---|---|---|
| Potion de vie | Rend une quantite moyenne de PV | Actif | Oui | Oui |
| Grande potion de vie | Rend tous les PV et augmente un peu les PV maximum | Actif | Oui | Oui |
| Item de transformation (nom [A DEFINIR])* | Transforme de la nourriture en PV (ratio 1 pour 1 [A Confirmer]) | Actif | Oui | Non |
| Bijou de Dexterite | Augmente les chances de touche et d'esquive | Passif | Oui | Non |
| Bijou de Force | Augmente les degats infliges | Passif | Oui | Non |
| Dague | Arme de niveau 1, augmente un peu les degats infliges | Passif | Non | Non |
| Protege bras en cuir | Armure de niveau 1, diminue un peu les degats recus | Passif | Non | Non |
| Ceinture** | Rajoute 2 emplacements d'inventaire | Passif | Non | Non |
| Runes | Items porteurs d'effets elementaires/magiques tels que feu, glace, tonnerre, chaos, peur... [A DEFINIR] | Actif | Oui | Oui |

*Peut-etre, en plus de la consommation de nourriture, appliquer une penalite (comme une lenteur digestive) en cas d'utilisation excessive d'un coup ?  
**Sera peut-etre fusionnee avec la ceinture de force.

### 5.5 Runes

Les runes sont des items porteurs d'effets elementaires et magiques, inspires de la mythologie nordique. Les effets doivent rester coherents avec cette mythologie (travail d'exploration mythologique a faire).

### 5.6 Artefacts

Chaque royaume vaincu donne un **artefact** unique (chapitre 2). Un artefact est un item special, non achetable. Sa nature (equipement, relique passive, capacite...) et son effet sont [A DEFINIR]. Candidats evoques : Mjolnir, Brisingamen, ceinture de force.

### 5.7 Sources d'items

| Source | Description |
|---|---|
| Loot dans l'etage | Items et ressources dissemines dans les pieces de l'etage (generation procedurale) |
| Marchands | Rencontres aleatoires dans l'etage. Proposent 4 items aleatoires contre de la monnaie |
| Monstres | Drop eventuel a la mort |
| Boss | Artefact du royaume + recompense eventuelle [A DEFINIR] |

### 5.8 Elements a trancher

- Familiers (pets) : evoques dans les notes, non confirmes [A DEFINIR].
- Rarete des items et tables de loot par biome : [A DEFINIR].
- Items maudits, pieges ou a risque : non prevus pour le moment [A VERIFIER].

## 6. Ennemis et obstacles

### 6.1 Principe general

Les ennemis sont les principales sources d'opposition du jeu. Ils evoluent sur la meme grille que le joueur et obeissent aux regles du tour par tour (chapitre 3) : a chaque tour de jeu declenche par le joueur, **chaque ennemi actif accomplit un tour**, c'est-a-dire **soit un deplacement, soit une attaque**.

Les valeurs de statistiques (PV, degats, vitesse) sont [A DEFINIR] et seront calibrees lors de l'integration.

### 6.2 Comportement des ennemis

| Element | Regle |
|---|---|
| Tour de jeu | 1 action par tour : deplacement **ou** attaque |
| Attaque au corps a corps | Un ennemi attaque le joueur lorsqu'il se trouve sur une case adjacente |
| Attaque a distance | Certains ennemis peuvent attaquer de loin [A DEFINIR] |
| Deplacement | Vers le joueur lorsqu'il est detecte [A DEFINIR : pathfinding, comportement hors detection] |
| Ordre de resolution | Dans l'univers, tous les ennemis agissent en meme temps. Pour le calcul, leurs actions sont resolues l'une apres l'autre, dans l'ordre de la liste des ennemis ; en cas de conflit pour une case, le premier de la liste l'obtient |
| Apparition | Placement procedural lors de la generation de l'etage (chapitre 7) |

### 6.3 Types d'ennemis

Chaque biome possede un **set de monstres endemiques**, propre au royaume et coherent avec son ambiance et la mythologie nordique. D'autres monstres sont plus generaux et peuvent apparaitre dans n'importe quel biome.

Le nombre de monstres par type et par biome, ainsi que leur description detaillee, seront ajoutes dans une version ulterieure de ce document. Chaque monstre devra y etre decrit avec : nom, biome, comportement, statistiques (PV, degats, distance de detection, propension au pas aleatoire pendant la poursuite, points de score), drop, moyen d'en venir a bout.

### 6.4 Score et recompenses

Chaque monstre tue rapporte des points au score de la run (chapitre 3). Le montant depend du type de monstre [A DEFINIR]. Les monstres peuvent laisser du loot a leur mort [A DEFINIR].

### 6.5 Boss

Un boss garde la sortie de chaque biome. C'est la **personne notoire** du royaume ; la liste des boss est au chapitre 2 (2.4).

- Chaque boss est affronte une seule fois par run, au dernier etage de son biome.
- Les boss suivent le meme systeme de tour par tour que les monstres, mais avec des comportements et des attaques propres [A DEFINIR].
- Vaincre un boss permet de recuperer l'artefact du royaume et d'acceder au biome suivant.
- Le combat contre Odin conclut la run (chapitre 3).
- L'ordre de rencontre des boss suit l'ordre des royaumes, [A DEFINIR] (chapitre 2).

Fiche detaillee par boss (PV, patterns d'attaque, phases, recompense) : [A DEFINIR].

### 6.6 Autres obstacles

| Obstacle | Description | Moyen d'en venir a bout |
|---|---|---|
| Famine | La nourriture baisse a chaque tour ; a 0, chaque tour coute 1 PV | Trouver ou acheter de la nourriture, ne pas gaspiller les tours |
| Ressources limitees | Hachettes et items en nombre restreint, inventaire limite | Choisir quoi garder, quoi acheter, quand utiliser |
| Murs et geometrie des pieces | Les murs bloquent le deplacement et les tirs ; le joueur doit trouver son chemin dans l'etage | Exploration, choix d'itineraire |
| Brouillard | Seule la zone de vision autour du joueur est visible (chapitre 8) | Exploration |
| Sortie a decouvrir | L'etage est genere procedurellement, la sortie n'est pas connue au depart | Exploration, qui coute de la nourriture |
| Mecaniques de biome | Contraintes propres a chaque royaume (froid, feu, obscurite...) | [A DEFINIR] |

## 7. Niveaux et generation

### 7.1 Principe general

Le jeu ne comporte pas de niveaux dessines a la main : chaque **etage** est genere procedurellement a chaque run. Les etages sont regroupes en **biomes**, un biome par royaume (chapitre 2), chacun comptant 3 a 5 etages normaux + 1 etage de boss [A Confirmer].

```
Run
 +-- Biome 1 (royaume) : etage 1, etage 2, ... etage n, boss
 +-- Biome 2 (royaume) : etage 1, etage 2, ... etage n, boss
 +-- ...
 +-- Asgard : etage(s), Odin
```

La progression de la difficulte d'un etage a l'autre est [A DEFINIR].

### 7.2 Structure d'un etage

Un etage est compose de **9 pieces disposees en matrice carree 3 x 3**, reliees entre elles par des **couloirs**, comme dans *Rogue*.

```
[ P1 ]--[ P2 ]--[ P3 ]
  |       |       |
[ P4 ]--[ P5 ]--[ P6 ]
  |       |       |
[ P7 ]--[ P8 ]--[ P9 ]
```

| Element | Regle |
|---|---|
| Disposition | Matrice carree de 9 pieces (3 x 3) |
| Taille des pieces | 1 a 7 cases de cote, variable d'une piece a l'autre (forme carree ou rectangulaire, limite exacte du rapport largeur / hauteur : [A DEFINIR]) |
| Liaison | Couloirs entre pieces voisines (1 case de large, au milieu de chaque cote) |
| Connexite | Les 12 connexions existent toujours, mais 2 pieces peuvent fusionner le cas echeant |
| Entree | Le joueur arrive par une case d'une piece (choix de la piece au hasard) |
| Sortie | Une case de sortie placee dans une autre piece de l'etage (position au hasard, distance minimale avec l'entree : [A DEFINIR]) |

### 7.3 Contenu d'un etage

Le contenu est place **de maniere procedurale** lors de la generation :

| Contenu | Description | Detail |
|---|---|---|
| Monstres | Rencontres de combat | Selon le set endemique du biome (chapitre 6) |
| Marchands | Rencontres d'achat | Proposent 4 items aleatoires (chapitre 5) |
| Loot | Items et ressources au sol | Nourriture, monnaie, hachettes, items (chapitre 5) |
| Sortie | Passage a l'etage suivant | Toujours presente |
| Boss | Present uniquement au dernier etage d'un biome | Chapitre 6 |

Les regles de repartition (nombre de monstres, de marchands et de loot par etage, probabilites, tables de loot par biome) sont [A DEFINIR]. Le meme jeu de regles est applique a chaque run, avec des graines aleatoires differentes.

### 7.4 Generation procedurale

Principes a respecter par l'algorithme :

1. **Aleatoire** : la disposition, les tailles de pieces, le contenu et la position de la sortie changent a chaque run.
2. **Jouable** : chaque etage doit etre completable (entree reliee a la sortie par un chemin praticable).
3. **Lisible** : la grille doit rester simple a lire dans la vue 2D du dessus (chapitre 8).
4. **Reproductible** : chaque run possede une graine (seed) ; la graine de chaque etage est derivee de la graine de la run et du numero de l'etage. Une meme graine de run regenere donc les memes etages.

### 7.5 Etage de boss

Le dernier etage d'un biome est consacre au boss de ce royaume. Sa structure (arene unique, plusieurs pieces, couloirs) est [A DEFINIR]. Le boss garde la sortie : le joueur doit le vaincre pour recuperer l'artefact et acceder au biome suivant.

### 7.6 Elements a trancher

- Ordre de passage des biomes : [A DEFINIR] (chapitre 2).
- Taille de la grille d'un etage (nombre de cases total) : [A DEFINIR].

## 8. Interface

Les controles associes a chaque element d'interface sont au chapitre 4.

### 8.1 Liste des vues

| Vue | Description | Camera |
|---|---|---|
| Menu principal | Point d'entree du jeu : lancer une run, options, leaderboard, quitter [A Confirmer] | Fixe |
| Vue etage (vue principale) | Vue 2D du dessus, sur grille, dans laquelle le joueur se deplace, combat et loote. Le HUD, l'inventaire et la bulle du marchand en font partie | Centree sur le joueur |
| Menu pause | Menu accessible en cours de run, superpose a la vue etage | Fixe |
| Ecran de fin de run | Resultat, score detaille et leaderboard (chapitre 3) | Fixe |

### 8.2 Enchainement des vues

```
Menu principal -> Vue etage <-> Menu pause
                     |
                     v
              Ecran de fin de run -> Menu principal ou nouvelle run
```

- Le jeu etant au tour par tour, afficher le menu pause ou la bulle du marchand ne fait pas avancer le temps.
- Le passage d'un etage a l'autre se fait par la case de sortie, sans ecran intermediaire [A DEFINIR : ecran de chargement].
- Le passage d'un biome a l'autre (apres un boss) peut etre marque par un ecran dedie [A DEFINIR].

### 8.3 Vue etage

**Cadrage**

Nombre fixe de lignes et de colonnes affichees, avec le joueur toujours au centre. Le canvas de jeu est limite par un cadre avec decorations [A DEFINIR] pour ramener a une forme carree. [A Confirmer]

**Brouillard**

La visibilite est limitee a une **zone de vision carree** de rayon **VisionRange** (chapitre 4) centree sur le joueur. Les murs ne bloquent pas la vision. La zone est mise a jour a chaque tour. Chaque case a l'un des trois etats suivants :

| Etat | Affichage |
|---|---|
| Jamais vue | Noir |
| Deja vue, hors zone de vision | Assombrie : le decor reste visible, les ennemis ne sont pas affiches |
| Visible (dans la zone de vision) | Normal |

**Bulle du marchand**

Lorsque le joueur entre en contact avec un marchand, une bulle de dialogue apparait, reliee au marchand. Elle contient **4 propositions d'achat** et disparait des que le joueur s'eloigne. Elle ne couvre qu'une petite partie de l'ecran : la vue reste celle du jeu, sans changement d'ecran ni interruption.

- Definition du "contact" (case adjacente, ou deplacement vers le marchand) : [A DEFINIR].
- Un achat consomme un tour (chapitre 4).

**Inventaire**

L'inventaire est affiche dans le HUD (8.4) ; ses regles sont au chapitre 5. Les emplacements d'equipement sont caches.

### 8.4 HUD de la vue etage

Le HUD affiche en permanence les informations vitales de la run. Il est concu en **16:9 (paysage)** pour le PC, avec une variante **portrait** envisagee pour le telephone. [TODO : Corriger pour correspondre aux decisions prises de vue carree et de brouillard]

| Element | Description | Position (paysage) |
|---|---|---|
| Barre de vie | Barre de PV completee d'une valeur numerique (ex. 17/34) | Haut gauche |
| Reserve de nourriture | Icone de nourriture avec quantite disponible en valeur numerique (ex. 320) | Sous la barre de vie |
| Monnaie | Icone de monnaie avec quantite disponible en valeur numerique (ex. 64) | Sous la barre de vie |
| Objets lancables | Icone de hachette avec quantite disponible en valeur numerique (ex. 5) | Sous la barre de vie |
| Inventaire | Emplacements d'items utilisables (jusqu'a 5 affiches) | Haut droite, en ligne |
| Score | Score courant de la run (ex. 1.320.000) | Bas droite |

**Variante portrait (tactile)** : barre de vie et compteurs en haut, colonne d'emplacements d'inventaire sur le cote droit en burger menu, croix directionnelle virtuelle en bas au centre, score tout en bas.

### 8.5 Menu pause

Le menu pause est accessible a tout moment pendant la vue etage.

- Contenu : reprendre, options, abandonner la run, quitter le jeu [A Confirmer].
- Presentation : plein ecran, ou pop up central avec le reste de l'ecran grise et le jeu visible par transparence [A DEFINIR].

## 9. Direction artistique et audio

### 9.1 Intention generale

L'identite visuelle de Futhark's Adventure s'inspire de la culture nordique : materiaux bruts, climats rudes, ornements tribaux. Le style doit rester **lisible** : le jeu est un roguelike sur grille ou chaque case compte, le joueur doit identifier d'un coup d'oeil le terrain, les ennemis, le loot et les dangers.

### 9.2 Style visuel

| Element | Choix |
|---|---|
| Rendu | **Pixel art** |
| Perspective | **2D, vue du dessus**, sur grille |
| Univers visuel | [A DEFINIR] |
| Texture / materiaux | Aspect brut |
| Resolution de reference des sprites | **16 x 16 px** par defaut, a ajuster selon les assets trouves [A Confirmer] |
| Palette | [A DEFINIR] : une palette generale, declinee par biome |
| Animations | [A DEFINIR] : deplacement, attaque, degats, mort |

### 9.3 Identite graphique de l'interface

L'interface reprend les codes de la culture nordique, tout en restant sobre pour ne pas gener la lecture de la grille.

| Element | Choix |
|---|---|
| Police de caractere | Police d'inspiration viking de type "Viking Normal" [A Confirmer] |
| Forme des cadres et boutons | Bords **"casses"** : rectangles dont les angles sont coupes (formes octogonales) |
| Ornements | **Motifs tribaux** : entrelacs, noeuds, frises geometriques repetees |
| Format | 16:9 en paysage ; variante portrait pour le tactile (chapitre 8) |

Les ecrans de fin de run (chapitre 3) reprendront cette identite. Leur traitement visuel est [A DEFINIR].

### 9.4 Identite visuelle par biome

Chaque biome possede une ambiance, des couleurs et des elements de decor propres, tout en respectant le style general ci-dessus. Les pistes sont donnees au chapitre 2 (2.4).

| Element a produire par biome | Statut |
|---|---|
| Tuiles de sol et de murs | [A DEFINIR] |
| Objets de decor | [A DEFINIR] |
| Monstres endemiques | [A DEFINIR] |
| Boss | [A DEFINIR] |
| Effets lies aux mecaniques de biome | [A DEFINIR] |

### 9.5 Assets importants pour le gameplay

Certains assets ont un role de lisibilite directe pour le joueur et doivent etre traites en priorite :

- **Joueur et ennemis** : distinguables immediatement des tuiles de decor.
- **Sortie de l'etage** : doit etre identifiable clairement.
- **Loot et marchands** : apparence distincte (nourriture, monnaie, hachettes, items) [A DEFINIR].
- **Indicateurs de combat** : degats subis et infliges, mort des ennemis [A DEFINIR].
- **Brouillard** : les trois etats de case (chapitre 8) doivent se distinguer clairement.
- **Icones du HUD** : barre de vie, nourriture, monnaie, hachettes, emplacements d'inventaire (chapitre 8).

### 9.6 Audio

L'ensemble du design sonore est [A DEFINIR].

| Categorie | Statut |
|---|---|
| Musique | [A DEFINIR] (style, une piste par biome ou non, musique de boss, de menu et de fin de run) |
| Effets sonores | [A DEFINIR] (deplacement, attaque, degats, mort, loot, achat, interface) |
| Ambiances | [A DEFINIR] (ambiance propre a chaque biome) |
| Voix | [A DEFINIR] (aucune prevue pour le moment) |

Role du son dans le gameplay : les retours sonores doivent confirmer chaque action du tour (deplacement, coup porte, coup recu) afin de renforcer la lisibilite.

### 9.7 Elements a trancher

- Assets graphiques : **externes** (achat possible si le prix reste raisonnable) ; choix du pack et verification des licences (assets et police) : [A DEFINIR].
- Nombre d'assets a produire pour la vertical slice : voir chapitre 10.
- Options d'accessibilite visuelle (contraste, taille du texte, daltonisme) : [A DEFINIR].

## 10. Vertical slice

### 10.1 Objectif

La vertical slice est une version jouable de bout en bout qui prouve que la boucle de jeu fonctionne : demarrer une run, explorer plusieurs etages generes procedurellement, combattre des monstres, gerer ses ressources, affronter un boss, puis voir son score au leaderboard. Elle correspond grosso modo au **premier biome** du jeu complet ; la victoire de la slice consiste a vaincre le boss de ce biome.

Support cible : **PC, clavier/souris**. Les controles manette et tactile sont decrits au chapitre 4 mais ne font pas partie de la vertical slice.

Royaume du premier biome : [A DEFINIR].

### 10.2 Perimetre du MVP (Minimum Viable Product)

Le MVP est la version minimale qui doit imperativement etre livree.

| Domaine | Contenu du MVP |
|---|---|
| Generation | 3 a 5 etages normaux (parametrable) generes procedurellement (chapitre 7), + 1 dernier etage avec le boss |
| Personnage joueur (PJ) | Deplacement, attaque au corps a corps, attaque a distance (hachettes), utilisation d'une potion |
| Combat | Degats fixes, toute attaque touche (pas de test de touche) |
| Tour par tour | Systeme de tours complet : le joueur agit, puis les monstres et le boss agissent (chapitre 3) |
| Ressources | Nourriture consommee a chaque tour, PV, hachettes, famine (a 0 de nourriture, 1 PV par tour) |
| Visibilite | Brouillard : zone de vision carree (VisionRange), cases jamais vues / deja vues / visibles (chapitre 8) |
| Monstres | Plusieurs types de monstres aux caracteristiques distinctes (chapitre 6) |
| Boss | Un boss en fin de biome |
| Loot | Nourriture, munitions d'attaque a distance (hachettes), potion de vie |
| HUD | Barre de vie, nourriture, hachettes, inventaire, score (chapitre 8) |
| Ecran de demarrage | Ecran de lancement d'une run |
| Fin de run | Ecran de victoire / defaite avec score (chapitre 3) |
| Leaderboard | Enregistrement et affichage des scores |

**Hors MVP** (meme si ces elements apparaissent dans les autres chapitres) : monnaie (zone reservee au HUD) et marchands, equipement, bijoux, ceinture, runes et sorts, item de transformation, grandes potions de vie, familiers, artefacts, autres biomes, Odin, mecaniques de biome, test de touche (Dex), manette, tactile.

Le HUD et les systemes devront etre concus pour accueillir ces ajouts sans refonte.

*Note : la liste du MVP n'est pas figee. Tout oubli sera ajoute en cours de developpement.*

### 10.3 Roadmap des ajouts

Les paliers sont ordonnes par priorite. Chaque palier n'est aborde que si le precedent est termine et que le temps le permet.

**Palier 0 - MVP** : voir 10.2.

**Palier 1 - Premiere couche de profondeur** (objectif souhaite)

- Une premiere arme physique (augmente les degats infliges)
- Une premiere armure (reduit les degats recus)
- Item de transformation de la nourriture en PV (nom [A DEFINIR])
- Quelques **runes** permettant de lancer des sorts (effets [A DEFINIR])
- Peut-etre : la ceinture (+2 emplacements d'inventaire)

**Palier 2 - Economie**

- Monnaie
- Marchands (4 items aleatoires proposes, chapitre 5)

**Palier 3 - Score et loot**

- Lootables de score brut (petit / moyen / gros, chapitre 3)

**Palier 4 - Consommables et magie**

- Grandes potions de vie
- Davantage de sorts

**Palier 5 - Familiers**

- Pets

**Palier a positionner**

- Test de touche (Dex)
- Support manette

### 10.4 Criteres de reussite de la vertical slice

- Une run complete est jouable de l'ecran de demarrage jusqu'a l'ecran de fin, victoire ou defaite.
- La boucle "explorer - combattre - gerer sa nourriture" est comprehensible sans explication.
- Le score est enregistre et visible au leaderboard.
- Chaque nouvelle run propose une disposition d'etages differente.
- Les monstres sont distincts dans leur comportement et leurs statistiques.
- Le boss constitue une difficulte marquante par rapport aux etages precedents.
- Le jeu est stable sur PC [A DEFINIR : configuration minimale].
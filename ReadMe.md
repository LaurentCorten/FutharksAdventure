# Futhark's Adventure
### *A Motion Twin Tribute*

**[English](#en) | [Français](#fr)**

> **Branch notice:** `main` holds the latest stable version. Active development happens on the [`dev`](https://github.com/<user>/<repo>/tree/dev) branch, where progress is updated after each feature.

---

<a id="en"></a>
## English

### The game
**Futhark's Adventure** is a 2D top-down, turn-based roguelike set in Norse mythology.
You play Futhark, a warrior fallen in battle and welcomed into Valhalla, who takes up Odin's challenge: cross the other realms, defeat their legendary figures, and face Odin himself.

Every action is one turn, every turn costs food. Explore to loot and survive, or rush to the exit before starving: each run starts from scratch, and the only goal is the best score on the leaderboard.

**Inspirations:** *Rogue* (A.I. Design), *Kanji's Adventure* (Motion Twin), *OneBit Adventure* (Galactic Slice).

### Project context
Final project of the **Game Designer** training at **Bruxelles Formation – DigitalCity**, supervised by trainers from the Belgian game studio **Team Panoptes**.

The deliverable is twofold:
- a professional **Game Design Document** describing the full game;
- a playable **vertical slice**: one biome, several procedurally generated floors, and a boss.

### Status
🚧 **In development** — vertical slice targeted for **December 2026**.

| Version | Content |
|---|---|
| Current stable (`main`) | None yet: the first stable release will be the vertical slice |
| Next milestone | Vertical slice, Tier 0 (MVP), December 2026 (see [Roadmap](Documents/FutharksAdventure_RoadMap.md)) |

### Tech & architecture
- **Unity 6.5**, **C#**
- **Game rules in pure C#** (`Core` assembly), independent from Unity and covered by **EditMode unit tests**
- **MonoBehaviours as thin glue**, data in **ScriptableObjects**
- **Event-driven** communication between game logic and display
- **Single entry point**: a Bootstrap scene acting as Composition Root
- **Seeded procedural generation**: the same run seed rebuilds the same floors
- **SOLID** principles, Git flow with `main` / `dev` / feature branches

### Documentation
| Document | Content |
|---|---|
| [Game Design Document *](Documents/FutharksAdventure_GDD.md) | Full game vision: universe, gameplay, items, enemies, generation, UI, art direction, vertical slice scope |
| [Roadmap *](Documents/FutharksAdventure_RoadMap.md) | Development plan of the vertical slice, phase by phase |
| [CV](CORTENLaurent-CV_GameDesigner_Developer_2026.en.pdf) | Author's resume |

**The documentation is written in French.*

### Run the project
1. Clone the repository.
2. Open it with **Unity 6.5**.
3. Open the **Bootstrap** scene and press Play.
4. Unit tests: *Window > General > Test Runner > EditMode*.

### Credits & license
- Design and code: **Laurent Corten** — [LinkedIn](https://www.linkedin.com/in/laurentcorten/)
- External assets: <pack name, author, license> *(to be added)*

© 2026 Laurent Corten. All rights reserved.

---

<a id="fr"></a>
## Français

### Le jeu
**Futhark's Adventure** est un roguelike en 2D vue du dessus, au tour par tour, dans l'univers de la mythologie nordique.
Vous incarnez Futhark, guerrier·e mort·e au combat et accueilli·e au Valhalla, qui relève le défi d'Odin : traverser les autres royaumes, y vaincre leurs figures légendaires, puis affronter Odin lui-même.

Chaque action est un tour, chaque tour coûte de la nourriture. Explorer pour looter et survivre, ou foncer vers la sortie avant la famine : chaque run repart de zéro, et le seul objectif est le meilleur score au leaderboard.

**Inspirations :** *Rogue* (A.I. Design), *Kanji's Adventure* (Motion Twin), *OneBit Adventure* (Galactic Slice).

### Contexte du projet
Travail de fin de formation **Game Designer** chez **Bruxelles Formation – DigitalCity**, encadré par des formateurs du studio de jeu vidéo belge **Team Panoptes**.

Le livrable est double :
- un **Game Design Document** professionnel décrivant le jeu complet ;
- une **vertical slice** jouable : un biome, plusieurs étages générés procéduralement et un boss.

### Avancement
🚧 **En développement** — vertical slice prévue pour **décembre 2026**.

| Version | Contenu |
|---|---|
| Version stable actuelle (`main`) | Aucune pour l'instant : la première version stable sera la vertical slice |
| Prochain jalon | Vertical slice, palier 0 (MVP), décembre 2026 (voir [Roadmap](Documents/FutharksAdventure_RoadMap.md)) |

### Technique et architecture
- **Unity 6.5**, **C#**
- **Règles du jeu en C# pur** (assembly `Core`), indépendantes d'Unity et couvertes par des **tests unitaires EditMode**
- **MonoBehaviours réduits à de la colle**, données dans des **ScriptableObjects**
- Communication logique → affichage **par événements**
- **Point d'entrée unique** : une scène Bootstrap servant de Composition Root
- **Génération procédurale par seed** : une même seed de run régénère les mêmes étages
- Principes **SOLID**, Git flow avec branches `main` / `dev` / feature

### Documentation
| Document | Contenu |
|---|---|
| [Game Design Document](Documents/FutharksAdventure_GDD.md) | Vision complète du jeu : univers, gameplay, items, ennemis, génération, interface, direction artistique, périmètre de la vertical slice |
| [Roadmap](Documents/FutharksAdventure_RoadMap.md) | Plan de développement de la vertical slice, phase par phase |
| [CV](Documents/CORTENLaurent-CV_GameDesigner_Developer_2026.fr.pdf) | CV de l'auteur |

### Lancer le projet
1. Cloner le dépôt.
2. L'ouvrir avec **Unity 6.5**.
3. Ouvrir la scène **Bootstrap** et lancer le Play mode.
4. Tests unitaires : *Window > General > Test Runner > EditMode*.

### Crédits et licence
- Design et code : **Laurent Corten** — [LinkedIn](https://www.linkedin.com/in/laurentcorten/)
- Assets externes : <nom du pack, auteur, licence> *(à compléter)*

© 2026 Laurent Corten. Tous droits réservés.
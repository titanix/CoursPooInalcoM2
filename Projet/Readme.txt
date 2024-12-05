# Projet

L'étudiant doit rendre un projet présentant les caractéristiques présentées plus bas.
Chaque item vaut un certain nombre de points (à définir). Un projet sera donné noté en fonction des objectifs atteints.

Tout le code doit avoir écrit par vous même (l'inspiration et copier-coller depuis le projet Pokedex est autorisée). Toute utilisation de l'IA (ChatGPT, Copilot, etc.) est interdite. Les projets sont individuels et à faire soit-même.

## Fonctionnement général

Sur le modèle du Pokedex vu en cours, le projet consiste à créer un utilitaire en ligne de commande qui permet de manipuler une collection d'objets (ex: livres, monstres, personnages de jeux vidéos, etc.)

Le programme doit tourner en continue jusqu'à ce que l'utilisateur décide de le quitter. Le programme lit sur son entrée standard du texte qui est interprété comme autant de commandes et leurs arguments.

Le programme doit contenir plusieurs commandes non-triviales.

## Livrables attendus

Le projet doit être rendu sous forme de dépot (repository) de code sur la plateforme GitHub.

### Documentation

Le projet doit contenir un fichier Readme.md qui contient la documentation du projet. La documentation doit contenir : une petite introduction sur ce que fait le programme, ainsi que les données utilisées. Vous devez décrire (rapidement) comment vous avez obtenu et prétraiter les données si cela a été fait (pas besoin de joindre le code de pré-traitement).

La documentation doit lister toutes les commandes utilisables dans le programme. Pour chaque commande, les arguments nécessaires et optionnels doivent être spécifié et être accompagné d'une description de leur comportement.

### Spécifications fonctionnelles

Plusieurs commandes doivent être présentes dans le projet, afin de permettre de réaliser des opérations telles que : recherche selon un critère, listing des données présentes, chargement d'un fichier, etc.

Les commandes doivent gérer correctement leurs arguments. Elles doivent également fonctionner même si l'utilisateur fourni des arguments (nombre, contenu, type) erronés.

Chaque commande (hormis celle pour quitter le programme) doit fournir un retour textuel à l'utilisateur sur son effet.

Une commande chacun de chacune des catégories suivantes doit être présentes :
- recherche avec argument
- lecture d'un fichier texte ou csv "à la main"
- écriture d'un fichier texte
- lecture d'un fichier structuré en utilisant un désérialiseur
- écriture d'un fichier structuré en utilisant un sérialiseur
- aide (liste les commandes disponibles)

### Spécifications techniques

Le projet doit :
- compiler (très très important ! n'hésitez pas à cloner votre projet dans un autre répertoire et à tester si `dotnet build` fonctionne)
- se lancer sans exception (même indication qu'avant, `dotnet run` doit pouvoir lancer votre programme)
- bonus : compile sans warnings

Plusieurs notions techniques vues en cours doivent être présentes au moins une fois dans le projet :
- une exception personnalisée
- un bloc qui attrape une exception
- utilisation de Ling: méthode Select ou Where
- un héritage
- une collection (tableau, liste, dictionnaire)
- une enum
- une conversion de type (string vers int par exemple)
- une boucle (foreach ou for)
- un switch
- une propriété en lecture/écriture
- une propriété en lecture seule
- une propriété calculée
- utilisation d'un espace de nom nommé comme le projet
- utilisation d'une API du framework qui nécessite une directive using en haut de fichier
- NE PAS créer de méthode statique
- bonus : utilisation d'une bibliothèque externe (par ex: HtmlAgilityPack)

### Bonnes pratiques logicielles

Le code doit être correctement structuré : 
- utilisation de plusieurs classes
- méthode pas trop longues
- utilisation des marqueurs de visibilité (private, public, etc.)


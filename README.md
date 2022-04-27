# Test technique
Ce test technique va permettre d'évaluer vos compétences en Dotnet 6 ainsi que sur l'écosystème Web Dotnet.
Le C# est le seul language requis pour effectuer ce test. Le temps estimé pour le réaliser est de 2 heures.
(Vous pouvez dépasser ce temps, il n'est pas imparti)

## Contexte
La solution qui vous ait fourni est une API Rest en architecture onion. Cette dernière ne fonctionne pas.
Vous devez modifier la solution pour qu'elle fonctionne.

La stack technique est décrite comme tel:
- L'application est codé avec Dotnet 6 et C# 10.
- Un swagger est intégré pour visualiser les routes.
- L'api est servi par un serveur Kestrel
- L'ORM utilisé est EFCore (Entity Framework Core)
- La base de données est un serveur PostgreSQL
- Le framework de test est Xunit et la librairie de mock est Moq.

## Tâches principales
- Modifier le controller 'ProductController' pour que les tests unitaires associez fonctione.
- Implémenter le 'ProductHandler' et les tests unitaires correspondants.
- Implémenter le 'ProductRepository'.

## Tâches optionelles
- Implémenter les test unitaires pour le 'ProductRepository'.
- Corriger les erreurs et incohérences cachées dans le code ou la solution. (Peut-être abordé en code review)

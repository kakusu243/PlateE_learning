# PlateE_learning
# Projet : Plateforme de formations certifiantes en ligne
# Technologies : Blazor Server, EF Core avec MySQL, hébergement MonsterASP.NET
# Objectif :
# - Enseignants : créer cours, chapitres, évaluations, personnaliser certificats
# - Apprenants : s’inscrire, suivre cours, passer évaluations, recevoir et télécharger certificat PDF
# - Administrateurs : gérer utilisateurs, supprimer cours non autorisés, consulter statistiques
# Modules attendus :
# 1. Gestion des utilisateurs avec rôles (Enseignant, Apprenant, Admin)
# 2. Gestion des cours (CRUD cours, chapitres, évaluations)
# 3. Génération automatique du plan cliquable du cours
# 4. Évaluations (QCM, sondages) avec correction
# 5. Génération et personnalisation des certificats (PDF)
# 6. Tableau de bord administrateur (statistiques)
# Contraintes :
# - Base MySQL avec EF Core
# - Hébergement MonsterASP.NET
# Tâche : Générer l'application  complet puis preparer le deploiement aves test local.

## Instructions de déploiement local

1. Installez MySQL et créez la base de données `platee_learning`.
2. Mettez à jour `appsettings.json` et `appsettings.Development.json` avec votre connexion MySQL :
   `server=localhost;port=3306;database=platee_learning;user=root;password=YourPassword;`
3. Exécutez les commandes :
   - `dotnet restore`
   - `dotnet build`
   - `dotnet run`
4. Ouvrez `https://localhost:5001` (ou l'URL indiquée) pour tester l'application.

## Comptes de démonstration

- Administrateur : `admin@platee.local` / `Admin123!`
- Enseignant : `teacher@platee.local` / `Teacher123!`
- Apprenant : `learner@platee.local` / `Learner123!`

## Préparation MonsterASP.NET

- Assurez-vous que la chaîne de connexion MySQL reflète les paramètres MonsterASP.NET.
- Déployez l'application en mode `Release`.
- Configurez l'environnement pour activer HTTPS et la base MySQL distante.

-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mar. 07 juil. 2026 à 19:13
-- Version du serveur : 10.4.32-MariaDB
-- Version de PHP : 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `platee_learning`
--

-- --------------------------------------------------------

--
-- Structure de la table `answeroptions`
--

CREATE TABLE `answeroptions` (
  `Id` int(11) NOT NULL,
  `Text` longtext NOT NULL,
  `IsCorrect` tinyint(1) NOT NULL,
  `QuestionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `certificates`
--

CREATE TABLE `certificates` (
  `Id` int(11) NOT NULL,
  `RecipientName` longtext NOT NULL,
  `CourseTitle` longtext NOT NULL,
  `IssuedOn` datetime(6) NOT NULL,
  `TemplateData` longtext DEFAULT NULL,
  `PdfPath` longtext NOT NULL,
  `UserId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `chapters`
--

CREATE TABLE `chapters` (
  `Id` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  `Summary` longtext NOT NULL,
  `Content` longtext NOT NULL,
  `Order` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `chapters`
--

INSERT INTO `chapters` (`Id`, `Title`, `Summary`, `Content`, `Order`, `CourseId`) VALUES
(1, 'Bienvenue', 'Vue d\'ensemble du parcours', 'Présentation du cours et des fonctionnalités.', 1, 1),
(2, 'Modules', 'Organisation du contenu', 'Chaque chapitre représente un bloc d\'apprentissage.', 2, 1),
(3, 'Évaluations', 'QCM et sondages', 'Répondez aux questions pour valider votre progression.', 3, 1);

-- --------------------------------------------------------

--
-- Structure de la table `courses`
--

CREATE TABLE `courses` (
  `Id` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `IsPublished` tinyint(1) NOT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `CreatedById` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `courses`
--

INSERT INTO `courses` (`Id`, `Title`, `Description`, `IsPublished`, `CreatedOn`, `CreatedById`) VALUES
(1, 'Découverte de la plateforme PlateE', 'Apprenez à utiliser la plateforme, suivre un cours et générer un certificat.', 1, '2026-07-04 15:47:42.999321', 2);

-- --------------------------------------------------------

--
-- Structure de la table `enrollments`
--

CREATE TABLE `enrollments` (
  `Id` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `EnrolledOn` datetime(6) NOT NULL,
  `IsComplete` tinyint(1) NOT NULL,
  `CertificateIssued` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `evaluations`
--

CREATE TABLE `evaluations` (
  `Id` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  `IsSurvey` tinyint(1) NOT NULL,
  `CourseId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `questions`
--

CREATE TABLE `questions` (
  `Id` int(11) NOT NULL,
  `Text` longtext NOT NULL,
  `IsMultipleChoice` tinyint(1) NOT NULL,
  `EvaluationId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `DisplayName` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `PasswordHash` longtext NOT NULL,
  `Role` longtext NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `CreatedOn` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`Id`, `DisplayName`, `Email`, `PasswordHash`, `Role`, `IsActive`, `CreatedOn`) VALUES
(1, 'Administrator', 'admin@platee.local', 'HbHSpy5W/80XObSsrV01O9ULdzEmvlKqJkqn0Zt2R8u0KqBk//4txL5j1fCqaZYO', 'Admin', 1, '2026-07-04 15:47:42.346451'),
(2, 'Enseignant Demo', 'teacher@platee.local', 'TA/zNt61PKXYzSzpwIAIaNT3zI36D0TgYV7vSR4IpO79I09rHoyaWZC7YmO7hieh', 'Teacher', 1, '2026-07-04 15:47:42.390638'),
(3, 'Apprenant Demo', 'learner@platee.local', 'wceLRa1nKdpA3qlE72Z4mMJO53H4qWfgvmMeN9vXKWLpwrWYS98PMgCh6kNL4eFJ', 'Learner', 1, '2026-07-04 15:47:42.424132');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `answeroptions`
--
ALTER TABLE `answeroptions`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AnswerOptions_QuestionId` (`QuestionId`);

--
-- Index pour la table `certificates`
--
ALTER TABLE `certificates`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Certificates_UserId` (`UserId`);

--
-- Index pour la table `chapters`
--
ALTER TABLE `chapters`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Chapters_CourseId` (`CourseId`);

--
-- Index pour la table `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Courses_CreatedById` (`CreatedById`);

--
-- Index pour la table `enrollments`
--
ALTER TABLE `enrollments`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Enrollments_CourseId` (`CourseId`),
  ADD KEY `IX_Enrollments_UserId` (`UserId`);

--
-- Index pour la table `evaluations`
--
ALTER TABLE `evaluations`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Evaluations_CourseId` (`CourseId`);

--
-- Index pour la table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Questions_EvaluationId` (`EvaluationId`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `answeroptions`
--
ALTER TABLE `answeroptions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `certificates`
--
ALTER TABLE `certificates`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `chapters`
--
ALTER TABLE `chapters`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `courses`
--
ALTER TABLE `courses`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `enrollments`
--
ALTER TABLE `enrollments`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `evaluations`
--
ALTER TABLE `evaluations`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `questions`
--
ALTER TABLE `questions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `answeroptions`
--
ALTER TABLE `answeroptions`
  ADD CONSTRAINT `FK_AnswerOptions_Questions_QuestionId` FOREIGN KEY (`QuestionId`) REFERENCES `questions` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `certificates`
--
ALTER TABLE `certificates`
  ADD CONSTRAINT `FK_Certificates_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `chapters`
--
ALTER TABLE `chapters`
  ADD CONSTRAINT `FK_Chapters_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `courses`
--
ALTER TABLE `courses`
  ADD CONSTRAINT `FK_Courses_Users_CreatedById` FOREIGN KEY (`CreatedById`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `enrollments`
--
ALTER TABLE `enrollments`
  ADD CONSTRAINT `FK_Enrollments_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Enrollments_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `evaluations`
--
ALTER TABLE `evaluations`
  ADD CONSTRAINT `FK_Evaluations_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `FK_Questions_Evaluations_EvaluationId` FOREIGN KEY (`EvaluationId`) REFERENCES `evaluations` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

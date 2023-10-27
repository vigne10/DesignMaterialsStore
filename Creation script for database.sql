-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Généré le : lun. 27 mars 2023 à 19:39
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`id`, `name`, `surname`, `address`, `active`) VALUES
(1, 'LOCONNO', 'JOE', 'Mons', 1),
(2, 'REUS', 'MARCO', 'Dortmund', 1);

-- --------------------------------------------------------

--
-- Structure de la table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE IF NOT EXISTS `invoice` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idWorker` int NOT NULL,
  `idClient` int NOT NULL,
  `date` datetime NOT NULL,
  `price` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `invoice_fk_1` (`idWorker`),
  KEY `invoice_fk_2` (`idClient`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `invoice`
--

INSERT INTO `invoice` (`id`, `idWorker`, `idClient`, `date`, `price`) VALUES
(1, 1, 1, '2023-03-26 00:00:00', 96.88);

-- --------------------------------------------------------

--
-- Structure de la table `invoice_item`
--

DROP TABLE IF EXISTS `invoice_item`;
CREATE TABLE IF NOT EXISTS `invoice_item` (
  `idInvoice` int NOT NULL,
  `idItem` int NOT NULL,
  `quantity` int NOT NULL,
  KEY `invoice_item_fk_1` (`idInvoice`),
  KEY `invoice_item_fk_2` (`idItem`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `invoice_item`
--

INSERT INTO `invoice_item` (`idInvoice`, `idItem`, `quantity`) VALUES
(1, 1, 5),
(1, 2, 7);

-- --------------------------------------------------------

--
-- Structure de la table `item`
--

DROP TABLE IF EXISTS `item`;
CREATE TABLE IF NOT EXISTS `item` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `price` double DEFAULT NULL,
  `active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `item`
--

INSERT INTO `item` (`id`, `name`, `description`, `price`, `active`) VALUES
(1, 'MARTEAU', 'blablabla', 10.99, 1),
(2, 'LOT DE 10 VIS', 'ajdbabdbakl', 5.99, 1),
(3, 'VISEUSSE BOSCH', 'Viseusse de bonne qualité', 69.99, 1),
(4, 'TOURNEVIS AIMANTÉ', 'daughuiduaib', 79.99, 1);

-- --------------------------------------------------------

--
-- Structure de la table `worker`
--

DROP TABLE IF EXISTS `worker`;
CREATE TABLE IF NOT EXISTS `worker` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `login` varchar(255) NOT NULL,
  `password` varbinary(32) NOT NULL,
  `active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `worker`
--

INSERT INTO `worker` (`id`, `name`, `surname`, `address`, `login`, `password`, `active`) VALUES
(1, 'DOE', 'JOHN', 'Mons', 'jdoe', 0x6763be597d6fd0cdea48cee202a8abb3f78242688dab3cd349768c6f9dbd9259, 1);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `invoice`
--
ALTER TABLE `invoice`
  ADD CONSTRAINT `invoice_fk_1` FOREIGN KEY (`idWorker`) REFERENCES `worker` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `invoice_fk_2` FOREIGN KEY (`idClient`) REFERENCES `client` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Contraintes pour la table `invoice_item`
--
ALTER TABLE `invoice_item`
  ADD CONSTRAINT `invoice_item_fk_1` FOREIGN KEY (`idInvoice`) REFERENCES `invoice` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `invoice_item_fk_2` FOREIGN KEY (`idItem`) REFERENCES `item` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

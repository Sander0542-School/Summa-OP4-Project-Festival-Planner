-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 16 mei 2018 om 09:34
-- Serverversie: 10.1.26-MariaDB
-- PHP-versie: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `festival`
--
CREATE DATABASE IF NOT EXISTS `festival` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `festival`;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `bands`
--

DROP TABLE IF EXISTS `bands`;
CREATE TABLE `bands` (
  `id` int(11) NOT NULL,
  `naam` varchar(100) NOT NULL,
  `genre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `bands`
--

INSERT INTO `bands` (`id`, `naam`, `genre`) VALUES
(1, 'Jostiband', 'Hardstyle'),
(2, 'Marco Borsato', 'Nederlands');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `logins`
--

DROP TABLE IF EXISTS `logins`;
CREATE TABLE `logins` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `logins`
--

INSERT INTO `logins` (`id`, `username`, `password`) VALUES
(1, '123', '123');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `podiums`
--

DROP TABLE IF EXISTS `podiums`;
CREATE TABLE `podiums` (
  `id` int(11) NOT NULL,
  `naam` varchar(100) NOT NULL,
  `genres` varchar(1000) NOT NULL,
  `opbouwTijd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `afbouwTijd` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `podiums`
--

INSERT INTO `podiums` (`id`, `naam`, `genres`, `opbouwTijd`, `afbouwTijd`) VALUES
(1, 'Jupiler', 'Hardstyle', '2018-05-09 10:03:41', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `programmas`
--

DROP TABLE IF EXISTS `programmas`;
CREATE TABLE `programmas` (
  `id` int(11) NOT NULL,
  `podiumID` int(11) NOT NULL,
  `aanvangsTijd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `eindTijd` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `programmas`
--

INSERT INTO `programmas` (`id`, `podiumID`, `aanvangsTijd`, `eindTijd`) VALUES
(1, 1, '2018-05-09 10:03:49', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `programma_data`
--

DROP TABLE IF EXISTS `programma_data`;
CREATE TABLE `programma_data` (
  `id` int(11) NOT NULL,
  `programmaID` int(11) NOT NULL,
  `bandID` int(11) NOT NULL,
  `beginTijd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `eindTijd` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `bandPrijs` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `programma_data`
--

INSERT INTO `programma_data` (`id`, `programmaID`, `bandID`, `beginTijd`, `eindTijd`, `bandPrijs`) VALUES
(1, 1, 1, '2018-05-09 10:04:30', '0000-00-00 00:00:00', 100),
(2, 1, 2, '2018-05-09 10:05:09', '0000-00-00 00:00:00', 500);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `bands`
--
ALTER TABLE `bands`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `logins`
--
ALTER TABLE `logins`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `podiums`
--
ALTER TABLE `podiums`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `programmas`
--
ALTER TABLE `programmas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `foreign_programmas_podiums` (`podiumID`);

--
-- Indexen voor tabel `programma_data`
--
ALTER TABLE `programma_data`
  ADD PRIMARY KEY (`id`),
  ADD KEY `foreign_programma_data_programmas` (`programmaID`),
  ADD KEY `foreign_programma_data_bands` (`bandID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `bands`
--
ALTER TABLE `bands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT voor een tabel `logins`
--
ALTER TABLE `logins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT voor een tabel `podiums`
--
ALTER TABLE `podiums`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT voor een tabel `programmas`
--
ALTER TABLE `programmas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT voor een tabel `programma_data`
--
ALTER TABLE `programma_data`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `programmas`
--
ALTER TABLE `programmas`
  ADD CONSTRAINT `foreign_programmas_podiums` FOREIGN KEY (`podiumID`) REFERENCES `podiums` (`id`);

--
-- Beperkingen voor tabel `programma_data`
--
ALTER TABLE `programma_data`
  ADD CONSTRAINT `foreign_programma_data_bands` FOREIGN KEY (`bandID`) REFERENCES `bands` (`id`),
  ADD CONSTRAINT `foreign_programma_data_programmas` FOREIGN KEY (`programmaID`) REFERENCES `programmas` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

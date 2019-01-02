-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Počítač: 127.0.0.1
-- Vytvořeno: Ned 16. pro 2018, 17:41
-- Verze serveru: 10.1.30-MariaDB
-- Verze PHP: 7.2.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `palmgroup`
--
CREATE DATABASE IF NOT EXISTS `palmgroup` DEFAULT CHARACTER SET utf8 COLLATE utf8_czech_ci;
USE `palmgroup`;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbchatmembers`
--

CREATE TABLE `tbchatmembers` (
  `Id` int(11) NOT NULL,
  `IdChat` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbchatrooms`
--

CREATE TABLE `tbchatrooms` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Color` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `ChatRoomPhoto` varchar(300) COLLATE utf8_czech_ci NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbcredentials`
--

CREATE TABLE `tbcredentials` (
  `Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `LoginName` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Password` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `IsTerminated` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbfriends`
--

CREATE TABLE `tbfriends` (
  `Id` int(11) NOT NULL,
  `IdApplicant` int(11) NOT NULL,
  `IdReciever` int(11) NOT NULL,
  `Accepted` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tblogs`
--

CREATE TABLE `tblogs` (
  `Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `ActionType` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `ActionMessage` varchar(400) COLLATE utf8_czech_ci NOT NULL,
  `IpAddress` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `MacAddress` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `DeviceName` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `LogDate` datetime NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbmessages`
--

CREATE TABLE `tbmessages` (
  `Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `IdChatRoom` int(11) NOT NULL,
  `Text` varchar(700) COLLATE utf8_czech_ci NOT NULL,
  `SendTime` datetime NOT NULL,
  `File` varchar(300) COLLATE utf8_czech_ci DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbressetcredentials`
--

CREATE TABLE `tbressetcredentials` (
  `Id` int(11) NOT NULL,
  `IdCredential` int(11) NOT NULL,
  `Code` varchar(250) COLLATE utf8_czech_ci NOT NULL,
  `ExpireDate` datetime NOT NULL,
  `IsDeleted` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbseenmessages`
--

CREATE TABLE `tbseenmessages` (
  `Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `IdMessage` int(11) NOT NULL,
  `SeenTime` datetime NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbtokens`
--

CREATE TABLE `tbtokens` (
  `Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `Token` varchar(500) CHARACTER SET latin2 COLLATE latin2_bin NOT NULL,
  `ValidTo` datetime NOT NULL,
  `DeviceName` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbusers`
--

CREATE TABLE `tbusers` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Surname` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `ProfilePhoto` varchar(300) COLLATE utf8_czech_ci NOT NULL,
  `BornDate` date NOT NULL,
  `Country` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `tbchatmembers`
--
ALTER TABLE `tbchatmembers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_UNIQUE` (`Id`),
  ADD KEY `FK_idx` (`IdUser`),
  ADD KEY `FK_IdChat_ChatMembers_idx` (`IdChat`);

--
-- Klíče pro tabulku `tbchatrooms`
--
ALTER TABLE `tbchatrooms`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_UNIQUE` (`Id`);

--
-- Klíče pro tabulku `tbcredentials`
--
ALTER TABLE `tbcredentials`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_UNIQUE` (`Id`),
  ADD UNIQUE KEY `LoginName_UNIQUE` (`LoginName`),
  ADD KEY `IdUser_idx` (`IdUser`);

--
-- Klíče pro tabulku `tbfriends`
--
ALTER TABLE `tbfriends`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_UNIQUE` (`Id`),
  ADD KEY `FK_IdApplicant_Friends_idx` (`IdApplicant`),
  ADD KEY `FK_IdReciever_Friends_idx` (`IdReciever`);

--
-- Klíče pro tabulku `tblogs`
--
ALTER TABLE `tblogs`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_UNIQUE` (`Id`),
  ADD KEY `FK_IdUser_Logs_idx` (`IdUser`);

--
-- Klíče pro tabulku `tbmessages`
--
ALTER TABLE `tbmessages`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_UNIQUE` (`Id`),
  ADD KEY `FK_idx` (`IdUser`),
  ADD KEY `FK_IdChat_Messages_idx` (`IdChatRoom`);

--
-- Klíče pro tabulku `tbressetcredentials`
--
ALTER TABLE `tbressetcredentials`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_UNIQUE` (`Id`),
  ADD UNIQUE KEY `Code_UNIQUE` (`Code`),
  ADD KEY `FK_idx` (`IdCredential`);

--
-- Klíče pro tabulku `tbseenmessages`
--
ALTER TABLE `tbseenmessages`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_UNIQUE` (`Id`),
  ADD KEY `FK_IdUser_SeenMessages_idx` (`IdUser`),
  ADD KEY `FK_IdMessage_SeenMessages_idx` (`IdMessage`);

--
-- Klíče pro tabulku `tbtokens`
--
ALTER TABLE `tbtokens`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_UNIQUE` (`Id`),
  ADD UNIQUE KEY `Token_UNIQUE` (`Token`),
  ADD KEY `FK__idx` (`IdUser`);

--
-- Klíče pro tabulku `tbusers`
--
ALTER TABLE `tbusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_UNIQUE` (`Id`),
  ADD UNIQUE KEY `email_UNIQUE` (`Email`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `tbchatmembers`
--
ALTER TABLE `tbchatmembers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tbchatrooms`
--
ALTER TABLE `tbchatrooms`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tbcredentials`
--
ALTER TABLE `tbcredentials`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pro tabulku `tbfriends`
--
ALTER TABLE `tbfriends`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tblogs`
--
ALTER TABLE `tblogs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tbmessages`
--
ALTER TABLE `tbmessages`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tbressetcredentials`
--
ALTER TABLE `tbressetcredentials`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tbseenmessages`
--
ALTER TABLE `tbseenmessages`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `tbtokens`
--
ALTER TABLE `tbtokens`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT pro tabulku `tbusers`
--
ALTER TABLE `tbusers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `tbchatmembers`
--
ALTER TABLE `tbchatmembers`
  ADD CONSTRAINT `FK_IdChat_ChatMembers` FOREIGN KEY (`IdChat`) REFERENCES `tbchatrooms` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_IdUser_ChatMembers` FOREIGN KEY (`IdUser`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tbcredentials`
--
ALTER TABLE `tbcredentials`
  ADD CONSTRAINT `FK_IdUser_Credentials` FOREIGN KEY (`IdUser`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tbfriends`
--
ALTER TABLE `tbfriends`
  ADD CONSTRAINT `FK_IdApplicant_Friends` FOREIGN KEY (`IdApplicant`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_IdReciever_Friends` FOREIGN KEY (`IdReciever`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tblogs`
--
ALTER TABLE `tblogs`
  ADD CONSTRAINT `FK_IdUser_Logs` FOREIGN KEY (`IdUser`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tbmessages`
--
ALTER TABLE `tbmessages`
  ADD CONSTRAINT `FK_IdChat_Messages` FOREIGN KEY (`IdChatRoom`) REFERENCES `tbchatrooms` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_IdUser_Messages` FOREIGN KEY (`IdUser`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tbressetcredentials`
--
ALTER TABLE `tbressetcredentials`
  ADD CONSTRAINT `FK_IdCredentials_tbCredentials` FOREIGN KEY (`IdCredential`) REFERENCES `tbcredentials` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tbseenmessages`
--
ALTER TABLE `tbseenmessages`
  ADD CONSTRAINT `FK_IdMessage_SeenMessages` FOREIGN KEY (`IdMessage`) REFERENCES `tbmessages` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_IdUser_SeenMessages` FOREIGN KEY (`IdUser`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Omezení pro tabulku `tbtokens`
--
ALTER TABLE `tbtokens`
  ADD CONSTRAINT `FK_IdUser_Tokens` FOREIGN KEY (`IdUser`) REFERENCES `tbusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

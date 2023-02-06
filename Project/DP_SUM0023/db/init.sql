CREATE DATABASE  IF NOT EXISTS `dp_sum0023` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dp_sum0023`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: dp_sum0023
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20230205231249_Initial','7.0.2');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'TestCompany');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `process`
--

DROP TABLE IF EXISTS `process`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `process` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `ProjectId` int NOT NULL,
  `UserAccountId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_process_ProjectId` (`ProjectId`),
  KEY `IX_process_UserAccountId` (`UserAccountId`),
  CONSTRAINT `FK_process_project_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `project` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_process_useraccount_UserAccountId` FOREIGN KEY (`UserAccountId`) REFERENCES `useraccount` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `process`
--

LOCK TABLES `process` WRITE;
/*!40000 ALTER TABLE `process` DISABLE KEYS */;
INSERT INTO `process` VALUES (1,'TestProcess',1,NULL);
/*!40000 ALTER TABLE `process` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `processevaluation`
--

DROP TABLE IF EXISTS `processevaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `processevaluation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DatePerformed` datetime(6) NOT NULL,
  `ProcessId` int NOT NULL,
  `EvaluatorAccountId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_processevaluation_EvaluatorAccountId` (`EvaluatorAccountId`),
  KEY `IX_processevaluation_ProcessId` (`ProcessId`),
  CONSTRAINT `FK_processevaluation_process_ProcessId` FOREIGN KEY (`ProcessId`) REFERENCES `process` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_processevaluation_useraccount_EvaluatorAccountId` FOREIGN KEY (`EvaluatorAccountId`) REFERENCES `useraccount` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `processevaluation`
--

LOCK TABLES `processevaluation` WRITE;
/*!40000 ALTER TABLE `processevaluation` DISABLE KEYS */;
/*!40000 ALTER TABLE `processevaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `CompanyId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_project_CompanyId` (`CompanyId`),
  CONSTRAINT `FK_project_company_CompanyId` FOREIGN KEY (`CompanyId`) REFERENCES `company` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES (1,'TestProject',1);
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccount`
--

DROP TABLE IF EXISTS `useraccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccount` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_useraccount_RoleId` (`RoleId`),
  CONSTRAINT `FK_useraccount_useraccountrole_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `useraccountrole` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccount`
--

LOCK TABLES `useraccount` WRITE;
/*!40000 ALTER TABLE `useraccount` DISABLE KEYS */;
INSERT INTO `useraccount` VALUES (1,3);
/*!40000 ALTER TABLE `useraccount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccountlogin`
--

DROP TABLE IF EXISTS `useraccountlogin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccountlogin` (
  `Username` varchar(255) NOT NULL,
  `PasswordHash` longtext NOT NULL,
  `PasswordSalt` longtext NOT NULL,
  `AccountId` int NOT NULL,
  PRIMARY KEY (`Username`),
  KEY `IX_useraccountlogin_AccountId` (`AccountId`),
  CONSTRAINT `FK_useraccountlogin_useraccount_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `useraccount` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccountlogin`
--

LOCK TABLES `useraccountlogin` WRITE;
/*!40000 ALTER TABLE `useraccountlogin` DISABLE KEYS */;
INSERT INTO `useraccountlogin` VALUES ('admin','hlzG74T45PbgT7Vk8qOoAbi6+x/oRfiXgiEVyuUS9sM=','yRXS4T5bzfVJrJ20v/SSNg==',1);
/*!40000 ALTER TABLE `useraccountlogin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccountrole`
--

DROP TABLE IF EXISTS `useraccountrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccountrole` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccountrole`
--

LOCK TABLES `useraccountrole` WRITE;
/*!40000 ALTER TABLE `useraccountrole` DISABLE KEYS */;
INSERT INTO `useraccountrole` VALUES (1,'User'),(2,'Editor'),(3,'Admin');
/*!40000 ALTER TABLE `useraccountrole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dp_sum0023'
--

--
-- Dumping routines for database 'dp_sum0023'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-06  0:15:23

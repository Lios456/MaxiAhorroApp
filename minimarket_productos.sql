-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: minimarket
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `descripcion` text,
  `categoria` varchar(100) DEFAULT NULL,
  `precio` decimal(10,2) NOT NULL,
  `cantidad` int NOT NULL,
  `fecha_ingreso` date DEFAULT NULL,
  `proveedor` varchar(255) DEFAULT NULL,
  `codigo_barra` varchar(255) DEFAULT NULL,
  `fecha_vencimiento` date DEFAULT NULL,
  `marca` varchar(100) DEFAULT NULL,
  `ubicacion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo_barra` (`codigo_barra`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'Leche Entera','Leche de vaca pasteurizada','7',1.20,100,'2024-06-23','Proveedor A','1234567890123','2024-12-18','Marca A','Pasillo 1'),(2,'Pan Integral','Pan integral sin azúcar','1',1.50,50,'2024-06-23','Proveedor B','1234567890124','2024-07-18','Marca B','Pasillo 2'),(3,'Jugo de Naranja','Jugo natural sin conservantes','5',1.00,1000,'2024-06-23','Proveedor A','1234567890125','2024-09-18','Marca C','Pasillo 3'),(4,'Pera','Pera Ecuatoriana','1',0.50,50,'2024-06-23','Proveedor A','1234567898541','2024-08-18','No','Pasillo 2'),(7,'Manzanas','Manzana Ecuatoriana','1',1.00,500,'2024-06-23','Proveedor A','Manz21-','2024-07-21','Nacional','Piso 1'),(8,'Jugo','Jugo de Manzana','2',1.00,1000,'2024-06-23','Proveedor B','JUGMAN','2024-09-29','TANG','Piso 5'),(11,'Leche','Leche Chocolatada','7',0.75,150,'2024-06-23','Proveedor A','LECHECHOC','2024-10-25','Tony','Piso 3'),(12,'Aceite','Aceite Vegetal 1 litro','9',3.00,1000,'2024-06-23','Proveedor A','ACEIGIRA1LT','2025-08-08','El Cocinero','Piso 2');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-07-03 16:46:17

create database if not exists minimarket;
use minimarket;
CREATE TABLE if not exists minimarket.categorias(
id int auto_increment primary key,
nombre varchar(100) not null
);
INSERT INTO `categorias` VALUES 
(1,'Alimentos'),
(2,'Bebidas'),
(3,'Aseo y Limpieza'),
(4,'Higiene Personal'),
(5,'Snacks y Dulces'),
(6,'Congelados'),
(7,'Lácteos y Derivados'),
(8,'Básicos'),
(9,'Productos de Cocina'),
(10,'Bebidas Calientes'),
(11,'Cuidado Personal');

-- Crear la tabla productos
CREATE TABLE IF NOT EXISTS productos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    descripcion TEXT,
    categoria VARCHAR(100),
    precio DECIMAL(10, 2) NOT NULL,
    cantidad INT NOT NULL,
    fecha_ingreso DATE,
    proveedor VARCHAR(255),
    codigo_barra VARCHAR(255) UNIQUE,
    fecha_vencimiento DATE,
    marca VARCHAR(100),
    ubicacion VARCHAR(100)
);

INSERT INTO `productos` VALUES 
(1,'Leche Entera','Leche de vaca pasteurizada','7',1.20,100,'2024-06-23','Proveedor A','1234567890123','2024-12-18','Marca A','Pasillo 1'),
(2,'Pan Integral','Pan integral sin azúcar','1',1.50,50,'2024-06-23','Proveedor B','1234567890124','2024-07-18','Marca B','Pasillo 2'),
(3,'Jugo de Naranja','Jugo natural sin conservantes','5',1.00,1000,'2024-06-23','Proveedor A','1234567890125','2024-09-18','Marca C','Pasillo 3'),
(4,'Pera','Pera Ecuatoriana','1',0.50,50,'2024-06-23','Proveedor A','1234567898541','2024-08-18','No','Pasillo 2'),
(7,'Manzanas','Manzana Ecuatoriana','1',1.00,500,'2024-06-23','Proveedor A','Manz21-','2024-07-21','Nacional','Piso 1'),
(8,'Jugo','Jugo de Manzana','2',1.00,1000,'2024-06-23','Proveedor B','JUGMAN','2024-09-29','TANG','Piso 5'),
(11,'Leche','Leche Chocolatada','7',0.75,150,'2024-06-23','Proveedor A','LECHECHOC','2024-10-25','Tony','Piso 3'),
(12,'Aceite','Aceite Vegetal 1 litro','9',3.00,1000,'2024-06-23','Proveedor A','ACEIGIRA1LT','2025-08-08','El Cocinero','Piso 2');


delimiter //
create procedure sp_total_productos_por_categoria() 
begin
SELECT c.nombre, sum(cantidad) FROM productos p inner join
categorias c on p.categoria = c.id group by categoria;
end //
delimiter ;

CREATE TABLE if not exists Cajeros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    dni VARCHAR(20) UNIQUE NOT NULL,
    direccion VARCHAR(255),
    telefono VARCHAR(15),
    email VARCHAR(100) UNIQUE,
    fecha_nacimiento DATE,
    fecha_contratacion DATE,
    turno ENUM('Mañana', 'Tarde', 'Noche') NOT NULL,
    salario DECIMAL(10, 2),
    supervisor_id INT,
    numero_caja INT NOT NULL,
    estado ENUM('Activo', 'Inactivo', 'Suspendido') DEFAULT 'Activo',
    comentarios TEXT,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
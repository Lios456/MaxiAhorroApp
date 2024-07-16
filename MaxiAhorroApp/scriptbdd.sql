CREATE DATABASE IF NOT EXISTS minimarket;
USE minimarket;

CREATE TABLE IF NOT EXISTS minimarket.categorias (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

INSERT IGNORE INTO minimarket.categorias (id, nombre) VALUES 
(1, 'Alimentos'),
(2, 'Bebidas'),
(3, 'Aseo y Limpieza'),
(4, 'Higiene Personal'),
(5, 'Snacks y Dulces'),
(6, 'Congelados'),
(7, 'Lácteos y Derivados'),
(8, 'Básicos'),
(9, 'Productos de Cocina'),
(10, 'Bebidas Calientes'),
(11, 'Cuidado Personal');

CREATE TABLE IF NOT EXISTS minimarket.proveedores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL
);

INSERT IGNORE INTO minimarket.proveedores (id, nombre) VALUES 
(1, 'Proveedor A'),
(2, 'Proveedor B');

CREATE TABLE IF NOT EXISTS minimarket.ubicaciones (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

INSERT IGNORE INTO minimarket.ubicaciones (id, nombre) VALUES 
(1, 'Pasillo 1'),
(2, 'Pasillo 2'),
(3, 'Pasillo 3'),
(4, 'Piso 1'),
(5, 'Piso 2'),
(6, 'Piso 3'),
(7, 'Piso 5');

CREATE TABLE IF NOT EXISTS minimarket.marcas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

INSERT IGNORE INTO minimarket.marcas (id, nombre) VALUES 
(1, 'Marca A'),
(2, 'Marca B'),
(3, 'Marca C'),
(4, 'No'),
(5, 'Nacional'),
(6, 'TANG'),
(7, 'Tony'),
(8, 'El Cocinero');

CREATE TABLE IF NOT EXISTS minimarket.productos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    descripcion TEXT,
    categoria_id INT,
    precio DECIMAL(10, 2) NOT NULL,
    cantidad INT NOT NULL,
    fecha_ingreso DATE,
    proveedor_id INT,
    codigo_barra VARCHAR(255) UNIQUE,
    fecha_vencimiento DATE,
    marca_id INT,
    ubicacion_id INT,
    estado VARCHAR(50) DEFAULT 'Activo',
    FOREIGN KEY (categoria_id) REFERENCES categorias(id),
    FOREIGN KEY (proveedor_id) REFERENCES proveedores(id),
    FOREIGN KEY (marca_id) REFERENCES marcas(id),
    FOREIGN KEY (ubicacion_id) REFERENCES ubicaciones(id)
);



INSERT IGNORE INTO minimarket.productos (id, nombre, descripcion, categoria_id, precio, cantidad, fecha_ingreso, proveedor_id, codigo_barra, fecha_vencimiento, marca_id, ubicacion_id) VALUES 
(1, 'Leche Entera', 'Leche de vaca pasteurizada', 7, 1.20, 100, '2024-06-23', 1, '1234567890123', '2024-12-18', 1, 1),
(2, 'Pan Integral', 'Pan integral sin azúcar', 1, 1.50, 50, '2024-06-23', 2, '1234567890124', '2024-07-18', 2, 2),
(3, 'Jugo de Naranja', 'Jugo natural sin conservantes', 2, 1.00, 1000, '2024-06-23', 1, '1234567890125', '2024-09-18', 3, 3),
(4, 'Pera', 'Pera Ecuatoriana', 1, 0.50, 50, '2024-06-23', 1, '1234567898541', '2024-08-18', 4, 2),
(5, 'Manzanas', 'Manzana Ecuatoriana', 1, 1.00, 500, '2024-06-23', 1, 'Manz21-', '2024-07-21', 5, 4),
(6, 'Jugo', 'Jugo de Manzana', 2, 1.00, 1000, '2024-06-23', 2, 'JUGMAN', '2024-09-29', 6, 7),
(7, 'Leche', 'Leche Chocolatada', 7, 0.75, 150, '2024-06-23', 1, 'LECHECHOC', '2024-10-25', 7, 6),
(8, 'Aceite', 'Aceite Vegetal 1 litro', 9, 3.00, 1000, '2024-06-23', 1, 'ACEIGIRA1LT', '2025-08-08', 8, 5);

CREATE TABLE IF NOT EXISTS minimarket.usuarios (
    IDUsuario INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
    Rol ENUM('Cajero', 'Administrador') NOT NULL
);

CREATE TABLE IF NOT EXISTS minimarket.empleados (
    IDEmpleado INT AUTO_INCREMENT PRIMARY KEY,
    IDUsuario INT,
    FechaContratacion DATE NOT NULL,
    Puesto ENUM('Cajero', 'Administrador') NOT NULL,
    Salario DECIMAL(10, 2) NOT NULL,
    Estado ENUM('Activo', 'Inactivo') NOT NULL,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
);

CREATE TABLE IF NOT EXISTS `administradores` (
  `IDAdministrador` int NOT NULL AUTO_INCREMENT,
  `IDEmpleado` int NOT NULL,
  `NivelAcceso` int DEFAULT NULL,
  PRIMARY KEY (`IDAdministrador`,`IDEmpleado`),
  UNIQUE KEY `IDEmpleado_UNIQUE` (`IDEmpleado`),
  CONSTRAINT `administradores_chk_1` CHECK ((`NivelAcceso` between 1 and 3))
);

DROP PROCEDURE IF EXISTS sp_total_productos_por_categoria;
CREATE PROCEDURE sp_total_productos_por_categoria()
BEGIN
    SELECT c.nombre, SUM(p.cantidad) 
    FROM productos p 
    INNER JOIN categorias c ON p.categoria_id = c.id 
    GROUP BY p.categoria_id;
END;

DROP TRIGGER IF EXISTS encriptar_contrasenia_usuario;

CREATE TRIGGER encriptar_contrasenia_usuario
BEFORE INSERT ON minimarket.usuarios 
FOR EACH ROW
begin
 SET NEW.Contraseña = MD5(NEW.Contraseña);
end;

Drop TRIGGER IF EXISTS verificar_fecha_contratacion;
CREATE TRIGGER verificar_fecha_contratacion 
BEFORE INSERT ON minimarket.empleados
FOR EACH ROW
BEGIN
IF New.FechaContratacion> date(now()) THEN
SIGNAL SQLSTATE '45000' SET 
MESSAGE_TEXT = 'Fecha no válida';
END IF; 
END;

DROP TRIGGER IF EXISTS verificar_empleado_repetido;
CREATE TRIGGER verificar_empleado_repetido 
BEFORE INSERT
ON minimarket.empleados
FOR EACH ROW
BEGIN
IF (SELECT COUNT(*) FROM minimarket.empleados WHERE IDUsuario = new.IDUsuario) > 0 THEN
	SIGNAL SQLSTATE '45000' SET 
	MESSAGE_TEXT = 'Empleado ya registrado';
END IF;
END;

DROP TRIGGER IF EXISTS verificar_usuario_repetido;
CREATE TRIGGER verificar_usuario_repetido
BEFORE INSERT 
ON minimarket.usuarios
FOR EACH ROW 
BEGIN
	IF(SELECT COUNT(*) FROM minimarket.usuarios 
    WHERE 
    Nombre = new.Nombre AND 
    Apellido = new.Apellido AND
    Rol = new.Rol) > 0 THEN
    SIGNAL SQLSTATE '45000' SET 
	MESSAGE_TEXT = 'Usuario ya registrado';
    END IF;
END;

DROP TRIGGER IF EXISTS Validar_actualizacion_empleado;

CREATE TRIGGER Validar_actualizacion_empleado
BEFORE UPDATE 
ON minimarket.empleados
FOR EACH ROW 
BEGIN
    DECLARE Mensaje TEXT;
    IF DATEDIFF(NEW.FechaContratacion, OLD.FechaContratacion) < 0 THEN
        SET Mensaje = 'Fecha de Contrato no válida';
    END IF;

    IF NEW.Salario < OLD.Salario OR NEW.Salario < 0 THEN
        IF Mensaje IS NULL THEN
            SET Mensaje = 'Salario no válido';
        ELSE
            SET Mensaje = CONCAT(Mensaje, '\nSalario no válido');
        END IF;
    END IF;

    IF Mensaje IS NOT NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = Mensaje;
    END IF;
END;

DROP TRIGGER IF EXISTS Encriptar_contrasenia_actualizar_usuario;
CREATE TRIGGER Encriptar_contrasenia_actualizar_usuario
BEFORE UPDATE ON minimarket.usuarios
FOR EACH ROW
BEGIN
IF new.Contraseña <> '' THEN
    IF new.Contraseña <> old.Contraseña THEN
	    SET new.Contraseña = MD5(new.Contraseña);
    END IF;
ELSE 
	SET new.Contraseña = old.Contraseña;
END IF;
END;

DROP TRIGGER IF EXISTS Poner_en_Mayusculas_Nombres_Insert;

create trigger Poner_en_Mayusculas_Nombres_Insert
BEFORE INSERT ON minimarket.usuarios
for each row
BEGIN
	set new.Nombre = upper(new.Nombre);
    set new.Apellido = upper(new.Apellido);
END;

DROP TRIGGER IF EXISTS Poner_en_Mayusculas_Nombres_Update;

create trigger Poner_en_Mayusculas_Nombres_Update
BEFORE UPDATE ON minimarket.usuarios
for each row
BEGIN
	set new.Nombre = upper(new.Nombre);
    set new.Apellido = upper(new.Apellido);
END;


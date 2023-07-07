CREATE DATABASE clientesDB;

USE clientesDB;

CREATE TABLE clientes (
	codCliente INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombreCliente VARCHAR(50) NOT NULL,
	telefonoCliente INT NOT NULL,
	duiCliente INT NOT NULL,
	correoCliente VARCHAR (100) NOT NULL
);

CREATE TABLE historicoEdiciones(
	codHistEdit INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	codCliente INT NOT NULL,
	fechaEdicion DATETIME NOT NULL
);

--ALTER TABLE historicoEdiciones ADD FOREIGN KEY (codCliente) REFERENCES clientes (codCliente);
ALTER TABLE historicoEdiciones ADD CONSTRAINT fk_clientesHist FOREIGN KEY (codCliente) REFERENCES clientes (codCliente);

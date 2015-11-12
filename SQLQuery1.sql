CREATE TABLE dbo.cliente
(
    ci int NOT NULL,
    nombre varchar(25) NULL,
    apellidoPaterno varchar(25) NULL,
    apellidoMaterno varchar(25) NULL,
    domicilio varchar(25) NULL,
    zona varchar(25) NULL,
	email varchar(25) NULL,
	telefonoCasa varchar(15) NULL,
	telefonoOficina varchar(15) NULL,
	fechaNacimiento date NULL,
    PRIMARY KEY (ci)
);

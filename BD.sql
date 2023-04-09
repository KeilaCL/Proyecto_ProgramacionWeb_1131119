CREATE TABLE [Paciente] (
	IdPaciente integer IDENTITY (1,1) NOT NULL,
	IdPersona integer NOT NULL,
	Peso decimal NOT NULL,
	Estatura decimal NOT NULL,
  CONSTRAINT [PK_PACIENTE] PRIMARY KEY CLUSTERED
  (
  [IdPaciente] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Personal] (
	IdPersonal integer IDENTITY (1,1) NOT NULL,
	IdPersona integer NOT NULL,
	Fecha_Ingreso date NOT NULL,
	Salario decimal NOT NULL,
  CONSTRAINT [PK_PERSONAL] PRIMARY KEY CLUSTERED
  (
  [IdPersonal] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Mantenimiento] (
	IdMantenimiento integer IDENTITY (1,1) NOT NULL,
	IdPersonal integer NOT NULL,
	FechaInicio date NOT NULL,
	FechaFinal date NOT NULL,
	DescripcionTarea varchar(80) NOT NULL,
  CONSTRAINT [PK_MANTENIMIENTO] PRIMARY KEY CLUSTERED
  (
  [IdMantenimiento] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Doctor] (
	IdDoctor integer IDENTITY (1,1) NOT NULL,
	IdPersonal integer NOT NULL,
	Especialidad varchar(50) NOT NULL,
	NoColegiado varchar(50) NOT NULL,
  CONSTRAINT [PK_DOCTOR] PRIMARY KEY CLUSTERED
  (
  [IdDoctor] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [AtencionCliente] (
	IdAtencionCliente integer IDENTITY (1,1) NOT NULL,
	IdPersonal integer NOT NULL,
	DescripcionServicio varchar(255) NOT NULL,
  CONSTRAINT [PK_ATENCIONCLIENTE] PRIMARY KEY CLUSTERED
  (
  [IdAtencionCliente] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Persona] (
	IdPersona integer IDENTITY (1,1) NOT NULL,
	DPI varchar(13) NOT NULL,
	Nombre varchar(30) NOT NULL,
	Apellido varchar(30) NOT NULL,
	FechaNacimiento date NOT NULL,
	Telefono varchar(15) NOT NULL,
	Correo varchar(50) NOT NULL,
	Direccion varchar(100) NOT NULL,
	Sexo varchar(10) NOT NULL,
  CONSTRAINT [PK_PERSONA] PRIMARY KEY CLUSTERED
  (
  [IdPersona] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [CitaMedica] (
	IdCita integer IDENTITY (1,1) NOT NULL,
	IdDoctor integer NOT NULL,
	IdPaciente integer NOT NULL,
	FechaCita date NOT NULL,
	HoraCita time NOT NULL,
	Observaciones varchar(255) NOT NULL,
  CONSTRAINT [PK_CITAMEDICA] PRIMARY KEY CLUSTERED
  (
  [IdCita] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [RecetaMedica] (
	IdRecetaMedica integer IDENTITY (1,1) NOT NULL,
	IdDoctor integer NOT NULL,
	FechaEmision date NOT NULL,
	DescripcionTratamiento varchar(255) NOT NULL
)
GO
CREATE TABLE [Usuario] (
	IdUsuario integer IDENTITY (1,1) NOT NULL,
	IdPersona integer NOT NULL,
	NombreUsuario varchar(50) NOT NULL,
	Contraseña varchar(50) NOT NULL,
  CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED
  (
  [IdUsuario] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Medicamentos] (
	IdMedicamento integer IDENTITY (1,1) NOT NULL,
	IdRecetaMedica integer NOT NULL,
	NombreMedicamento varchar(60) NOT NULL,
	Dosis varchar(60) NOT NULL,
  CONSTRAINT [PK_MEDICAMENTOS] PRIMARY KEY CLUSTERED
  (
  [IdMedicamento] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [Paciente] WITH CHECK ADD CONSTRAINT [Paciente_fk0] FOREIGN KEY ([IdPersona]) REFERENCES [Persona]([IdPersona])
ON UPDATE CASCADE
GO
ALTER TABLE [Paciente] CHECK CONSTRAINT [Paciente_fk0]
GO

ALTER TABLE [Personal] WITH CHECK ADD CONSTRAINT [Personal_fk0] FOREIGN KEY ([IdPersona]) REFERENCES [Persona]([IdPersona])
ON UPDATE CASCADE
GO
ALTER TABLE [Personal] CHECK CONSTRAINT [Personal_fk0]
GO

ALTER TABLE [Mantenimiento] WITH CHECK ADD CONSTRAINT [Mantenimiento_fk0] FOREIGN KEY ([IdPersonal]) REFERENCES [Personal]([IdPersonal])
ON UPDATE CASCADE
GO
ALTER TABLE [Mantenimiento] CHECK CONSTRAINT [Mantenimiento_fk0]
GO

ALTER TABLE [Doctor] WITH CHECK ADD CONSTRAINT [Doctor_fk0] FOREIGN KEY ([IdPersonal]) REFERENCES [Personal]([IdPersonal])
ON UPDATE CASCADE
GO
ALTER TABLE [Doctor] CHECK CONSTRAINT [Doctor_fk0]
GO

ALTER TABLE [AtencionCliente] WITH CHECK ADD CONSTRAINT [AtencionCliente_fk0] FOREIGN KEY ([IdPersonal]) REFERENCES [Personal]([IdPersonal])
ON UPDATE CASCADE
GO
ALTER TABLE [AtencionCliente] CHECK CONSTRAINT [AtencionCliente_fk0]
GO


ALTER TABLE [CitaMedica] WITH CHECK ADD CONSTRAINT [CitaMedica_fk0] FOREIGN KEY ([IdDoctor]) REFERENCES [Doctor]([IdDoctor])
ON UPDATE CASCADE
GO
ALTER TABLE [CitaMedica] CHECK CONSTRAINT [CitaMedica_fk0]
GO
ALTER TABLE [CitaMedica] WITH CHECK ADD CONSTRAINT [CitaMedica_fk1] FOREIGN KEY ([IdPaciente]) REFERENCES [Paciente]([IdPaciente])
ON UPDATE CASCADE
GO
ALTER TABLE [CitaMedica] CHECK CONSTRAINT [CitaMedica_fk1]
GO

ALTER TABLE [RecetaMedica] WITH CHECK ADD CONSTRAINT [RecetaMedica_fk0] FOREIGN KEY ([IdDoctor]) REFERENCES [Doctor]([IdDoctor])
ON UPDATE CASCADE
GO
ALTER TABLE [RecetaMedica] CHECK CONSTRAINT [RecetaMedica_fk0]
GO
ALTER TABLE [RecetaMedica] WITH CHECK ADD CONSTRAINT [RecetaMedica_fk1] FOREIGN KEY ([FechaEmision]) REFERENCES [Doctor]([IdDoctor])
ON UPDATE CASCADE
GO
ALTER TABLE [RecetaMedica] CHECK CONSTRAINT [RecetaMedica_fk1]
GO

ALTER TABLE [Usuario] WITH CHECK ADD CONSTRAINT [Usuario_fk0] FOREIGN KEY ([IdPersona]) REFERENCES [Persona]([IdPersona])
ON UPDATE CASCADE
GO
ALTER TABLE [Usuario] CHECK CONSTRAINT [Usuario_fk0]
GO

ALTER TABLE [Medicamentos] WITH CHECK ADD CONSTRAINT [Medicamentos_fk0] FOREIGN KEY ([IdRecetaMedica]) REFERENCES [RecetaMedica]([IdRecetaMedica])
ON UPDATE CASCADE
GO
ALTER TABLE [Medicamentos] CHECK CONSTRAINT [Medicamentos_fk0]
GO


Create database Proy_Biblioteca 
go
Use Proy_Biblioteca 
go
Create table Autores
(Id_Autor integer primary key,
Nombre_Autor varchar(50)
);



Create table Lectores
(Num_Targeta varchar(4) primary key,
Nombre_Lector varchar(50),
Direccion_Lector varchar(100),
Telefono_Lector varchar(10),
Foto image
);

Create table Editoriales
(Cod_Ed integer  primary key,
Nombre_Ed varchar(50) not null,
Pais_Ed varchar(50),
Telefono_Ed varchar(10) not null,
);

Create table Libros
(Id_Libro integer primary key,
Titulo varchar(50) not null,
Cod_Ed integer not null,
constraint fk_Libros_Editoriales foreign key(Cod_Ed)
references Editoriales(Cod_Ed) on update cascade on delete no action,
);

Create table Prestamos
(Id_Prestamos integer primary key,
Id_Libro integer not null,
Num_Targeta varchar(4) not null,
Fecha_Salida varchar(10),
Fecha_Devol varchar(10),
constraint fk_Prestamos_Libros foreign key(Id_Libro)
references Libros(Id_Libro) on update cascade on delete no action,
constraint fk_Prestamos_Lectores foreign key(Num_Targeta)
references  Lectores(Num_Targeta) on update cascade on delete no action,
);

Create table Autores_Libros
(Id_Libro integer not null,
Id_Autor integer not null,
constraint fk_AutoresLibros_Libros foreign key(Id_Libro)
references Libros(Id_Libro) on update cascade on delete no action,
Constraint fk_AutoresLibros_Autores foreign key(Id_Autor)
references Autores(Id_Autor) on update cascade on delete no action,
);

Create table Copias_Libros
(Id_Libro integer not null,
Num_Copias integer not null,
constraint fk_CopiasLibros_Libros foreign key(Id_Libro)
references Libros(Id_Libro) on update cascade on delete no action,

);

SELECT lb.Id_Libro, Titulo,Nombre_Autor as [Autor] ,Nombre_Ed as [Editorial], Num_Copias FROM Autores_Libros as al INNER JOIN Autores as a ON a.Id_Autor=al.Id_Autor inner join Libros as lb on lb.Id_Libro=al.Id_Libro  inner join Copias_libros as cp on cp.Id_Libro=lb.Id_Libro INNER JOIN Editoriales as ed ON lb.Cod_Ed = ed.Cod_Ed 

  select * from autores
 insert into Autores values (0164,'Claudia')
select * from Libros;





 SELECT Id_Prestamos,Nombre_Lector as [Lector ],Titulo,Fecha_salida as [Fecha de Prestamo],Fecha_Devol as [Fecha de Devolucion] from Prestamos as p inner join Libros  as  l on p.Id_Libro =l.Id_Libro
 inner join Lectores as lc on lc.Num_Targeta=p.Num_Targeta



CREATE PROCEDURE Prestamos_persona
@nombre varchar(50)
 as
 begin
 SELECT Id_Prestamos,Nombre_Lector as [Lector ],Titulo,Fecha_salida as [Fecha de Prestamo],Fecha_Devol as [Fecha de Devolucion] 
 from Prestamos as p 
 inner join Libros  as  l on p.Id_Libro =l.Id_Libro 
 inner join Lectores as lc on lc.Num_Targeta=p.Num_Targeta and Nombre_Lector like '%'+@nombre+'%' 
 end

 exec Prestamos_persona 'v'

 CREATE PROCEDURE Detalle_Prestamos
 AS
 BEGIN
  SELECT Id_Prestamos,Nombre_Lector as [Lector ],Titulo,Fecha_salida as [Fecha de Prestamo],Fecha_Devol as [Fecha de Devolucion] 
 from Prestamos as p 
 inner join Libros  as  l on p.Id_Libro =l.Id_Libro 
 inner join Lectores as lc on lc.Num_Targeta=p.Num_Targeta
 END


 create table Usuarios(
 usuario varchar(50),
 contraseñe varchar(8)
 )
 
 insert into usuarios values('Admin','1234');
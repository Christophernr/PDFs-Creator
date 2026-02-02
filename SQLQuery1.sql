create database Base_PDFs
go

create table Persona(
id int identity(1,1) primary key,
nombre nvarchar(50),
apellido nvarchar (50),
fechaIngreso date,
fechaSalida date null,
telefono nvarchar (20),
direccion nvarchar (50),
tipo bit
)
go
--drop table Persona


create table Estudiante (
idEstudiante int identity (1,1) primary key,
idPersona int, --foreign
SeccionId int, --foreign 
nivel bit
)
go

--drop table Estudiante

create table Trabajador (
idTrabajador int identity (1,1) primary key,
idPersona int , --foreign,
Puesto nvarchar (50),
departamentoId int --foreign
)
go

--drop table Trabajador

create table Seccion (
idSeccion int identity (1,1) primary key,
seccion nvarchar (10)
)
go
--drop table Seccion
create table Departamento(
idDepartamento int identity (1,1) primary key,
departamento nvarchar (10)
)
go

create table Institucion (
idInstitucion int identity (1,1) primary key,
nombre nvarchar (50),
tipo bit , -- colegio o empresa
direccion nvarchar (50),
telefono nvarchar (50)
)
go

create table Colegio(
idColegio int identity (1,1) primary key,
nombre nvarchar(50),
idInstitucion int
)
go

create table Empresa(
idEmpresa int identity (1,1) primary key,
nombre nvarchar (50),
idInstitucion int
)
go

alter table Colegio
add constraint FK_Colegio_Institucion
foreign key (idInstitucion)
references Institucion(idInstitucion)
go


alter table Empresa
add constraint FK_Empresa_Institucion
foreign key (idInstitucion)
references Institucion(idInstitucion)
go

create table RelacionPersonaInstitucion(
idPersonaInstitucion int identity (1,1) primary key,
personaId int, --foreign 
institucionId int, -- foreign
fechaIngreso date,
estado bit, --activo o inactivo
)
go

--drop table RelacionPersonaInstitucion
create table Reporte(
idReporte int identity (1,1) primary key,
tipoDocumento bit, -- nacional o extranjero
titulo nvarchar (20),
motivo nvarchar (50),
fechaEmision date ,
estado bit , -- proceso o finalizado
personaId int , -- foreign 
institucionId int , --foreign
aprobadoPor nvarchar (50)
)
go

--drop table Reporte


--alter de las tablas 

-- persona a estudiante

alter table Estudiante
add constraint  FK_Estudiante_Persona
foreign key (idPersona)
references Persona(id)
go

--persona a trabajador

alter table Trabajador
add constraint FK_Trabajador_Persona
foreign key (idPersona)
references Persona(id)
go

-- personainstitucion a persona

alter table RelacionPersonaInstitucion
add constraint FK_RelacionPersonaInstitucion_Persona
foreign key  (idPersonaInstitucion)
references Persona(id)
go

-- personaInstitucion a institucion

alter table RelacionPersonaInstitucion
add constraint FK_RelacionPersonaInstitucion_Institucion
foreign key (institucionId)
references Institucion(idInstitucion)
go

-- reporte a persona 

alter table Reporte
add constraint FK_Reporte_Persona
foreign key (personaId)
references Persona(id)
go

--reporte a institucion

alter table Reporte
add constraint FK_Reporte_Institucion
foreign key (institucionId)
references Institucion(idInstitucion)
go


-- seccion a estudiante
alter table Estudiante
add constraint FK_Seccion_Estudiante
foreign key (SeccionId)
references Seccion(idSeccion)
go



-- queries


-- queries de estudiantes
create procedure sp_BuscarEstudiante
@idEstudiante int
as
begin 
select * from Estudiante where idEstudiante = @idEstudiante
end 
go

create procedure sp_BuscarEstudiante_IdPersona
@idPersona int
as
begin
select * from Estudiante where idPersona = @idPersona
end
go

--queries de persona

create procedure sp_BuscarPersonaId
@idPersona int
as
begin
select * from Persona where id = @idPersona
end 
go

create procedure sp_BuscarPersonaNombre
@nombre nvarchar(50)
as begin
select * from Persona where nombre = @nombre 
order by nombre asc 
end
go

create procedure sp_BuscarPersonaFechaIngreso
@fechaIngreso date
as begin
select * from Persona where fechaIngreso = @fechaIngreso
order by fechaIngreso asc
end
go

create procedure sp_BuscarPersonaFechaSalida
@fechaSalida date
as begin
select * from Persona where fechaSalida = @fechaSalida
order by fechaSalida asc
end
go



-- queries trabajador
create procedure sp_BuscarTrabajador
@idTrabajador int
as
begin 
select * from Trabajador where idTrabajador = @idTrabajador
end 
go

create procedure sp_BuscarTrabajador_IdPersona
@idPersona int
as
begin
select * from Trabajador where idPersona = @idPersona
end
go

-- queries seccion

create procedure sp_BuscarSeccionId
@idSeccion int 
as 
begin 
select * from Seccion where idSeccion = @idSeccion
end
go

create procedure sp_BuscarSeccionSeccion
@seccion int 
as 
begin
select * from Seccion where seccion = @seccion
end 
go

--queries de departamento

create procedure sp_BuscarDepartamentoId
@idDepartamento int
as
begin
    select * 
    from Departamento 
    where idDepartamento = @idDepartamento
end
go

create procedure sp_BuscarDepartamentoNombre
@departamento nvarchar(10)
as
begin
    select * 
    from Departamento 
    where departamento = @departamento
end
go


--queries para institucion
create procedure sp_BuscarInstitucionId
@idInstitucion int
as
begin
    select * 
    from Institucion
    where idInstitucion = @idInstitucion
end
go

create procedure sp_BuscarInstitucionNombre
@nombre nvarchar(50)
as
begin
    select * 
    from Institucion
    where nombre = @nombre
end
go

create procedure sp_BuscarInstitucionTipo
@tipo bit
as
begin
    select * 
    from Institucion
    where tipo = @tipo
end
go

-- commands


--commans de persona, inserta estudiantes y trabajador de una vez

create procedure sp_InsertPersona
@nombre nvarchar(50),
@apellido nvarchar (50),
@fechaIngreso date,
@fechaSalida date,
@telefono nvarchar (20),
@direccion nvarchar (50),
@tipo bit,

-- estudiante


--idPersona int, --foreign
@SeccionId int, --foreign 
@nivel bit,

-- trabajador

@Puesto nvarchar (50),
@departamentoId int --foreign

as begin

set nocount on;

begin try

    begin transaction;
--mete en el try la persona
    insert into Persona(nombre,apellido,fechaIngreso,fechaSalida,telefono,direccion,tipo)
    values(@nombre,@apellido,@fechaIngreso,@fechaSalida,@telefono,@direccion,@tipo);

-- se obtiene el id generado por el identity de la tabla

    declare @personaId int;
    set @personaId = SCOPE_IDENTITY();

    if(@tipo = 0)
    begin
--de una vez se mete al estudiante o al trabajador

    insert into Estudiante(idPersona,nivel,SeccionId)
    values(@personaId,@nivel,@SeccionId);
    end
    
    if(@tipo=1)
    begin
        insert into Trabajador(idPersona,Puesto,departamentoId)
        values(@personaId,@Puesto,@departamentoId);
    end
    commit transaction

    select @personaId as PersonaId;

end try
begin catch
    rollback transaction;
    throw;
end catch

end
go

create procedure sp_DeletePersona
@idPersona int


as
begin
set nocount on;

    begin try

        begin transaction;
        --delete from Persona where id=@idPersona  
        if not exists (select * from Persona where id= @idPersona)
        begin 
            throw 5003, 'La persona no existe',1;
        end

        declare @tipo bit;

        select @tipo = tipo from Persona where id = @idPersona;

        if(@tipo = 0)
        begin 
            delete from Estudiante where idPersona = @idPersona;    
        end

        if(@tipo=1)
        begin
            delete from Trabajador where  idPersona = @idPersona;
        end


        delete from Persona where id = @idPersona;
        commit transaction;

    end try
    begin catch 
        rollback transaction;
        throw;
    end catch

end
go

--drop procedure sp_DeletePersona

create procedure sp_EditarPersona
@idPersona int,
@nombre nvarchar(50),
@apellido nvarchar (50),
--fechaIngreso date,
@fechaSalida date null,
@telefono nvarchar (20),
@direccion nvarchar (50),
@tipo bit,

@SeccionId int, --foreign 
@nivel bit,

-- trabajador

@Puesto nvarchar (50),
@departamentoId int --foreign
as
begin
    set nocount on;

    begin try
        begin transaction;

        if not exists(select 1 from Persona where id = @idPersona)
        begin
            throw 5004, 'La persona no existe', 1;
        end

        declare @tipoActual bit;
        select @tipoActual= tipo from Persona where id= @idPersona;


        update  Persona 
        set nombre = @nombre,
            apellido = @apellido,
            fechaSalida = @fechaSalida,
            telefono = @telefono,
            direccion = @direccion,
            tipo = @tipo
        where id = @idPersona;

        if(@tipoActual <> @tipo)
        begin
            if(@tipo =0)
            begin
                delete from Trabajador where idPersona = @idPersona;
                insert into Estudiante (idPersona, nivel, SeccionId)
                values(@idPersona,@nivel,@SeccionId)
            end
            
            if(@tipo=1)
            begin
                delete from Estudiante where idPersona = @idPersona;
                insert into Trabajador(idPersona,Puesto,departamentoId)
                values(@idPersona,@Puesto,@departamentoId);
            end
        end
        commit transaction ;

    end try
    begin catch
        rollback transaction;
        throw;
    end catch
        
end
go

-- commands de estudiantes

create procedure sp_EliminarEstudiante
@idEstudiante int
as
begin
    set nocount on;

    if not exists (select 1 from Estudiante where idEstudiante = @idEstudiante)
    begin
        throw 5005, 'La estudiante no existe', 1;
    end

    delete from Estudiante where idEstudiante = @idEstudiante;
end
go


create procedure sp_EditarEstudiante
@idEstudiante int,
@SeccionId int, --foreign 
@nivel bit
as 
begin
    set nocount on;
    if not exists (select 1 from Estudiante where idEstudiante = @idEstudiante)
    begin
        return;
    end

    update Estudiante
    set SeccionId = @SeccionId,
        nivel = @nivel
    where idEstudiante = @idEstudiante
end
go


--commands de trabajador

create procedure sp_EliminarTrabajador
@idTrabajador int
as
begin
    set nocount on;
    if not exists (select 1 from Trabajador where idTrabajador = @idTrabajador)
    begin
        return;
    end
    
    delete from Trabajador where idTrabajador = @idTrabajador;
end
go

create procedure sp_EditarTrabajador
@idTrabajador int,
@Puesto nvarchar (50),
@departamentoId int --foreign
as
begin 
    set nocount on;
    
    if not exists (select 1 from Trabajador where idTrabajador = @idTrabajador)
    begin
        return;
    end

    update Trabajador
    set Puesto = @Puesto,
        departamentoId = @departamentoId
    where idTrabajador = @idTrabajador
end
go


-- commands de seccion
create procedure sp_InsertarSeccion
@seccion nvarchar (10)
as 
begin
    set nocount on;
    set xact_abort on;

    insert into Seccion (seccion)
    values(@seccion)
end
go

create procedure sp_EliminarSeccion
@idSeccion int
--@seccion nvarchar (10)
as
begin
    set nocount on;

    if not exists (select 1 from Seccion where idSeccion = @idSeccion)
    begin
        return;
    end

    delete from Seccion where idSeccion = @idSeccion;
end
go


create procedure sp_EditarSeccion
@idSeccion int,
@seccion nvarchar (10)
as
begin
    set nocount on;

    if not exists (select 1 from Seccion where idSeccion = @idSeccion)
    begin
        return;
    end

    update Seccion
    set seccion = @seccion
    where idSeccion  = @idSeccion
end
go


--commands de departamento

create procedure sp_InsertarDepartamento
@departamento nvarchar (50)
as
begin
    set nocount on;
    set xact_abort on;

    insert into Departamento(departamento)
    values (@departamento)
end
go


create procedure sp_EliminarDepartamento
@idDepartamento int
--@departamento nvarchar (10)
as
begin
    set nocount on;

    if not exists (select 1 from Departamento where idDepartamento = @idDepartamento)
    begin
        return;
    end

    delete from Departamento where idDepartamento = @idDepartamento;
end
go


create procedure sp_EditarDepartamento
@idDepartamento int,
@departamento nvarchar (10)
as
begin
    set nocount on;

    if not exists ( select 1 from Departamento where idDepartamento = @idDepartamento)
    begin
        return;
    end

    update Departamento
    set departamento = @departamento
    where idDepartamento = @idDepartamento

end
go

--commands de institucion

create procedure sp_CrearInstitucion
--@idInstitucion int,
@nombre nvarchar (50),
@tipo bit , -- colegio(0) o empresa(1)
@direccion nvarchar (50),
@telefono nvarchar (50),

--idColegio int identity (1,1) primary key,
@nombreColegio nvarchar(50),
--@idInstitucionColegio int,

--idEmpresa int identity (1,1) primary key,
@nombreEmpresa nvarchar (50)
--@idInstitucionEmpresa int

as
begin
    set nocount on;
    begin try
        begin transaction
        
        insert into Institucion(nombre,tipo,direccion,telefono)
        values(@nombre,@tipo,@direccion,@telefono)

        declare @idInstitucion int = scope_identity();

        if(@tipo = 0)
        begin
            insert into Colegio(nombre,idInstitucion)
            values(@nombreColegio,@idInstitucion)

        end

        if(@tipo = 1)
        begin
            insert into Empresa(nombre,idInstitucion)
            values(@nombreEmpresa,@idInstitucion)
        end

        commit transaction;
        select @idInstitucion as idInstitucion
    end try

    begin catch
        rollback transaction;
        throw;
    end catch
end
go

create procedure sp_EliminarInstitucion
@idInstitucion int
as
begin
    set nocount on;

    begin try
        begin transaction;

        if not exists (select 1 from Institucion where idInstitucion = @idInstitucion)
        begin
        
            return;
        end

        declare @tipo bit;

        select @tipo = tipo
        from Institucion
        where idInstitucion = @idInstitucion;

        --elimino al colegio o a la empresa primero, genera dependencia

        if(@tipo = 0)
        begin 
            delete from Colegio
            where idInstitucion = @idInstitucion;
        end

        if(@tipo = 1 )
        begin
            delete from Empresa 
            where idInstitucion = @idInstitucion;
        end


        delete from Institucion where idInstitucion = @idInstitucion;
        commit transaction;

    end try

    begin catch
        rollback transaction;
        throw;
    end catch

end
go

create procedure sp_EditarInstitucion
@idInstitucion int,
@nombre nvarchar (50),
@tipo bit , -- colegio o empresa
@direccion nvarchar (50),
@telefono nvarchar (50),

--idColegio int identity (1,1) primary key,
@nombreColegio nvarchar(50),
--idInstitucion int

--idEmpresa int identity (1,1) primary key,
@nombreEmpresa nvarchar (50)
--idInstitucion int

as
begin

    set nocount on;
    set xact_abort on;
    begin try

        begin transaction;
        if not exists (Select 1 from Institucion where idInstitucion = @idInstitucion)
        begin
            return;
        end

        declare @tipoActual bit;

        select @tipoActual = tipo
        from Institucion 
        where idInstitucion = @idInstitucion;

        update Institucion
        set nombre = @nombre,
            tipo = @tipo,
            direccion = @direccion,
            telefono = @telefono
        where idInstitucion = @idInstitucion;

        if (@tipoActual <> @tipo)
        begin
            if(@tipo = 0)
            begin
                
                delete from Empresa where idInstitucion = @idInstitucion;

                insert into Colegio( nombre, idInstitucion)
                values (@nombreColegio, @idInstitucion);
            end

            if(@tipo = 1)
            begin
                delete from Colegio where idInstitucion = @idInstitucion;
                insert into Empresa ( nombre, idInstitucion)
                values (@nombreEmpresa, @idInstitucion);
            end

        end
        commit transaction;
    end try

    begin catch
        rollback transaction;
        throw;
    end catch

end
go

--commands de colegios

create procedure sp_EliminarColegio
@idColegio int,
@nombre nvarchar (50)
as
begin
    set nocount on;
    set xact_abort on;
    delete from Colegio where idColegio = @idColegio;
end 
go

create procedure sp_EditarColegio
@idColegio int,
@nombre nvarchar (50)
as
begin
    set nocount on;
    set xact_abort on;

    update Colegio
    set nombre = @nombre
    where idColegio = @idColegio;

end 
go

--commands de empresa

create procedure sp_EliminarEmpresa
@idEmpresa int,
@nombre nvarchar (50)
as
begin
    set nocount on;
    set xact_abort on;

    delete from Empresa where idEmpresa = @idEmpresa;

end
go


create procedure sp_EditarEmpresa
@idEmpresa int,
@nombre nvarchar (50)
as
begin
    set nocount on;
    set xact_abort on;

    update Empresa
    set nombre = @nombre
    where idEmpresa = @idEmpresa;
end
go
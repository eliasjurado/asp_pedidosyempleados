use Negocios2018
go

create table tb_pedidos(
idped int primary key,
fechaped datetime default getdate(),
idempleado int references tb_empleados,
detped varchar(255),
costoped decimal
)
go

insert into tb_pedidos values (1,getdate(),1,'cargamento de pegamento de madera',3500.23)

select*from tb_empleados
select*from tb_pedidos

select IdEmpleado, CONCAT( NomEmpleado,' ',ApeEmpleado) as nomempleado from tb_empleados
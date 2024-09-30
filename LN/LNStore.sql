use storedb

create proc searchproductsbyid
@id int
as
select * from Products
where id=@id

select * from Products

insert into Products values (1, 'Cocacola', 7.50)
insert into Products values (2, 'Pepsi', 5.50)

create proc showeverything
as
select * from Products



create proc insertproducts
@id int,
@description varchar(50),
@price money
as
insert into Products
values(@id, @description, @price)



create proc deleteproducts
@id int
as
delete from Products
where id=@id



create proc updateproducts
@id int,
@description varchar(50),
@price money
as
update Products
set description=@description, price=@price
where id=@id
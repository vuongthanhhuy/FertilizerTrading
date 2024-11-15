drop database if exists FertilizerTrading
go
create database FertilizerTrading
go
use FertilizerTrading
go

create table _Fertilizer
(
	fertilizer_id varchar(10) primary key,
	_description nvarchar(500),
	_image varchar(500),
	_name nvarchar(500),
	_category nvarchar(500),
	_price float,
	_stock int
)
go

create table _Customer
(
	customer_phone varchar(20) primary key,
	_name nvarchar(500),
	_email varchar(500)
)
go

create table _Account
(
	account_id varchar(10) primary key,
	_username varchar(20),
	_password varchar(500)
)
go

create table _Order
(
	order_id varchar(10) primary key,
	_total_price float,
	_date datetime,
	_total_payment float,
	customer_phone varchar(20),
	account_id varchar(10)
)
go

create table _ItemOrdered
(
	_quantity int,
	fertilizer_id varchar(10),
	order_id varchar(10)
)
go

alter table _Order
add constraint fk_order_customer
foreign key (customer_phone) references _Customer(customer_phone)
go

alter table _Order
add constraint fk_order_account
foreign key (account_id) references _Account(account_id)
go

alter table _ItemOrdered
add constraint fk_itemordered_fertilizer
foreign key (fertilizer_id) references _Fertilizer(fertilizer_id)
go

alter table _ItemOrdered
add constraint fk_itemordered_order
foreign key (order_id) references _Order(order_id)
go

create procedure AddFertilizer
	@_description nvarchar(500),
	@_image varchar(500),
	@_name nvarchar(500),
	@_category nvarchar(500),
	@_price float,
	@_stock int
as
begin
    declare @newFertilizerID varchar(10)
	declare @maxFertilizerID varchar(10)
	set @newFertilizerID = 'A000000001'
	select @maxFertilizerID = cast(max(cast(substring(fertilizer_id, 2, 10) as int)) + 1 as varchar) from _Fertilizer where substring(fertilizer_id, 1, 1) = 'A'
	if (cast(@maxFertilizerID as int) > cast(substring(@newFertilizerID, 2, 10) as int))
	begin
		while (len(@maxFertilizerID) < 9)
		begin
			set @maxFertilizerID = '0' + @maxFertilizerID
		end
		set @newFertilizerID = 'A' + @maxFertilizerID 
	end
    insert into _Fertilizer (fertilizer_id, _description, _image, _name, _category, _price, _stock) values (@newFertilizerID, @_description, @_image, @_name, @_category, @_price, @_stock)
end
go

delete from _Fertilizer
go

exec AddFertilizer 'abc', 'abc', 'abc', 'abc', 1.1, 1
go

delete from _Account
go

insert into _Account values ('A0000001', 'vuonggthanhhhuyy', '$2a$12$5dR7hBKWbj1O4rOt9DuRA.okJsA1g4.09.j16GS35LikHvTDydo/O')
go
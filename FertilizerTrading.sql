drop database if exists FertilizerTrading
go
create database FertilizerTrading
go
use FertilizerTrading
go

CREATE TABLE _Fertilizer (
    fertilizer_id VARCHAR(10) PRIMARY KEY,
    _description NVARCHAR(500),
    _image VARCHAR(500),
    _name NVARCHAR(500),
    _category NVARCHAR(500),
    _price FLOAT,
    _isdeleted BIT DEFAULT 0,
    _stock INT
);

go

create table _Customer
(
	customer_phone varchar(20) primary key,
	_purchase_update Date,
	_debt float,
	_total_bought float,
	_name nvarchar(500),
	_email varchar(500),
	purchase_times int default 1,
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

CREATE PROCEDURE AddFertilizer
    @_description NVARCHAR(500),
    @_name NVARCHAR(500),
    @_category NVARCHAR(500),
    @_price FLOAT,
    @_stock INT
AS
BEGIN
    DECLARE @newFertilizerID VARCHAR(10)
    DECLARE @maxFertilizerID VARCHAR(10)
    SET @newFertilizerID = 'F000000001'
    SELECT @maxFertilizerID = CAST(MAX(CAST(SUBSTRING(fertilizer_id, 2, 10) AS INT)) + 1 AS VARCHAR)
    FROM _Fertilizer
    WHERE SUBSTRING(fertilizer_id, 1, 1) = 'F'

    IF (CAST(ISNULL(@maxFertilizerID, '0') AS INT) > CAST(SUBSTRING(@newFertilizerID, 2, 10) AS INT))
    BEGIN
        WHILE (LEN(@maxFertilizerID) < 9)
        BEGIN
            SET @maxFertilizerID = '0' + @maxFertilizerID
        END
        SET @newFertilizerID = 'F' + @maxFertilizerID
    END
    INSERT INTO _Fertilizer (fertilizer_id, _description, _name, _category, _price, _stock)
    VALUES (@newFertilizerID, @_description, @_name, @_category, @_price, @_stock)
END
GO

CREATE SEQUENCE OrderIdSequence
    AS INT
    START WITH 3
    INCREMENT BY 1;
	go

CREATE PROCEDURE AddOrder
    @_total_price FLOAT,
    @_date DATETIME,
    @_total_payment FLOAT,
    @_customer_phone VARCHAR(20), -- Correct naming here for the parameter
    @_account_id VARCHAR(10)      -- Correct naming here for the parameter
AS
BEGIN
    DECLARE @newOrderID VARCHAR(10)
    DECLARE @maxOrderID VARCHAR(10)
    
    SET @newOrderID = 'O000000001'
    
    SELECT @maxOrderID = CAST(MAX(CAST(SUBSTRING(order_id, 2, 10) AS INT)) + 1 AS VARCHAR)
    FROM _Order
    WHERE SUBSTRING(order_id, 1, 1) = 'O'
    
    IF (CAST(@maxOrderID AS INT) > CAST(SUBSTRING(@newOrderID, 2, 10) AS INT))
    BEGIN
        WHILE (LEN(@maxOrderID) < 9)
        BEGIN
            SET @maxOrderID = '0' + @maxOrderID
        END
        SET @newOrderID = 'O' + @maxOrderID
    END
    
    INSERT INTO _Order (order_id, _total_price, _date, _total_payment, customer_phone, account_id)
    VALUES (@newOrderID, @_total_price, @_date, @_total_payment, @_customer_phone, @_account_id)
END
GO



--delete from _Fertilizer
--go

--exec AddFertilizer N'Mô tả 1', N'Tên 1', N'Loại 1', 300000, 3
--exec AddFertilizer N'Mô tả 2', N'Tên 2', N'Loại 2', 300000, 3
--go

--go
--delete from _Account
--go

insert into _Account values ('A0000001', 'admin', '$2a$12$FAl30FWUMTGULHV6jA82r.vYucj1KFRkzn/aX4YfeeA4.q2sLHQdO')
go


--delete from _Customer
--go


--insert into _Customer(customer_phone,_purchase_update,_debt,_total_bought,_name,_email) values ('0854637748', '11-18-2024', 200000, 1200000, N'Vương Thanh Huy 1', 'vuonggthanhhhuyy1@gmail.com')
--insert into _Customer(customer_phone,_purchase_update,_debt,_total_bought,_name,_email) values ('0854637749', '11-18-2024', 300000, 2300000, N'Vương Thanh Huy 2', 'vuonggthanhhhuyy2@gmail.com')
--go

--EXEC AddOrder 5000, '2024-11-17', 3000, '0854637748', 'A0000001';
--go
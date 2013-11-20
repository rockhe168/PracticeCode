use Sales
go

--��һ�����������ݿ��ļ�����


--�ڶ����������������������������Ǵ���������������how����ζ����ݽ��з�����
create partition function pf_OrderDate(datetime)
as range left
for values('2003-01-01','2004-01-01')--[�������������ֱ�Ϊ��2003��֮ǰ�ǵ�һ��������2003~2004���ǵڶ���������2004��֮���ǵ���������]n���ܳ��� 999�������ķ��������� n + 1
go

--���������������������������������� where(����������ݽ��з���)
create partition scheme ps_OrderDate
as partition pf_OrderDate
To(File1,File2,File3)
go

--���Ĳ���������������������������й���
create table Orders
(
OrderID int identity(10000,1),
OrderDate datetime not null,
CustomerID int not null,
constraint pk_Orders primary key(OrderId,OrderDate)
)
on ps_OrderDate(OrderDate)  --������������

create table OrdersHistory
(
OrderID int identity(10000,1),
OrderDate datetime not null,
CustomerID int not null,
constraint pk_OrdersHistory primary key(OrderId,OrderDate)
)
on ps_OrderDate(OrderDate)  --��������������һ����ֻ�ܹ���һ������������һ�������������Թ������������



--�����ݱ���д��2002��ķ�������
USE Sales    
GO    
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2002/6/25', 1000)    
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2002/8/13', 1000)    
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2002/8/25', 1000)    
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2002/9/23', 1000) 
GO
 
--�����ݱ���д��2003��ķ�������
USE Sales    
GO 
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2003/6/25', 1000) 
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2003/8/13', 1000) 
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2003/8/25', 1000) 
INSERT INTO dbo.Orders (OrderDate, CustomerID) VALUES ('2003/9/23', 1000)    
GO

 
--���ǿ���������Ĵ����ѯ��2��
SELECT * FROM dbo.Orders    
SELECT * FROM dbo.OrdersHistory

--��ѯ�ѷ�����Order�ĵ�һ���������������£�
select * from Orders where $Partition.pf_OrderDate(OrderDate)=1

--�������2003�������[�ڵڶ�������]����Ҫ���µĴ��룺
select * from Orders where $Partition.pf_OrderDate(OrderDate)=2


--���ǻ����Բ�ѯĳ�������ж��������ݣ��������£�
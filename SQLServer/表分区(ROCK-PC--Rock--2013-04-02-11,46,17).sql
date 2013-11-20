use Sales
go

--第一步，创建数据库文件分组


--第二步，创建分区函数，（这里我们创建三个分区）。how（如何对数据进行分区）
create partition function pf_OrderDate(datetime)
as range left
for values('2003/01/01','2004/01/01')--[这里三个分区分别为，2003年之前是第一个分区，2003~2004年是第二个分区，2004年之后是第三个分区]n不能超过 999，创建的分区数等于 n + 1
go

--第三步，创建分区方案、关联分区函数 where(在哪里对数据进行分区)
create partition scheme ps_OrderDate
as partition pf_OrderDate
To(File1,File2,File3)
go

--第四步，创建分区表，并与分区方案进行关联
create table Orders
(
OrderID int identity(10000,1),
OrderDate datetime not null,
CustomerID int not null,
constraint pk_Orders primary key(OrderId,OrderDate)
)
on ps_OrderDate --关联分区方案
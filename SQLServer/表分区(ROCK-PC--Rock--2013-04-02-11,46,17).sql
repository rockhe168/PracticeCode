use Sales
go

--��һ�����������ݿ��ļ�����


--�ڶ����������������������������Ǵ���������������how����ζ����ݽ��з�����
create partition function pf_OrderDate(datetime)
as range left
for values('2003/01/01','2004/01/01')--[�������������ֱ�Ϊ��2003��֮ǰ�ǵ�һ��������2003~2004���ǵڶ���������2004��֮���ǵ���������]n���ܳ��� 999�������ķ��������� n + 1
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
on ps_OrderDate --������������
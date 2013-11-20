use RockCommonDB
go

--����Person��
create table Person
(
 id int identity(1,1) not null,
 pid varchar(18) not null,
 md varchar(11) not null,
 age int
)
go

--����100������¼
declare @pid varchar(18)
declare @md varchar(11)
declare @age int
declare @count int

set @count=0

while(@count<10000000)
begin
     --���������pid
     select @pid=substring(cast(rand() as varchar(20)),3,6)+
          substring(cast(rand() as varchar(20)),3,6)+ 
          substring(cast(rand() as varchar(20)),3,6)
     --���������md
     select @md=substring(cast(rand() as varchar(20)),3,6)+
         substring(cast(rand() as varchar(20)),3,5)
     --���������age
     select @age=cast(rand() * 100 as int)
     --������ɵ�����Inesrt Person Table��
     insert into Person values(@pid,@md,@age) 
     
     --��ǰ��������
     set @count=@count+1
end

--��ѯ������
select count(id) from person


--��������
--------------------��100������¼�еĵ� �������ļ�¼��---------------

--����һ��
select top 1 * from Person order by age desc --ȱ�㣺ֻ�ܲ�ѯһ����¼����Ȼ���������ܴ��ڶ��
--������
select top 1 with ties * from Person order by age desc--��ѯ�����10031��
--�������������Ӳ�ѯ��
select * from Person where age=(select max(age) from Person)
��
select * from Person where age=(select top 1 age from Person order by age desc)



--���sQL����
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers


----------������ѯʱ�䡾���ܷ�����------------

--1��top���
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select top 1 * from Person order by age desc
set @endTime=getdate()

set @diffTime=datediff(millisecond ,@beginTime,@endTime)
select 'Top��ѯ���ĵĺ�����Ϊ��-->'+ convert(varchar,@diffTime)+' ms'
--print '��ѯ���ĵĺ�����Ϊ��-->'+ convert(varchar,@diffTime)

--���sQL����
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--2���Ӳ�ѯ
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select * from Person where age=(select max(age) from Person)
set @endTime=getdate()
set @diffTime=datediff(millisecond,@beginTime,@endTime)
select '�Ӳ�ѯ���ĵĺ�����Ϊ��-->'+convert(varchar,@diffTime)+' ms'


--------------�����Ǿۼ���������������Ĳ�ѯ---------------
create nonclustered index ix_age on Person(age)--�����Ǿۼ�����

--���sQL����
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--1��top���
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select top 1 * from Person order by age desc
set @endTime=getdate()

set @diffTime=datediff(millisecond ,@beginTime,@endTime)
select 'Top��ѯ���ĵĺ�����Ϊ��-->'+ convert(varchar,@diffTime)+' ms'
--print '��ѯ���ĵĺ�����Ϊ��-->'+ convert(varchar,@diffTime)

--���sQL����
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--2���Ӳ�ѯ
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select * from Person where age=(select max(age) from Person)
set @endTime=getdate()
set @diffTime=datediff(millisecond,@beginTime,@endTime)
select '�Ӳ�ѯ���ĵĺ�����Ϊ��-->'+convert(varchar,@diffTime)+' ms'



--------------�����ۼ���������������Ĳ�ѯ---------------
drop index  Person.ix_age
create index ix_age on Person(age)--�����ۼ�����

--���sQL����
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--1��top���
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select top 1 * from Person order by age desc
set @endTime=getdate()

set @diffTime=datediff(millisecond ,@beginTime,@endTime)
select 'Top��ѯ���ĵĺ�����Ϊ��-->'+ convert(varchar,@diffTime)+' ms'
--print '��ѯ���ĵĺ�����Ϊ��-->'+ convert(varchar,@diffTime)

--���sQL����
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--2���Ӳ�ѯ
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select * from Person where age=(select max(age) from Person)
set @endTime=getdate()
set @diffTime=datediff(millisecond,@beginTime,@endTime)
select '�Ӳ�ѯ���ĵĺ�����Ϊ��-->'+convert(varchar,@diffTime)+' ms'


---�ܽ�
---���int���ͣ�top��䣺�ۼ������ٶ�Ҫ����Ǿۼ��������Ǿۼ�����Ҫ�ȴ�ͳsql��Ķ�
---             �Ӳ�ѯ��������һ���ȴ�ͳ��sql����











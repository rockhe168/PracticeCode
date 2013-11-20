use RockCommonDB
go

--创建Person表
create table Person
(
 id int identity(1,1) not null,
 pid varchar(18) not null,
 md varchar(11) not null,
 age int
)
go

--插入100万条记录
declare @pid varchar(18)
declare @md varchar(11)
declare @age int
declare @count int

set @count=0

while(@count<10000000)
begin
     --生成随机的pid
     select @pid=substring(cast(rand() as varchar(20)),3,6)+
          substring(cast(rand() as varchar(20)),3,6)+ 
          substring(cast(rand() as varchar(20)),3,6)
     --生成随机的md
     select @md=substring(cast(rand() as varchar(20)),3,6)+
         substring(cast(rand() as varchar(20)),3,5)
     --生成随机的age
     select @age=cast(rand() * 100 as int)
     --随机生成的数据Inesrt Person Table中
     insert into Person values(@pid,@md,@age) 
     
     --当前插入条数
     set @count=@count+1
end

--查询总行数
select count(id) from person


--问题描述
--------------------从100万条记录中的到 年龄最大的记录？---------------

--方法一：
select top 1 * from Person order by age desc --缺点：只能查询一条记录，当然这个年龄可能存在多个
--方法二
select top 1 with ties * from Person order by age desc--查询结果：10031行
--方法三【利用子查询】
select * from Person where age=(select max(age) from Person)
或
select * from Person where age=(select top 1 age from Person order by age desc)



--清除sQL缓存
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers


----------分析查询时间【性能分析】------------

--1、top语句
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select top 1 * from Person order by age desc
set @endTime=getdate()

set @diffTime=datediff(millisecond ,@beginTime,@endTime)
select 'Top查询消耗的毫秒数为：-->'+ convert(varchar,@diffTime)+' ms'
--print '查询消耗的毫秒数为：-->'+ convert(varchar,@diffTime)

--清除sQL缓存
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--2、子查询
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select * from Person where age=(select max(age) from Person)
set @endTime=getdate()
set @diffTime=datediff(millisecond,@beginTime,@endTime)
select '子查询消耗的毫秒数为：-->'+convert(varchar,@diffTime)+' ms'


--------------创建非聚集索引，进行上面的查询---------------
create nonclustered index ix_age on Person(age)--创建非聚集索引

--清除sQL缓存
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--1、top语句
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select top 1 * from Person order by age desc
set @endTime=getdate()

set @diffTime=datediff(millisecond ,@beginTime,@endTime)
select 'Top查询消耗的毫秒数为：-->'+ convert(varchar,@diffTime)+' ms'
--print '查询消耗的毫秒数为：-->'+ convert(varchar,@diffTime)

--清除sQL缓存
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--2、子查询
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select * from Person where age=(select max(age) from Person)
set @endTime=getdate()
set @diffTime=datediff(millisecond,@beginTime,@endTime)
select '子查询消耗的毫秒数为：-->'+convert(varchar,@diffTime)+' ms'



--------------创建聚集索引，进行上面的查询---------------
drop index  Person.ix_age
create index ix_age on Person(age)--创建聚集索引

--清除sQL缓存
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--1、top语句
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select top 1 * from Person order by age desc
set @endTime=getdate()

set @diffTime=datediff(millisecond ,@beginTime,@endTime)
select 'Top查询消耗的毫秒数为：-->'+ convert(varchar,@diffTime)+' ms'
--print '查询消耗的毫秒数为：-->'+ convert(varchar,@diffTime)

--清除sQL缓存
dbcc freeproccache  --free proc cache
dbcc dropcleanbuffers --drop clearn buffers

--2、子查询
declare @beginTime datetime
declare @endTime datetime
declare @diffTime int

set @beginTime=getdate()
select * from Person where age=(select max(age) from Person)
set @endTime=getdate()
set @diffTime=datediff(millisecond,@beginTime,@endTime)
select '子查询消耗的毫秒数为：-->'+convert(varchar,@diffTime)+' ms'


---总结
---针对int类型，top语句：聚集索引速度要快与非聚集索引，非聚集索引要比传统sql快的多
---             子查询：索引不一定比传统的sql语句块











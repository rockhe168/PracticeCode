if exists(select * from sysobjects where name='tb_Score')
   drop table tb_Score
   
--成绩表
create table tb_Score
(
id int identity(1,1) not null primary key ,--成绩Id
stuName varchar(50),--学员名称
subjectName varchar(50),--科目名称
subjectScore int--科目成绩分数
)
go


--插入测试数据
insert into tb_Score values('张三' , '语文' , 74)
insert into tb_Score values('张三' , '数学' , 83)
insert into tb_Score values('张三' , '物理' , 93)
insert into tb_Score values('李四' , '语文' , 74)
insert into tb_Score values('李四' , '数学' , 84)
insert into tb_Score values('李四' , '物理' , 94)
go

select * from tb_score


--行转列,需要的结果为
姓名 语文 数学 物理 
李四 74   84   94
张三 74   83   93


-----------------------------静态转换----------------------

--行转成列方式一,利用group by 语句.
select 
stuName as 姓名,
max(case subjectName when '语文' then subjectScore else 0 end) as 语文,
max(case subjectName when '数学' then subjectScore else 0 end) as 数学,
max(case subjectName when '物理' then subjectScore else 0 end) as 物理
from tb_score
group by stuName


--行转列方式二，SQL Server2005 支持的方法 pivot()
select * from (select stuName as 姓名,subjectName,subjectScore from tb_Score) as a 
pivot (max(subjectScore) for subjectName in(语文,数学,物理)) as b 


--希望得到如下结果
姓名 语文 数学 物理 平均分 总分 
---- ---- ---- ---- ------ ----
李四 74   84   94   84.00  252
张三 74   83   93   83.33  250


--行转成列方式一,利用group by 语句.
select 
stuName as 姓名,
max(case subjectName when '语文' then subjectScore else 0 end) as 语文,
max(case subjectName when '数学' then subjectScore else 0 end) as 数学,
max(case subjectName when '物理' then subjectScore else 0 end) as 物理,
cast(avg(subjectScore*1.0) as decimal(18,2)) as 平均分,
sum(subjectScore) as 总分
from tb_Score
group by stuName

--行转列方式二，SQL Server2005 支持的方法 pivot()
select m.* , n.平均分 , n.总分 from
(select * from (select * from tb_Score) a pivot (max(subjectScore) for tb_Score in (语文,数学,物理)) b) m , 
(select stuName , cast(avg(subjectScore*1.0) as decimal(18,2)) 平均分 , sum(subjectScore) 总分 from tb_Score group by stuName) n
where m.stuName = n.stuName
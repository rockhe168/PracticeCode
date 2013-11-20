if exists(select * from sysobjects where name='tb_Score')
   drop table tb_Score
   
--�ɼ���
create table tb_Score
(
id int identity(1,1) not null primary key ,--�ɼ�Id
stuName varchar(50),--ѧԱ����
subjectName varchar(50),--��Ŀ����
subjectScore int--��Ŀ�ɼ�����
)
go


--�����������
insert into tb_Score values('����' , '����' , 74)
insert into tb_Score values('����' , '��ѧ' , 83)
insert into tb_Score values('����' , '����' , 93)
insert into tb_Score values('����' , '����' , 74)
insert into tb_Score values('����' , '��ѧ' , 84)
insert into tb_Score values('����' , '����' , 94)
go

select * from tb_score


--��ת��,��Ҫ�Ľ��Ϊ
���� ���� ��ѧ ���� 
���� 74   84   94
���� 74   83   93


-----------------------------��̬ת��----------------------

--��ת���з�ʽһ,����group by ���.
select 
stuName as ����,
max(case subjectName when '����' then subjectScore else 0 end) as ����,
max(case subjectName when '��ѧ' then subjectScore else 0 end) as ��ѧ,
max(case subjectName when '����' then subjectScore else 0 end) as ����
from tb_score
group by stuName


--��ת�з�ʽ����SQL Server2005 ֧�ֵķ��� pivot()
select * from (select stuName as ����,subjectName,subjectScore from tb_Score) as a 
pivot (max(subjectScore) for subjectName in(����,��ѧ,����)) as b 


--ϣ���õ����½��
���� ���� ��ѧ ���� ƽ���� �ܷ� 
---- ---- ---- ---- ------ ----
���� 74   84   94   84.00  252
���� 74   83   93   83.33  250


--��ת���з�ʽһ,����group by ���.
select 
stuName as ����,
max(case subjectName when '����' then subjectScore else 0 end) as ����,
max(case subjectName when '��ѧ' then subjectScore else 0 end) as ��ѧ,
max(case subjectName when '����' then subjectScore else 0 end) as ����,
cast(avg(subjectScore*1.0) as decimal(18,2)) as ƽ����,
sum(subjectScore) as �ܷ�
from tb_Score
group by stuName

--��ת�з�ʽ����SQL Server2005 ֧�ֵķ��� pivot()
select m.* , n.ƽ���� , n.�ܷ� from
(select * from (select * from tb_Score) a pivot (max(subjectScore) for tb_Score in (����,��ѧ,����)) b) m , 
(select stuName , cast(avg(subjectScore*1.0) as decimal(18,2)) ƽ���� , sum(subjectScore) �ܷ� from tb_Score group by stuName) n
where m.stuName = n.stuName
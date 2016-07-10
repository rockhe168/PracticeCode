/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2016/5/16 16:30:38                           */
/*==============================================================*/


drop table if exists wlt_catalog;

drop table if exists wlt_company;

drop table if exists wlt_companyUserInfo;

drop table if exists wlt_company_collect;

drop table if exists wlt_headhunter;

drop table if exists wlt_headhunter_identity;

drop table if exists wlt_index_ad;

drop table if exists wlt_location;

drop table if exists wlt_mobile_message;

drop table if exists wlt_personDelegate;

drop table if exists wlt_person_resume_log;

drop table if exists wlt_personcollect;

drop table if exists wlt_personinfo;

drop table if exists wlt_personinfo_basic;

drop table if exists wlt_positioninfo;

drop table if exists wlt_positioninfo_content;

drop table if exists wlt_resume;

drop table if exists wlt_resume_edu;

drop table if exists wlt_resume_exper;

drop table if exists wlt_resume_jobIntension;

drop table if exists wlt_resume_language;

drop table if exists wlt_resume_selfevaluation;

drop table if exists wlt_resume_technical;

drop table if exists wlt_resume_workhistory;

drop table if exists wlt_resume_working;

drop table if exists wlt_sendmessage;

/*==============================================================*/
/* Table: wlt_catalog                                           */
/*==============================================================*/
create table wlt_catalog
(
   Id                   int not null auto_increment,
   ��Ŀ¼Id                int,
   Ŀ¼����                 varchar(256),
   ��ע                   varchar(256),
   ����ʱ��                 timestamp not null,
   primary key (Id)
);

alter table wlt_catalog comment '���ø������ƣ�����ҵ���ʡ���ҵ�����';

/*==============================================================*/
/* Table: wlt_company                                           */
/*==============================================================*/
create table wlt_company
(
   companyId            bigint not null auto_increment comment '��ҵId',
   partentId            bigint not null default 1 comment '����ҵId(0=һ����˾,Ĭ��1=����ҵ������Աͨ�����䣬���ֶ�Ϊ����ҵId)',
   companyFullName      varchar(100) comment '��˾����',
   phoneImagePath       varchar(200) comment 'ͷ����Ƭ��ַ',
   businessId           int comment '��ҵId',
   businessName         varchar(100) comment '��ҵ����',
   scaleId              int comment '��ģId',
   scaleName            varchar(100) comment '��ģ����',
   personNumber         varchar(50) comment 'Ա������',
   contract             varchar(50) comment '��ϵ��',
   phone                varchar(50) comment '�绰',
   mobile               varchar(11) comment '�ֻ�',
   twoDimensionCode     varchar(100) comment '��ά��',
   address              varchar(100) comment '��ַ',
   email                varchar(100) comment '����',
   intro                text comment '���',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (companyId)
);

alter table wlt_company comment '��ҵ������Ϣ';

/*==============================================================*/
/* Table: wlt_companyUserInfo                                   */
/*==============================================================*/
create table wlt_companyUserInfo
(
   companyUserId        bigint not null auto_increment comment '��ҵId',
   companyId            bigint comment '������ҵId',
   mobile               varchar(11) not null comment '�ֻ�����',
   loginName            varchar(50) not null comment '��¼����',
   loginPwd             varchar(50) not null comment '��¼����',
   handlerStatus        tinyint not null comment '����״̬(�ֻ���֤-->δ��֤-->��֤��ͷ)',
   regTime              datetime comment 'ע��ʱ��',
   lastLoginTime        datetime comment '���һ�ε�¼ʱ��',
   status               tinyint comment '״̬',
   IsRealNameCertification tinyint comment 'ʵ����֤״̬(0=Ϊ��֤��1=����֤)',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (companyUserId)
);

alter table wlt_companyUserInfo comment '��ҵ�û�';

/*==============================================================*/
/* Table: wlt_company_collect                                   */
/*==============================================================*/
create table wlt_company_collect
(
   Id                   bigint not null auto_increment comment '����',
   companyId            bigint not null comment '��˾Id',
   hunterId             bigint not null comment '��ͷId',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (Id)
);

alter table wlt_company_collect comment '��ҵ�ղ���ͷ';

/*==============================================================*/
/* Table: wlt_headhunter                                        */
/*==============================================================*/
create table wlt_headhunter
(
   hunterId             bigint not null auto_increment comment '��ͷId',
   mobile               varchar(11) not null comment '�ֻ�����',
   loginName            varchar(50) not null comment '��¼����',
   loginPwd             varchar(50) not null comment '��¼����',
   handlerStatus        tinyint not null comment '����״̬(�ֻ���֤-->δ��֤-->��֤��ͷ)',
   regTime              datetime comment 'ע��ʱ��',
   lastLoginTime        datetime comment '���һ�ε�¼ʱ��',
   status               tinyint comment '״̬',
   IsRealNameCertification tinyint comment 'ʵ����֤״̬(0=Ϊ��֤��1=����֤)',
   IsWorkingCertification tinyint comment '��ҵ��֤(0=δ�ύ,1=��֤�У�1=����֤)',
   IsPhoneCertification tinyint comment '��Ƭ��֤(0=δ�ύ,1=��֤�У�1=����֤)',
   phoneImagePath       varchar(200) comment 'ͷ����Ƭ��ַ',
   publicPositionCount  int comment '���˷���ְλ��',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (hunterId)
);

alter table wlt_headhunter comment '��ͷ�û�';

/*==============================================================*/
/* Table: wlt_headhunter_identity                               */
/*==============================================================*/
create table wlt_headhunter_identity
(
   hunterId             bigint not null comment '��ͷId',
   realName             varchar(50) comment '��ʵ����',
   IdCarNo              varchar(20) comment '���֤����',
   mobile               varchar(11) comment '�ֻ�����',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (hunterId)
);

alter table wlt_headhunter_identity comment '��ͷ��Ϣ��ʵ�����Ϣ';

/*==============================================================*/
/* Table: wlt_index_ad                                          */
/*==============================================================*/
create table wlt_index_ad
(
   adId                 int not null auto_increment comment '����',
   title                varchar(100) comment '��ʾ����',
   imgUrl               varchar(200) comment 'ͼƬ��ַ',
   skipUrl              varchar(200) comment '��תurl',
   sortNo               int comment '˳��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   createTime           datetime not null comment '����ʱ��',
   primary key (adId)
);

alter table wlt_index_ad comment '��ҳ���';

/*==============================================================*/
/* Table: wlt_location                                          */
/*==============================================================*/
create table wlt_location
(
   area_id              int not null auto_increment comment 'Id',
   area_name            varchar(50) not null comment '��Ŀ��',
   parent_id            int not null comment '����Ŀ',
   short_name           varchar(50) comment '����Ŀ��',
   pinyin               varchar(100) comment 'ƴ��',
   lng                  varchar(20) comment '����',
   lat                  varchar(20) comment 'γ��',
   level                tinyint not null comment '����ȼ� 0=������,1=ʡ��,2=һ������,3=����,4=�ֵ�',
   recommend            int,
   sort                 int,
   primary key (area_id)
);

alter table wlt_location comment 'λ�ñ�(����ʡ,�С������ء��ֵ�)';

/*==============================================================*/
/* Table: wlt_mobile_message                                    */
/*==============================================================*/
create table wlt_mobile_message
(
   MessgeId             bigint not null auto_increment comment 'MessgeId',
   mobile               varchar(11) not null comment '�ֻ�����',
   seccode              varchar(8) not null comment '������֤��',
   effectiveTime        datetime not null comment '��Чʱ��',
   IsUse                bool not null comment '�Ƿ���֤��',
   CreateTime           datetime not null comment '����ʱ��',
   LastUpdateTime       datetime comment '����޸�ʱ��',
   primary key (MessgeId)
);

alter table wlt_mobile_message comment '������֤����Ϣ';

/*==============================================================*/
/* Table: wlt_personDelegate                                    */
/*==============================================================*/
create table wlt_personDelegate
(
   Id                   bigint not null auto_increment comment '����',
   personId             bigint not null comment '����Id',
   hunterId             bigint not null comment '��ͷId',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (Id)
);

alter table wlt_personDelegate comment '����ί����ͷ';

/*==============================================================*/
/* Table: wlt_person_resume_log                                 */
/*==============================================================*/
create table wlt_person_resume_log
(
   Id                   bigint not null auto_increment comment '����',
   personId             bigint not null comment '����Id',
   posId                bigint not null comment 'ְλId',
   sendDate             datetime not null comment 'Ͷ������',
   CreateTime           datetime not null comment '����ʱ��',
   LastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (Id)
);

alter table wlt_person_resume_log comment '����Ͷ�ݼ�����¼';

/*==============================================================*/
/* Table: wlt_personcollect                                     */
/*==============================================================*/
create table wlt_personcollect
(
   Id                   bigint not null auto_increment comment '����Id',
   personId             bigint not null comment '����Id',
   posId                bigint not null comment 'ְλId',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime comment '����޸�ʱ��',
   primary key (Id)
);

alter table wlt_personcollect comment '�����ղ�ְλ';

/*==============================================================*/
/* Table: wlt_personinfo                                        */
/*==============================================================*/
create table wlt_personinfo
(
   personId             bigint not null auto_increment comment '������������',
   mobile               varchar(11) not null comment '�ֻ�����',
   loginName            varchar(50) not null comment '��¼����',
   loginPwd             varchar(50) not null comment '��¼����',
   handlerStatus        tinyint not null comment '����״̬(1=�ֻ���֤-->2=��д��Ƭ-->3=ӵ�м���)',
   regTime              datetime comment 'ע��ʱ��',
   lastLoginTime        datetime comment '���һ�ε�¼ʱ��',
   status               tinyint comment '״̬(0=����,1=��������ʹ��ϵͳ)',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (personId)
);

alter table wlt_personinfo comment '�����û�';

/*==============================================================*/
/* Table: wlt_personinfo_basic                                  */
/*==============================================================*/
create table wlt_personinfo_basic
(
   Id                   bigint not null auto_increment comment '����Id',
   personId             bigint comment '����Id',
   mobil                varchar(11) comment '�ֻ�����',
   email                varchar(100) comment 'Email',
   realname             varchar(50) comment '��ʵ����',
   birthdate            date comment '��������',
   gender               tinyint comment '�Ա�(0=��,1=Ů)',
   marriageState        tinyint comment '����״̬(0=����,1=�ѻ�,2=δ��)',
   beginWorkingYear     date comment '��ʼ�������',
   jobTitle             varchar(100) comment 'ְλ����',
   edu                  varchar(100) comment '���ѧ��',
   cityId               int comment '��ס����Id',
   cityName             varchar(50) comment '��ס��������',
   inCompanyName        varchar(50) comment '��ǰ���ڹ�˾����',
   businessId           int comment '��ҵId',
   businessName         varchar(200) comment '��ҵ����(��+�����)',
   functionId           int comment 'ְ��Id',
   functionName         varchar(200) comment 'ְ������(��+�����)',
   phoneImagePath       varchar(200) comment 'ͷ����Ƭ��ַ',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (Id)
);

alter table wlt_personinfo_basic comment '�����û�������Ϣ��Ƭ';

/*==============================================================*/
/* Table: wlt_positioninfo                                      */
/*==============================================================*/
create table wlt_positioninfo
(
   posId                bigint not null auto_increment comment 'ְλId',
   hunterId             bigint not null comment '��ͷId',
   posName              varchar(200) not null comment 'ְλ����',
   businessId           int comment '��ҵId',
   businessName         varchar(200) comment '��ҵ����(���)',
   provinceId           int comment 'ְλ����ʡ��Id��level=1��',
   provinceName         varchar(50) comment 'ְλ����ʡ������',
   cityId               int comment 'ְλ���ڳ���Id(level=2)',
   cityName             varchar(50) comment 'ְλ���ڳ�������',
   districtsId          int comment 'ְλ��������Id(level=3)',
   districtsName        varchar(50) comment 'ְλ������������',
   streetId             int comment 'ְλ���ڽֵ�(level=4)',
   streetName           varchar(50) comment 'ְλ���ڽֵ�����',
   salaryId             int comment 'ְλн�ʷ�ΧId',
   salaryName           varchar(50) comment 'ְλн�ʷ�Χ�ı�',
   educationalId        int comment 'ְλҪ��ѧ����ΧId',
   educationalText      varchar(50) comment 'ְλҪ��ѧ����Χ�ı�',
   experienceId         int comment 'ְλ��Ҫ�������鷶ΧId',
   experienceName       varchar(50) comment 'ְλ��Ҫ�������鷶ΧId�ı�',
   companyName          varchar(100) comment 'ְλ���ڹ�˾����',
   companyBackgroundIdStr varchar(500) comment 'ְλ��Ӧ��˾����Id�ַ���',
   companyBackgroundNameStr varchar(1000) comment 'ְλ��Ӧ��˾���������ַ������ã�ƴ�ӣ�',
   companyFeatureIdStr  varchar(500) comment 'ְλ��Ӧ��˾����Id�ַ���',
   companyFeatureIdNameStr varchar(1000) comment 'ְλ��Ӧ��˾���������ַ������ã�ƴ�ӣ�',
   status               tinyint comment 'ְλ״̬',
   pvCount              int comment 'ְλ�鿴��',
   sendCount            int comment 'ְλͶ����',
   sharedCount          int comment 'ְλ������',
   publishTime          datetime comment 'ְλ����ʱ��(ˢ��)',
   CreateTime           datetime not null comment '����ʱ��',
   LastUpdateTime       datetime comment '����޸�ʱ��',
   primary key (posId)
);

alter table wlt_positioninfo comment '��ͷְλ��Ϣ��';

/*==============================================================*/
/* Table: wlt_positioninfo_content                              */
/*==============================================================*/
create table wlt_positioninfo_content
(
   posId                bigint not null comment 'ְλId',
   underlingNumber      int comment '��������',
   compaynyDepartment   varchar(200) comment '���ڲ���',
   reportObject         varchar(100) comment '�㱨����',
   postionDesc          text comment '�㱨����',
   majors               text comment 'רҵҪ��',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (posId)
);

alter table wlt_positioninfo_content comment '��ͷְλ������Ϣ';

/*==============================================================*/
/* Table: wlt_resume                                            */
/*==============================================================*/
create table wlt_resume
(
   resumeId             bigint not null auto_increment comment '����Id',
   personId             bigint comment '����Id',
   name                 varchar(100) comment '��������',
   lastHandlerTime      datetime comment '������ʱ��',
   languageType         tinyint comment '��������(0=���ģ�1=Ӣ��)',
   showLevel            tinyint comment '�����ɼ���(0=���ż�����1=���ؼ���..)',
   IsDelete             bool comment '�Ƿ�ɾ��',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (resumeId)
);

alter table wlt_resume comment '��ְ�߼�����Ϣ';

/*==============================================================*/
/* Table: wlt_resume_edu                                        */
/*==============================================================*/
create table wlt_resume_edu
(
   eduId                bigint not null auto_increment comment '��������Id',
   resumeId             bigint comment '����Id',
   personId             bigint comment '����Id',
   schoolName           varchar(100) comment 'ѧУ��������',
   majorName            varchar(100) comment 'רҵ����',
   attendStartYear      varchar(10) comment '�Ͷ���ʼ���',
   attendStartMonth     varchar(10) comment '�Ͷ���ʼ�·�',
   attendEndYear        varchar(10) comment '�Ͷ��������',
   attendEndMonth       varchar(10) comment '�Ͷ������·�',
   degreeId             int comment 'ѧ��Id(��������)',
   degreeName           varchar(100) comment 'ѧ������',
   IsRecruitment        bool comment '�Ƿ�ͳ��',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime comment '����޸�ʱ��',
   primary key (eduId)
);

alter table wlt_resume_edu comment '���˼���_��������';

/*==============================================================*/
/* Table: wlt_resume_exper                                      */
/*==============================================================*/
create table wlt_resume_exper
(
   experId              bigint not null auto_increment comment '����',
   resumeId             bigint comment '����Id',
   personId             bigint comment '����Id',
   projectName          varchar(100) not null comment '��Ŀ����',
   companyName          varchar(100) not null comment '��˾����',
   productduty          varchar(100) comment '��Ŀְ��',
   startYear            varchar(10) comment '��ʼ���',
   startMonth           varchar(10) comment '��ʼ�·�',
   endYear              varchar(10) comment '�������',
   endMonth             varchar(10) comment '�����·�',
   projectDesc          text comment '��Ŀ����',
   projectFuntion       text comment '��Ŀְ��',
   projectPerformance   text comment '��Ŀҵ��',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (experId)
);

alter table wlt_resume_exper comment '���˼�����Ŀ����';

/*==============================================================*/
/* Table: wlt_resume_jobIntension                               */
/*==============================================================*/
create table wlt_resume_jobIntension
(
   resumeId             bigint not null comment '����Id',
   personId             bigint not null comment '����Id',
   expectBusinessId     int comment '������ҵId',
   expectBusinessName   varchar(200) comment '������ҵ���ƣ���+����أ�',
   expectFunctionId     int comment '����ְ��Id',
   expectFunctionName   varchar(200) comment '����ְ�����ƣ���+����أ�',
   expectCityId         int comment '������������Id',
   expectCityName       varchar(200) comment '����������������',
   expectSalaryId       int comment '������н��ΧId������������',
   expectSalary         varchar(200) comment '������н��Χ������������',
   expectIsPrivate      bool comment '������н�Ƿ���ʾ����',
   currentSalaryId      int comment 'Ŀǰ��н��ΧId������������',
   currentSalary        varchar(200) comment 'Ŀǰ��н��Χ������������',
   currentIsPrivate     bool comment 'Ŀǰ��н�Ƿ���ʾ����',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime comment '����޸�ʱ��',
   primary key (resumeId, personId)
);

alter table wlt_resume_jobIntension comment '��ְ�߼������ݱ�';

/*==============================================================*/
/* Table: wlt_resume_language                                   */
/*==============================================================*/
create table wlt_resume_language
(
   langId               bigint not null auto_increment comment '����Id',
   resumeId             bigint comment '����Id',
   personId             bigint comment '����Id',
   language             varchar(20) not null comment '����',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (langId)
);

alter table wlt_resume_language comment '���˼�����������';

/*==============================================================*/
/* Table: wlt_resume_selfevaluation                             */
/*==============================================================*/
create table wlt_resume_selfevaluation
(
   resumeId             bigint not null comment '����Id',
   personId             bigint not null comment '����Id',
   evaluate             text comment '����',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (resumeId, personId)
);

alter table wlt_resume_selfevaluation comment '���˼�����������';

/*==============================================================*/
/* Table: wlt_resume_technical                                  */
/*==============================================================*/
create table wlt_resume_technical
(
   techId               bigint not null auto_increment comment '����Id',
   resumeId             bigint comment '����Id',
   personId             bigint comment '����Id',
   techName             varchar(50) comment '�ó���������',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (techId)
);

alter table wlt_resume_technical comment '���˼����ó�����';

/*==============================================================*/
/* Table: wlt_resume_workhistory                                */
/*==============================================================*/
create table wlt_resume_workhistory
(
   workId               bigint not null auto_increment comment '����Id',
   resumeId             bigint comment '����Id',
   personId             bigint comment '����Id',
   companyName          varchar(200) comment '��˾����',
   workBusinessId       int comment '������ҵId',
   workBusinessName     varchar(200) comment '������ҵ���ƣ���+����أ�',
   workFunctionId       int comment '����ְ��Id',
   workFunctionName     varchar(200) comment '����ְ�����ƣ���+����أ�',
   workCityId           int comment '������������Id',
   workCityName         varchar(200) comment '����������������',
   underlingNumber      int comment '��������',
   workStartYear        varchar(10) comment '��ְ��ʼ���',
   workStartMonth       varchar(10) comment '��ְ��ʼ�·�',
   workEndYear          varchar(10) comment '��ְ�������',
   workEndMonth         varchar(10) comment '��ְ�����·�',
   workDesc             text comment '����ְ��',
   companyNature        varchar(200) comment '��˾�������ƣ�����������',
   companyScale         varchar(200) comment '��˾��ģ���ƣ�����������',
   companyIntro         text comment '��˾���',
   compaynyDepartment   varchar(200) comment '���ڲ���',
   reportObject         varchar(100) comment '�㱨����',
   monthlySalary        varchar(20) comment '��н',
   workPerformance      text comment '����ҵ��',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (workId)
);

alter table wlt_resume_workhistory comment '���˼�����������';

/*==============================================================*/
/* Table: wlt_resume_working                                    */
/*==============================================================*/
create table wlt_resume_working
(
   hunterId             bigint not null comment '��ͷId',
   companyFullName      varchar(100) comment '��˾ȫ��',
   areacode             varchar(10) comment '��˾��������',
   phonenumber          varchar(15) comment '��˾�����ܻ���',
   phoneext             varchar(10) comment '��˾�ֻ���',
   cityId               int comment '��ǰʵ�ڵس���Id',
   cityName             varchar(50) comment '��ǰʵ�ڵس�������',
   workTitle            varchar(100) comment 'Ŀǰͷ�Σ�����������',
   workStartYear        varchar(10) comment '��ҵ��ʼʱ�����',
   businessIdStr        varchar(100) comment '�ó���ҵId�ַ�(����� , �ָ�ƴ��)',
   businessNameStr      varchar(500) comment '�ó���ҵ�����ַ�(����� , �ָ�ƴ��)',
   functionIdStr        varchar(100) comment '�ó�ְ��Id�ַ�(����� , �ָ�ƴ��)',
   functionNameStr      varchar(500) comment '�ó�ְ�������ַ�(����� , �ָ�ƴ��)',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (hunterId)
);

alter table wlt_resume_working comment '��ͷ�û���ҵ��֤��Ϣ';

/*==============================================================*/
/* Table: wlt_sendmessage                                       */
/*==============================================================*/
create table wlt_sendmessage
(
   msgId                int not null auto_increment comment '��ϢId',
   sendUserId           bigint comment '������Id',
   sendUSendName        varchar(50) comment '����������',
   sendType             tinyint not null comment '����������(1=��ҵ,2=��ͷ)',
   receiveUserId        bigint comment '������Id',
   receiveUserName      tinyint comment '����������(1=��ҵ,2=��ͷ)',
   content              varchar(500) comment '��Ϣ����',
   status               tinyint comment '��Ϣ״̬(0=δ��,1= �Ѷ�)',
   createTime           datetime not null comment '����ʱ��',
   lastUpdateTime       datetime not null comment '����޸�ʱ��',
   primary key (msgId)
);

alter table wlt_sendmessage comment '��ͷ��ҵվ����';


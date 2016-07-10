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
   父目录Id                int,
   目录名称                 varchar(256),
   备注                   varchar(256),
   创建时间                 timestamp not null,
   primary key (Id)
);

alter table wlt_catalog comment '配置各种名称，如企业性质、行业分类等';

/*==============================================================*/
/* Table: wlt_company                                           */
/*==============================================================*/
create table wlt_company
(
   companyId            bigint not null auto_increment comment '企业Id',
   partentId            bigint not null default 1 comment '父企业Id(0=一级公司,默认1=子企业，管理员通过分配，此字段为父企业Id)',
   companyFullName      varchar(100) comment '公司名称',
   phoneImagePath       varchar(200) comment '头像照片地址',
   businessId           int comment '行业Id',
   businessName         varchar(100) comment '行业名称',
   scaleId              int comment '规模Id',
   scaleName            varchar(100) comment '规模名称',
   personNumber         varchar(50) comment '员工人数',
   contract             varchar(50) comment '联系人',
   phone                varchar(50) comment '电话',
   mobile               varchar(11) comment '手机',
   twoDimensionCode     varchar(100) comment '二维码',
   address              varchar(100) comment '地址',
   email                varchar(100) comment '邮箱',
   intro                text comment '简介',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (companyId)
);

alter table wlt_company comment '企业基本信息';

/*==============================================================*/
/* Table: wlt_companyUserInfo                                   */
/*==============================================================*/
create table wlt_companyUserInfo
(
   companyUserId        bigint not null auto_increment comment '企业Id',
   companyId            bigint comment '所属企业Id',
   mobile               varchar(11) not null comment '手机号码',
   loginName            varchar(50) not null comment '登录名称',
   loginPwd             varchar(50) not null comment '登录密码',
   handlerStatus        tinyint not null comment '处理状态(手机验证-->未认证-->认证猎头)',
   regTime              datetime comment '注册时间',
   lastLoginTime        datetime comment '最后一次登录时间',
   status               tinyint comment '状态',
   IsRealNameCertification tinyint comment '实名认证状态(0=为认证，1=已认证)',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (companyUserId)
);

alter table wlt_companyUserInfo comment '企业用户';

/*==============================================================*/
/* Table: wlt_company_collect                                   */
/*==============================================================*/
create table wlt_company_collect
(
   Id                   bigint not null auto_increment comment '主键',
   companyId            bigint not null comment '公司Id',
   hunterId             bigint not null comment '猎头Id',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (Id)
);

alter table wlt_company_collect comment '企业收藏猎头';

/*==============================================================*/
/* Table: wlt_headhunter                                        */
/*==============================================================*/
create table wlt_headhunter
(
   hunterId             bigint not null auto_increment comment '猎头Id',
   mobile               varchar(11) not null comment '手机号码',
   loginName            varchar(50) not null comment '登录名称',
   loginPwd             varchar(50) not null comment '登录密码',
   handlerStatus        tinyint not null comment '处理状态(手机验证-->未认证-->认证猎头)',
   regTime              datetime comment '注册时间',
   lastLoginTime        datetime comment '最后一次登录时间',
   status               tinyint comment '状态',
   IsRealNameCertification tinyint comment '实名认证状态(0=为认证，1=已认证)',
   IsWorkingCertification tinyint comment '从业认证(0=未提交,1=认证中，1=已认证)',
   IsPhoneCertification tinyint comment '照片认证(0=未提交,1=认证中，1=已认证)',
   phoneImagePath       varchar(200) comment '头像照片地址',
   publicPositionCount  int comment '个人发布职位数',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (hunterId)
);

alter table wlt_headhunter comment '猎头用户';

/*==============================================================*/
/* Table: wlt_headhunter_identity                               */
/*==============================================================*/
create table wlt_headhunter_identity
(
   hunterId             bigint not null comment '猎头Id',
   realName             varchar(50) comment '真实姓名',
   IdCarNo              varchar(20) comment '身份证号码',
   mobile               varchar(11) comment '手机号码',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (hunterId)
);

alter table wlt_headhunter_identity comment '猎头信息真实身份信息';

/*==============================================================*/
/* Table: wlt_index_ad                                          */
/*==============================================================*/
create table wlt_index_ad
(
   adId                 int not null auto_increment comment '主键',
   title                varchar(100) comment '显示标题',
   imgUrl               varchar(200) comment '图片地址',
   skipUrl              varchar(200) comment '跳转url',
   sortNo               int comment '顺序',
   lastUpdateTime       datetime not null comment '最后修改时间',
   createTime           datetime not null comment '创建时间',
   primary key (adId)
);

alter table wlt_index_ad comment '首页广告';

/*==============================================================*/
/* Table: wlt_location                                          */
/*==============================================================*/
create table wlt_location
(
   area_id              int not null auto_increment comment 'Id',
   area_name            varchar(50) not null comment '栏目名',
   parent_id            int not null comment '父栏目',
   short_name           varchar(50) comment '短栏目名',
   pinyin               varchar(100) comment '拼音',
   lng                  varchar(20) comment '经度',
   lat                  varchar(20) comment '纬度',
   level                tinyint not null comment '区域等级 0=自治区,1=省份,2=一级城市,3=县区,4=街道',
   recommend            int,
   sort                 int,
   primary key (area_id)
);

alter table wlt_location comment '位置表(包括省,市、区、县、街道)';

/*==============================================================*/
/* Table: wlt_mobile_message                                    */
/*==============================================================*/
create table wlt_mobile_message
(
   MessgeId             bigint not null auto_increment comment 'MessgeId',
   mobile               varchar(11) not null comment '手机号码',
   seccode              varchar(8) not null comment '发送验证码',
   effectiveTime        datetime not null comment '有效时间',
   IsUse                bool not null comment '是否验证过',
   CreateTime           datetime not null comment '创建时间',
   LastUpdateTime       datetime comment '最后修改时间',
   primary key (MessgeId)
);

alter table wlt_mobile_message comment '短信验证码信息';

/*==============================================================*/
/* Table: wlt_personDelegate                                    */
/*==============================================================*/
create table wlt_personDelegate
(
   Id                   bigint not null auto_increment comment '主键',
   personId             bigint not null comment '个人Id',
   hunterId             bigint not null comment '猎头Id',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (Id)
);

alter table wlt_personDelegate comment '个人委托猎头';

/*==============================================================*/
/* Table: wlt_person_resume_log                                 */
/*==============================================================*/
create table wlt_person_resume_log
(
   Id                   bigint not null auto_increment comment '主键',
   personId             bigint not null comment '个人Id',
   posId                bigint not null comment '职位Id',
   sendDate             datetime not null comment '投递日期',
   CreateTime           datetime not null comment '创建时间',
   LastUpdateTime       datetime not null comment '最后修改时间',
   primary key (Id)
);

alter table wlt_person_resume_log comment '个人投递简历记录';

/*==============================================================*/
/* Table: wlt_personcollect                                     */
/*==============================================================*/
create table wlt_personcollect
(
   Id                   bigint not null auto_increment comment '主键Id',
   personId             bigint not null comment '个人Id',
   posId                bigint not null comment '职位Id',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime comment '最后修改时间',
   primary key (Id)
);

alter table wlt_personcollect comment '个人收藏职位';

/*==============================================================*/
/* Table: wlt_personinfo                                        */
/*==============================================================*/
create table wlt_personinfo
(
   personId             bigint not null auto_increment comment '主建、自增长',
   mobile               varchar(11) not null comment '手机号码',
   loginName            varchar(50) not null comment '登录名称',
   loginPwd             varchar(50) not null comment '登录密码',
   handlerStatus        tinyint not null comment '处理状态(1=手机验证-->2=填写名片-->3=拥有简历)',
   regTime              datetime comment '注册时间',
   lastLoginTime        datetime comment '最后一次登录时间',
   status               tinyint comment '状态(0=正常,1=不能正常使用系统)',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (personId)
);

alter table wlt_personinfo comment '个人用户';

/*==============================================================*/
/* Table: wlt_personinfo_basic                                  */
/*==============================================================*/
create table wlt_personinfo_basic
(
   Id                   bigint not null auto_increment comment '主键Id',
   personId             bigint comment '个人Id',
   mobil                varchar(11) comment '手机号码',
   email                varchar(100) comment 'Email',
   realname             varchar(50) comment '真实姓名',
   birthdate            date comment '出生年月',
   gender               tinyint comment '性别(0=男,1=女)',
   marriageState        tinyint comment '婚姻状态(0=保密,1=已婚,2=未婚)',
   beginWorkingYear     date comment '开始工作年份',
   jobTitle             varchar(100) comment '职位名称',
   edu                  varchar(100) comment '最高学历',
   cityId               int comment '常住城市Id',
   cityName             varchar(50) comment '常住城市名称',
   inCompanyName        varchar(50) comment '当前所在公司名称',
   businessId           int comment '行业Id',
   businessName         varchar(200) comment '行业名称(父+子落地)',
   functionId           int comment '职能Id',
   functionName         varchar(200) comment '职能名称(父+子落地)',
   phoneImagePath       varchar(200) comment '头像照片地址',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (Id)
);

alter table wlt_personinfo_basic comment '个人用户基本信息名片';

/*==============================================================*/
/* Table: wlt_positioninfo                                      */
/*==============================================================*/
create table wlt_positioninfo
(
   posId                bigint not null auto_increment comment '职位Id',
   hunterId             bigint not null comment '猎头Id',
   posName              varchar(200) not null comment '职位名称',
   businessId           int comment '行业Id',
   businessName         varchar(200) comment '行业名称(落地)',
   provinceId           int comment '职位属在省份Id（level=1）',
   provinceName         varchar(50) comment '职位属在省份名称',
   cityId               int comment '职位属在城市Id(level=2)',
   cityName             varchar(50) comment '职位属在城市名称',
   districtsId          int comment '职位属在区县Id(level=3)',
   districtsName        varchar(50) comment '职位属在区县名称',
   streetId             int comment '职位属在街道(level=4)',
   streetName           varchar(50) comment '职位属在街道名称',
   salaryId             int comment '职位薪资范围Id',
   salaryName           varchar(50) comment '职位薪资范围文本',
   educationalId        int comment '职位要求学历范围Id',
   educationalText      varchar(50) comment '职位要求学历范围文本',
   experienceId         int comment '职位需要工作经验范围Id',
   experienceName       varchar(50) comment '职位需要工作经验范围Id文本',
   companyName          varchar(100) comment '职位对于公司名称',
   companyBackgroundIdStr varchar(500) comment '职位对应公司背景Id字符串',
   companyBackgroundNameStr varchar(1000) comment '职位对应公司背景姓名字符串（用，拼接）',
   companyFeatureIdStr  varchar(500) comment '职位对应公司背景Id字符串',
   companyFeatureIdNameStr varchar(1000) comment '职位对应公司背景姓名字符串（用，拼接）',
   status               tinyint comment '职位状态',
   pvCount              int comment '职位查看数',
   sendCount            int comment '职位投递数',
   sharedCount          int comment '职位分享数',
   publishTime          datetime comment '职位发布时间(刷新)',
   CreateTime           datetime not null comment '创建时间',
   LastUpdateTime       datetime comment '最后修改时间',
   primary key (posId)
);

alter table wlt_positioninfo comment '猎头职位信息表';

/*==============================================================*/
/* Table: wlt_positioninfo_content                              */
/*==============================================================*/
create table wlt_positioninfo_content
(
   posId                bigint not null comment '职位Id',
   underlingNumber      int comment '下属人数',
   compaynyDepartment   varchar(200) comment '所在部门',
   reportObject         varchar(100) comment '汇报对象',
   postionDesc          text comment '汇报对象',
   majors               text comment '专业要求',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (posId)
);

alter table wlt_positioninfo_content comment '猎头职位内容信息';

/*==============================================================*/
/* Table: wlt_resume                                            */
/*==============================================================*/
create table wlt_resume
(
   resumeId             bigint not null auto_increment comment '简历Id',
   personId             bigint comment '个人Id',
   name                 varchar(100) comment '简历名称',
   lastHandlerTime      datetime comment '最后操作时间',
   languageType         tinyint comment '语种类型(0=中文，1=英文)',
   showLevel            tinyint comment '简历可见度(0=开放简历，1=隐藏简历..)',
   IsDelete             bool comment '是否删除',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (resumeId)
);

alter table wlt_resume comment '就职者简历信息';

/*==============================================================*/
/* Table: wlt_resume_edu                                        */
/*==============================================================*/
create table wlt_resume_edu
(
   eduId                bigint not null auto_increment comment '教育经历Id',
   resumeId             bigint comment '简历Id',
   personId             bigint comment '个人Id',
   schoolName           varchar(100) comment '学校教育名称',
   majorName            varchar(100) comment '专业名称',
   attendStartYear      varchar(10) comment '就读开始年份',
   attendStartMonth     varchar(10) comment '就读开始月份',
   attendEndYear        varchar(10) comment '就读结束年份',
   attendEndMonth       varchar(10) comment '就读结束月份',
   degreeId             int comment '学历Id(来自下拉)',
   degreeName           varchar(100) comment '学历名称',
   IsRecruitment        bool comment '是否统招',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime comment '最后修改时间',
   primary key (eduId)
);

alter table wlt_resume_edu comment '个人简历_教育经历';

/*==============================================================*/
/* Table: wlt_resume_exper                                      */
/*==============================================================*/
create table wlt_resume_exper
(
   experId              bigint not null auto_increment comment '主键',
   resumeId             bigint comment '简历Id',
   personId             bigint comment '个人Id',
   projectName          varchar(100) not null comment '项目名称',
   companyName          varchar(100) not null comment '公司名称',
   productduty          varchar(100) comment '项目职务',
   startYear            varchar(10) comment '开始年份',
   startMonth           varchar(10) comment '开始月份',
   endYear              varchar(10) comment '结束年份',
   endMonth             varchar(10) comment '结束月份',
   projectDesc          text comment '项目描述',
   projectFuntion       text comment '项目职责',
   projectPerformance   text comment '项目业绩',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (experId)
);

alter table wlt_resume_exper comment '个人简历项目经验';

/*==============================================================*/
/* Table: wlt_resume_jobIntension                               */
/*==============================================================*/
create table wlt_resume_jobIntension
(
   resumeId             bigint not null comment '简历Id',
   personId             bigint not null comment '个人Id',
   expectBusinessId     int comment '期望行业Id',
   expectBusinessName   varchar(200) comment '期望行业名称（父+子落地）',
   expectFunctionId     int comment '期望职能Id',
   expectFunctionName   varchar(200) comment '期望职能名称（父+子落地）',
   expectCityId         int comment '期望工作城市Id',
   expectCityName       varchar(200) comment '期望工作城市名称',
   expectSalaryId       int comment '期望年薪范围Id（来自下拉）',
   expectSalary         varchar(200) comment '期望年薪范围（来自下拉）',
   expectIsPrivate      bool comment '期望年薪是否显示保密',
   currentSalaryId      int comment '目前年薪范围Id（来自下拉）',
   currentSalary        varchar(200) comment '目前年薪范围（来自下拉）',
   currentIsPrivate     bool comment '目前年薪是否显示保密',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime comment '最后修改时间',
   primary key (resumeId, personId)
);

alter table wlt_resume_jobIntension comment '就职者简历内容表';

/*==============================================================*/
/* Table: wlt_resume_language                                   */
/*==============================================================*/
create table wlt_resume_language
(
   langId               bigint not null auto_increment comment '主键Id',
   resumeId             bigint comment '简历Id',
   personId             bigint comment '个人Id',
   language             varchar(20) not null comment '语言',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (langId)
);

alter table wlt_resume_language comment '个人简历语言能力';

/*==============================================================*/
/* Table: wlt_resume_selfevaluation                             */
/*==============================================================*/
create table wlt_resume_selfevaluation
(
   resumeId             bigint not null comment '简历Id',
   personId             bigint not null comment '个人Id',
   evaluate             text comment '评价',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (resumeId, personId)
);

alter table wlt_resume_selfevaluation comment '个人简历自我评价';

/*==============================================================*/
/* Table: wlt_resume_technical                                  */
/*==============================================================*/
create table wlt_resume_technical
(
   techId               bigint not null auto_increment comment '主键Id',
   resumeId             bigint comment '简历Id',
   personId             bigint comment '个人Id',
   techName             varchar(50) comment '擅长技术名称',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (techId)
);

alter table wlt_resume_technical comment '个人简历擅长技能';

/*==============================================================*/
/* Table: wlt_resume_workhistory                                */
/*==============================================================*/
create table wlt_resume_workhistory
(
   workId               bigint not null auto_increment comment '经历Id',
   resumeId             bigint comment '简历Id',
   personId             bigint comment '个人Id',
   companyName          varchar(200) comment '公司名称',
   workBusinessId       int comment '期望行业Id',
   workBusinessName     varchar(200) comment '期望行业名称（父+子落地）',
   workFunctionId       int comment '期望职能Id',
   workFunctionName     varchar(200) comment '期望职能名称（父+子落地）',
   workCityId           int comment '期望工作城市Id',
   workCityName         varchar(200) comment '期望工作城市名称',
   underlingNumber      int comment '下属人数',
   workStartYear        varchar(10) comment '任职开始年份',
   workStartMonth       varchar(10) comment '任职开始月份',
   workEndYear          varchar(10) comment '任职结束年份',
   workEndMonth         varchar(10) comment '任职结束月份',
   workDesc             text comment '工作职责',
   companyNature        varchar(200) comment '公司性质名称（来自下拉）',
   companyScale         varchar(200) comment '公司规模名称（来自下拉）',
   companyIntro         text comment '公司简介',
   compaynyDepartment   varchar(200) comment '所在部门',
   reportObject         varchar(100) comment '汇报对象',
   monthlySalary        varchar(20) comment '月薪',
   workPerformance      text comment '工作业绩',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (workId)
);

alter table wlt_resume_workhistory comment '个人简历工作经历';

/*==============================================================*/
/* Table: wlt_resume_working                                    */
/*==============================================================*/
create table wlt_resume_working
(
   hunterId             bigint not null comment '猎头Id',
   companyFullName      varchar(100) comment '公司全称',
   areacode             varchar(10) comment '公司座机区号',
   phonenumber          varchar(15) comment '公司座机总机号',
   phoneext             varchar(10) comment '公司分机号',
   cityId               int comment '当前实在地城市Id',
   cityName             varchar(50) comment '当前实在地城市名称',
   workTitle            varchar(100) comment '目前头衔（来自下拉）',
   workStartYear        varchar(10) comment '从业开始时间年份',
   businessIdStr        varchar(100) comment '擅长行业Id字符(多个已 , 分割拼接)',
   businessNameStr      varchar(500) comment '擅长行业名称字符(多个已 , 分割拼接)',
   functionIdStr        varchar(100) comment '擅长职能Id字符(多个已 , 分割拼接)',
   functionNameStr      varchar(500) comment '擅长职能名称字符(多个已 , 分割拼接)',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (hunterId)
);

alter table wlt_resume_working comment '猎头用户从业认证信息';

/*==============================================================*/
/* Table: wlt_sendmessage                                       */
/*==============================================================*/
create table wlt_sendmessage
(
   msgId                int not null auto_increment comment '消息Id',
   sendUserId           bigint comment '发送人Id',
   sendUSendName        varchar(50) comment '发送人姓名',
   sendType             tinyint not null comment '发送人类型(1=企业,2=猎头)',
   receiveUserId        bigint comment '接收人Id',
   receiveUserName      tinyint comment '接收人类型(1=企业,2=猎头)',
   content              varchar(500) comment '消息内容',
   status               tinyint comment '消息状态(0=未读,1= 已读)',
   createTime           datetime not null comment '创建时间',
   lastUpdateTime       datetime not null comment '最后修改时间',
   primary key (msgId)
);

alter table wlt_sendmessage comment '猎头企业站内信';


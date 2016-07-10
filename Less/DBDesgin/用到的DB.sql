
select * from apl_catalog where parent_id=33  --企业性质


--插入猎头sql
INSERT INTO `jobs`.`wlt_headhunter` (
`hunterId`, 
`mobile`, 
`loginName`, 
`loginPwd`, 
`handlerStatus`, 
`regTime`, 
`lastLoginTime`, 
`status`, 
`IsRealNameCertification`, 
`IsWorkingCertification`,
`IsPhoneCertification`, 
`phoneImagePath`, 
`publicPositionCount`, 
 FreeStatus,
`createTime`, 
`lastUpdateTime`) 
VALUES (
'3', 
'17751728413', 
'17751728413', 
'e10adc3949ba59abbe56e057f20f883e', 
3,
now(), 
now(), 
'0', 
1, 
1, 
1, 
NULL, 
1, 
0,
'2016-05-20 22:36:17', 
'2016-05-20 22:36:17');

--猎头真实信息
INSERT INTO wlt_headhunter_identity
VALUES
	(
		3,
		'张建',
		'4305231965354656214',
		'17751728413',
		NOW(),
		NOW()
	)


--猎头背景信息
INSERT INTO wlt_headhunter_working
VALUES
	(
		3,
		'上海网络科技有限公司',
		'021',
		'5768888',
		'17343',
		310100,
		'上海',
		'招聘顾问',
		8,
		'112,117',
		'计算机软件,互联网/电子商务',
    '243,244',
		'Web前端开发,网站架构设计师',
		'本人擅长行业: 制造，消费电子，IT，汽车，医疗，精密仪器，航空等行业 擅长职位: 销售（管理）类，人力资源类，IT设计类，工艺工程类,项目管理类,质量管理类，采购类，研发类 顾问介绍: 本人专门为行业内世界顶级消费电子，互联网，信息技术与服务等公司提供猎头服务并招募中高级技术人才，客户很靠谱，就等你了！',
		NOW(),
		NOW())


--猎头服务过的企业
INSERT INTO wlt_headhunter_serviceCompany
VALUES
	(
    1,
		3,
		'淘宝网',
		'../logo/taobao.png',
		'www.taobao.com',
		NOW(),
		NOW()
	);

INSERT INTO wlt_headhunter_serviceCompany
VALUES
	(
    2,
		3,
		'携程',
		'../logo/ctrip.png',
		'www.ctrip.com',
		NOW(),
		NOW()
	);



	--嵌入职位信息
	INSERT INTO wlt_positioninfo
VALUES
	(
		1,
		3,
		'高级Java开发工程师',
		199,
		'互联网软件开发工程师',
		310000,
		'上海市',
		310100,
		'上海',
		null,
		null,
		null,
		null,
		1566,
		'40-50万',
		65,
		'本科',
		176,
		'5-10年',
		'上海网路科技有限公司',
		NULL,
		null,
		null,
		null,
		0,
		0,
		0,
		0,
		NOW(),
		NOW(),
		NOW());

--*****************************�������ݿ�*****************************
-- CREATE DATABASE [DB_wwj] ON  PRIMARY
-- ( NAME = 'DB_wwj', FILENAME = 'D:\04_MyDataBase\DB_wwj.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON
-- ( NAME = 'DB_wwj_log', FILENAME = 'D:\04_MyDataBase\DB_wwj_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
-- GO

use master  --ָ����ʼʹ��ϵͳ���ݿ�
go
--�����Ϊ"DB_wwj"�����ݿ��Ƿ���ڣ���ѯϵͳ��
if exists(select * from sysdatabases where name='DB_wwj')
 drop database DB_wwj   --���������ɾ����
go  --�����������־
create database DB_wwj
on primary
(
  name='DB_wwj',    --���ݿ��߼���
  filename='D:\04_MyDataBase\DB_wwj.mdf',   --���ݿ��ļ���������·��
  MAXSIZE =UNLIMITED    --�ļ����������ֵ
  filegrowth=15%,   --�ļ�������
  size=16384KB  --��ʼ��С
)
log on
(
  name='DB_wwj_log',    --��־�ļ��߼���
  filename='D:\04_MyDataBase\DB_wwj_log.ldf',   --��־�ļ�������
  MAXSIZE=2048GB    --��־�ļ����ֵ
  filegrowth=5%,    --��־�ļ�������
  size=6272KB   --��־�ļ���ʼ��С
)
go





--*****************************������*************************

--�û���
use DB_wwj
create table Users
(
userID int not null, --XJJZ֤���ţ�������Ψһ��ʶ
userIP nvarchar(20) not null, --��IP��ַ
userName nvarchar(10) not null, --�û���������
userLevel int not null, --�û�����
userDW int not null, --�û���λ
UserRole int not null default '0', --��Ա��ɫ
userPassWord nvarchar(20) not null,
primary Key (userID)
)
go

--��λ��
use DB_wwj
create table DWs
(
dwID int not null, --��λID��������Ψһ��ʶ
dwName nvarchar(50),--��λ����
primary Key (dwID)
)
go

--�����
use DB_wwj
create table Levels
(
levelID int not null, --����ID��������Ψһ��ʶ
leverName nvarchar(20), --�������ƣ���JX
primary key (levelID)
)
go

--��־��
use DB_wwj
create table Logs
(
logID int not null, --��־ID��������Ψһ��ʶ
logUserID int not null, --����ԱID�����
logOperation text not null, --��������
logTimeSign datetime not null default getdate(),--��ǰ������ʱ��
primary key (logID)
)
go

--��Ա����
use DB_wwj
create table Roles
(
roleID int not null, --��ɫID��������Ψһ��ʶ
roleName nvarchar(20), --��ɫ���ƣ�����Ա���
primary key (roleID)
)
go

--*****************��֤�������***********************
use DB_wwj
select * from Users
select * from DWs
select * from Logs
select * from Levels
select * from Roles
go

--*******************��1ϵ�н������ 2021.1.24****************

/*
sql��䲻��ֱ�Ӹı��ֶβ���Ϊ������������Ҫ�Ƚ����ֶ�ɾ�������������ֶΡ�

alter table A  drop column [ID]--ɾ����AԭID��

alter table A  add [ID] bigint identity(1,1)--��A����ID�в���Ϊ����������Ϊbigint

*/

use DB_wwj
--�ļ����ͱ�
create table FileClass
(
    fileClassID int not null,   --�ļ������
    fileClassName nvarchar(20), --�ļ��������
    primary key(fileClassID)
)
--�ļ���Ϣ��
create table FileInfo
(
    fileID bigint identity(1,1) not null,    --����Ϊ��int�ͣ�����Ϊ1������
    fileName nvarchar(2000) not null,   --�ļ����ƣ����ֻ����4000
    fileDate nvarchar(12) not null,  --�ļ�����
    fileClassID int not null,    --�ļ����
    fileUserID int not null, --�ļ�ӵ����ID
    fileNote nvarchar(500),  --�ļ���ע
    fileDatas image not null,   --�ļ�������
    status int not null, --�ļ�ɾ����ʶ
    --workClassID int not null,   --�ļ�����ʶ
    primary key(fileID)
)
go

--���ļ���Ϣ�����һ���ļ������
use DB_wwj
alter table FileInfo add fileNumbers nvarchar(20) not null
go

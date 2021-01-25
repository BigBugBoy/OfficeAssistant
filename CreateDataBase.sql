
--*****************************�������ݿ�*****************************
CREATE DATABASE [DB_wwj] ON  PRIMARY
( NAME = 'DB_wwj', FILENAME = 'D:\04_MyDataBase\DB_wwj.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
LOG ON
( NAME = 'DB_wwj_log', FILENAME = 'D:\04_MyDataBase\DB_wwj_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO


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

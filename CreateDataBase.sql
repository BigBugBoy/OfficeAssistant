
--*****************************创建数据库*****************************
CREATE DATABASE [DB_wwj] ON  PRIMARY
( NAME = 'DB_wwj', FILENAME = 'D:\04_MyDataBase\DB_wwj.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
LOG ON
( NAME = 'DB_wwj_log', FILENAME = 'D:\04_MyDataBase\DB_wwj_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO


--*****************************创建表*************************

--用户表
use DB_wwj
create table Users
(
userID int not null, --XJJZ证件号，主键，唯一标识
userIP nvarchar(20) not null, --绑定IP地址
userName nvarchar(10) not null, --用户名，汉字
userLevel int not null, --用户级别
userDW int not null, --用户单位
UserRole int not null default '0', --人员角色
userPassWord nvarchar(20) not null,
primary Key (userID)
)
go

--单位表
use DB_wwj
create table DWs
(
dwID int not null, --单位ID，主键，唯一标识
dwName nvarchar(50),--单位名称
primary Key (dwID)
)
go

--级别表
use DB_wwj
create table Levels
(
levelID int not null, --级别ID，主键，唯一标识
leverName nvarchar(20), --级别名称，即JX
primary key (levelID)
)
go

--日志表
use DB_wwj
create table Logs
(
logID int not null, --日志ID，主键，唯一标识
logUserID int not null, --操作员ID，外键
logOperation text not null, --所作操作
logTimeSign datetime not null default getdate(),--当前服务器时间
primary key (logID)
)
go

--人员类别表
use DB_wwj
create table Roles
(
roleID int not null, --角色ID，主键，唯一标识
roleName nvarchar(20), --角色名称，即人员类别
primary key (roleID)
)
go

--*****************验证表建立情况***********************
use DB_wwj
select * from Users
select * from DWs
select * from Logs
select * from Levels
select * from Roles
go

--*******************表1系列建立完成 2021.1.24****************


--*****************************创建数据库*****************************
-- CREATE DATABASE [DB_wwj] ON  PRIMARY
-- ( NAME = 'DB_wwj', FILENAME = 'D:\04_MyDataBase\DB_wwj.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON
-- ( NAME = 'DB_wwj_log', FILENAME = 'D:\04_MyDataBase\DB_wwj_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
-- GO

use master  --指定初始使用系统数据库
go
--检测名为"DB_wwj"的数据库是否存在，查询系统表
if exists(select * from sysdatabases where name='DB_wwj')
 drop database DB_wwj   --如果存在则删除掉
go  --批处理结束标志
create database DB_wwj
on primary
(
  name='DB_wwj',    --数据库逻辑名
  filename='D:\04_MyDataBase\DB_wwj.mdf',   --数据库文件名，包含路径
  MAXSIZE =UNLIMITED    --文件不限制最大值
  filegrowth=15%,   --文件增长率
  size=16384KB  --初始大小
)
log on
(
  name='DB_wwj_log',    --日志文件逻辑名
  filename='D:\04_MyDataBase\DB_wwj_log.ldf',   --日志文件物理名
  MAXSIZE=2048GB    --日志文件最大值
  filegrowth=5%,    --日志文件增长率
  size=6272KB   --日志文件初始大小
)
go





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

/*
sql语句不能直接改变字段并设为自增，所以需要先将该字段删除，再新增该字段。

alter table A  drop column [ID]--删除表A原ID列

alter table A  add [ID] bigint identity(1,1)--表A新增ID列并设为自增，类型为bigint

*/

use DB_wwj
--文件类型表
create table FileClass
(
    fileClassID int not null,   --文件类别编号
    fileClassName nvarchar(20), --文件类别名称
    primary key(fileClassID)
)
--文件信息表
create table FileInfo
(
    fileID bigint identity(1,1) not null,    --这是为长int型，步长为1，自增
    fileName nvarchar(2000) not null,   --文件名称，最大只能是4000
    fileDate nvarchar(12) not null,  --文件日期
    fileClassID int not null,    --文件类别
    fileUserID int not null, --文件拥有者ID
    fileNote nvarchar(500),  --文件备注
    fileDatas image not null,   --文件流数据
    status int not null, --文件删除标识
    --workClassID int not null,   --文件类别标识
    primary key(fileID)
)
go

--给文件信息表添加一个文件编号列
use DB_wwj
alter table FileInfo add fileNumbers nvarchar(20) not null
go

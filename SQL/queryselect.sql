/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [USER_ID]
      ,[LOGIN_NAME]
      ,[PASS]
      ,[ENCODE_PASS]
      ,[LOGIN_TIME]
      ,[LOGIN_STATUS]
  FROM [phanhiep].[dbo].[USER_INFO]

SELECT * FROM [phanhiep].[dbo].[USER_INFO] WHERE [LOGIN_NAME] = 'hiep'
delete from [phanhiep].[dbo].[USER_INFO] where 1 = 1

SELECT TOP 1000 [USER_ID]
      ,[VALUE_INCOME]
      ,[TYPE_INCOME]
      ,[DATE_INCOME]
      ,[NOTE_INCOME]
  FROM [phanhiep].[dbo].[INCOME]

SELECT TOP 1000 [USER_ID]
      ,[VALUE_SPENDING]
      ,[TYPE_SPENDING]
      ,[DATE_SPENDING]
      ,[NOTE_SPENDING]
  FROM [phanhiep].[dbo].[SPENDING]

  select * FROM [phanhiep].[dbo].[INCOME] where [USER_ID] = 16 AND YEAR(DATE_INCOME) = '2021' AND MONTH(DATE_INCOME) = '3' order by DATE_INCOME DESC
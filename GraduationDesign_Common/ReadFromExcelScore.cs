﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_Common
{
    public class ReadFromExcelScore
    {
        /// <summary>
        /// 从Excel表中获取数据
        /// </summary>
        /// <param name="strExcelPath">Excel表的路径</param>
        /// <param name="tableName">需要获取的表名称</param>
        /// <returns></returns>
        public DataTable GetExcelTableByOleDB(string strExcelPath, string tableName)
        {
            try
            {
                DataTable dtExcel = new DataTable();
                //数据表
                DataSet ds = new DataSet();


                //获取文件名与扩展名
                string strFileName = System.IO.Path.GetFileName(strExcelPath);
                string strExtension = System.IO.Path.GetExtension(strExcelPath);


                //Excel连接字符串拼接
                OleDbConnection objConn = null;
                //根据后缀名决定使用的连接方式
                switch (strExtension)
                {
                    //XLS格式（97-03）
                    case ".xls":
                        objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
                        break;
                    //XLSX格式（07-16）
                    case ".xlsx":
                        objConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"");
                        break;
                    //格式有误，不是Excel
                    default:
                        objConn = null;
                        break;
                }
                if (objConn == null)
                {
                    return null;
                }

                objConn.Open();




                //获取Excel中所有Sheet表的信息
                //System.Data.DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                //获取Excel的第一个Sheet表名
                //string tableName = schemaTable.Rows[0][2].ToString().Trim();


                string strSql = "select * from [" + tableName + "]";

                //获取Excel指定Sheet表中的信息
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                //填充数据
                myData.Fill(ds, tableName);
                objConn.Close();
                //dtExcel即为excel文件中指定表中存储的信息
                dtExcel = ds.Tables[tableName];
                return dtExcel;
            }
            catch
            {
                return null;
            }
        }

    }
}

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FytSoa.Common.ExportHelper
{
    public class ExportExcel
    {
        #region fields
        private IWorkbook _workbook = null;
        private FileStream _fs = null;
        #endregion

        #region 导出Excel
        /// <summary>
        /// 描述：将DataTable数据写入Excel,并保存到指定的路径
        /// 创建标识：dangfy on 20160112
        /// </summary>
        /// <param name="data">要导出的DataTable数据源</param>
        /// <param name="headers">表头Key=DataTable列名，Value=要写入Excel的表头；如果此处设置为Null,则将列名作为表头写入</param>
        /// <param name="filePath">文件保存的绝对路径，包含文件名</param>
        /// <param name="sheetName">工作表名称，默认"Sheet1"</param>
        /// <returns>返回值：大于0=导出成功，其它=导出失败</returns>
        public int DtToExcel(DataTable data, Dictionary<string, string> headers, string filePath, string sheetName = "Sheet1")
        {
            int ret = -1;
            using (_fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //填充数据
                ret = DtWriteToExcel(data, headers, filePath, sheetName);
                _workbook.Write(_fs); //写入到excel
            }
            return ret;
        }
        /// <summary>
        /// 描述：将DataTable数据写入Excel,返回MemoryStream供客户端下载
        /// 创建标识：dangfy on 20160112
        /// </summary>
        /// <param name="data">要导出的DataTable数据源</param>
        /// <param name="headers">表头Key=DataTable列名，Value=要写入Excel的表头；如果此处设置为Null,则将列名作为表头写入</param>
        /// <param name="fileName">文件名</param>
        /// <param name="sheetName">工作表名称，默认"Sheet1"</param>
        /// <returns>返回值：Null=导出失败,其它=导出成功</returns>
        public byte[] DtToExcelByte(DataTable data, Dictionary<string, string> headers, string fileName, string sheetName = "Sheet1")
        {
            byte[] retResult = null;
            //填充数据
            int ret = DtWriteToExcel(data, headers, fileName, sheetName);
            if (ret > 0)
            {
                // 写入到客户端 
                using (MemoryStream ms = new System.IO.MemoryStream())
                {
                    _workbook.Write(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    retResult = ms.GetBuffer();
                }
            }
            return retResult;
        }
        /// <summary>
        /// 描述：将泛型List数据写入Excel,并保存到指定的路径
        /// 创建标识：dangfy on 20160112
        /// </summary>
        /// <param name="listR">要导出的List<T>数据源</param>
        /// <param name="headers">表头Key=T属性名称，Value=要写入Excel的表头；如果此处设置为Null,则将属性名作为表头写入</param>
        /// <param name="filePath">文件保存的绝对路径，包含文件名</param>
        /// <param name="sheetName">工作表名称，默认"Sheet1"</param>
        /// <returns>返回值：大于0=导出成功，其它=导出失败</returns>
        public int ListToExcel<T>(List<T> listR, Dictionary<string, string> headers, string filePath, string sheetName = "Sheet1")
        {
            int ret = 0;
            using (_fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //填充数据
                ret = ListWriteToExcel<T>(listR, headers, filePath, sheetName);
                _workbook.Write(_fs); //写入到excel
            }
            return ret;
        }
        /// <summary>
        /// 描述：将泛型List数据写入Excel,返回MemoryStream供客户端下载
        /// 创建标识：dangfy on 20160112
        /// </summary>
        /// <param name="listR">要导出的List<T>数据源</param>
        /// <param name="headers">表头Key=T属性名称，Value=要写入Excel的表头；如果此处设置为Null,则将属性名作为表头写入</param>
        /// <param name="fileName">文件名</param>
        /// <param name="sheetName">工作表名称，默认"Sheet1"</param>
        /// <returns>返回值：Null=导出失败,其它=导出成功</returns>
        public byte[] ListToToExcelByte<T>(List<T> listR, Dictionary<string, string> headers, string fileName, string sheetName = "Sheet1")
        {
            byte[] retResult = null;
            //填充数据
            int ret = ListWriteToExcel<T>(listR, headers, fileName, sheetName);
            if (ret > 0)
            {
                // 写入到客户端 
                using (MemoryStream ms = new System.IO.MemoryStream())
                {
                    _workbook.Write(ms);
                    // ms.Seek(0, SeekOrigin.Begin);
                    retResult = ms.GetBuffer();
                }
            }
            return retResult;
        }
        /// <summary>
        /// </summary>
        /// <param name="listR">要导出的List<T>数据源</param>
        /// <param name="headers">表头Key=T属性名称，Value=要写入Excel的表头；如果此处设置为Null,则将属性名作为表头写入</param>
        /// <param name="fileName">文件名</param>
        /// <param name="sheetName">工作表名称，默认"Sheet1"</param>
        /// <param name="hebing">要合并的行hebing.key是合并行的开始行,kebing.value要合并多少行</param>
        /// <returns></returns>
        public byte[] ListToToExcelByte<T>(List<T> listR, Dictionary<string, string> headers, Dictionary<int, int> hebing, string title, string subtitle, string fileName, string sheetName = "Sheet1")
        {
            byte[] retResult = null;
            //填充数据
            int ret = ListWriteToExcel<T>(listR, headers, hebing, title, subtitle, fileName, sheetName);
            if (ret > 0)
            {
                // 写入到客户端 
                using (MemoryStream ms = new System.IO.MemoryStream())
                {
                    _workbook.Write(ms);
                    // ms.Seek(0, SeekOrigin.Begin);
                    retResult = ms.GetBuffer();
                }
            }
            return retResult;
        }
        /// <summary>
        /// 直接根据T导出Excel
        /// </summary>
        public static bool ListToToExcelOutPut<T>(List<T> listR, Dictionary<string, string> headers, string fileName)
        {
            var bl = true;
            try
            {
                var bytes = new ExportExcel().ListToToExcelByte<T>(listR, headers, fileName);
                using (var ms = new MemoryStream(bytes))
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "utf-8";
                    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    if (HttpContext.Current.Request.Browser.Browser.ToLower() == "firefox")
                    {
                        HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
                    }
                    else
                    {
                        HttpContext.Current.Response.AddHeader("Content-Disposition",
                            $"attachment;filename={System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8)}");
                    }
                    ms.WriteTo(HttpContext.Current.Response.OutputStream);
                    HttpContext.Current.Response.End();
                }
            }
            catch (Exception)
            {
                bl = false;
            }
            return bl;
        }
        /// <summary>
        /// 直接根据T导出Excel
        /// </summary>
        public static bool ListToToExcelOutPut<T>(List<T> listR, Dictionary<string, string> headers, Dictionary<int, int> hebing, string title, string subtitle, string fileName)
        {
            var bl = true;
            try
            {
                var bytes = new ExportExcel().ListToToExcelByte<T>(listR, headers, hebing, title, subtitle, fileName);
                using (var ms = new MemoryStream(bytes))
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "utf-8";
                    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    if (HttpContext.Current.Request.Browser.Browser.ToString().ToLower() == "firefox")
                    {
                        HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
                    }
                    else
                    {
                        HttpContext.Current.Response.AddHeader("Content-Disposition",
                            $"attachment;filename={System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8)}");
                    }
                    ms.WriteTo(HttpContext.Current.Response.OutputStream);
                    HttpContext.Current.Response.End();
                }
            }
            catch (Exception)
            {
                bl = false;
            }
            return bl;
        }
        #endregion

        #region 导入Excel
        /// <summary>
        /// 根据上传的文件进行读取数据
        /// add huafg by 2016-05-24
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="importnum">开始导入的行，索引从0开始</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDataTable(string filePath, int importnum = 0)
        {
            try
            {
                //验证数据                
                if (!File.Exists(filePath)) return null;
                _workbook = null;
                var data = new DataTable();
                _fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (filePath.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007+版本
                    _workbook = new XSSFWorkbook(_fs);
                else if (filePath.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                    _workbook = new HSSFWorkbook(_fs);
                if (_workbook == null)
                    return null;

                //获取Sheet页
                var sheet = _workbook.GetSheetAt(0);
                //最后行数
                int rowCount = sheet.LastRowNum;

                //取得列
                if (importnum >= 0)
                {
                    //开始行
                    IRow startRw = sheet.GetRow(importnum);
                    //开始行的上一行是列
                    IRow firstRow = null;
                    firstRow = importnum > 0 ? sheet.GetRow(importnum - 1) : sheet.GetRow(0);

                    //获取最后单元格
                    int cellCount = firstRow.LastCellNum;
                    //构造表头
                    for (int j = firstRow.FirstCellNum; j < cellCount; ++j)
                    {
                        ICell cell = firstRow.GetCell(j);
                        string cellValue = cell.StringCellValue.Trim();
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            data.Columns.Add(new DataColumn(cellValue));
                        }
                    }

                    //取得数据
                    for (int i = importnum; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 发证备案表用表头行有两个
        /// by zhangxl
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="importnum"></param>
        /// <param name="importnum1"></param>
        /// <returns></returns>
        public DataTable ExcelToDataTable(string filePath, int importnum = 0, int importnum1 = 0)
        {
            try
            {
                //验证数据                
                if (!File.Exists(filePath)) return null;
                _workbook = null;
                var data = new DataTable();
                _fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (filePath.IndexOf(".xlsx") > 0) // 2007+版本
                    _workbook = new XSSFWorkbook(_fs);
                else if (filePath.IndexOf(".xls") > 0) // 2003版本
                    _workbook = new HSSFWorkbook(_fs);
                if (_workbook == null)
                    return null;

                //获取Sheet页
                var sheet = _workbook.GetSheetAt(0);
                //最后行数
                int rowCount = sheet.LastRowNum;

                //取得列
                if (importnum1 >= 0 && importnum1 <= rowCount)
                {
                    //开始行
                    IRow startRw = sheet.GetRow(importnum);
                    //开始行的上一行是列
                    IRow firstRow = null;
                    IRow SecondRow = null;
                    if (importnum > 0)
                        firstRow = sheet.GetRow(importnum - 1);
                    else
                        firstRow = sheet.GetRow(0);
                    if (importnum1 > 0)
                        SecondRow = sheet.GetRow(importnum1 - 1);
                    else
                        SecondRow = sheet.GetRow(0);
                    //获取最后单元格
                    int cellCount = firstRow.LastCellNum;
                    //构造表头
                    if (firstRow != null)
                    {
                        for (int j = firstRow.FirstCellNum; j < cellCount; ++j)
                        {
                            ICell cell = firstRow.GetCell(j);
                            ICell cell1 = SecondRow.GetCell(j);
                            string cellValue = cell.StringCellValue;
                            string cell1Value = cell1.StringCellValue;
                            if (cellValue != null && (cell1Value == null || cell1Value == ""))
                            {
                                cellValue = cellValue.Replace("\n", string.Empty).Replace("\r", string.Empty);
                                data.Columns.Add(new DataColumn(cellValue));
                            }
                            else
                            {
                                cell1Value = cell1Value.Replace("\n", string.Empty).Replace("\r", string.Empty);
                                data.Columns.Add(new DataColumn(cell1Value));
                            }
                        }
                    }

                    //取得数据
                    for (int i = importnum1; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="filePath">文件保存的绝对路径，包含文件名</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否为表头</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string filePath, string sheetName, bool isFirstRowColumn)
        {
            _workbook = null;
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = -1;
            try
            {
                _fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                    _workbook = new XSSFWorkbook(_fs);
                else if (filePath.IndexOf(".xls") > 0) // 2003版本
                    _workbook = new HSSFWorkbook(_fs);
                if (_workbook == null)
                    return null;
                if (sheetName != null)
                {
                    sheet = _workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = _workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = _workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;

                    //查询第一列不合并的行
                    for (int i = 0; i <= rowCount; ++i)
                    {
                        IRow startRw = sheet.GetRow(i);
                        if (startRw != null)
                        {
                            for (int j = startRw.FirstCellNum; j < cellCount; ++j)
                            {
                                ICell cell = startRw.GetCell(j);

                                if (cell != null)
                                {
                                    string cellValue = cell.StringCellValue;
                                    if (cell.IsMergedCell)
                                    {
                                        if (j + 1 < cellCount)
                                        {
                                            ICell cellAdd = startRw.GetCell(j + 1);
                                            if (cellAdd.StringCellValue == "")
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (cellValue == "")
                                            break;
                                    }

                                    if (j + 1 == cellCount)
                                    {
                                        startRow = i;
                                        break;
                                    }
                                }
                            }
                        }

                        if (startRow >= 0)
                            break;
                    }

                    //取得列
                    if (startRow >= 0 && startRow <= rowCount)
                    {
                        IRow startRw = sheet.GetRow(startRow);
                        if (startRw != null)
                        {
                            for (int j = startRw.FirstCellNum; j < cellCount; ++j)
                            {
                                ICell cell = startRw.GetCell(j);
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }

                        //取得数据
                        for (int i = startRow + 1; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue; //没有数据的行默认是null　　　　　　　

                            DataRow dataRow = data.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                    dataRow[j] = row.GetCell(j).ToString();
                            }
                            data.Rows.Add(dataRow);
                        }
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
        public List<T> ExcelToList<T>(List<string> properties, string filePath, string sheetName, bool isFirstRowColumn)
        {
            List<T> retList = ReadToList<T>(properties, filePath, sheetName, isFirstRowColumn);
            return retList;
        }
        public List<T> ExcelToList<T>(List<string> properties, string filePath, string sheetName, bool isFirstRowColumn, string primaryKey, PrimaryKeyType pkType, int startKey)
        {
            List<T> retList = ReadToList<T>(properties, filePath, sheetName, isFirstRowColumn, primaryKey, pkType, startKey);
            return retList;
        }
        /// <summary>
        /// 将excel中的数据导入到泛型List中
        /// </summary>
        /// <param name="filePath">文件保存的绝对路径，包含文件名</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否为表头</param>
        /// <returns>返回的List</returns>
        private List<T> ReadToList<T>(List<string> properties, string filePath, string sheetName, bool isFirstRowColumn, string primaryKey = "", PrimaryKeyType pkType = PrimaryKeyType.无, int startKey = -1)
        {
            _workbook = null;
            ISheet sheet = null;
            List<T> list = new List<T>();
            int startRow = -1;

            if (pkType == PrimaryKeyType.数字 && startKey == -1)
                return null;

            try
            {
                _fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                    _workbook = new XSSFWorkbook(_fs);
                else if (filePath.IndexOf(".xls") > 0) // 2003版本
                    _workbook = new HSSFWorkbook(_fs);
                if (_workbook == null)
                    return null;
                if (sheetName != null)
                {
                    sheet = _workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = _workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = _workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;

                    //查询第一列不合并的行
                    for (int i = 0; i <= rowCount; ++i)
                    {
                        IRow startRw = sheet.GetRow(i);
                        if (startRw != null)
                        {
                            for (int j = startRw.FirstCellNum; j < cellCount; ++j)
                            {
                                ICell cell = startRw.GetCell(j);

                                if (cell != null)
                                {
                                    string cellValue = cell.StringCellValue;
                                    if (cell.IsMergedCell)
                                    {
                                        if (j + 1 < cellCount)
                                        {
                                            ICell cellAdd = startRw.GetCell(j + 1);
                                            if (cellAdd.StringCellValue == "")
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (cellValue == "")
                                            break;
                                    }

                                    if (j + 1 == cellCount)
                                    {
                                        startRow = i;
                                        break;
                                    }
                                }
                            }
                        }

                        if (startRow >= 0)
                            break;
                    }

                    int col = 0;
                    //取得数据
                    for (int i = startRow + 1; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        T s = System.Activator.CreateInstance<T>();
                        //属性赋值
                        if (pkType == PrimaryKeyType.无)
                        {
                            foreach (var item in properties)
                            {
                                if (row.GetCell(col) != null) //没有数据的单元格都默认是null 
                                    typeof(T).GetProperty(item).SetValue(s, row.GetCell(col), null);
                                ++col;
                            }
                        }
                        else
                        {
                            foreach (var item in properties)
                            {
                                if (row.GetCell(col) != null) //没有数据的单元格都默认是null 
                                {
                                    PropertyInfo pi = typeof(T).GetProperty(item);
                                    if (item.Equals(primaryKey))
                                    {
                                        if (pkType == PrimaryKeyType.数字)
                                        {
                                            pi.SetValue(s, startKey, null);
                                            startKey++;
                                        }
                                        else
                                        {
                                            pi.SetValue(s, Guid.NewGuid(), null);
                                        }
                                    }
                                    else
                                    {
                                        pi.SetValue(s, row.GetCell(col), null);
                                    }
                                }
                                ++col;
                            }
                        }
                        list.Add(s);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region 读取模板导出Excel
        /// <summary>
        /// 描述：将DataTable数据写入Excel,并保存到指定的路径
        /// 创建标识：dangfy on 20160112
        /// </summary>
        /// <param name="data">要导出的DataTable数据源</param>
        /// <param name="templatePath">模板绝对路径</param>
        /// <param name="filePath">文件保存的绝对路径，包含文件名</param>
        /// <param name="headerCount">表头数</param>
        /// <param name="sheetName">工作表名称，默认"Sheet1"</param>
        /// <returns>返回值：大于0=导出成功，其它=导出失败</returns>
        public int DataTableToExcel(DataTable data, string templatePath, string filePath, int headerCount, string sheetName = "Sheet1")
        {
            //读取模板
            using (FileStream file = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                _workbook = new HSSFWorkbook(file);
                ISheet hssfSheet = _workbook.GetSheet(sheetName);
                try
                {
                    int i = headerCount - 1;
                    int j = 0;
                    IRow row = null;
                    //写入表数据
                    for (i = headerCount - 1; i < data.Rows.Count; i++)
                    {
                        row = hssfSheet.GetRow(i + 1);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                    }
                    //保存
                    using (FileStream f = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        _workbook.Write(f);
                    }
                    return i;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return -1;
                }
            }
        }
        public byte[] DataTableToExcel(DataTable data, string templatePath, int headerCount, string sheetName = "Sheet1")
        {
            byte[] retResult = null;
            //读取模板
            using (FileStream file = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                _workbook = new HSSFWorkbook(file);
                ISheet hssfSheet = _workbook.GetSheet(sheetName);
                try
                {
                    int i = headerCount - 1;
                    int j = 0;
                    IRow row = null;
                    //写入表数据
                    for (i = headerCount - 1; i < data.Rows.Count; i++)
                    {
                        row = hssfSheet.GetRow(i + 1);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                    }

                    // 写入到客户端 
                    using (MemoryStream ms = new System.IO.MemoryStream())
                    {
                        _workbook.Write(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        retResult = ms.GetBuffer();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return retResult;
            }
        }
        #endregion

        #region 辅助方法
        //DataTable导出到Excel方法
        private int DtWriteToExcel(DataTable data, Dictionary<string, string> headers, string fileName, string sheetName)
        {
            if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
                _workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                _workbook = new HSSFWorkbook();

            //创建Sheet
            if (_workbook != null)
                _workbook.CreateSheet(sheetName);
            else
                return -1;
            try
            {
                int i = 0;
                int j = 0;

                ISheet sheet = null;
                if (_workbook != null)
                {
                    sheet = _workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (headers != null && headers.Count > 0)
                {
                    //自定义表头
                    IRow row = sheet.CreateRow(0);
                    foreach (var header in headers)
                    {
                        row.CreateCell(j).SetCellValue(header.Value);
                        j++;
                    }
                    //按自定义表头顺序写入表数据
                    for (i = 0; i < data.Rows.Count; ++i)
                    {
                        row = sheet.CreateRow(i + 1);
                        var dataRow = data.Rows[i];
                        j = 0;
                        foreach (var header in headers)
                        {
                            if (data.Columns.Contains(header.Key.ToUpper()))
                                row.CreateCell(j).SetCellValue(dataRow[header.Key].ToString());
                            j++;
                        }
                    }
                }
                else
                {
                    //以DataTable列名作为表头
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    //写入表数据
                    for (i = 0; i < data.Rows.Count; ++i)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                    }
                }
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }
        //读取模板将Excel导出到Excel方法
        private int DtWriteToExcel(DataTable data, string fileName, string sheetName, int headerCount, ISheet hssfSheet)
        {
            if (_workbook == null)
                return -1;
            try
            {
                int i = headerCount - 1;
                int j = 0;
                IRow row = null;
                //写入表数据
                for (i = headerCount - 1; i < data.Rows.Count; i++)
                {
                    row = hssfSheet.CreateRow(i + 1);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                }
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }
        //List泛型集合导出到Excel方法
        private int ListWriteToExcel<T>(List<T> listR, Dictionary<string, string> headers, string fileName, string sheetName)
        {
            ISheet hssfSheet = null;
            Type t = typeof(T);
            int col = 0;
            int rowNum = 0;

            if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007+版本
                _workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                _workbook = new HSSFWorkbook();

            if (_workbook != null)
                hssfSheet = _workbook.CreateSheet(sheetName);
            else
                return -1;

            try
            {
                if (headers != null && headers.Count > 0)
                {
                    //自定义表头
                    IRow hssfRow = hssfSheet.CreateRow(0);
                    foreach (var header in headers)
                    {
                        hssfRow.CreateCell(col).SetCellValue(header.Value);
                        if (header.Value != "序号")
                        {
                            hssfSheet.SetColumnWidth(col, 17 * 256);
                        }

                        ++col;
                    }
                    rowNum = 1;
                    //按自定义表头顺序写入表数据
                    foreach (var item in listR)
                    {
                        hssfRow = hssfSheet.CreateRow(rowNum);
                        col = 0;
                        foreach (var header in headers)
                        {
                            ICell cell = hssfRow.CreateCell(col, CellType.String);

                            PropertyInfo pi = t.GetProperty(header.Key);
                            if (pi != null)
                            {
                                var _v = pi.GetValue(item, null);
                                if (_v != null)
                                    cell.SetCellValue(_v.ToString());
                                else
                                    cell.SetCellValue("");
                            }
                            ++col;
                        }
                        ++rowNum;
                    }
                }
                else
                {
                    PropertyInfo[] tProperties = t.GetProperties();
                    //将性属性名字作为表头写入
                    IRow hssfRow = hssfSheet.CreateRow(rowNum);
                    foreach (PropertyInfo pi in tProperties)
                    {
                        ICell cell = hssfRow.CreateCell(col, CellType.String);
                        cell.SetCellValue(pi.Name);
                        ++col;
                    }
                    //数据写入
                    foreach (var item in listR)
                    {
                        hssfRow = hssfSheet.CreateRow(rowNum);
                        col = 0;
                        foreach (PropertyInfo pi in tProperties)
                        {
                            ICell cell = hssfRow.CreateCell(col, CellType.String);
                            var _v = pi.GetValue(item, null);
                            if (_v != null)
                                cell.SetCellValue(_v.ToString());
                            else
                                cell.SetCellValue("");
                            ++col;
                        }
                        ++rowNum;
                    }
                }
                return rowNum;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        /// <summary>
        /// List泛型集合导出到Excel方法
        /// add zhangxl 2016-06-01
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listR"></param>
        /// <param name="headers"></param>
        /// <param name="hebing"></param>
        /// <param name="title"></param>
        /// <param name="subtitle"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private int ListWriteToExcel<T>(List<T> listR, Dictionary<string, string> headers, Dictionary<int, int> hebing, string title, string subtitle, string fileName, string sheetName)
        {
            ISheet hssfSheet = null;
            Type t = typeof(T);
            //单元格列数
            int col = 0;
            //行数
            int rowNum = 0;
            if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007+版本
                _workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                _workbook = new HSSFWorkbook();

            if (_workbook != null)
                hssfSheet = _workbook.CreateSheet(sheetName);
            else
                return -1;

            //默认单元格样式
            ICellStyle cellStyle = _workbook.CreateCellStyle();

            try
            {
                if (headers != null && headers.Count > 0)
                {
                    IRow hssfRow;

                    #region 主标题与副标题处理

                    if (!string.IsNullOrEmpty(title))
                    {
                        //字体样式
                        IFont font;
                        int a = 1;
                        //主标题
                        IRow titleRow1 = hssfSheet.CreateRow(0);
                        ICell cell1 = titleRow1.CreateCell(0);
                        titleRow1.HeightInPoints = 25f;  //- 设置行高   
                        font = _workbook.CreateFont();//设置字体
                        font.FontHeightInPoints = 20;//设置字体大小
                        font.Boldweight = short.MaxValue;//粗体显示  
                        cell1.CellStyle = GetCellStyle(cellStyle);
                        cell1.CellStyle.SetFont(font);
                        cell1.SetCellValue(title);
                        int i = headers.Count;
                        hssfSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, i - 1));

                        if (!string.IsNullOrEmpty(subtitle))
                        {
                            //副标题
                            IRow titleRow = hssfSheet.CreateRow(1);
                            ICell cell = titleRow.CreateCell(0);
                            cell.CellStyle = GetCellStyle(cellStyle);
                            cell.SetCellValue(subtitle);
                            hssfSheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, i - 1));
                            //给变量a赋值，再增加一行
                            ++a;
                        }
                        //拥有主标题后行数增加
                        hssfRow = hssfSheet.CreateRow(a);
                        rowNum = a + 1;
                    }
                    else
                    {
                        hssfRow = hssfSheet.CreateRow(0);
                        rowNum = 1;
                    }

                    #endregion

                    //构造表头
                    foreach (var header in headers)
                    {
                        ICell cell = hssfRow.CreateCell(col);
                        if (header.Value != "序号")
                        {
                            hssfSheet.SetColumnWidth(col, 17 * 256);
                        }
                        cell.CellStyle = GetCellStyle(cellStyle);
                        //字体样式
                        IFont font = _workbook.CreateFont();
                        //字体
                        cell.CellStyle.SetFont(GetFont(font));
                        cell.SetCellValue(header.Value);
                        ++col;
                    }

                    //按自定义表头顺序写入表数据
                    foreach (var item in listR)
                    {
                        hssfRow = hssfSheet.CreateRow(rowNum);
                        col = 0;
                        foreach (var header in headers)
                        {
                            ICell cell = hssfRow.CreateCell(col, CellType.String);
                            cell.CellStyle = GetCellStyle(cellStyle);
                            IFont font = _workbook.CreateFont();
                            var newfont = GetFont(font);
                            newfont.Boldweight = short.MinValue;
                            cell.CellStyle.SetFont(newfont);
                            //构造数据
                            PropertyInfo pi = t.GetProperty(header.Key);
                            if (pi != null)
                            {
                                var _v = pi.GetValue(item, null);
                                if (_v != null)
                                    cell.SetCellValue(_v.ToString());
                                else
                                    cell.SetCellValue("");
                            }
                            else
                            {
                                cell.SetCellValue("");
                            }
                            ++col;
                        }
                        ++rowNum;
                    }
                }
                else
                {
                    #region 无自定义表头处理

                    PropertyInfo[] t_properties = t.GetProperties();
                    //将性属性名字作为表头写入
                    IRow hssfRow = hssfSheet.CreateRow(rowNum);
                    foreach (PropertyInfo pi in t_properties)
                    {
                        ICell cell = hssfRow.CreateCell(col, CellType.String);
                        cell.CellStyle = GetCellStyle(cellStyle);
                        //字体样式
                        IFont font = _workbook.CreateFont();
                        cell.CellStyle.SetFont(GetFont(font));
                        cell.SetCellValue(pi.Name);
                        ++col;
                    }
                    //数据写入
                    foreach (var item in listR)
                    {
                        hssfRow = hssfSheet.CreateRow(rowNum);
                        col = 0;
                        foreach (PropertyInfo pi in t_properties)
                        {
                            ICell cell = hssfRow.CreateCell(col, CellType.String);
                            cell.CellStyle = GetCellStyle(cellStyle);
                            var _v = pi.GetValue(item, null);
                            if (_v != null)
                                cell.SetCellValue(_v.ToString());
                            else
                                cell.SetCellValue("");
                            ++col;
                        }
                        ++rowNum;
                    }

                    #endregion
                }
                if (hebing != null && hebing.Count > 0)
                {
                    foreach (var he in hebing)
                    {
                        hssfSheet.AddMergedRegion(new CellRangeAddress(he.Key, he.Key + he.Value, 0, 0));
                    }
                }
                return rowNum;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        /// <summary>
        /// 构造Excel背景表格
        /// </summary>
        private ICellStyle GetCellStyle(ICellStyle cellStyle)
        {
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            return cellStyle;
        }
        /// <summary>
        /// 构造字体样式
        /// </summary>
        private IFont GetFont(IFont font)
        {
            font.FontHeightInPoints = 12;//设置字体大小
            font.Boldweight = short.MaxValue;//粗体显示
            font.FontName = "宋体";
            return font;
        }
        #endregion

        #region DataColumn转换Liststring
        /// <summary>
        /// DataColumn转换Liststring
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static List<string> DataColumnToList(DataColumnCollection dc)
        {
            try
            {
                return (from DataColumn item in dc select item.ColumnName.Trim()).ToList();
            }
            catch
            {
                return new List<string>();
            }
        }
        #endregion
    }
    public enum PrimaryKeyType
    {
        无 = 0,
        Guid = 1,
        数字 = 2
    }
}

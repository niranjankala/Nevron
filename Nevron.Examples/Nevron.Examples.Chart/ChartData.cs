using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevron.Examples.Chart
{
    public class ChartData
    {

        public DataTable GetDataTable(string xmlFilePath)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if (!string.IsNullOrWhiteSpace(xmlFilePath) && File.Exists(xmlFilePath))
            {
                ds.ReadXml(xmlFilePath);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }

            return dt;
        }

        //public DataTable GetDataTable(string excelPath)
        //{
        //    DataTable dt = new DataTable();

        //    string connectionString = string.Format(@"provider=Microsoft.Ace.OLEDB.12.0;data source={0};Extended Properties=Excel 12.0;", excelPath);
        //    OleDbConnection objConn = new OleDbConnection(connectionString);
        //    objConn.Open();
        //    DataTable schemaTable = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //    DataSet ds = new DataSet();
        //    //Read From EXCEL and Create DataSet

        //    for (int i = 0; i <= schemaTable.Rows.Count - 1; i++)
        //    {
        //        string tablename = "";
        //        DataRow dr = schemaTable.Rows[i];
        //        tablename = dr["TABLE_NAME"].ToString().Trim();
        //        if (tablename != null)
        //        {
        //            DataTable librariesDt = new DataTable() { TableName = tablename };
        //            if (!librariesDt.TableName.ToString().Contains("_xlnm#_FilterDatabase"))
        //            {
        //                ds.Tables.Add(librariesDt);
        //                OleDbDataAdapter objAdp = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", tablename), objConn);
        //                objAdp.Fill(ds.Tables[tablename]);
        //                objAdp.Dispose();
        //            }
        //        }
        //    }
        //    dt = ds.Tables[0];
        //    ds.WriteXml("d:\\data.xml");
        //    return dt;
        //}

        //public DataTable GetDataTable(string excelFilePath)
        //{
        //    //Create a new DataTable.
        //    DataTable dt = new DataTable();
        //    //Open the Excel file in Read Mode using OpenXml.
        //    using (DocumentFormat.OpenXml.Packaging.SpreadsheetDocument doc = DocumentFormat.OpenXml.Packaging.SpreadsheetDocument.Open(excelFilePath, false))
        //    {
        //        //Read the first Sheet from Excel file.
        //        Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

        //        //Get the Worksheet instance.
        //        Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

        //        //Fetch all the rows present in the Worksheet.
        //        IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();



        //        //Loop through the Worksheet rows.
        //        foreach (Row row in rows)
        //        {
        //            //Use the first row to add columns to DataTable.
        //            if (row.RowIndex.Value == 1)
        //            {
        //                foreach (Cell cell in row.Descendants<Cell>())
        //                {
        //                    dt.Columns.Add(GetValue(doc, cell));
        //                }
        //            }
        //            else
        //            {
        //                //Add rows to DataTable.
        //                dt.Rows.Add();
        //                int i = 0;
        //                foreach (Cell cell in row.Descendants<Cell>())
        //                {
        //                    dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
        //                    i++;
        //                }
        //            }
        //        }
        //    }
        //    return dt;

        //}
        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }



            return value;
        }

        public static DateTime FromExcelSerialDate(int SerialDate)
        {
            if (SerialDate > 59) SerialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            return new DateTime(1899, 12, 31).AddDays(SerialDate);
        }
    }
}

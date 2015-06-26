using DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        DataTable schemaTable;
        OleDbDataReader myReader;

        //Open a connection to the SQL Server Northwind database.
        cn.ConnectionString = "Provider=SQLOLEDB;Data Source=.;integrated security=SSPI;Initial Catalog=RealEstate";
        cn.Open();

        //Retrieve records from the Employees table into a DataReader.
        cmd.Connection = cn;
        cmd.CommandText = "SELECT * FROM Town";
        myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);

        //Retrieve column schema into a DataTable.
        schemaTable = myReader.GetSchemaTable();


        string createMth = "Town AddTown(";
        string createStr = "Town obj = new Town() {";


        //For each field in the table...
        foreach (DataRow myField in schemaTable.Rows)
        {
            //For each property of the field...

            pnl.Controls.Add(new Literal() { Text = "<br />" });
            
            pnl.Controls.Add(new Literal() { Text = "ColumnName = " + myField["ColumnName"].ToString() + ", " });
            pnl.Controls.Add(new Literal() { Text = "DataType = " + myField["DataType"].ToString() + ", " });
            pnl.Controls.Add(new Literal() { Text = "IsAutoIncrement = " + myField["IsAutoIncrement"].ToString() + ", " });
            pnl.Controls.Add(new Literal() { Text = "AllowDBNull = " + myField["AllowDBNull"].ToString() });

            if(myField != schemaTable.Rows[schemaTable.Rows.Count - 1])
                createMth += myField["DataType"].ToString() + " " + myField["ColumnName"].ToString() + ",";
            else
                createMth += myField["DataType"].ToString() + " " + myField["ColumnName"].ToString();

            // create code
            createStr += " " + myField["ColumnName"].ToString() + " = " + myField["ColumnName"].ToString() + ",";

            foreach (DataColumn myProperty in schemaTable.Columns)
            {
                //Display the field name and value.                  
                //pnl.Controls.Add(new Literal() { Text = "<br />" + myProperty.ColumnName });
            }
            pnl.Controls.Add(new Literal() { Text = "<br /><br />//<br />" });
        }
        createMth += ") {";
        createStr += " }; this.AddToTown(obj); this.SaveChanges(); return obj;";
        pnl.Controls.Add(new Literal() { Text = createMth + createStr + "}" });
        //Always close the DataReader and connection.
        myReader.Close();
        cn.Close();
    }

    
}
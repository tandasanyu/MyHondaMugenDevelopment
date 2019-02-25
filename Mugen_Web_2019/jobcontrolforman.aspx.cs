using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.IO;

public partial class jobcontrolforman : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }
    protected void GetTime(object sender, EventArgs e)
    {
        GridView6.DataBind();
        GridView2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string hasil = txtCari.Text;
        Response.Redirect("jobcontrolforman.aspx?q=" + hasil);
    }


   
       
    
   
   

   
}
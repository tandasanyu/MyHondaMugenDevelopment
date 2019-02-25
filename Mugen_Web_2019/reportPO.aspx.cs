using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reportPO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
        string tawl = Request.QueryString["tawl"];
        string takr = Request.QueryString["takr"];
        string cab = Request.QueryString["cab"];
       
        lblTawl.Text = tawl;
        lblTakr.Text = takr;
        lblCab.Text = cab;
        
    }
}
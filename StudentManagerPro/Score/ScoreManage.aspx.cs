using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace StudentManagerPro.Score
{
    public partial class ScoreManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlClass.DataSource = new StudentClassService().queryAllClass();
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = new ScoreListService().getScoreList(Convert.ToInt32(ddlClass.SelectedValue));
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover",
                        "CurrentColor=this.style.backgroundColor;this.style.backgroundColor='#69f'");
                 e.Row.Attributes.Add("onmouseout",
                        "this.style.backgroundColor=CurrentColor");
            }
            
        }

        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            int ClassId = Convert.ToInt32(ddlClass.SelectedValue);
            String ClassName = ddlClass.SelectedItem.Text.Trim();
            Response.Redirect("~/Handler/ExportToExcel.ashx?ClassId="+ClassId+"&ClassName="+ClassName);
        }  
    }
}
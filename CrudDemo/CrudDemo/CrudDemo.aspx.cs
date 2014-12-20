using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CrudDemo
{
    public partial class CrudDemo : System.Web.UI.Page
    {
        BOLCountryMaster bol = new BOLCountryMaster();
        BALCountryMaster bal = new BALCountryMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillGrid();
                LoadPanel();
                Reset();
            }
        }

        private void Reset()
        {
            txtCountry.Text = lblMessage.Text = lblMessageGrid.Text = "";
            btnSubmit.Text = "Submit";
        }

        private void FillGrid()
        {
            DataTable dt = new DataTable();
            dt = new BALCountryMaster().Select(new BOLCountryMaster());
            gvCountry.DataSource = dt;
            gvCountry.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                if(btnSubmit.Text=="Submit")
                {
                    int Id = 1;
                    DataTable dt = bal.SelectMaxId(bol);
                    if (dt.Rows.Count > 0)
                    {
                        Id = int.Parse(dt.Rows[0]["Id"].ToString()) + 1;
                    }
                    bol.Id = Id;
                    bol.Country = txtCountry.Text;

                    bal.Insert(bol);
                    Reset();
                    lblMessageGrid.Text = "Record Inserted successfully";
                    LoadPanel();
                    FillGrid();
                }
                else if(btnSubmit.Text=="Update")
                {
                    int Id = int.Parse(lblId.Text);
                    bol.Id = Id;
                    bol.Country = txtCountry.Text;
                    bal.Update(bol);
                    Reset();
                    lblMessageGrid.Text = "Record Updated Successfully.";
                    FillGrid();
                    LoadPanel();
                }
                
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pnlData.Visible = true;
            pnlGrid.Visible = false;
            Reset();
            txtCountry.Focus();
        }

        private void LoadPanel()
        {
            pnlGrid.Visible = true;
            pnlData.Visible = false;
        }

        protected void lnkbtnEdit_Click(object sender,EventArgs e)
        {
            LinkButton btnEdit = sender as LinkButton;
            GridViewRow gr = (GridViewRow)btnEdit.NamingContainer;
            Label lblId1 = (Label)gvCountry.Rows[gr.RowIndex].FindControl("lblId");
            DataTable dt = new BALCountryMaster().Select(new BOLCountryMaster() { Id = int.Parse(lblId1.Text) });
            if(dt.Rows.Count>0)
            {
                lblId.Text = lblId1.Text;
                txtCountry.Text = dt.Rows[0]["Country"].ToString();
            }
            pnlData.Visible = true;
            pnlGrid.Visible = false;
            btnSubmit.Text = "Update";
            txtCountry.Focus();
        }

        protected void lnkbtnDelete_Click(object sender,EventArgs e)
        {
            LinkButton btnDelete = sender as LinkButton;
            GridViewRow gr = (GridViewRow)btnDelete.NamingContainer;

            Label lblId1 = (Label)gvCountry.Rows[gr.RowIndex].FindControl("lblId");
            bol.Id = int.Parse(lblId1.Text);
            bal.Delete(bol);
            LoadPanel();
            Reset();
            FillGrid();
            lblMessageGrid.Text = "Record Deleted Sucessfully.";
        }
    }
}
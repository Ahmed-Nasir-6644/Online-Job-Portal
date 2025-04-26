using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                string concatQuery = string.Empty;
                string a = string.Empty;
                string filePath = string.Empty;
                bool IsValid = false;
                if (fuimage.HasFile)
                {
                    if (Utils.IsValidExtension(fuimage.FileName))
                    {
                        a = ",photo";
                        concatQuery = ",@photo";
                        IsValid = true;
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                }
                else
                {
                    concatQuery = string.Empty;

                }
                string query = @"Insert into [User](Username,Password,Name,Email,Mobile,Address,Country" + a + ") values (@Username,@Password,@Name,@Email,@MobileNo,@Address,@Country" + concatQuery + ")";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);

                if (fuimage.HasFile)
                {
                    if (Utils.IsValidExtension(fuimage.FileName))
                    {
                        Guid obj = Guid.NewGuid();
                        fuimage.PostedFile.SaveAs(Server.MapPath("~/photos/") + fuimage.FileName);
                        cmd.Parameters.AddWithValue("@photo", fuimage.FileName);
                        IsValid = true;
                    }
                    else
                    {
                        concatQuery = string.Empty;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Please Select .png, .jpg, .jpeg file for photo!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    IsValid = true;
                }
                if (IsValid)
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Registered Successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        Clear();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot save record right now, plz try after sometime..!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot save record right now, plz try after sometime..!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            
                
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique key violation error number
                {
                    // Extract the duplicate value from the error message
                    string duplicateValue = Utils.ExtractDuplicateValue(ex.Message);

                    if (duplicateValue == txtEmail.Text.Trim())
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = $"<b>{txtEmail.Text.Trim()}</b> email address already exists, please use a different one!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    else if (duplicateValue == txtUserName.Text.Trim())
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = $"<b>{txtUserName.Text.Trim()}</b> username already exists, try a new one!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "An error occurred while registering. Please try again later.";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }

            finally { con.Close(); }

        }

        private void Clear()
        {
            txtUserName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            ddlCountry.ClearSelection();
        }
    }
}
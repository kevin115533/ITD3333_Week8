using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    private string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            FillAuthorList();
        }
    }

    private void FillAuthorList()
    {
        lastNameDropList.Items.Clear();
        string selectSQL = "SELECT au_lname, au_fname, au_id FROM Authors";

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem newItem = new ListItem();
                newItem.Text = reader["au_lname"] + ", " + reader["au_fname"];
                newItem.Value = reader["au_id"].ToString();
                lastNameDropList.Items.Add(newItem);
            }
            reader.Close();
        }
        catch (Exception err)
        {
            resultLbl.Text = "Error reading list of names. ";
            resultLbl.Text += err.Message;
        }
        finally
        {
            con.Close();
        }
    }

    protected void lstAuthor_SelectedIndexChanged(Object sender, EventArgs e)
    {
        string selectSQL;
        selectSQL = "SELECT * FROM Authors ";
        selectSQL += "WHERE au_id='" + lastNameDropList.SelectedItem.Value + "'";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>"); sb.Append(reader["au_lname"]);
            sb.Append(", ");
            sb.Append(reader["au_fname"]);
            sb.Append("</b><br />");
            sb.Append("Phone: ");
            sb.Append(reader["phone"]);
            sb.Append("<br />");
            sb.Append("Address: ");
            sb.Append(reader["address"]);
            sb.Append("<br />");
            sb.Append("City: ");
            sb.Append(reader["city"]);
            sb.Append("<br />");
            sb.Append("State: ");
            sb.Append(reader["state"]);
            sb.Append("<br />");
            
            resultLbl.Text = sb.ToString();
            reader.Close();
        }
        catch (Exception err)
        {
            resultLbl.Text = "Error getting author. ";
            resultLbl.Text += err.Message;
        }
        finally
        {
            con.Close();
        }
    }
}
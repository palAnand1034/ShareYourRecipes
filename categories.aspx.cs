using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
            }
        }

        protected void BindCategories()
        {
            try
            {
                List<Category> categories = GetCategoriesFromDatabase();
                ListViewCategories.DataSource = categories;
                ListViewCategories.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = TextBoxCategoryName.Text;
                InsertCategoryIntoDatabase(categoryName);
                BindCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(TextBoxCategoryId.Text);
                string categoryName = TextBoxCategoryName.Text;
                UpdateCategoryInDatabase(categoryId, categoryName);
                BindCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(TextBoxCategoryId.Text);
                DeleteCategoryFromDatabase(categoryId);
                BindCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ListViewCategories_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListViewCategories.EditIndex = e.NewEditIndex;
            BindCategories();
        }

        protected void ListViewCategories_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(ListViewCategories.DataKeys[e.ItemIndex].Value);
                TextBox TextBoxEditCategoryName = (TextBox)ListViewCategories.Items[e.ItemIndex].FindControl("TextBoxEditCategoryName");
                string categoryName = TextBoxEditCategoryName.Text;
                UpdateCategoryInDatabase(categoryId, categoryName);
                ListViewCategories.EditIndex = -1;
                BindCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ListViewCategories_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(ListViewCategories.DataKeys[e.ItemIndex].Value);
                DeleteCategoryFromDatabase(categoryId);
                BindCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ListViewCategories_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListViewCategories.EditIndex = -1;
            BindCategories();
        }

        protected void ListViewCategories_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox textBoxNewCategoryName = e.Item.FindControl("TextBoxNewCategoryName") as TextBox;
                string categoryName = textBoxNewCategoryName.Text;
                InsertCategoryIntoDatabase(categoryName);
                ListViewCategories.EditIndex = -1;
                BindCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertCategoryIntoDatabase(string categoryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<Category> GetCategoriesFromDatabase()
        {
            List<Category> categories = new List<Category>();
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "SELECT CategoryID, CategoryName, ImageURL FROM Categories";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.Id = Convert.ToInt32(reader["CategoryID"]);
                        category.Name = reader["CategoryName"].ToString();
                        category.ImageURL = reader["ImageURL"].ToString();
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        private void UpdateCategoryInDatabase(int categoryId, string categoryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteCategoryFromDatabase(int categoryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "DELETE FROM Categories WHERE CategoryId = @CategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImageURL { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMealTypes();
            }
        }

        protected void BindMealTypes()
        {
            try
            {
                List<MealType> mealTypes = GetMealTypesFromDatabase();
                ListViewMealTypes.DataSource = mealTypes;
                ListViewMealTypes.DataBind();
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
                string mealTypeName = TextBoxMealTypesName.Text;
                InsertMealTypeIntoDatabase(mealTypeName);
                BindMealTypes();
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
                int mealTypeId = Convert.ToInt32(TextBoxMealTypesId.Text);
                string mealTypeName = TextBoxMealTypesName.Text;
                UpdateMealTypeInDatabase(mealTypeId, mealTypeName);
                BindMealTypes();
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
                int mealTypeId = Convert.ToInt32(TextBoxMealTypesId.Text);
                DeleteMealTypeFromDatabase(mealTypeId);
                BindMealTypes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ListViewMealTypes_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListViewMealTypes.EditIndex = e.NewEditIndex;
            BindMealTypes();
        }

        protected void ListViewMealTypes_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            try
            {
                int mealTypeId = Convert.ToInt32(ListViewMealTypes.DataKeys[e.ItemIndex].Value);
                TextBox TextBoxEditMealTypesName = (TextBox)ListViewMealTypes.Items[e.ItemIndex].FindControl("TextBoxEdiTMealTypesName");
                string mealTypeName = TextBoxEditMealTypesName.Text;
                UpdateMealTypeInDatabase(mealTypeId, mealTypeName);
                ListViewMealTypes.EditIndex = -1;
                BindMealTypes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ListViewMealTypes_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                int mealTypeId = Convert.ToInt32(ListViewMealTypes.DataKeys[e.ItemIndex].Value);
                DeleteMealTypeFromDatabase(mealTypeId);
                BindMealTypes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ListViewMealTypes_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListViewMealTypes.EditIndex = -1;
            BindMealTypes();
        }

        protected void ListViewMealTypes_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox textBoxNewMealTypesName = e.Item.FindControl("TextBoxNewMealTypesName") as TextBox;
                string mealTypeName = textBoxNewMealTypesName.Text;
                InsertMealTypeIntoDatabase(mealTypeName);
                ListViewMealTypes.EditIndex = -1;
                BindMealTypes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertMealTypeIntoDatabase(string mealTypeName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "INSERT INTO MealTypes (MealTypeName) VALUES (@MealTypeName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MealTypeName", mealTypeName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<MealType> GetMealTypesFromDatabase()
        {
            List<MealType> mealTypes = new List<MealType>();
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "SELECT MealTypeID, MealTypeName, ImageURL FROM MealTypes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MealType mealType = new MealType();
                        mealType.Id = Convert.ToInt32(reader["MealTypeID"]);
                        mealType.Name = reader["MealTypeName"].ToString();
                        mealType.ImageURL = reader["ImageURL"].ToString();
                        mealTypes.Add(mealType);
                    }
                }
            }

            return mealTypes;
        }

        private void UpdateMealTypeInDatabase(int mealTypeId, string mealTypeName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "UPDATE MealTypes SET MealTypeName = @MealTypeName WHERE MealTypeID = @MealTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MealTypeID", mealTypeId);
                    command.Parameters.AddWithValue("@MealTypeName", mealTypeName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteMealTypeFromDatabase(int mealTypeId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "DELETE FROM MealTypes WHERE MealTypeID = @MealTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MealTypeID", mealTypeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public class MealType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImageURL { get; set; }
        }
    }
}

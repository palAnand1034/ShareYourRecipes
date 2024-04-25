<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="OnlineRecipeSharing.categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Manage Categories</h2>
        <div>
            <!-- Input fields for adding or updating categories -->
            <div>
                <asp:TextBox ID="TextBoxCategoryId" runat="server" placeholder="Category ID" Visible="false"></asp:TextBox>
                <asp:TextBox ID="TextBoxCategoryName" runat="server" placeholder="Category Name"></asp:TextBox>
                <asp:FileUpload ID="FileUploadImage" runat="server" />
                <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" />
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" />
            </div>
            <!-- ListView for displaying categories -->
            <asp:ListView ID="ListViewCategories" runat="server" DataKeyNames="Id" OnItemEditing="ListViewCategories_ItemEditing"
                OnItemUpdating="ListViewCategories_ItemUpdating" OnItemDeleting="ListViewCategories_ItemDeleting"
                OnItemCanceling="ListViewCategories_ItemCanceling" OnItemInserting="ListViewCategories_ItemInserting">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>Category ID</th>
                            <th>Category Name</th>
                            <th>Image</th>
                            <th>Actions</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><asp:Image ID="ImageCategory" runat="server" ImageUrl='<%# Eval("ImageURL") %>' Height="100px" Width="100px" /></td>
                        <td>
                            <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td><asp:TextBox ID="TextBoxEditId" runat="server" Text='<%# Bind("Id") %>' ReadOnly="true" /></td>
                        <td><asp:TextBox ID="TextBoxEditCategoryName" runat="server" Text='<%# Bind("Name") %>' /></td>
                        <td><asp:Image ID="ImageCategoryEdit" runat="server" ImageUrl='<%# Bind("ImageURL") %>' Height="100px" Width="100px" /></td>
                        <td>
                            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td></td>
                        <td><asp:TextBox ID="TextBoxNewCategoryName" runat="server" placeholder="New Category Name"></asp:TextBox></td>
                        <td><asp:FileUpload ID="FileUploadNewImage" runat="server" /></td>
                        <td>
                            <asp:Button ID="ButtonInsert" runat="server" Text="Insert" CommandName="Insert" />
                            <asp:Button ID="ButtonCancelInsert" runat="server" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MealTypes.aspx.cs" Inherits="OnlineRecipeSharing.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Manage MealTypes</h2>
        <div>
            <!-- Input fields for adding or updating MealTypes -->
            <div>
                <asp:TextBox ID="TextBoxMealTypesId" runat="server" placeholder="MealTypes ID" Visible="false"></asp:TextBox>
                <asp:TextBox ID="TextBoxMealTypesName" runat="server" placeholder="MealTypes Name"></asp:TextBox>
                <asp:FileUpload ID="FileUploadImage" runat="server" />
                <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" />
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" />
            </div>
            <!-- ListView for displaying MealTypes -->
            <asp:ListView ID="ListViewMealTypes" runat="server" DataKeyNames="Id" OnItemEditing="ListViewMealTypes_ItemEditing"
                OnItemUpdating="ListViewMealTypes_ItemUpdating" OnItemDeleting="ListViewMealTypes_ItemDeleting"
                OnItemCanceling="ListViewMealTypes_ItemCanceling" OnItemInserting="ListViewMealTypes_ItemInserting">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>MealTypes ID</th>
                            <th>MealTypes Name</th>
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
                        <td><asp:Image ID="ImageMealTypes" runat="server" ImageUrl='<%# Eval("ImageURL") %>' Height="100px" Width="100px" /></td>
                        <td>
                            <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td><asp:TextBox ID="TextBoxEditId" runat="server" Text='<%# Bind("Id") %>' ReadOnly="true" /></td>
                        <td><asp:TextBox ID="TextBoxEdiTMealTypesName" runat="server" Text='<%# Bind("Name") %>' /></td>
                        <td><asp:Image ID="ImageMealTypesEdit" runat="server" ImageUrl='<%# Bind("ImageURL") %>' Height="100px" Width="100px" /></td>
                        <td>
                            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td></td>
                        <td><asp:TextBox ID="TextBoxNewMealTypesName" runat="server" placeholder="New MealTypesName"></asp:TextBox></td>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="WebApplication1.Admin.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Headcontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-2 lh-sm">Category List</h2>
    <div class="mt-4">
        <div class="row g-4">
            <div class="col-12 col-xl-12 order-1 order-xl-0">
                <div class="mb-9">
                    <div class="card shadow-none border my-4" data-component-card="data-component-card">
                        <div class="card-header p-4 border-bottom bg-body">
                            <div class="row g-3 justify-content-between align-items-center">
                                <div class="col-12 col-md">
                                    <h4 class="text-body mb-0" data-anchor="data-anchor" id="example">Category List
                                    </h4>
                                </div>
                                <div class="col col-md-auto">
                                    <nav class="nav justify-content-end doc-tab-nav align-items-center" role="tablist">
                                        <a class="btn btn-link px-2 text-body copy-code-btn" href="CategoryForm.aspx">
                                            <span data-feather="plus"></span>Add</a>
                                    </nav>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" id="vehicleForm">

                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" CssClass="table table-responsive border-0" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <%#Eval("CateID") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <%#Eval("CateName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Icon">
                                            <ItemTemplate>
                                                <%#Eval("Icon") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <input type="checkbox" disabled <%# Eval("IsActive").ToString() == "True" ? "checked" : "" %>>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                               
                                                    <a class="btn btn-info" href='CategoryForm.aspx?Edit=<%#Eval("CateID") %>'><i class="fa-solid fa-pen"></i></a>
                                                    <asp:LinkButton CssClass="btn btn-danger" ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this item?');" runat="server" CommandName="Del" CommandArgument='<%#Eval("CateID") %>'><i class="fa-solid fa-xmark"></i></asp:LinkButton>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>

                    </div>

                </div>
            </div>

        </div>

    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContent" runat="server">
</asp:Content>

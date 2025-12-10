<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CategoryForm.aspx.cs" Inherits="WebApplication1.Admin.CategoryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Headcontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-2 lh-sm">Add Category</h2>
    <div class="mt-4">
        <div class="row g-4">
            <div class="col-12 col-xl-12 order-1 order-xl-0">
                <div class="mb-9">
                    <div id="alert" runat="server">

                    </div>

                    <div class="card shadow-none border my-4" data-component-card="data-component-card">
                        <div class="card-header p-4 border-bottom bg-body">
                            <div class="row g-3 justify-content-between align-items-center">
                                <div class="col-12 col-md">
                                    <h4 class="text-body mb-0" data-anchor="data-anchor" id="example">Category
                                    </h4>
                                </div>
                                <div class="col col-md-auto">
                                    <nav class="nav justify-content-end doc-tab-nav align-items-center" role="tablist"><a class="btn btn-link px-2 text-body copy-code-btn" href="CategoryList.aspx"><span class="fas fa-arrow-circle-left me-1"></span>Back</a></nav>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" id="vehicleForm">
                            <div class="mb-3">
                                <label class="form-label" for="exampleFormControlInput">Brand Name</label>
                                <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="text-danger error-message" ID="FillCatErr" ControlToValidate="txtCategory" runat="server" ErrorMessage="Category Requir*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-0">
                                <label class="form-label" for="Status">Icon</label>
                                <div class="d-flex justify-content-between">
                                    <asp:FileUpload ID="FileIcon" CssClass="form-control" runat="server" />
                                    <asp:Image ID="IconImg" runat="server" CssClass="img-thumbnail" />
                                </div>
                            </div>
                            <div class="mb-0">
                                <label class="form-label" for="Status">Status</label>
                                <asp:DropDownList CssClass="form-select" ID="Status" runat="server">
                                    <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="True">Active</asp:ListItem>
                                    <asp:ListItem Value="false"> Deavtive</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger error-message" ID="dropStatusErr" ControlToValidate="Status" runat="server" ErrorMessage="Select Any Option"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="card-footer">
                            <asp:LinkButton ID="BttnInsert" runat="server" CssClass="btn  btn-subtle-success me-1 mb-1" OnClick="BttnInsert_Click" Text="Insert">Save</asp:LinkButton>
                            <button class="btn  btn-subtle-close me-1 mb-1" type="reset" id="BtnCancel">Cancel</button>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContent" runat="server">
</asp:Content>

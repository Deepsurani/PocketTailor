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
									<nav class="nav justify-content-end doc-tab-nav align-items-center" role="tablist"><a class="btn btn-link px-2 text-body copy-code-btn" href="CategoryForm.aspx">
											<span data-feather="plus"></span>Add</a></nav>
								</div>
							</div>
						</div>
						<div class="card-body" id="vehicleForm">
							
								<div class="table-responsive">
									<asp:GridView ID="GridView1" CssClass="table table-striped table-sm fs-9 mb-0" runat="server"></asp:GridView>
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

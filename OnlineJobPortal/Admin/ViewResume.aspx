﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewResume.aspx.cs" Inherits="OnlineJobPortal.Admin.ViewResume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container-fluid pt -4 pb-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>

            <h3 class="text-center">Resume</h3>

            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"
                        EmptyDataText="No Record to Display..!" AllowPaging="True" PageSize="5"
                        OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppliedJobId" OnRowDeleting="GridView1_RowDeleting"
                        OnRowDataBound="GridView1_RowDataBound" onSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
                        <Columns>

                            <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:BoundField DataField="Title" HeaderText="Job Title">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="UserName" HeaderText="User Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Email" HeaderText="User Email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Mobile" HeaderText="User Mobile no.">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Resume">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.Resume","../{0}") %>'>
                                        <i class="fas fa-download" ></i>Download</asp:HyperLink>
                                    <asp:HiddenField ID="hdnJobId" runat="server" Value='<%# Eval("JobId") %>' Visible="false"/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:CommandField CausesValidation="false" HeaderText="Job Details" ShowDeleteButton="true"
                                DeleteImageUrl="../assets/img/icon/view.png" ButtonType="Image">
                                <ControlStyle Height="15px" Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField >

                        </Columns>
                        <HeaderStyle BackColor="#7200cf" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>


        </div>
    </div>
</asp:Content>

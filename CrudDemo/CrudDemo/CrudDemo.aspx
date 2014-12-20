<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrudDemo.aspx.cs" Inherits="CrudDemo.CrudDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD Demo</title>
</head>
<body>
    <style>
        .padding{
            padding-left:10px;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlGrid" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 30%"></td>
                            <td style="width: 20%"></td>
                            <td style="width: 30%"></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblMessageGrid" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" Text="Add Country" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width:500px;">
                                <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SrNo" HeaderStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" CssClass="padding" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" HeaderStyle-Font-Bold="true" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Country" HeaderStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCountry1" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="50%" CssClass="padding" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" OnClick="lnkbtnEdit_Click" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Id") %>'>Edit</asp:LinkButton>
                                                <asp:LinkButton ID="lnkbtnDelete" OnClick="lnkbtnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete?')" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Id") %>'>Delete</asp:LinkButton>
                                            </ItemTemplate>
                                             <ItemStyle Width="100px" CssClass="padding" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnlData" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 30%"></td>
                            <td style="width: 20%"></td>
                            <td style="width: 30%"></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCountry" runat="server" Text="Country" Font-Bold="true"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_Country" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCountry"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                            </td>
                        </tr>

                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

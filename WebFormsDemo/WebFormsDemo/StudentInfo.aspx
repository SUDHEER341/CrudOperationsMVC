<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="WebFormsDemo.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="2" style="height: 38px">
                <asp:Label ID="lblstudinfo" runat="server" Text="StudentInformation"></asp:Label>
            </td>
            <td style="height: 38px"></td>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td style="height: 34px; width: 79px">
                <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
            </td>
            <td style="height: 34px; width: 553px;">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
            <td colspan="2" rowspan="7">
                <asp:GridView ID="gridview1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="StudentID" DataSourceID="SqlDataSource1" Height="200px" style="margin-right: 111px; margin-left: 64px;" Width="572px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        <asp:BoundField DataField="StudentID" HeaderText="StudentID" ReadOnly="True" SortExpression="StudentID"></asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender"></asp:BoundField>
                        <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" DataFormatString="{0:mm/dd/yyyy}"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AMDBConnectionString %>" ProviderName="<%$ ConnectionStrings:AMDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="height: 42px; width: 79px">
                <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
            </td>
            <td style="height: 42px; width: 553px;">
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 42px; width: 79px">
                <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
            </td>
            <td style="height: 42px; width: 553px;">
                <asp:DropDownList ID="ddlgender" runat="server" Width="130px">
                    <asp:ListItem>choose one</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 46px; width: 79px">
                <asp:Label ID="lbldob" runat="server" Text="DateofBirth"></asp:Label>
            </td>
            <td style="height: 46px; width: 553px;">
                <asp:TextBox ID="txtdob" runat="server" TextMode="Date" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 44px; width: 79px">
                &nbsp;</td>
            <td style="height: 44px; width: 553px;">
                <asp:CheckBox ID="chkboxagree" runat="server" Text="Yes, Iagree" />
            &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 79px; height: 35px">
                <asp:Label ID="lblsid" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="height: 35px; width: 553px;">
            </td>
        </tr>
        <tr>
            <td style="width: 79px; height: 84px"></td>
            <td style="height: 84px; width: 553px;">
                <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 79px">&nbsp;</td>
            <td style="width: 553px">
                <asp:Button ID="btncancel" runat="server" Text="Cancel operation" Width="179px" OnClick="btncancel_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 79px">&nbsp;</td>
            <td style="width: 553px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 79px; height: 21px"></td>
            <td style="height: 21px; width: 553px;"><asp:Label ID="lblmessage" runat="server"></asp:Label>
            </td>
            <td style="height: 21px"></td>
            <td style="height: 21px"></td>
        </tr>
        <tr>
            <td style="width: 79px">&nbsp;</td>
            <td style="width: 553px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 79px">&nbsp;</td>
            <td style="width: 553px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br>
    <br>
</asp:Content>

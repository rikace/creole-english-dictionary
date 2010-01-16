<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Translate.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Haiti.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h1>
        English / Creole Translator</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:RadioButtonList runat="server" OnSelectedIndexChanged="SwitchLanguage" CausesValidation="false"
                AutoPostBack="true">
                <asp:ListItem Value="1" Enabled="false"><img src="/images/flags/usa.jpg" /><img src="/images/arrowright.jpg" /><img src="/images/flags/haiti.jpg" /></asp:ListItem>
                <asp:ListItem Text="Creole to English" Value="2" Selected="True"><img src="/images/flags/haiti.jpg" /><img src="/images/arrowright.jpg" /><img src="/images/flags/usa.jpg" /></asp:ListItem>
            </asp:RadioButtonList>
            <h2>
                Input Text</h2>
            <table>
                <tr>
                    <td>
                        <asp:Image runat="server" ImageUrl="~/images/flags/usa.jpg" ImageAlign="Top" ID="InputFlag" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InputText" Width="500" Height="100" />
                        <br />
                        <asp:Button runat="server" OnClick="Translate_OnClick" Text="Translate" ID="TranslateButton"
                            Width="100px" />
                    </td>
                </tr>
            </table>
            <h2>
                Output Text</h2>
            <table>
                <tr>
                    <td>
                        <asp:Image runat="server" ImageUrl="~/images/flags/haiti.jpg" ImageAlign="Top" ID="OutputFlag" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="OutputText" />
                    </td>
                </tr>
            </table>
            <asp:Literal runat="server" ID="Statistics" />
            
            <br />
            <a href="WebPageTranslator.aspx">Creole to English Web Page Translator</a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

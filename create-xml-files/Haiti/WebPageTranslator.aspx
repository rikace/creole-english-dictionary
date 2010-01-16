<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebPageTranslator.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Creole to English Web Page Translator</h1>
        <asp:TextBox runat="server" ID="txtUrl" Width="200" />
        <asp:Button runat="server" ID="btnSubmit" OnClick="GoButtonHandler" Text="Translate"/><br />
        <asp:Literal runat="server" ID="litContent" />
    </div>
    </form>
</body>
</html>

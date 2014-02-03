<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GissaDetHemligaTalet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="GuessBoxLabel" runat="server" Text="Ange ett tal mellan 1 och 100:" AssociatedControlID="GuessTextBox"></asp:Label>
            <asp:TextBox ID="GuessTextBox" runat="server" autofocus="autofocus"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett tal måste anges" Display="Dynamic" ControlToValidate="GuessTextBox" ValidationGroup="Slutarrå" Text="*"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1 och 100." MaximumValue="100" MinimumValue="1" Display="Dynamic" ControlToValidate="GuessTextBox" Text="*" Type="Integer"></asp:RangeValidator>
            <asp:Button ID="GuessButton" runat="server" Text="Skicka Gissning" OnClick="GuessButton_Click" ValidationGroup="Slutarrå" />

        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
        <div>
            <asp:Label ID="PreviousGuessLabel" runat="server" Text=""></asp:Label>
        </div>

        <div><asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label></div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False">
            <div>
                <asp:Label ID="ResetLabel" runat="server"></asp:Label>
            </div>
            <asp:Button ID="ResetButton" runat="server" Text="Slumpa nytt tal" OnClick="ResetButton_Click" autofocus="autofocus" />
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>

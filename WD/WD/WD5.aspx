<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WD5.aspx.cs" Inherits="WD.WD5" %>

<!--
* FILE : WD5.aspx
* PROJECT : WebDesign - Assignment #5
* PROGRAMMER : Zhendong Tang
* FIRST VERSION : 2018-11-13
* DESCRIPTION : This program is to design a HI-LO game with ASP.NET technology   
-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style >
        .Hide
        {
            display:none;
        }
        .Show
        {
            display:normal;
        }
        .auto-style1 {
            height: 20px;
        }
    </style>


</head>
<body id="PageBody" runat="server">
    <form id="form1" runat="server">
        
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Please tell me your name:"></asp:Label></td>
                <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="ValidateName" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name can only include letters." ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3"><asp:Label ID="LabeL2" runat="server" Text=""></asp:Label></td>
             
            </tr>
            <tr>
               
                <td class="auto-style1"> <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td class="auto-style1"> <asp:TextBox ID="TextBox2" runat="server" cssClass="Hide"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox2" CssClass="Hide" Display="Dynamic" ErrorMessage="Value must be a whole number" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
             
            </tr>
            
            <tr>
               
                <td> <asp:Label ID="Label5" runat="server" Text = "Please guess a Number:" cssClass="Hide"></asp:Label></td>
                <td> <asp:TextBox ID="TextBox3" runat="server" cssClass="Hide"></asp:TextBox></td>
                <td>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Value must be a whole number" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
             
            </tr>
           
            <tr>
                <td colspan="3"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
             </tr>
            
            <tr>
                <td colspan="3"><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
             
            </tr>
             
           
            <tr>
               
                <td> </td>
                <td> <asp:Button Text="Submit" runat="server" OnClick="Unnamed1_Click" ID="btnSubmit" /></td>
                <td> </td>
            </tr>
            <tr>
               
                <td> </td>
                <td> <asp:Button Text="Play Again" runat="server"  cssClass="Hide" OnClick="Unnamed2_Click"  ID="playAgain"/></td>
                <td> </td>
            </tr>
            
        </table>
        
       
       
					
					
        


	

        

    </form>
</body>
</html>
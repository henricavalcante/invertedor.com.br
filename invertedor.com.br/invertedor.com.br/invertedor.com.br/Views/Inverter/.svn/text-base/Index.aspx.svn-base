<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Link original:</h2>
   <%= ViewData["linkoriginal"] %>
   <br />
    <h2>Link Desprotegido:</h2>

    <% 
        var lst = (List<string>)ViewData["url"];
        foreach (var item in lst)
        {
    %>
    <a href="<%= item %>"><%= item %></a><br />       
           
    
    <%        
        }
           %>
           <%= ViewData["mensagem"] %>


           <% if (ViewData["encurtado"] != null)
              {
              %>
              
    <h2>Link Encurtado / Equivalente:</h2>
    <a href="<%= ViewData["encurtado"] %>"><%= ViewData["encurtado"] %></a><br />       
              
              
              <%
              
              
              } %>

   
</asp:Content>

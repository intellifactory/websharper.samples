<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
	  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title>Samples</title>
  </head>
<body>
    <table>
    <%
        string[] samples = WebSharperSiteletsProject.SamplesList.GetSampleNames();
        foreach (string sample in samples)
        {   
    %>
        <tr>
            <td>
                <a href="<%= sample %>"> <%= sample %> </a>
            </td>
        </tr>
    <%
        }
    %>
    </table>    
</body>
</html>

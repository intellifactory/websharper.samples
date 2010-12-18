<%@ Page Language="C#" AutoEventWireup="true"%>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>WebSharper Application</title>
    <WebSharper:ScriptManager runat="server" />
    <style type="text/css">
      .CodeMirror-line-numbers {
        width: 2.2em;
        color: #aaa;
        background-color: #eee;
        text-align: right;
        padding-right: 0.3em;
        font-size: 10pt;
        font-family: monospace;
        padding-top: 0.4em;
        line-height: normal;
      }
      .success
      {
          color:Green;
      }
      .error
      {
          color:Red;
      }
      .WebSharper
      {
          height:100%;
      }
      table
      {
          border:1px solid;
          height:100%;
      }
      .output
      {
          border-width:1px;
          border-style:solid;          
          font-style:italic;
          font-size:8pt;
          overflow:auto;
          height:200px;          
      }
      .message
      {
          margin-left:5px;
      }
    </style>

  </head>

  <body>
    <ws:WebSchemeUI runat="server"/>
  </body>
</html>

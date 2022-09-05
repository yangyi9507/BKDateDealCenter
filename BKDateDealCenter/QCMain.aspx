<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QCMain.aspx.cs" Inherits="BKDateDealCenter.QCMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>博科固定资产数据管理</title>         
    <link href="../Scripts/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/base.js" type="text/javascript"></script> 
    <script src="../Scripts/ligerGrid.js" type="text/javascript"></script>
    <script src="../Scripts/ligerCheckBox.js" type="text/javascript"></script>
    <script src="../Scripts/ligerTextBox.js" type="text/javascript"></script>
    <style>
        input{
            outline-style: none ;
            border: 1px solid #ccc; 
            border-radius: 3px;
            padding: 13px 14px;
            width: 100px;
            font-size: 14px;
            font-weight: 700;
            font-family: "Microsoft soft";
            margin-left:5px;
            margin-top:10px;

        }

        input:focus{
            border-color: #66afe9;
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
        }
        label {
            font-size:17px;            
            margin-left:20px;
            text-align:right;
        }
        td {
            width:280px;
            margin-left:5px;
            margin-top:20px;
            text-align:right;
        }
    </style>
    
    <script type="text/javascript">
        var gridmain = null;

        $(function () {
            //#region 表信息
            gridmain = $("#maingrid").ligerGrid({
                columns: [
                    { display: 'ID', name: 'ID', width: 50,  hide:1 },
                    { display: '批次', name: 'QCNumber', width: 150, editor: { type: "string" }, isAllowHide: false},
                    { display: '运行状态', name: 'Status', width: 150, editor: { type: "string" }},
                    { display: '型号', name: 'Type', width: 100, editor: { type: 'string' }},
                    { display: '种类', name: 'Class', width: 100, editor: { type: 'string' }}
                ],
                enabledSort: true,
                enabledEdit: true,
                clickToEdit: true,
                checkbox: false,
                rownumbers: true,
                cssClass: 'l-grid-gray',
                usePager: false,
                showTitle: true,                
                heightDiff: -2,                
                url: "AjaxMain.aspx?Action=GetQCData",
                width: 1300,
                height: 550,
                onBeforeSubmitEdit: f_onBeforeSubmitEdit
            });
        //#endregion
        });

        function f_onBeforeSubmitEdit(rowdom)
        {
            var row = gridmain.getSelectedRow(); //获取选中行信息

            var conName = rowdom.column.columnname;
            var conValue = rowdom.value;
            switch (conName) {
                case "QCNumber":
                    rowdom.record.QCNumber = conValue;
                    break;
                case "Status":
                    rowdom.record.Status = conValue;
                    break;
                case "Type":
                    rowdom.record.Type = conValue;
                    break;
                case "Class":
                    rowdom.record.Class = conValue;
                    break;
            }

            $.ajax({
                cache: false,
                async: false,
                url: "AjaxMain.aspx?Action=UpdateQCData",
                data: { ID: row.ID, QCNumber: row.QCNumber, Status: row.Status, Type: row.Type, Class: row.Class },
                dataType: 'json', type: 'post',
                beforeSend: function () {
                },
                complete: function () {
                },
                success: function (result) {
                    
                }
            });
        }


        function DataAdd()
        {
            $.ajax({
                cache: false,
                async: false,
                url: "AjaxMain.aspx?Action=InsertQCData",
                data: { QCNumber: txtQCNumber.value, Status: txtStatus.value, Type: txtType.value, Class: txtClass.value},
                dataType: 'json', type: 'post',
                beforeSend: function () {
                },
                complete: function () {
                },
                success: function (result) {

                    GetQCData();
                }
            });
        }

        function GetQCData() {

            var url = "AjaxMain.aspx?Action=GetQCData";
            gridmain.setOptions({ url: url });
        }

        function DataDelete()
        {
            var row = gridmain.getSelectedRow(); //获取选中行信息
            $.ajax({
                cache: false,
                async: false,
                url: "AjaxMain.aspx?Action=DeleteQCData",
                data: { ID:row.ID },
                dataType: 'json', type: 'post',
                beforeSend: function () {
                },
                complete: function () {
                },
                success: function (result) {

                    GetQCData();
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center;color:coral;margin-top:15px;margin-bottom:10px;">
                博科固定资产数据管理
            </h1>            
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <label >批次号:</label>
                        <input type="text" placeholder="批次号" id="txtQCNumber" />
                    </td>
                    <td>
                        <label >运行状态:</label>
                        <input type="text" placeholder="运行状态" id="txtStatus" />
                    </td>
                    <td>
                        <label >型号:</label>
                        <input type="text" placeholder="型号" id="txtType" />
                    </td>
                    <td>
                        <label >种类:</label>
                        <input type="text" placeholder="种类" id="txtClass" />
                    </td>
                    <td>
                        <input type="button" style="background-color:dodgerblue;color:white;width: 100px;height: 47px;border:0;font-size: 16px;border-radius: 30px;" value="增加" onclick="DataAdd()" />
                        <input type="button" style="background-color:dimgrey;color:white;width: 100px;height: 47px;border:0;font-size: 16px;border-radius: 30px;" value="删除" onclick="DataDelete()"  />
                    </td>
                </tr>
            </table>                        
            

        </div>
        
        <div id="maingrid" style="margin-left:60px;margin-top:20px;"></div>
    </form>
</body>
</html>


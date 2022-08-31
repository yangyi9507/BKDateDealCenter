<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BKDateDealCenter.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>博科MES数据管理</title>         
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
                    { display: '订单号', name: 'ORDER_NUM', width: 150, editor: { type: "string" }, isAllowHide: false},
                    { display: '型号', name: 'MODEL_TYPE', width: 150, editor: { type: "string" }},
                    { display: '库存数', name: 'STOCK_NUM', width: 100, editor: { type: 'string' }},
                    { display: '当日入库数', name: 'STORAGE_NUM', width: 100, editor: { type: 'string' }},
                    { display: '当日出库数', name: 'OUTBOUND_NUM', width: 100, editor: { type: 'string' }},
                    { display: '目前缺货数', name: 'SHORAGE_NUM', width: 100, editor: { type: 'string' }},
                    { display: '在产数量', name: 'PRODUCTION_NUM', width: 100, editor: { type: 'string' } },
                    { display: '在途计划', name: 'PLAN_NUM', width: 100, editor: { type: 'string' } }
                ],
                enabledSort: true,
                enabledEdit: true,
                clickToEdit: true,
                checkbox: false,
                rownumbers: true,
                cssClass: 'l-grid-gray',
                usePager: true,
                showTitle: true,                
                heightDiff: -2,                
                url: "AjaxMain.aspx?Action=GetData",
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
                case "ORDER_NUM":
                    rowdom.record.ORDER_NUM = conValue;
                    break;
                case "MODEL_TYPE":
                    rowdom.record.MODEL_TYPE = conValue;
                    break;
                case "STOCK_NUM":
                    rowdom.record.STOCK_NUM = conValue;
                    break;
                case "STORAGE_NUM":
                    rowdom.record.STORAGE_NUM = conValue;
                    break;
                case "OUTBOUND_NUM":
                    rowdom.record.OUTBOUND_NUM = conValue;
                    break;
                case "SHORAGE_NUM":
                    rowdom.record.SHORAGE_NUM = conValue;
                    break;
                case "PRODUCTION_NUM":
                    rowdom.record.PRODUCTION_NUM = conValue;
                    break;
                case "PLAN_NUM":
                    rowdom.record.PLAN_NUM = conValue;
                    break;
            }

            $.ajax({
                cache: false,
                async: false,
                url: "AjaxMain.aspx?Action=UpdateData",
                data: { ID: row.ID, ORDER_NUM: row.ORDER_NUM, MODEL_TYPE: row.MODEL_TYPE, STOCK_NUM: row.STOCK_NUM, STORAGE_NUM: row.STORAGE_NUM, OUTBOUND_NUM: row.OUTBOUND_NUM, SHORAGE_NUM: row.SHORAGE_NUM, PRODUCTION_NUM: row.PRODUCTION_NUM, PLAN_NUM:row.PLAN_NUM },
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
                url: "AjaxMain.aspx?Action=InsertData",
                data: { ORDER_NUM: txtORDER_NUM.value, MODEL_TYPE: txtMODEL_TYPE.value, STOCK_NUM: txtSTOCK_NUM.value, STORAGE_NUM: txtSTORAGE_NUM.value, OUTBOUND_NUM: txtOUTBOUND_NUM.value, SHORAGE_NUM: txtSHORAGE_NUM.value, PRODUCTION_NUM: txtPRODUCTION_NUM.value, PLAN_NUM: txtPLAN_NUM.value },
                dataType: 'json', type: 'post',
                beforeSend: function () {
                },
                complete: function () {
                },
                success: function (result) {

                    GetData();
                }
            });
        }

        function GetData() {

            var url = "AjaxMain.aspx?Action=GetData";
            gridmain.setOptions({ url: url });
        }

        function DataDelete()
        {
            var row = gridmain.getSelectedRow(); //获取选中行信息
            $.ajax({
                cache: false,
                async: false,
                url: "AjaxMain.aspx?Action=DeleteData",
                data: { ID:row.ID },
                dataType: 'json', type: 'post',
                beforeSend: function () {
                },
                complete: function () {
                },
                success: function (result) {

                    GetData();
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center;color:coral;margin-top:15px;margin-bottom:10px;">
                博科MES数据管理
            </h1>            
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <label >订单号:</label>
                        <input type="text" placeholder="输入订单号" id="txtORDER_NUM" />
                    </td>
                    <td>
                        <label >型号:</label>
                        <input type="text" placeholder="输入型号" id="txtMODEL_TYPE" />
                    </td>
                    <td>
                        <label >库存数:</label>
                        <input type="text" placeholder="输入库存数" id="txtSTOCK_NUM" />
                    </td>
                    <td>
                        <label >当日入库数:</label>
                        <input type="text" placeholder="输入当日入库数" id="txtSTORAGE_NUM" />
                    </td>
                    <td>
                        <label >当日出库数:</label>
                        <input type="text" placeholder="输入当日出库数" id="txtOUTBOUND_NUM" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label >目前缺货数:</label>
                        <input type="text" placeholder="输入目前缺货数" id="txtSHORAGE_NUM" />
                    </td>
                    <td>
                        <label >在产数量:</label>
                        <input type="text" placeholder="输入在产数量" id="txtPRODUCTION_NUM" />
                    </td>
                    <td>
                        <label >在途计划:</label>
                        <input type="text" placeholder="输入在途计划" id="txtPLAN_NUM" />
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

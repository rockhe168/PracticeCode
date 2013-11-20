<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%
    DataTable dataTable = Model as DataTable;
%>
<div>
    <p>
        <label>
            上级字典项编号：</label>
        <input name="parentid" type='text' size='30' class="required" title="上级字典项编号不能为空"
            value="<%=ViewData["parentid"] %>" />
    </p>
    <p>
        <label>
            字典项编号：</label>
        <input name="id" type='text' size='30' readonly="readonly" value="<%=ViewData["id"] %>" />
    </p>
    <p style="width:500px;">
        <label>
            字典项名称：</label>
        <input name="name" type='text' size='30' class="required readonly" readonly=readonly title="字典项名称不能为空" value="<%=ViewData["name"] %>" />
        <%--<label style="color:Red; width:auto;">不要改变该内容， 会影响系统</label>--%>
    </p>
    <p>
        <label>
            字典项标题：</label>
        <input name="title" type='text' size='30' class="required" value="<%=ViewData["title"] %>" />
    </p>
</div>
<div>
    <%if (dataTable != null)
      {
    %>
    <table id="table<%=PageId %>" class="list nowrap itemDetail" addbutton="新增" width="100%">
        <thead>
            <th type="label" name="items[#index#].id" defaultval="[#index#]" size="12" fieldclass="digits">
                Id
            </th>
            <th type="enum" name="items[#index#].enableflag" enumurl="/config/SelectDataDict.bee?name=items%5b%23index%23%5d.enableflag&dictname=是否">
                是否有效
            </th>
            <th type="number" name="items[#index#].optionid" fieldclass="required" size="15">
                值
            </th>
            <th type="number" name="items[#index#].optionvalue" fieldclass="required" size="30">
                名称
            </th>
            <th type="del" width="60">
                操作
            </th>
        </thead>
        <tbody>
            <%
                int index = 0;
                foreach (DataRow row in dataTable.Rows)
                {

                    string prefix = string.Format("items[{0}].", index);
                    index++;
                    
            %>
            <tr>
                <td>
                    <input type="hidden" name="<%=prefix %>id" value="<%=row["id"] %>" />
                    <span>[<%=index %>]</span>
                </td>
                <td>
                    <select name="<%=prefix %>enableflag" class="combox" svalue="<%=row["enableflag"] %>">
                        <option value="False">否</option>
                        <option value="True">是</option>
                    </select>
                </td>
                <td>
                    <input type="textbox" value='<%=row["optionid"] %>' name='<%=prefix %>optionid' class="required"
                        size="15" />
                </td>
                <td>
                    <input type="textbox" value='<%=row["optionvalue"] %>' name='<%=prefix %>optionvalue'
                        class="required" size="30" />
                </td>
                <td>
                    <a href='javascript:void(0)' class='btnDel'>删除</a>
                </td>
            </tr>
            <%}
          
            %>
        </tbody>
    </table>
    <%
        } %>
</div>

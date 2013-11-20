     $(document).ready(function() {
            //加载PageSize和页码PageIndex
            GetData(10,1);
        });
        function InitPager(RecordCount, PageIndex,PageSize,Data) {
        $("#Pager").setPager({ RecordCount: RecordCount, PageIndex: PageIndex,PageSize:PageSize, buttonClick: PageClick });
            //页面数据填充
       $("#tBodyMaster").empty();
       $.each(Data,function(key,value){
          //图片回调(集中请求)
         var PicSrc="/Admin/FileManage/GetImg.ashx?method=GetMasterPic&type=medium&fileName="+Data[key].Picturepath;
            var item='<tr><td><a href="MasterInfo.aspx?MasterId='+Data[key].Id+'"><img src="'+PicSrc+'" title="'+Data[key].Name+'" alt="'+Data[key].Name+'"/><br/>'+Data[key].Name+'</a></td>';
            item+='<td class="jianjie"><a href="MasterInfo.aspx?MasterId='+Data[key].Id+'"><span>'+Data[key].Introduction+'</span></a></td>';
            item+='<td class="adress"><a href="MasterInfo.aspx?MasterId='+Data[key].Id+'">'+Data[key].Name+'的主页</a></td></tr>';
       $("#tBodyMaster").append(item);
       }); 
        };
        PageClick = function(RecordCount,PageIndex,PageSize) {
             GetData(PageSize,PageIndex);
        };
        //sortField排序字段
       function GetData(PageSize,PageIndex){
       $.ajax({
       url:'Data/MasterInfo.ashx?method=SearchMaster',
       //注意后台分页存储过程的PageIndex是从0开始的,所以这里要-1
       data:'sortField=Id&sortOrder=desc&pageIndex='+(PageIndex-1)+'&pageSize='+PageSize,
       success:function(text){
       var jsonData=$.parseJSON(text);
       InitPager(jsonData.total, PageIndex,PageSize,jsonData.data);
       }
       
       });
       }
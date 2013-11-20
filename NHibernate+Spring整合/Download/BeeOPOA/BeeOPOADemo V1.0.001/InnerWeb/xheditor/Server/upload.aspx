<%@ Page Language="C#" AutoEventWireup="true" CodePage="65001" %>
<%@ Import namespace="System" %>
<%@ Import namespace="System.Collections" %>
<%@ Import namespace="System.Configuration" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="System.Web" %>
<%@ Import namespace="System.Web.Security" %>
<%@ Import namespace="System.Web.UI" %>
<%@ Import namespace="System.Web.UI.HtmlControls" %>
<%@ Import namespace="System.Web.UI.WebControls" %>
<%@ Import namespace="System.Web.UI.WebControls.WebParts" %>

<script runat="server">
    /*
 * upload demo for c# .net 2.0
 * 
 * @requires xhEditor
 * @author Jediwolf<jediwolf@gmail.com>
 * @licence LGPL(http://www.opensource.org/licenses/lgpl-license.php)
 * 
 * @Version: 0.1.4 (build 111027)
 * 
 * ע1���������Ϊ��ʾ�ã�������ظ����Լ����������Ӧ�޸ģ������ؿ���
 * ע2��������HTML5�ϴ�����ͨPOST�ϴ�ת��Ϊbyte����ͳһ����
 * 
 */

protected void Page_Load(object sender, EventArgs e)
{
    Response.Charset = "UTF-8";

	// ��ʼ��һ��ѱ���
	string inputname = "filedata";//���ļ���name
    string attachdir = "/Resources/upimages";     // �ϴ��ļ�����·������β��Ҫ��/
    int dirtype = 1;                 // 1:�������Ŀ¼ 2:���´���Ŀ¼ 3:����չ����Ŀ¼  ����ʹ�ð����
    int maxattachsize = 2097152;     // ����ϴ���С��Ĭ����2M
    string upext = "txt,rar,zip,jpg,jpeg,gif,png,swf,wmv,avi,wma,mp3,mid,xls";    // �ϴ���չ��
    int msgtype = 2;                 //�����ϴ������ĸ�ʽ��1��ֻ����url��2�����ز�������
	string immediate = Request.QueryString["immediate"];//�����ϴ�ģʽ����Ϊ��ʾ��
    byte[] file;                     // ͳһת��Ϊbyte���鴦��
    string localname = "";
    string disposition = Request.ServerVariables["HTTP_CONTENT_DISPOSITION"];

    string err = "";
    string msg = "''";
    
    if (disposition != null)
    {
        // HTML5�ϴ�
        file = Request.BinaryRead(Request.TotalBytes);
        localname = Server.UrlDecode(Regex.Match(disposition, "filename=\"(.+?)\"").Groups[1].Value);// ��ȡԭʼ�ļ���
    }
    else 
    {        
        HttpFileCollection filecollection = Request.Files;
        HttpPostedFile postedfile = filecollection.Get(inputname);

        // ��ȡԭʼ�ļ���
        localname = postedfile.FileName;
        // ��ʼ��byte����.
        file = new Byte[postedfile.ContentLength];
        
        // ת��Ϊbyte����
        System.IO.Stream stream = postedfile.InputStream;
        stream.Read(file, 0, postedfile.ContentLength);
        stream.Close();

        filecollection = null;
    }
    
    if (file.Length == 0)err = "�������ύ";
    else
    {
        if (file.Length > maxattachsize)err = "�ļ���С����" + maxattachsize + "�ֽ�";
        else
        {
            string attach_dir, attach_subdir, filename, extension, target;

            // ȡ�����ļ���׺��
            extension = GetFileExt(localname);
            
            if (("," + upext + ",").IndexOf("," + extension + ",") < 0)err = "�ϴ��ļ���չ������Ϊ��" + upext;
            else
            {
                switch (dirtype)
                {
                    case 2:
                        attach_subdir = "month_" + DateTime.Now.ToString("yyMM");
                        break;
                    case 3:
                        attach_subdir = "ext_" + extension;
                        break;
                    default:
                        attach_subdir = "day_" + DateTime.Now.ToString("yyMMdd");
                        break;
                }
                attach_dir = attachdir + "/" + attach_subdir + "/";

                // ��������ļ���
                Random random = new Random(DateTime.Now.Millisecond);
                filename = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000) + "." + extension;

                target = attach_dir + filename;
                try
                {
                    CreateFolder(Server.MapPath(attach_dir));

                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(target), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    fs.Write(file, 0, file.Length);
                    fs.Flush();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    err = ex.Message.ToString();
                }

                // ����ģʽ�ж�
                if (immediate == "1") target = "!" + target;
				target=jsonString(target);
				if(msgtype==1)msg = "'"+target+"'";
                else msg = "{'url':'" + target + "','localname':'" + jsonString(localname) + "','id':'1'}";
            }
        }
    }

    file = null;
    
    Response.Write("{'err':'" + jsonString(err) + "','msg':" + msg + "}");
}


string jsonString(string str) 
{
    str = str.Replace("\\", "\\\\");
    str = str.Replace("/", "\\/");
    str = str.Replace("'", "\\'");
    return str;
}


string GetFileExt(string FullPath) 
{
    if (FullPath != "")return FullPath.Substring(FullPath.LastIndexOf('.') + 1).ToLower();
    else return "";
}

void CreateFolder(string FolderPath)
{
    if (!System.IO.Directory.Exists(FolderPath))System.IO.Directory.CreateDirectory(FolderPath);
}
    
</script>

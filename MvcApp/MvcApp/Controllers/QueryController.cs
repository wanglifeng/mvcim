using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class QueryController : Controller
    {
        //
        // GET: /Query/

        DBHelper helper = new DBHelper();
        public ActionResult JqQuery()
        {
            return View();
        }
        public bool GetValue(string str, QueryModels model)
        {
            string[] ReadText = str.Split(',');
          


            model.weight = Convert.ToDouble(ReadText[1]);//体重1
            model.height = Convert.ToDouble(ReadText[2]); //身高input2
            model.zongchang = Convert.ToDouble(ReadText[3]); //总长3
            model.rugao = Convert.ToDouble(ReadText[4]); //乳高4
            model.waistheight = Convert.ToDouble(ReadText[5]); //腰高5
            model.hipheight = Convert.ToDouble(ReadText[6]); //臀高6
            model.yaogao = Convert.ToDouble(ReadText[7]);//腰长7
            model.Up = Convert.ToDouble(ReadText[8]);//上裆长8
            model.Down = Convert.ToDouble(ReadText[9]);//下裆长9
            model.huiyingao = Convert.ToDouble(ReadText[10]);//会阴高10
            model.waihuaigao = Convert.ToDouble(ReadText[11]);//外踝高11

            model.shoulder = Convert.ToDouble(ReadText[12]);//肩宽12
            model.across = Convert.ToDouble(ReadText[13]);//背宽13
            model.xiongkuan = Convert.ToDouble(ReadText[14]); //胸宽14
            model.shuangrujiankuan = Convert.ToDouble(ReadText[15]);//双乳间隔宽15


            model.bust = Convert.ToDouble(ReadText[16]); //胸围input16
            model.underbust = Convert.ToDouble(ReadText[17]); //胸下围input17
            model.waist = Convert.ToDouble(ReadText[18]);//腰围input18
            model.abd = Convert.ToDouble(ReadText[19]);//腹围input19
            model.hip = Convert.ToDouble(ReadText[20]);//臀围input20
            model.shoubiwei = Convert.ToDouble(ReadText[21]);//手臂终端围21
            model.biwei = Convert.ToDouble(ReadText[22]);//臂围22
            model.zhouwei = Convert.ToDouble(ReadText[23]); //肘围23
            model.shouwanwei = Convert.ToDouble(ReadText[24]); //手腕围24
            model.head = Convert.ToDouble(ReadText[25]);//头围25
            model.jingwei = Convert.ToDouble(ReadText[26]);//颈围26
            model.thigh = Convert.ToDouble(ReadText[27]);//大腿围27
            model.calf = Convert.ToDouble(ReadText[28]);//小腿围28

            model.beichang = Convert.ToDouble(ReadText[29]); //背长29
            model.houchang = Convert.ToDouble(ReadText[30]);//后长30
            model.qianchang = Convert.ToDouble(ReadText[31]);//前长31
            model.xiuchang = Convert.ToDouble(ReadText[32]); //袖长32
            model.xichang = Convert.ToDouble(ReadText[33]);//膝长33
            model.shangdangchang = Convert.ToDouble(ReadText[34]);//上档前后长34

            return true;
        }
        [HttpGet]
        public ActionResult JqQuery(string jiguan, string shengao, string xiongwei,
          string xiawei, string yaowei, string fuwei, string tunwei
            )
        {
            helper.OpenConnection();
            OleDbDataReader reader = helper.ExecuteQuery("select * from CustInfo ");
            List<QueryModels> querymodels = new List<QueryModels>();
            QueryModels model=new QueryModels();
            while (reader.Read())
            {
                string a = reader["Info"].ToString();
                GetValue(a,model);
                model.age = Convert.ToInt32(reader["Age"]); //年龄
                model.pro = Convert.ToString(reader["JiGuan"]);//籍贯input
                querymodels.Add(model);
            }
            return View(querymodels);
            //int pageSize = 10;
            //IEnumerable<User> users = DbContext.Users.OrderBy(t => t.IsDeleted);
            //int totalCount = users.Count();
            //users = users.OrderByDescending(t => t.Id).Skip((page - 1) * pageSize).Take(pageSize);
            //return View(users.ToPageList<User>(page, pageSize, totalCount));
        }

    }
}

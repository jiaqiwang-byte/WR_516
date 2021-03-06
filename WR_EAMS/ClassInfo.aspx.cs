﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_BLL;
using WR_Model;

namespace WR_EAMS
{
    public partial class ClassInfo : System.Web.UI.Page
    {
        ScienceManager scienceManager = new ScienceManager(); 
        Student student = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (Session["students"] != null)
                {
                    student = Session["students"] as Student;
                    if (!IsPostBack)
                    {
                        IntitData(student);
                    }
                }
                else
                {
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
            }
        }

        private void IntitData(Student student)
        {
            Session["sciences"] = scienceManager.CheckScienceListBySid(student);
        }
    }
}
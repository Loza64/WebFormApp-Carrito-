using System;
using System.Web.UI;

namespace Pedidos.Custom
{
    public class BasePage : Page
    {
        private SessionManager _sessionmanager;

        protected SessionManager SessionManager
        {
            get { return _sessionmanager; }
            set { _sessionmanager = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Session["KeyStore"] = "0";
            this._sessionmanager = new SessionManager(Session);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Context.Session != null)
            {
                if (Session.IsNewSession)
                {
                    try
                    {
                        string cookie = Request.Headers["Cookie"];
                        if (cookie != null && cookie.IndexOf("ASP.NET_UserSession") >= 0)
                        {
                            Response.Redirect("Acces/Login.aspx");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Acces/Login.aspx");
                    }

                }
            }
        }
    }
}
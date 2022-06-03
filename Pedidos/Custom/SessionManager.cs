using Entities;
using System.Web.SessionState;

namespace Pedidos.Custom
{
    public class SessionManager
    {
        #region  variables
        private HttpSessionState _currentsession;
        #endregion
        //Almacena la información en parametro
        public SessionManager(HttpSessionState Session)
        {
            // se llama a la varable declarada
            this._currentsession = Session;
        }
        #region metodos
        //retorna la información que se almacena en el parametro segun el tipo de parametro
        private HttpSessionState Currentsession
        {
            get { return this._currentsession; }
        }
        //Almacenar toda la informacion en la clase entidad de usuario para mostrarlo en la pagina mastra
        public Usuario UserSession
        {
            set { Currentsession["UserSession"] = value; }
            get { return (Usuario)Currentsession["UserSession"]; }
        }
        #endregion
    }
}
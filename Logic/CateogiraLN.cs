using Entities;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System;
using DataAcces;

namespace Logic
{
    public class CateogiraLN
    {
        private static CateogiraLN categoriaLn = null;
        private CateogiraLN() { }
        public static CateogiraLN GetInstance()
        {
            if (categoriaLn == null)
            {
                categoriaLn = new CateogiraLN();
            }
            return categoriaLn;
        }

        public string GetCategory(long id)
        {
            try
            {
                return CateogiraDAO.GetInstance().GetCategory(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SqlNullValueException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

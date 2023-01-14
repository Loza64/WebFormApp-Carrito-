using DataAcces;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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

        public string GetCategoryName(long id)
        {
            try
            {
                return CateogiraDAO.GetInstance().GetCategoryName(id);
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

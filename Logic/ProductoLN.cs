using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Logic
{
    public class ProductoLN
    {
        private static ProductoLN product = null;
        private ProductoLN() { }
        public static ProductoLN GetInstance()
        {
            if (product == null)
            {
                product = new ProductoLN();
            }
            return product;
        }

        public List<Producto> ShowProducts()
        {
            try
            {
                return ProductoDAO.GetInstance().ShowProducts();
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

        public Producto GetProduct(long id)
        {
            try
            {
                return ProductoDAO.GetInstance().GetProduct(id);
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

        public string GetImgProduct(long id)
        {
            try
            {
                return ProductoDAO.GetInstance().GetImgProduct(id);
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

        public List<Producto> SearchProduct(string nombre)
        {
            try
            {
                return ProductoDAO.GetInstance().SearchProduct(nombre);
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

        public bool registrarproducto(Producto producto)
        {
            try
            {
                return ProductoDAO.GetInstance().NewProduct(producto);
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

        public long Stock(long Id)
        {
            try
            {
                return ProductoDAO.GetInstance().GetStockProduct(Id);
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



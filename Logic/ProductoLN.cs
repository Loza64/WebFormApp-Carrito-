using DataAcces;
using Entities;
using System;
using System.Data;
using System.Data.SqlClient;

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

        public DataTable mostrarproducto()
        {
            try
            {
                return ProductoDAO.GetInstance().mostrarproducto();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ImagenProducto(long id)
        {
            try
            {
                return ProductoDAO.GetInstance().ImagenProducto(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto seleccionarproducto(long id)
        {
            try
            {
                return ProductoDAO.GetInstance().selectproduct(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable buscarproducto(string nombre)
        {
            try
            {
                return ProductoDAO.GetInstance().buscarproducto(nombre);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
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
                return ProductoDAO.GetInstance().registrarproducto(producto);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
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



using DataAcces;
using Entities;
using System;
using System.Data;

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto seleccionarproducto(long id)
        {
            try
            {
                return ProductoDAO.GetInstance().seleccionarproducto(id);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

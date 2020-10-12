using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miguel_P1_AP2.DAL;
using Miguel_P1_AP2.Models;

namespace Miguel_P1_AP2.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            if (!Existe(articulo.ArticuloId))

                return Insertar(articulo);
            else
                return Modificar(articulo);

        }

        private static bool Insertar(Articulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Articulos.Add(articulo);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Articulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(articulo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var auxProducto = contexto.Articulos.Find(id);
                if (auxProducto != null)
                {
                    contexto.Articulos.Remove(auxProducto);
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulo;

            try
            {
                articulo = contexto.Articulos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulo;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Articulos.Any(p=>p.ArticuloId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Articulos.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Miguel_P1_AP2.Models;
using Miguel_P1_AP2.DAL;

namespace Miguel_P1_AP2.BLL
{
    public class PedidosBLL
    {

        public static bool Guardar(Pedidos pedido)
        {
            if (!Existe(pedido.PedidoId))

                return Insertar(pedido);
            else
                return Modificar(pedido);

        }

        private static bool Insertar(Pedidos pedido)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Pedidos.Add(pedido);
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

        private static bool Modificar(Pedidos pedido)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(pedido).State = EntityState.Modified;
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
                var auxPedido = contexto.Pedidos.Find(id);
                if (auxPedido != null)
                {
                    contexto.Pedidos.Remove(auxPedido);
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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Pedidos.Any(p=>p.PedidoId == id);

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

        public static Pedidos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pedidos pedidos;

            try
            {
                pedidos = contexto.Pedidos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pedidos;

        }

        public static List<Pedidos> GetList(Expression<Func<Pedidos, bool>> expression)
        {
            List<Pedidos> lista = new List<Pedidos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Pedidos.Where(expression).ToList();
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
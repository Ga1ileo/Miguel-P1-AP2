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
    public class DepartamentosBLL
    {
        public static Departamentos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Departamentos departamentos;

            try
            {
                departamentos = contexto.Departamentos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return departamentos;

        }

        public static List<Departamentos> GetList(Expression<Func<Departamentos, bool>> expression)
        {
            List<Departamentos> lista = new List<Departamentos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Departamentos.Where(expression).ToList();
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
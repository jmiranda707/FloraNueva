/*
using Marvelapp.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class DataAccess : IDisposable
    {
        #region Properties
        private SQLiteConnection connection { set; get; }
        #endregion

        #region Constructor    
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(
                config.DirectorioDB,
                "FloraNueva.db3"));
           //////////estas son mis Tablas de BD//////////
            connection.CreateTable<Material>();
           
        }

        #endregion

        #region Methods Material
        public void InsertMaterial(Material material)
        {
            connection.Insert(material);
        }

        public void UpdateMaterial(Material material)
        {
            connection.Update(material);
        }

        public void DeleteMaterial(Material material)
        {
            connection.Delete(material);
        }

        public Material GetMateriales(int id)
        {
            return connection.Table<Material>().FirstOrDefault(c => c.IdMaterial == id);
        }

        public List<Material> GetMateriales()
        {
            return connection.Table<Material>().ToList();
        }

        public void DeleteAllMateriales()
        {
            connection.DeleteAll<Material>();
        }
        #endregion




        public void Dispose()
        {
            connection.Dispose();//cerrar conexion
        }
    }
}
*/
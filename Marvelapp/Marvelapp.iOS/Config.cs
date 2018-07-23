/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Marvelapp.Interfaces;
using SQLite.Net.Interop;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Marvelapp.iOS.Config))]
namespace Marvelapp.iOS
{
    public class Config : IConfig
    {
        string directorioDB;

        ISQLitePlatform plataforma { set; get; }

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directorioDB = System.IO.Path.Combine(directorio, "..", "Library");
                }
                return directorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return plataforma;
            }
        }

    }
}
*/
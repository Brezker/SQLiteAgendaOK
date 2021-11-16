﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;
using System.IO;
using SQLiteAgendaOK.Droid;
using SQLiteAgendaOK.Datos;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLiteDB))]
namespace SQLiteAgendaOK.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la Base de Datos
            var path = Path.Combine(ruta, "AgendaSQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}

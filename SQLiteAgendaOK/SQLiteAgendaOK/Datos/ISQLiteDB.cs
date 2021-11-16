using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SQLiteAgendaOK.Datos
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

//WebService que recebe os dados da Playlist e ouvinte vindos do client .NET no projecto iRadioDEI e grava na sua tabela da sua própria BD

public class Service : IService
{
    public void SetPreferences(IEnumerable<Preference> Lp)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        db.Preferences.InsertAllOnSubmit(Lp.ToList());
        db.SubmitChanges();
    }

}
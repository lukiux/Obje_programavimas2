using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Collections;

/// <summary>
/// Klasė Gyventojaus duomenis saugoti
/// </summary>
/// <class name="Resident"></class>
public class Resident : IComparable<Resident>, IEquatable<Resident>
{
    public string street { get; set; }  // gatvė
    public string name { get; set; }    // pavardė
    public int homeNR { get; set; }     // namo nr.
    public int telNr { get; set; }     // tel. nr.
    /// <summary>
    /// Pradiniai gyventojaus duomenys
    /// </summary>
    public Resident() { }
    /// <summary>
    /// Spausdinimo metodas
    /// </summary>
    /// <returns>formatas</returns>
    public override string ToString()
    {
        return string.Format("{0, -12}{1, -13}{2, 8}{3, 20}", name, street, homeNR, telNr);
    }
    /// <summary>
    /// Palyginimo sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns></returns>
    public int CompareTo(Resident other)
    {
        if (other == null) return 1;
        if (homeNR.CompareTo(other.homeNR) != 0)
            return homeNR.CompareTo(other.homeNR);
        else
            return name.CompareTo(other.name);
    }
    /// <summary>
    /// Vienodų sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns>true ar false</returns>
    public bool Equals(Resident other)
    {
        if (other == null)
            return false;
        if (this.street == other.street)
            return true;
        else
            return false;
    }
    /// <summary>
    /// Vienodų sąsajos užkloto metodas
    /// </summary>
    /// <param name="obj">objektas</param>
    /// <returns>true ar false</returns>
    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;
        Resident res = obj as Resident;
        if (res == null)
            return false;
        else
            return Equals(res);
    }
    /// <summary>
    /// Užklotas metodas
    /// </summary>
    /// <returns>gethascode</returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
/// <summary>
/// Klasė telefonų numerio duomenims saugoti
/// </summary>
/// <class name="TelNumber"></class>
public class TelNumber : IComparable<TelNumber>, IEquatable<TelNumber>
{
    public int oldTelNr { get; set; }  // senas telefono numeris
    public int newTelNr { get; set; }  // naujas telefono numeris
    /// <summary>
    /// Pradiniai telefonų numerio duomenys
    /// </summary>
    public TelNumber() { }
    /// <summary>
    /// Palyginimo sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns></returns>
    public int CompareTo(TelNumber other)
    {
        if (other == null) return 1;
        if (oldTelNr.CompareTo(other.oldTelNr) != 0)
            return oldTelNr.CompareTo(other.oldTelNr);
        else
            return -1;
    }
    /// <summary>
    /// Vienodų sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns>true ar false</returns>
    public bool Equals(TelNumber other)
    {
        if (other == null)
            return false;
        if (this.oldTelNr == other.oldTelNr)
            return true;
        else
            return false;
    }
    /// <summary>
    /// Vienodų sąsajos užkloto metodas
    /// </summary>
    /// <param name="obj">objektas</param>
    /// <returns>true ar false</returns>
    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;
        TelNumber res = obj as TelNumber;
        if (res == null)
            return false;
        else
            return Equals(res);
    }
    /// <summary>
    /// Užklotas metodas
    /// </summary>
    /// <returns>gethashcode</returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
public partial class LD4 : System.Web.UI.Page
{
    const string fv1 = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld4\Failas";
    const string fvtel = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld4\TelefonoNr.txt";
    const string fr = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld4\Rezultatai.txt";
    object sender = fv1;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox3.Visible = false;
        Label3.Visible = false;
        string[] files = Directory.GetFiles(fv1);
        foreach (string file in files)
            TextBox1.Text = TextBox1.Text + "\n" + File.ReadAllText(file, Encoding.GetEncoding(1257));
        TextBox2.Text = File.ReadAllText(fvtel, Encoding.GetEncoding(1257));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        File.WriteAllText(fr, string.Empty);
        Button1.Visible = false;
        TextBox3.Visible = true;
        Label3.Visible = true;
        var A = new LinkedList<Resident>();
        var Tel = new LinkedList<TelNumber>();
        var NewList = new LinkedList<Resident>();
        var NewList2 = new LinkedList<Resident>();
        ReadData(fv1, A);
        PrintData(fr, A, " Pradiniai duomenis");
        ReadDataTel(fvtel, Tel);
        NewLists(A, Tel, NewList);        
        PrintData(fr, NewList, "Abonentų sąrašas");
        List<Resident> Cr;
        Cr = NewList.ToList();
        Cr.Sort();
        PrintData(fr, Cr, "Rikiuotas");
        Max(NewList, fr);        
        TextBox3.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Rezultatai.txt");
    }
    /// <summary>
    /// Skaitomi gyventojų duomenys iš failo
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Kolekcijos vardas</param>
    static void ReadData(string fv, LinkedList<Resident> A)
    {
        string line;
        string[] files = Directory.GetFiles(fv);
        foreach (string file in files)
        {
            using (var reader = new StreamReader(file, Encoding.GetEncoding(1257)))
            {
                line = reader.ReadLine();
                string[] values = line.Split(';');
                string street = values[0];
                while ((line = reader.ReadLine()) != null)
                {
                    values = line.Split(';');
                    var Res = new Resident();
                    Res.name = values[0];
                    Res.homeNR = Convert.ToInt32(values[1]);
                    Res.telNr = Convert.ToInt32(values[2]);                    
                    Res.street = street;
                    A.AddLast(Res);
                }
            }
        }
    }
    /// <summary>
    /// Skaitomi telefonų numerių duomenys iš failo
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Kolekcijos vardas</param>
    static void ReadDataTel(string fv, LinkedList<TelNumber> A)
    {
        string line;
        using (var reader = new StreamReader(fv))
        {
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                var Res = new TelNumber();
                Res.oldTelNr = Convert.ToInt32(values[0]);
                Res.newTelNr = Convert.ToInt32(values[1]);                
                A.AddLast(Res);
            }
        }
    }
    /// <summary>
    /// Spausdinami gyventojų duomenys į failą
    /// </summary>
    /// <typeparam name="type">typas</typeparam>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Kolekcijos vardas</param>
    /// <param name="eil">Paraštė</param>
    static void PrintData<type>(string fv, IEnumerable<type> A, string eil) where type : IComparable<type>, IEquatable<type>
    {
        using (var frr = new StreamWriter(fv, true))
        {
            string bruk = new string('-', 55);
            frr.WriteLine(eil);
            frr.WriteLine(bruk);
            frr.WriteLine(" Pavardė    Gatvė           Namas Nr.       Tel.Nr.");
            frr.WriteLine(bruk);
            foreach (type one in A)
                frr.WriteLine(one);
            frr.WriteLine(bruk);
            frr.WriteLine();
        }
    }
    /// <summary>
    /// Suranda ir sudaro sąrašą abonentų, kurių telefonų numeriai pasikeitė
    /// </summary>
    /// <param name="A">Gyventojų kolekcijos vardas</param>
    /// <param name="TelNr">Telefonų numerių kolekcijos vardas</param>
    /// <param name="New">Naujas sąrašas</param>
    static void NewLists(LinkedList<Resident> A, LinkedList<TelNumber> TelNr, LinkedList<Resident> New) 
    {
        foreach (Resident one in A)
        {
            foreach (TelNumber tel in TelNr)
            {
                if (one.telNr == tel.oldTelNr)
                {
                    one.telNr = tel.newTelNr;
                    New.AddLast(one);
                    break;
                }
            }            
        }
    }
    /// <summary>
    /// Suranda ir išspausdina, kurioje gatvėje pasikeičia daugiausiai telefonų numerių.
    /// </summary>
    /// <param name="A">Kolekcijos vardas</param>
    /// <param name="fv">Duomenų failo vardas</param>
    static void Max(LinkedList<Resident> A, string fv)
    {
        int max = 0;
        IEnumerable<string> D = A.Select(m => m.street);
        int number = 0;
        string street = "";
        string str = "";
        foreach (string one in D)
        {
            if (one != street)
            {
                number = A.Count(l => l.street == one);
                if (number > max)
                {
                    max = number;
                    str = one;
                }
            }
            street = one;
        }
        using (var frr = new StreamWriter(fv, true))
        {
            frr.WriteLine("{0} gatvėje pakeista daugiausia telefonų", str);
        }
    }
}
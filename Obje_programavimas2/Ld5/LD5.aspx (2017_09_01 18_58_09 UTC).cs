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
public class Resident
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
}
/// <summary>
/// Klasė telefonų numerio duomenims saugoti
/// </summary>
/// <class name="TelNumber"></class>
public class TelNumber 
{
    public int oldTelNr { get; set; }  // senas telefono numeris
    public int newTelNr { get; set; }  // naujas telefono numeris
    /// <summary>
    /// Pradiniai telefonų numerio duomenys
    /// </summary>
    public TelNumber() { }
}

public partial class LD5 : System.Web.UI.Page
{
    const string fv1 = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld5\Failas";
    const string fvtel = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld5\TelefonoNr.txt";
    const string fr = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld5\Rezultatai.txt";
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox3.Visible = false;
        Label3.Visible = false;
        string[] files = Directory.GetFiles(fv1);
        foreach (var file in files)
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
        ReadData(fv1, A);
        ReadDataTel(fvtel, Tel);
        PrintData(fr, A, "Pradiniai duomenis");
        List<Resident> NewList = (from a in A from b in Tel where a.telNr == b.oldTelNr select new Resident{ name = a.name, street = a.street, homeNR = a.homeNR, telNr = b.newTelNr}).ToList<Resident>();
        if (NewList.Any())
            PrintData(fr, NewList, "Abonentų sąrašas");
        List<Resident> Sort = (from a in NewList orderby a.homeNR, a.name select a).ToList<Resident>();
        PrintData(fr, Sort, "Rikiuota");
        var B = NewList.ToList<Resident>();
        var kok = from a in B select new { kieks = NewList.Count(m => m.street == a.street), pav = a.street};
        var k = from a in kok where kok.Max(l => l.kieks) == a.kieks select a.pav;
        using (var frr = new StreamWriter(fr, true))
        {
            string pav = k.First();
            frr.WriteLine(pav + " " + "gatvėje pakeista daugiausia telefonų");
        }            
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
    static void PrintData(string fv, IEnumerable A, string eil)
    {
        using (var frr = new StreamWriter(fv, true))
        {
            string bruk = new string('-', 55);
            frr.WriteLine(eil);
            frr.WriteLine(bruk);
            frr.WriteLine(" Pavardė    Gatvė           Namas Nr.       Tel.Nr.");
            frr.WriteLine(bruk);
            foreach (var one in A)
                frr.WriteLine(one);
            frr.WriteLine(bruk);
            frr.WriteLine();
        }
    }
}
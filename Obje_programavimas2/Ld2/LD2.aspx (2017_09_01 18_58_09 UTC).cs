using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public class Krepšininkas
{
    public string team { get; set; }
    public string var { get; set; }
    public string pav { get; set; }
    public int gim { get; set; }
    public int ugis { get; set; }
    public string poz { get; set; }
    public int taskas { get; set; }
    public int klaida { get; set; }
    public Krepšininkas() { }
    public Krepšininkas(string team1, string vardas, string pavarde, int gimi, int ugiss, string pozicija, int point, int klaid)
    {
        this.team = team1;
        this.pav = pavarde;
        this.var = vardas;
        this.gim = gimi;
        this.ugis = ugiss;
        this.poz = pozicija;
        this.taskas = point;
        this.klaida = klaid;
    }
    public override string ToString()
    {
        string eilute;
        eilute = string.Format("{0,-20}{1,-12}{2,-18}{3,-12}{4,10}{5, -9}{6,10}{7,5}", team, var, pav, gim, ugis, poz, taskas, klaida);
        return eilute;
    }
    static public bool operator >(Krepšininkas pirmas, Krepšininkas antras)
    {
        int poz = String.Compare(pirmas.pav, antras.pav, StringComparison.CurrentCulture);
        return poz > 0;
    }
    static public bool operator <(Krepšininkas pirmas, Krepšininkas antras)
    {
        int poz = String.Compare(pirmas.pav, antras.pav, StringComparison.CurrentCulture);          
        return poz < 0;
    }
}
public class Komanda
{
    public string team { get; set; }
    public int rung { get; set; }
    public int win { get; set; }
    public Komanda() { }
    public Komanda(string komanda, int rungtynes, int laime)
    {
        this.team = komanda;
        this.rung = rungtynes;
        this.win = laime;
    }
    public override string ToString()
    {
        string eilute = string.Format("{0,-20}{1,7}{2,30}", team, rung, win);
        return eilute;
    }
    static public bool operator >(Komanda pirmas, Komanda antras)       
    {
        return pirmas.win > antras.win;
    }
    static public bool operator <(Komanda pirmas, Komanda antras)
    {
        return pirmas.win < antras.win;
    }
}
public sealed class Mazgas
{
    public Krepšininkas Duom { get; set; }
    public Mazgas Kitas { get; set; }
    public Mazgas(Krepšininkas reiksme, Mazgas adr)
    {
        Duom = reiksme;
        Kitas = adr;
    }
}
public sealed class MazgasKom
{
    public Komanda Duom { get; set; }
    public MazgasKom Kitas { get; set; }
    public MazgasKom(Komanda reiksme, MazgasKom adr)
    {
        Duom = reiksme;
        Kitas = adr;
    }
}
public sealed class Sąrašas
{
    private Mazgas pr;
    private Mazgas pb;
    private Mazgas d;
    public Sąrašas()
    {
        pr = null;
        pb = null;
        d = null;
    }
    public void DetiDuomenisA(Krepšininkas naujas)
    {
        pr = new Mazgas(naujas, pr);
    }
    public void Pradzia() { d = pr; }
    public void Kitas() { d = d.Kitas; }
    public bool Yra() { return d != null; }
    public Krepšininkas ImtisDuomenis() { return d.Duom; }
    public void Rikiuoti()
    {
        for (Mazgas d1 = pr; d1 != null; d1 = d1.Kitas)
        {
            Mazgas maxv = d1;
            for (Mazgas d2 = d1; d2 != null; d2 = d2.Kitas)
                if (d2.Duom < maxv.Duom)
                    maxv = d2;
            Krepšininkas Kre = d1.Duom;
            d1.Duom = maxv.Duom;
            maxv.Duom = Kre;
        }
    }
    /// <summary>
    /// Surasta ir pašalinimas, kai įveskia nurodytos komandos žaidėjus.
    /// </summary>
    /// <param name="nickPlayer">Įvesti vardą</param>
    /// <param name="lastPlayer">Įvesti pavardę</param>
    /// <param name="available">Taip ar ne</param>
    public void Pasalinti(string team, ref bool available)
    {
        Mazgas dd = pr;
        while (dd != null && dd.Duom.team != team)
        {
            dd = dd.Kitas;
        }
        if (dd != null) { available = true; }
        Mazgas s = dd;
        while (s != null && s.Duom.team == team)
        {
            s = s.Kitas;
        }
        if (s == null)
        {
            Mazgas pb = dd;
            for (Mazgas dt = pr; dt != null; dt = dt.Kitas)
            {
                if (dt.Kitas == pb)
                {
                    dt.Kitas = null;
                }
            }
        }
        else
        {
            dd.Duom = s.Duom;
            dd.Kitas = s.Kitas;
            s = null;
            Pasalinti(team, ref available);
        }
    }
}
class KitasSar
{
    private MazgasKom prk;
    private MazgasKom pbk;
    private MazgasKom dk;
    public KitasSar()
    {
        prk = null;
        pbk = null;
        dk = null;
    }
    public void DetiDuomenisK(Komanda nauja)
    {
        prk = new MazgasKom(nauja, prk);
    }
    public void PradziaK() { dk = prk; }
    public void KitasK() { dk = dk.Kitas; }
    public bool YraK() { return dk != null; }
    public Komanda ImtisDuomenisK() { return dk.Duom; }
    public void Rikiuoti()
    {
        for (MazgasKom d1 = prk; d1 != null; d1 = d1.Kitas)
        {
            MazgasKom maxv = d1;
            for (MazgasKom d2 = d1; d2 != null; d2 = d2.Kitas)
                if (d2.Duom > maxv.Duom)
                    maxv = d2;
            Komanda Kom = d1.Duom;
            d1.Duom = maxv.Duom;
            maxv.Duom = Kom;
        }
    }
}
public partial class LD2 : System.Web.UI.Page
{
    const string fv1 = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld2\U13a.txt";
    const string fv2 = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld2\U13b.txt";
    const string fr = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld2\Rezultatai.txt";
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = File.ReadAllText(fv1, Encoding.GetEncoding(1257));
        TextBox2.Text = File.ReadAllText(fv2, Encoding.GetEncoding(1257));
        Label4.Visible = false;
        TextBox3.Visible = false;
        Label5.Visible = false;
        TextBox4.Visible = false;
        Button2.Visible = false;     
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        File.WriteAllText(fr, string.Empty);
        Sąrašas A = new Sąrašas();
        var K = new KitasSar();
        var gynejasTaskas = new Sąrašas();
        var puolejasTaskas = new Sąrašas();
        var centrasTaskas = new Sąrašas();
        var gynejasKlaida = new Sąrašas();
        var puolejasKlaida = new Sąrašas();
        var centrasKlaida = new Sąrašas();
        Label4.Visible = true;
        TextBox3.Visible = true;
        Label5.Visible = true;
        TextBox4.Visible = true;
        Button2.Visible = true;
        Button1.Visible = false;
        IvestiA(fv1, A);
        Spausdinti(fr, A, "Atvirkštinis žaidėjų sąrašas");
        IvestiK(fv2, K);
        SpausdintiK(fr, K, "Turyno lentelė");
        Taskas(A, K, 2, ref gynejasTaskas, ref puolejasTaskas, ref centrasTaskas);
        Spausdinti(fr, gynejasTaskas, "Daugiausiai taškų pelnęs gynėjas:");
        Spausdinti(fr, puolejasTaskas, "Daugiausiai taškų pelnęs puolėjas:");
        Spausdinti(fr, centrasTaskas, "Daugiausiai taškų pelnęs centras:");
        Klaida(A, K, 2, ref gynejasKlaida, ref puolejasKlaida, ref centrasKlaida);
        Spausdinti(fr, gynejasKlaida, "Daugiausiai klaidų padaręs gynėjas:");
        Spausdinti(fr, puolejasKlaida, "Daugiausiai klaidų padaręs puolėjas:");
        Spausdinti(fr, centrasKlaida, "Daugiausiai klaidų padaręs centras:");
        K.Rikiuoti();
        KomandosPoint(A, K, fr);
        A.Rikiuoti();
        Spausdinti(fr, A, "Rikiuotas krepšininkų sąrašas");
        TextBox3.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Rezultatai.txt");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Sąrašas A = new Sąrašas();
        var B = new KitasSar();
        Label4.Visible = true;
        TextBox3.Visible = true;
        IvestiA(fv1, A);
        IvestiK(fv2, B);
        
        string team = TextBox4.Text;
        if (team != "")
        {
            bool available = false;
            A.Pasalinti(team, ref available);
            if (available)
            {
                A.Rikiuoti();
                Spausdinti(fr, A, "Sąrašas po žaidėjo pašalinimo:");
                TextBox3.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Rezultatai.txt");
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "Tokio žaidėjo nėra sąraše !!!";
            }
        }
        else
        {
            Label5.Visible = true;
            Label5.Text = "Jūs neįveskite nė žodžio !!!";
        }
    }
    /// <summary>
    /// Skaitomi krepšininkų duomenys iš failo
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    static void IvestiA(string fv, Sąrašas A)
    {
        string team, pav, vard, poz;
        int gim, ugis, point, kl;
        string line;
        using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            while ((line = reader.ReadLine()) != null)
            {
                var Split = line.Split(';');
                team = Split[0];
                vard = Split[1];
                pav = Split[2];
                gim = int.Parse(Split[3]);
                ugis = int.Parse(Split[4]);
                poz = Split[5];
                point = int.Parse(Split[6]);
                kl = int.Parse(Split[7]);
                var kre = new Krepšininkas(team, vard, pav, gim, ugis, poz, point, kl);
                A.DetiDuomenisA(kre);
            }
    }
    /// <summary>
    /// Skaitomi komandos krepšininkų duomenys iš failo
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    static void IvestiK(string fv, KitasSar A)
    {
        string team;
        int rung, win;
        string line;
        using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            while ((line = reader.ReadLine()) != null)
            {
                string[] Split = line.Split(';');
                team = Split[0];
                rung = int.Parse(Split[1]);
                win = int.Parse(Split[2]);
                var kom = new Komanda(team, rung, win);
                A.DetiDuomenisK(kom);
            }
    }
    /// <summary>
    /// Spausdinami krepšinikų duomenys į failą
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="eil">Paraštė</param>
    static void Spausdinti(string fv, Sąrašas A, string eil)
    {
        using (var frr = new StreamWriter(fv, true))
        {
            string bruk = new string('-', 105);
            frr.WriteLine(eil);
            frr.WriteLine(bruk);
            frr.WriteLine("  Komanda            Vardas      Pavardė       Gimimo metai     Ūgis(cm)    Pozicija    Taškai    Klaidos");
            frr.WriteLine(bruk);
            for (A.Pradzia(); A.Yra(); A.Kitas())
                frr.WriteLine(A.ImtisDuomenis());
            frr.WriteLine(bruk);
            frr.WriteLine();
        }
    }
    /// <summary>
    /// Spausdinami komandos krepšinikų duomenys į failą
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="eil"></param>
    static void SpausdintiK(string fv, KitasSar A, string eil)
    {
        using (var frr = new StreamWriter(fv, true))
        {
            string bruk = new string('-', 70);
            frr.WriteLine(eil);
            frr.WriteLine(bruk);
            frr.WriteLine(" Komanda        Žaistų rungtynių skaičius   Laimėtų rungtynių skaičius");
            frr.WriteLine(bruk);
            for (A.PradziaK(); A.YraK(); A.KitasK())
                frr.WriteLine(A.ImtisDuomenisK());
            frr.WriteLine(bruk);
            frr.WriteLine();
        }
    }
    /// <summary>
    /// Paieška ir saraso formavimas, kuris kiekvienoje pozicijoje žaidėjas daugiausiai pelnė taškų.
    /// </summary>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="B">Konteinerinės komandos vardas</param>
    /// <param name="i">Masyvo indeksas</param>
    /// <param name="G">Konteinerinės gynejo vardas</param>
    /// <param name="P">Konteinerinės puolejo vardas</param>
    /// <param name="C">Konteinerinės centro vardas</param>    
    static void Taskas(Sąrašas A, KitasSar B, int i, ref Sąrašas G, ref Sąrašas P, ref Sąrašas C)
    {
        Krepšininkas kre = new Krepšininkas();
        string[] pozicija = { " gynėjas", " puolėjas", " centras" };
        if (i == -1)
            return;
        for (B.PradziaK(); B.YraK(); B.KitasK())
        {
            int suma = 0;
            for (A.Pradzia(); A.Yra(); A.Kitas())
                if (A.ImtisDuomenis().poz == pozicija[i] && A.ImtisDuomenis().team == B.ImtisDuomenisK().team)
                    if (A.ImtisDuomenis().taskas > suma)
                    {
                        suma = A.ImtisDuomenis().taskas;
                        kre = A.ImtisDuomenis();
                    }
            if (pozicija[i] == pozicija[2])
                C.DetiDuomenisA(kre);
            else
                if (pozicija[i] == pozicija[1])
                    P.DetiDuomenisA(kre);
                else
                    G.DetiDuomenisA(kre);
        }
        Taskas(A, B, i - 1, ref G, ref P, ref C);
    }
    /// <summary>
    /// Paieška ir suformuoti sarasas, kuris kiekvienoje pozicijoje žaidėjas daugiausiai padaryti klaidu.
    /// </summary>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="B">Konteinerinės komandos vardas</param>
    /// <param name="i">Masyvo indeksas</param>
    /// <param name="G">Konteinerinės gynejo vardas</param>
    /// <param name="P">Konteinerinės puolejo vardas</param>
    /// <param name="C">Konteinerinės centro vardas</param>
    static void Klaida(Sąrašas A, KitasSar B, int i, ref Sąrašas G, ref Sąrašas P, ref Sąrašas C)
    {
        Krepšininkas kre = new Krepšininkas();
        string[] pozicija = { " gynėjas", " puolėjas", " centras" };
        if (i == -1)
            return;
        for (B.PradziaK(); B.YraK(); B.KitasK())
        {
            int suma = 0;
            for (A.Pradzia(); A.Yra(); A.Kitas())
                if (A.ImtisDuomenis().poz == pozicija[i] && A.ImtisDuomenis().team == B.ImtisDuomenisK().team)
                    if (A.ImtisDuomenis().klaida > suma)
                    {
                        suma = A.ImtisDuomenis().klaida;
                        kre = A.ImtisDuomenis();
                    }
            if (pozicija[i] == pozicija[2])
                C.DetiDuomenisA(kre);
            else
                if (pozicija[i] == pozicija[1])
                    P.DetiDuomenisA(kre);
                else
                    G.DetiDuomenisA(kre);
        }
        Klaida(A, B, i - 1, ref G, ref P, ref C);
    }
    /// <summary>
    /// Paieška ir spausdinimas, kurios komandos žaidėjai pelnė daugiausiai taškų ir atspausdinama šios komandos užimta vieta.
    /// </summary>
    /// <param name="A">Krepšininko konteinerinės vardas</param>
    /// <param name="B">Komandos konteinerinės vardas</param>
    /// <param name="fv">Duomenų failo vardas</param>
    static void KomandosPoint(Sąrašas A, KitasSar B, string fv)
    {
        int max = 0;
        int k = 0;
        string team = "";
        for (B.PradziaK(); B.YraK(); B.KitasK())
        {
            string komanda = B.ImtisDuomenisK().team;
            int win = B.ImtisDuomenisK().win;
            Max(A, komanda, win, ref max, ref team);
        }
        for (B.PradziaK(); B.YraK(); B.KitasK())
        {
            k++;
            using (var frr = new StreamWriter(fv, true))
            {
                if (B.ImtisDuomenisK().team == team)
                {
                    frr.WriteLine("Komanda, kurios žaidėjai pelnė daugiausiai taškų:");
                    frr.WriteLine("{0, -20}{1,2} taškų/ai ir užimta{2,2} vieta.", team, max, k);
                    frr.WriteLine();
                }
            }
        }
    }
    /// <summary>
    /// Suskaičiuoja ir grąžina, kurios komandos žaidėjai pelnė daugiausiai taškų ir palyginima kas daugiausiai pelnė taškų.
    /// </summary>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="komanda">Komandos pavadinimas</param>
    /// <param name="win">Komandos laimeti</param>
    /// <param name="max">Daugiausiai taškų</param>
    /// <param name="team">Komandos pavadinimas, kuris daugiausiai taškų</param>
    static void Max(Sąrašas A, string komanda, int win, ref int max, ref string team)
    {
        int suma = 0;
        int win1 = 0;
        for (A.Pradzia(); A.Yra(); A.Kitas())
        {
            if (komanda == A.ImtisDuomenis().team)
                suma = suma + A.ImtisDuomenis().taskas;

        }
        if (suma > max)
        {
            team = komanda;
            max = suma;
            win1 = win;
        }
        else
            if (suma == max)
                if (win > win1)
                {
                    win1 = win;
                    team = komanda;
                    max = suma;
                }
    }
}
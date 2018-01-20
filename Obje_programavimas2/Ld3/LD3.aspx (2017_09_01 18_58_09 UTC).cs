using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Text;

/// <summary>
/// Klasė krepšininko duomenims saugoti
/// </summary>
/// <class name="Player"></class>
public class Player : IComparable<Player>, IEquatable<Player>
{
    public string team { get; set; }       // Komanda
    public string firstName { get; set; }  // Vardas
    public string lastName { get; set; }   // Pavardė
    public int birth { get; set; }         // Gimimo metai
    public int height { get; set; }        // Ūgis
    public string postion { set; get; }    // Pozicija
    public int point { get; set; }         // taškas
    public int turnovers { get; set; }     // klaida
    /// <summary>
    /// Pradiniai krepšininko duomenys
    /// </summary>
    public Player() { }
    /// <summary>
    /// Krepšininko duomenų įrašymas
    /// </summary>
    /// <param name="tea">komanda</param>
    /// <param name="first">vardas</param>
    /// <param name="last">pavardė</param>
    /// <param name="birt">gimimo metai</param>
    /// <param name="hei">ūgis</param>
    /// <param name="pos">pozicija</param>
    /// <param name="poi">taškai</param>
    /// <param name="tur">klaida</param>
    public Player(string tea, string first, string last, int birt, int hei, string pos, int poi, int tur)
    {
        this.team = tea;
        this.firstName = first;
        this.lastName = last;
        this.birth = birt;
        this.height = hei;
        this.postion = pos;
        this.point = poi;
        this.turnovers = tur;
    }
    /// <summary>
    /// Spausdinimo metodas
    /// </summary>
    /// <returns>eilutė</returns>
    public override string ToString()
    {
        string eilute;
        eilute = string.Format("{0,-20}{1,-12}{2,-18}{3,-12}{4,10}{5, -9}{6,10}{7,5}", team, firstName, lastName, birth, height, postion, point, turnovers);
        return eilute;
    }
    /// <summary>
    /// Palyginimo sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns></returns>
    public int CompareTo(Player other)
    {
        if (other == null) return 1;
        if (lastName.CompareTo(other.lastName) != 0)
            return lastName.CompareTo(other.lastName);
        else
            return 0;
    }
    /// <summary>
    /// Palyginimo užkloto operatorius
    /// </summary>
    /// <param name="first">Krepšininkas pirmas</param>
    /// <param name="second">Krepšininkas antras</param>
    /// <returns>1</returns>
    static public bool operator >(Player first, Player second)
    {
        return first.CompareTo(second) == 1;
    }
    /// <summary>
    /// Palyginimo užkloto operatorius
    /// </summary>
    /// <param name="first">krepšininkas pirmas</param>
    /// <param name="second">krepšininkas antras</param>
    /// <returns>-1</returns>
    static public bool operator <(Player first, Player second)
    {
        return first.CompareTo(second) == -1;
    }
    /// <summary>
    /// Vienodų sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns>true ar false</returns>
    public bool Equals(Player other)
    {
        if (other == null)
            return false;
        if (this.team == other.team)
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
        Player play = obj as Player;
        if (play == null)
            return false;
        else
            return Equals(play);
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
/// <summary>
/// Klasė krepšininkų komandos duomenims saugoti
/// </summary>
/// <class name="Team"></class>
public class Team : IComparable<Team>, IEquatable<Team>
{
    public string team { get; set; }   // komandos pavadinimas
    public int match { get; set; }     // rungtynės
    public int win { get; set; }       // laimėjimai
    /// <summary>
    /// Pradiniai komandos duomenys
    /// </summary>
    public Team() { }
    /// <summary>
    /// Komandų duomenų įrašymas
    /// </summary>
    /// <param name="komanda">komandos pavadinimas</param>
    /// <param name="rungtynes">rungtynės</param>
    /// <param name="laime">laimėjimai</param>
    public Team(string komanda, int rungtynes, int laime)
    {
        this.team = komanda;
        this.match = rungtynes;
        this.win = laime;
    }
    /// <summary>
    /// Spausdinimo metodas
    /// </summary>
    /// <returns>eilute</returns>
    public override string ToString()
    {
        string eilute = string.Format("{0,-20}{1,7}{2,30}", team, match, win);
        return eilute;
    }
    /// <summary>
    /// Palyginimo sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns></returns>
    public int CompareTo(Team other)
    {
        if (other == null)
            return 1;
        else
            return win.CompareTo(other.win);
    }
    /// <summary>
    /// Palyginimo užkloto metodas
    /// </summary>
    /// <param name="first">komanda pirma</param>
    /// <param name="second">komanda antra</param>
    /// <returns>1</returns>
    static public bool operator >(Team first, Team second)
    {
        return first.CompareTo(second) == 1;
    }
    /// <summary>
    /// Palyginimo užkloto metodas
    /// </summary>
    /// <param name="first">komanda pirma</param>
    /// <param name="second">komanda antra</param>
    /// <returns>-1</returns>
    static public bool operator <(Team first, Team second)
    {
        return first.CompareTo(second) == -1;
    }
    /// <summary>
    /// Vienodų sąsajos metodas
    /// </summary>
    /// <param name="other">objektas</param>
    /// <returns>true ar false</returns>
    public bool Equals(Team other)
    {
        if (other == null)
            return false;
        if (this.win == other.win)
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
        Team team = obj as Team;
        if (team == null)
            return false;
        else
            return Equals(team);
    }
    /// <summary>
    /// Užklotas metodas GetHashCode
    /// </summary>
    /// <returns>GetHashCode</returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
/// <summary>
/// Klasė Mazgo duomenims saugoti
/// </summary>
/// <class name="Node"></class>
public sealed class Node<type> where type : IComparable<type>, IEquatable<type>
{
    public type Data { get; set; }         // tipo duomenys
    public Node<type> Next { get; set; }   // tipo kito mazgo adresas 
    /// <summary>
    /// Mazgo duomenų įrašymas
    /// </summary>
    /// <param name="value">reikšmė</param>
    /// <param name="adr">adresas</param>
    public Node(type value, Node<type> adr)
    {
        Data = value;
        Next = adr;
    }
}
/// <summary>
/// Klasė susietojo sąrašo duomenims saugoti
/// </summary>
/// <class name="Sarasas"></class>
/// <typeparam name="tipo klasės"></typeparam>
public sealed class Sarasas<type> : IEnumerable<type> where type : IComparable<type>, IEquatable<type>
{
    private Node<type> st;    // tipo mazgo pradžia
    private Node<type> end;   // tipo mazgo pabaiga
    /// <summary>
    /// Pradiniai sąrašo duomenys
    /// </summary>
    public Sarasas()
    {
        this.st = null;
        this.end = null;
    }
    /// <summary>
    /// Grąžina tipo klasės objektą
    /// </summary>
    /// <returns>objektas</returns>
    public type ImtiDuomenis() { return st.Data; }
    /// <summary>
    /// Padeda į tipo objektų sąrašą naują tipo objektą
    /// </summary>
    /// <param name="news">tipo objektas</param>
    public void DetiDuomenisA(type news)
    {
        st = new Node<type>(news, st);
    }
    /// <summary>
    /// Grąžina sąsajos iteratorių
    /// </summary>
    /// <returns></returns>
    public IEnumerator<type> GetEnumerator()
    {
        for (Node<type> dd = st; dd != null; dd = dd.Next)
        {
            yield return dd.Data;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Surikiuoja krepšininkų masyvą išrinkimo metodu pagal abėcėlę.
    /// </summary>
    public void Sort()
    {
        for (Node<type> d1 = st; d1 != null; d1 = d1.Next)
        {
            Node<type> maxv = d1;
            for (Node<type> d2 = d1; d2 != null; d2 = d2.Next)
                if (d2.Data.CompareTo(maxv.Data) < 0)
                    maxv = d2;
            type Pl = d1.Data;
            d1.Data = maxv.Data;
            maxv.Data = Pl;
        }
    }
    /// <summary>
    /// Surikiuoja komandų masyvą išrinkimo metodu pagal laimėjimus.
    /// </summary>
    public void Sort1()
    {
        for (Node<type> d1 = st; d1 != null; d1 = d1.Next)
        {
            Node<type> maxv = d1;
            for (Node<type> d2 = d1; d2 != null; d2 = d2.Next)
                if (d2.Data.CompareTo(maxv.Data) > 0)
                    maxv = d2;
            type team = d1.Data;
            d1.Data = maxv.Data;
            maxv.Data = team;
        }
    }
    /// <summary>
    /// Suranda ir pašalina nurodytos komandos žaidėjus.
    /// </summary>
    /// <param name="one">krepšininko objektas</param>
    /// <param name="available">taip ar ne</param>
    public void Remove1(Player one, ref bool available)
    {
        Node<type> dd = st;
        while (dd != null && dd.Data.Equals(one) == false)
            dd = dd.Next;
        if (dd != null) { available = true; }
        Node<type> s = dd.Next;
        while (s != null && s.Data.Equals(one) == true)
            s = s.Next;
        if (s == null)
        {
            Node<type> pb = dd;
            for (Node<type> dt = st; dt != null; dt = dt.Next)
                if (dt.Next == pb)
                    dt.Next = null;
        }
        else
        {
            dd.Data = s.Data;
            dd.Next = s.Next;
        }
        s = null;
    }
}
public partial class LD3 : System.Web.UI.Page
{
    const string fv1 = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld3\U13a.txt";
    const string fv2 = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld3\U13b.txt";
    const string fr = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld3\Rezultatai.txt";
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
        Label4.Visible = true;
        TextBox3.Visible = true;
        Label5.Visible = true;
        TextBox4.Visible = true;
        Button2.Visible = true;
        Button1.Visible = false;
        var A = new Sarasas<Player>();
        var K = new Sarasas<Team>();
        var guardPoint = new Sarasas<Player>();
        var forwardPoint = new Sarasas<Player>();
        var centerPoint = new Sarasas<Player>();
        var guardT = new Sarasas<Player>();
        var forwardT = new Sarasas<Player>();
        var centerT = new Sarasas<Player>();
        readData1(fv1, A);
        printData1(fr, A, "Atvirkštinis žaidėjų sąrašas");
        readData2(fv2, K);
        printData2(fr, K, "Turyno lentelė");
        Point(A, K, 2, ref guardPoint, ref forwardPoint, ref centerPoint);
        printData1(fr, guardPoint, "Daugiausiai taškų pelnęs gynėjas:");
        printData1(fr, forwardPoint, "Daugiausiai taškų pelnęs puolėjas:");
        printData1(fr, centerPoint, "Daugiausiai taškų pelnęs centras:");
        Turnovers(A, K, 2, ref guardT, ref forwardT, ref centerT);
        printData1(fr, guardT, "Daugiausiai klaidų padaręs gynėjas:");
        printData1(fr, forwardT, "Daugiausiai klaidų padaręs puolėjas:");
        printData1(fr, centerT, "Daugiausiai klaidų padaręs centras:");
        K.Sort1();
        TeamPoint(A, K, fr);
        A.Sort();
        printData1(fr, A, "Rikiuotas krepšininkų sąrašas");
        TextBox3.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Rezultatai.txt");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label4.Visible = true;
        TextBox3.Visible = true;
        var A = new Sarasas<Player>();
        var K = new Sarasas<Team>();
        readData1(fv1, A);
        readData2(fv2, K);
        string team = TextBox4.Text;
        bool available = false;
        if (team != "")
        {
            foreach (Player one in A)
                if (one.team == team)
                    A.Remove1(one, ref available);
            if (available)
            {
                A.Sort();
                printData1(fr, A, "Sąrašas po žaidėjo pašalinimo:");
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
        TextBox3.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Rezultatai.txt");
    }
    /// <summary>
    /// Skaitomi krepšininkų duomenys iš failo
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    static void readData1(string fv, Sarasas<Player> A)
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
                var kre = new Player(team, vard, pav, gim, ugis, poz, point, kl);
                A.DetiDuomenisA(kre);
            }
    }
    /// <summary>
    /// Skaitomi komandos krepšininkų duomenys iš failo
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    static void readData2(string fv, Sarasas<Team> A)
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
                var kom = new Team(team, rung, win);
                A.DetiDuomenisA(kom);
            }
    }
    /// <summary>
    /// Spausdinami krepšinikų duomenys į failą
    /// </summary>
    /// <param name="fv">Duomenų failo vardas</param>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="eil">Paraštė</param>
    static void printData1<type>(string fv, IEnumerable<type> A, string eil) where type : IComparable<type>, IEquatable<type>
    {
        using (var frr = new StreamWriter(fv, true))
        {
            string bruk = new string('-', 105);
            frr.WriteLine(eil);
            frr.WriteLine(bruk);
            frr.WriteLine("  Komanda            Vardas      Pavardė       Gimimo metai     Ūgis(cm)    Pozicija    Taškai    Klaidos");
            frr.WriteLine(bruk);
            foreach (type one in A)
                frr.WriteLine(one);
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
    static void printData2<type>(string fv, IEnumerable<type> A, string eil) where type : IComparable<type>, IEquatable<type>
    {
        using (var frr = new StreamWriter(fv, true))
        {
            string bruk = new string('-', 70);
            frr.WriteLine(eil);
            frr.WriteLine(bruk);
            frr.WriteLine(" Komanda        Žaistų rungtynių skaičius   Laimėtų rungtynių skaičius");
            frr.WriteLine(bruk);
            foreach (type one in A)
                frr.WriteLine(one);
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
    static void Point(Sarasas<Player> A, Sarasas<Team> B, int i, ref Sarasas<Player> G, ref Sarasas<Player> P, ref Sarasas<Player> C)
    {
        Player pla = new Player();
        string[] pozicija = { " gynėjas", " puolėjas", " centras" };
        if (i == -1)
            return;
        foreach (Team one in B)
        {
            int suma = 0;
            foreach (Player value in A)
                if (value.postion == pozicija[i] && value.team == one.team)
                    if (value.point > suma)
                    {
                        suma = value.point;
                        pla = value;
                    }
            if (pozicija[i] == pozicija[2])
                C.DetiDuomenisA(pla);
            else
                if (pozicija[i] == pozicija[1])
                    P.DetiDuomenisA(pla);
                else
                    G.DetiDuomenisA(pla);
        }
        Point(A, B, i - 1, ref G, ref P, ref C);
    }
    /// <summary>
    /// Paieška ir saraso formavimas, kuris kiekvienoje pozicijoje žaidėjas daugiausiai padarė klaidu.
    /// </summary>
    /// <param name="A">Konteinerinės vardas</param>
    /// <param name="B">Konteinerinės komandos vardas</param>
    /// <param name="i">Masyvo indeksas</param>
    /// <param name="G">Konteinerinės gynejo vardas</param>
    /// <param name="P">Konteinerinės puolejo vardas</param>
    /// <param name="C">Konteinerinės centro vardas</param>
    static void Turnovers(Sarasas<Player> A, Sarasas<Team> B, int i, ref Sarasas<Player> G, ref Sarasas<Player> P, ref Sarasas<Player> C)
    {
        Player pla = new Player();
        string[] pozicija = { " gynėjas", " puolėjas", " centras" };
        if (i == -1)
            return;
        foreach (Team one in B)
        {
            int suma = 0;
            foreach (Player value in A)
                if (value.postion == pozicija[i] && value.team == one.team)
                    if (value.turnovers > suma)
                    {
                        suma = value.turnovers;
                        pla = value;
                    }
            if (pozicija[i] == pozicija[2])
                C.DetiDuomenisA(pla);
            else
                if (pozicija[i] == pozicija[1])
                    P.DetiDuomenisA(pla);
                else
                    G.DetiDuomenisA(pla);
        }
        Turnovers(A, B, i - 1, ref G, ref P, ref C);
    }
    /// <summary>
    /// Paieška ir spausdinimas, kurios komandos žaidėjai pelnė daugiausiai taškų ir atspausdinama šios komandos užimta vieta.
    /// </summary>
    /// <param name="A">Krepšininko konteinerinės vardas</param>
    /// <param name="B">Komandos konteinerinės vardas</param>
    /// <param name="fv">Duomenų failo vardas</param>
    static void TeamPoint(Sarasas<Player> A, Sarasas<Team> B, string fv)
    {
        int max = 0;
        int k = 0;
        string team = "";
        foreach (Team one in B)
        {
            string komanda = one.team;
            int win = one.win;
            Max(A, komanda, win, ref max, ref team);
        }
        foreach (Team one in B)
        {
            k++;
            using (var frr = new StreamWriter(fv, true))
            {
                if (one.team == team)
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
    static void Max(Sarasas<Player> A, string komanda, int win, ref int max, ref string team)
    {
        int suma = 0;
        int win1 = 0;
        foreach (Player one in A)
        {
            if (komanda == one.team)
                suma = suma + one.point;
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
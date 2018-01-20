using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class Ld1 : System.Web.UI.Page
{
    public class MagicSet
    {
        const int Cn = 100;
        public int[] Skaiciai { get; set;}
        public int tikslas { get; set; }
        public int[] Veiksmai { get; set; }
        public bool Sprendinys { get; set; }        
        public MagicSet()
        {
            tikslas = 0;
            Skaiciai = new int[Cn];
            Veiksmai = new int[Cn];
        }
    }
    const string fv = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld1\Duomenys.txt";
    const string fr = @"C:\Users\Z585\Documents\Visual Studio 2012\WebSites\Ld1\Rezultatai.txt";

    protected void Page_Load(object sender, EventArgs e)
    {
        int kiek;
        string line = "";
        MagicSet Ms = new MagicSet();
        Skaityti(fv, out kiek, Ms);
        Label4.Visible = false;
        for (int i = 0; i < kiek; i++)
           line = line + " " + Ms.Skaiciai[i].ToString();
        Label5.Text = "Skaičiai:" + line;
        Label3.Text = "galutinis tikslas: " + Ms.tikslas.ToString();
        TextBox1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int kiek;
        MagicSet Ms = new MagicSet();
        Skaityti(fv, out kiek, Ms);
        Label4.Visible = true;
        TextBox1.Visible = true;
        if (File.Exists(fr))
            File.Delete(fr);
        Kombinancija(ref Ms, 0, kiek, fr);
        if (Ms.Sprendinys)
        {
            Label4.Text = "Rezultatai:";
            Button1.Visible = false;
        }
        else
        {
            Label4.Text = "Nėra sprendinio";
            TextBox1.Visible = false;
            Button1.Visible = false;
        }

    }
    /// <summary>
    /// Skaitomi duomenys iš failo
    /// </summary>
    /// <param name="fv">duomenų failo vardas</param>
    /// <param name="kiek">masyvo dydis</param>
    /// <param name="Sk">Masyvo vardas</param>
    /// <param name="rez">galutinis tikslas</param>
    /// <returns>iš failo nuskaitytų skaičių masyvą</returns>
    static void Skaityti(string fv, out int kiek, MagicSet Ms)
    {
        const int Cn = 100;
        int[] Sk = new int[Cn];
        using (StreamReader reader = new StreamReader(fv))
        {
            string line;
            line = reader.ReadLine();
            string[] parts = line.Split(' ');
            kiek = parts.Length;
            for (int i = 0; i < kiek; i++)
            {
                Sk[i] = int.Parse(parts[i]);
            }
            line = reader.ReadLine();
            Ms.tikslas = int.Parse(line);
        }
        Ms.Skaiciai = Sk;
    }
    /// <summary>
    /// surandami aritmetiniai veiksmai tikslui pasiekti
    /// </summary>
    /// <param name="ms">Objekto vardas</param>
    /// <param name="i">Skaičių, su kuriais atliekami veiksmai, numeris masyve</param>
    /// <param name="kiek">Magijos skaičius</param>
    /// <param name="suma">Einamoji suma patikrinti</param>
    /// <param name="fr">Spausdinamo failo vardas</param>
    void Magija(MagicSet ms, int i, int kiek, int suma, string fr)
    {
        int[] Sk = ms.Skaiciai;
        if (i != kiek)
        {
            int temp;
            string zenklas;
            i++;
            for (int j = 0; j < 4; j++)
            {
                ms.Veiksmai[i] = j;
                temp = suma;
                suma = Veiksmas(suma, Sk[i], j, out zenklas);
                if (zenklas != "!")
                {
                    if (suma == ms.tikslas)
                    {
                        int rez = ms.Skaiciai[0];
                        Print(ms, 0, i, rez, fr);
                        ms.Sprendinys = true;
                        return;
                    }
                    Magija(ms, i, kiek, suma, fr);
                    if (ms.Sprendinys) { return; }
                    suma = temp;
                }
            }
        }
    }
    /// <summary>
    /// Išspausdimas
    /// </summary>
    /// <param name="ms">Objekto vardas</param>
    /// <param name="j">Spausdinamų aritmetinių veiksmų eilutės numeris</param>
    /// <param name="i">Visų spausdinamų eilučių skaičius</param>
    /// <param name="suma">Tarpinės sumos</param>
    /// <param name="fr">Spausdinamo failo vardas</param>
    void Print(MagicSet ms, int j, int i, int suma, string fr)
    {
        if (j != i)
        {
                string zenklas;
                int tarp = suma;
                suma = Veiksmas(suma, ms.Skaiciai[j + 1], ms.Veiksmai[j + 1], out zenklas);
                using (var frr = File.AppendText(fr))
                {
                frr.WriteLine(tarp + " " + zenklas + " " + ms.Skaiciai[j + 1] + " = " + suma);
                }
                TextBox1.Text = TextBox1.Text + "\r\n " 
                    + tarp.ToString() + " " + zenklas + " " + ms.Skaiciai[j + 1].ToString() + " = " + suma.ToString();
                j++;
                Print(ms, j, i, suma, fr);
        }
    }
    /// <summary>
    /// Atliekamos aritmetinės operacijos ir grąžina operacijos rezultatą: +, *, -, / 
    /// </summary>
    /// <param name="suma">operacijos rezultatas</param>
    /// <param name="demuo">operacijos dėmuo</param>
    /// <param name="i">operacijos numeris</param>
    /// <param name="zenklas">grąžinama aritmetinės operacijos</param>
    /// <returns>Gražina aritmetinės operacijos rezultatas</returns>
    int Veiksmas(int suma, int demuo, int i, out string zenklas)
    {
        if (i == 0)
        {
            zenklas = "+";
            return (suma + demuo);
        }
        else
            if (i == 1)
            {
                zenklas = "-";
                return (suma - demuo);
            }
            else
                if (i == 2)
                {
                    zenklas = "*";
                    return (suma * demuo);
                }
                else
                    if (demuo == 0)
                    {
                        zenklas = "!";
                        return suma;
                    }
                    int dalyba = suma / demuo;
                    if (dalyba * demuo == suma)
                    {
                        zenklas = "/";
                        return dalyba;
                    }
                    else
                    {
                        zenklas = "!";
                        return suma;
                    }
    }
    /// <summary>
    /// Skaičių kombinancija po kiekvieno skaičiaus sukeitimo
    /// </summary>
    /// <param name="ms">Objekto vardas</param>
    /// <param name="i">Skaičių, su kuriais atliekami veiksmai, numeris masyve</param>
    /// <param name="kiek">Magijos skaičius</param>
    /// <param name="fr">Spausdinamo failo vardas</param>
    void Kombinancija(ref MagicSet ms, int i, int kiek, string fr)
    {
        if (i == kiek)
        {
            int suma = ms.Skaiciai[0];
            Magija(ms, 0, kiek - 1, suma, fr);
        }
        for (int j = i; j < kiek; j++)
        {
            Swap(ref ms.Skaiciai[i], ref ms.Skaiciai[j]);
            Kombinancija(ref ms, i + 1, kiek, fr);
            Swap(ref ms.Skaiciai[i], ref ms.Skaiciai[j]);
        }
    }
    /// <summary>
    /// Skaičių sukeitimas
    /// </summary>
    /// <param name="x">Skaičius iš X</param>
    /// <param name="y">X skaičius į Y</param>
    void Swap(ref int x, ref int y)
    {
        int temp;
        temp = x;
        x = y;
        y = temp;
    }
}
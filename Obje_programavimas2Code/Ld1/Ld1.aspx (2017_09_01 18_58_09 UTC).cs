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
    public class magicSet
    {
        private int[] skaiciai;
        public int[] veiksmai;
        private int tikslas;
        private bool sprendinys = false;
        public magicSet()
        {
        }
        public void detiTiksla(int tikslas) { this.tikslas = tikslas; }
        public int imtiTiksla() { return tikslas; }
        public void detiSkaicius(int[] skaiciai) { this.skaiciai = skaiciai; }
        public int[] imtiSkaicius() { return skaiciai; }
        public void detiVeiksmus(int[] veiksmai) { this.veiksmai = veiksmai; }
        public int[] imtiVeiksmus() { return veiksmai; }
        public void detiSprendini(bool sprendinys) { this.sprendinys = sprendinys; }
        public bool imtiSprendini() { return sprendinys; }
    }
    magicSet ms = new magicSet();
    const int Cn = 100;
    const string fv = @"C:\Users\Z585\Pictures\Ld1\Duomenys.txt";
    const string fr = @"C:\Users\Z585\Pictures\Ld1\Rezultatai.txt";

    protected void Page_Load(object sender, EventArgs e)
    {
        string line;
        TextBox1.Visible = false;
        Label4.Visible = false;
        line = DropDownList1.Text + " " + DropDownList2.Text + " " + DropDownList3.Text + " " + DropDownList4.Text + " " + DropDownList5.Text + " " + DropDownList6.Text;
        Label5.Text = "skaičiai: " + line;
        Label3.Text = "galutinis tikslas: " + TextBox2.Text;

        Skaityti(line, ms);
        ms.detiTiksla(int.Parse(TextBox2.Text));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {        
        Label2.Visible = false;
        Label3.Visible = true;
        Label4.Visible = true;
        Button1.Visible = false;
        if (File.Exists(fr))
            File.Delete(fr);

        Kombinancija(ref ms, 0, 6, fr);
        Label4.Text = "Rezultatai";
        if (ms.imtiSprendini()) { TextBox1.Visible = true; }
        else
        {
            Label2.Visible = true;
            Label2.Text = "nėra sprendinių";
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
    static void Skaityti(string line, magicSet ms)
    {
        int[] Sk = new int[Cn];
        string[] parts = line.Split(' ');
        for (int i = 0; i < 6; i++)
            Sk[i] = int.Parse(parts[i]);
        ms.detiSkaicius(Sk);
    }
    /// <summary>
    /// surandami aritmetiniai veiksmai tikslui pasiekti
    /// </summary>
    /// <param name="Sk">Masyvo vardas</param>
    /// <param name="veiksmai">Suskaičiuoti artimetinės operacija</param>
    /// <param name="i">skaičių, su kuriais atliekami veiksmai, numeris masyve</param>
    /// <param name="kiek">masyvo skaičius</param>
    /// <param name="suma">einamoji suma patikrinti</param>
    /// <param name="rez">galutinis tikslas</param>
    /// <param name="sprendinys">Sprendinio egzistavimo patvirtinimas</param>
    /// <param name="fr">Spausdinamo failo vardas</param>
    void Magija(magicSet ms, int i, int kiek, int suma, string fr)
    {
        int[] Sk = ms.imtiSkaicius();
        int[] veiksmai = ms.imtiVeiksmus();
        if (i != kiek)
        {
            int temp;
            string zenklas;
            i++;
            for (int j = 0; j < 4; j++)
            {
                veiksmai[i] = j;
                temp = suma;
                suma = Veiksmas(suma, Sk[i], j, out zenklas);
                if (zenklas != "!")
                {
                    if (suma == ms.imtiTiksla())
                    {
                        Print(Sk, 0, i, veiksmai, Sk[0], fr);
                        ms.detiSprendini(true);
                        return;
                    }
                    if (ms.imtiSprendini()) { return; }
                    Magija(ms, i, kiek, suma, fr);
                    suma = temp;
                }
            }
        }
    }
    /// <summary>
    /// Išspausdimas
    /// </summary>
    /// <param name="Sk">Masyvo vardas</param>
    /// <param name="j">spausdinamų aritmetinių veiksmų eilutės numeris</param>
    /// <param name="i">visų spausdinamų eilučių skaičius</param>
    /// <param name="veiksmai">Suskaičiuoti artimetinės operacija</param>
    /// <param name="suma">tarpinės sumos</param>
    /// <param name="fr">Spausdinamo failo vardas</param>
    void Print(int[] Sk, int j, int i, int[] veiksmai, int suma, string fr)
    {
        if (j != i)
        {
                string zenklas;
                int tarp = suma;
                suma = Veiksmas(suma, Sk[j + 1], veiksmai[j + 1], out zenklas);
                using (var frr = File.AppendText(fr))
                {
                frr.WriteLine(tarp + " " + zenklas + " " + Sk[j + 1] + " = " + suma);
                }
                TextBox1.Text = TextBox1.Text + "\r\n " 
                    + tarp.ToString() + " " + zenklas + " " + Sk[j + 1].ToString() + " = " + suma.ToString();
                j++;
                Print(Sk, j, i, veiksmai, suma, fr);
        }
    }
    /// <summary>
    /// atliekamos aritmetinės operacijos ir grąžina operacijos rezultatą: +, *, -, / 
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
    /// <param name="Sk">Masyvo vardas</param>
    /// <param name="i">skaičių, su kuriais atliekami veiksmai, numeris masyve</param>
    /// <param name="kiek">Masyvo skaičius</param>
    /// <param name="rez">galutinis tikslas</param>
    /// <param name="sprendinys">Sprendinio egzistavimo patvirtinimas</param>
    /// <param name="fr">Spausdinamo failo vardas</param>
    void Kombinancija(ref magicSet ms, int i, int kiek, string fr)
    {
        int[] Sk = ms.imtiSkaicius();
        if (i == kiek)
        {
            int suma = Sk[0];
            int[] Veiksmai = new int[Cn];
            ms.detiVeiksmus(Veiksmai);
            Magija(ms, 0, kiek - 1, suma, fr);
        }
        for (int j = i; j < kiek; j++)
        {
            Swap(ref Sk[i], ref Sk[j]);
            Kombinancija(ref ms, i + 1, kiek, fr);
            Swap(ref Sk[i], ref Sk[j]);
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
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}
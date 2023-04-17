namespace Calc;

public partial class MainPage : ContentPage
{
    // Kezdeti állapotváltozók beállítása
    int allapot = 1; //A számológép aktuális 'állapotát' kifejező változó, (értéke alapesetben: + 1)
    string mat_muvelet; //Az elvégzendő matematikai műveletet jelöli, stringgel.
    double elso, masodik; //A művelet első és második operandusa, double értékkel.

    public MainPage() //A program belépési pontja
    {
        InitializeComponent();
        Torles(this, null); //konstruktor
    }

    // A numerikus billentyűk gombnyomási eseményeinek kezelése

    void SzamKiValaszt(object sender, EventArgs e)
    {
        // Megkapja a megnyomott gomb értékét
        Button button = (Button)sender;
        string pressed = button.Text;

        if (this.resultText.Text == "0" || allapot < 0) // Ha a kijelző 0 vagy az 'állapot' negatív értéket mutat, törölje a kijelzőt, és állítsa az 'állapot' változót pozitívra.
        {
            this.resultText.Text = "";
            if (allapot < 0)
                allapot *= -1;
        }

        this.resultText.Text += pressed; // A megnyomott gomb szövegének hozzáadása a kijelzőhöz, többször megnyomva hosszabb számot ír ki.

        double szam;
        if (double.TryParse(this.resultText.Text, out szam)) // Double értékké konvertálja a megkapott string szöveget.
        {
            this.resultText.Text = szam.ToString("N0");//A számok formázása fixpontos jelöléssel, ezres elválasztójelekkel, de ez most '0' értékű.
            if (allapot == 1)
            {
                elso = szam;
            }
            else
            {
                masodik = szam;
            }
        }
    }

    void MuvKiValaszt(object sender, EventArgs e) // A matematikai műveletek (+, -, *, /) gombnyomási eseményeinek kezelése.
    {
        allapot = -2; // Az állapotot úgy állítja be, hogy jelezze, hogy egy matematikai művelet lett kiválasztva.
        Button button = (Button)sender;
        string pressed = button.Text;
        mat_muvelet = pressed; // a kiválasztott matematikai művelet tárolása.
    }

    void Torles(object sender, EventArgs e) // A "C" (clear) gomb nyomási eseményeinek kezelése
    {
        elso = 0;
        masodik = 0;
        allapot = 1; // A számológép 'állapotának' visszaállítása.
        this.resultText.Text = "0";// Visszaállítja a kijelzőt 0-ra.
    }

    void Egyenlo(object sender, EventArgs e) // Kezelje az "=" (egyenlő) gomb megnyomására vonatkozó eseményeket.
    {
        if (allapot == 2) // ha mindkét operandus változó be lett írva,
        {
            var szam_eredmeny = SimpleCalculator.Calculate(elso, masodik, mat_muvelet);// Kiszámolja az eredményt a 'SimpleCalculator' osztály segítségével.

            this.resultText.Text = szam_eredmeny.ToString();
            elso = szam_eredmeny; // Az eredmény megjelenítése és az első operandus változó frissítése az esetleges további számításokhoz.
            allapot = -1; // állítsuk a számológép állapotát "új operandusra vár" állapotba.
        }
    }
}

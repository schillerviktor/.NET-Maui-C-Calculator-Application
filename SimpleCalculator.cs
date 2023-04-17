/* Ez egy SimpleCalculator nevű statikus osztályt definiál a Calc nevű névtérben.
 Az osztály tartalmaz egy Calculate nevű statikus metódust, amely két dupla értéket (ertek1 és ertek2)
 és egy string értéket (muv_jel) vesz fel, amely az ertek1 és ertek2 értékeken végrehajtandó matematikai 
 műveletet jelöli. A módszer egy switch utasítással a muv_jel értéke alapján elvégzi a megfelelő matematikai műveletet,
 és az eredményt double értékként adja vissza, és a MainPage.xaml.cs oldal var 'szam_eredmeny' változóba kerül az egyenlőségjel
 megnyomásakor. */



namespace Calc
{
    public static class SimpleCalculator
    {
        public static double Calculate(double ertek1, double ertek2, string muv_jel)
        {
            double eredmeny = 0;

            switch (muv_jel)
            {
                case "/":
                    eredmeny = ertek1 / ertek2;
                    break;
                case "x":
                    eredmeny = ertek1 * ertek2;
                    break;
                case "+":
                    eredmeny = ertek1 + ertek2;
                    break;
                case "-":
                    eredmeny = ertek1 - ertek2;
                    break;
            }

            return eredmeny;
        }
    }
}

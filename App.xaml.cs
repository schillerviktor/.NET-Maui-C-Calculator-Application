/* Ez a Xamarin Forms alkalmazás belépési pontjának tekinthető. A kód deklarál egy "App" nevű nyilvános & részleges osztályt, 
 amely kiterjeszti az "Application" osztályt. A konstruktorban meghívásra kerül az InitializeComponent() metódus, 
 amely egy generált metódus, amely inicializálja az oldal XAML fájljában definiált komponenseket és vezérlőelemeket.
 Ezután a MainPage tulajdonságot a MainPage osztály egy új példányára állítjuk, amely az alkalmazás főoldalaként fog szolgálni.
 Összességében ez a kód beállítja az alkalmazás alapvető szerkezetét, és biztosítja, hogy a főoldal 
 megfelelően inicializálva legyen, és készen álljon a megjelenítésre. */

namespace Calc;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}

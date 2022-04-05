using System;
class Calcul
{
    public static double DoOperation(double nbre1, double nbre2, string operation)
    {
        double result = double.NaN;

        // condition
        switch (operation)
        {
            case "1":
                result = nbre1 + nbre2;
                break;
            case "2":
                result = nbre1 - nbre2;
                break;
            case "3":
                result = nbre1 * nbre2;
                break;
            case "4":
                // Si l'utilisateur a entré 0 comme 1er nombre.
                if (nbre2 != 0)
                {
                    result = nbre1 / nbre2;
                }
                break;
            // erreur sur une entrée.
            default:
                break;
        }
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        
        Console.WriteLine("Calculatrice en C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Déclaration des variables.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            // Ask the user to type the first number.
            Console.Write("entrer un nombre, puis sur la touche entrée: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("cet insertion n'est pas valide, entrer à nouveau un nombre: ");
                numInput1 = Console.ReadLine();
            }

            // entrée du nombre par l'utilisateur.
            Console.Write("entrer le second nombre, puis sur la touche entrée: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("cet insertion n'est pas valide, entrer à nouveau un nombre: ");
                numInput2 = Console.ReadLine();
            }

            // Faire le choix sur l'opération.
            Console.WriteLine("Quelle opération voulez-vous effectuer ? :");
            Console.WriteLine("\t 1 - Addition");
            Console.WriteLine("\t 2 - Soustration");
            Console.WriteLine("\t 3 - Multiplication");
            Console.WriteLine("\t 4 - Division");
            Console.Write("Quel est votre choix ? ");

            string operation = Console.ReadLine();

            try
            {
                result = Calcul.DoOperation(cleanNum1, cleanNum2, operation);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Le résultat est : {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Choix sur la fermeture de la console.
            Console.Write("Voulez-vous continuer les calculs ? (ecrivez non si vous souhaitez arréter sinon n'importe quelle touche fera l'affaire): ");
            if (Console.ReadLine() == "non") endApp = true;

            Console.WriteLine("\n");
        }
        return;
    }
}

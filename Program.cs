using System;

namespace oxid_ai
{

    class App
    {
        public static void Main()
        {
            Atom a = new Atom("C", 6, 6, 2.5);
            Atom a2 = new Atom("O", 8, 16, 3.5);
            Atom a3 = new Atom("O", 8, 16, 3.5);
            Atom a4 = new Atom("H", 1, 1, 2.1);
            Atom a5 = new Atom("H", 1, 1, 2.1);

            Molecule water = new Molecule();
            water.AddAtom(a2);
            water.AddAtom(a4);
            water.AddAtom(a5);

            water.ConnectAtoms(a2, a5);
            water.ConnectAtoms(a2, a4);

            water.CalculateSharedElectronPairs();
            water.CalculateOxidationNumber();
            
            water.Display();
            Console.WriteLine(water);
            return;
        }
    }
}
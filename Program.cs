using System;

namespace oxid_ai
{

    class App
    {
        public static void Main()
        {
            Atom hydrogen1 = new Atom("H", 1, 1.008, 2.1);
            Atom hydrogen2 = new Atom("H", 1, 1.008, 2.1);
            Atom oxygen = new Atom("O", 8, 15.999, 3.5);

            Molecule water = new Molecule();
            water.AddAtom(hydrogen1);
            water.AddAtom(hydrogen2);
            water.AddAtom(oxygen);

            water.ConnectAtoms(oxygen, hydrogen1);
            water.ConnectAtoms(oxygen, hydrogen2);

            water.CalculateSharedElectronPairs();
            water.CalculateOxidationNumber();
            
            water.Display();
            Console.WriteLine(water);
            return;
        }
    }
}
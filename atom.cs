namespace oxid_ai
{
    public class Atom
    {
        public string Symbol { get; private set; }
        public int AtomicNumber { get; private set; }
        public double AtomicWeight { get; private set; }
        public double ElectroneGravity { get; private set; }
        public int Period { get; private set; }
        public int Group { get; private set; }
        public List<Atom> ConnectedAtoms { get; set; } = new List<Atom>();
        public int SharedElectronPairs { get; set; } = 0;
        public int OxidationNumber { get; set; } = 0;

        private int calculateGroupFromNumber() {
            if (AtomicNumber >= 1 && AtomicNumber <= 2)
                return 1;
            else if (AtomicNumber >= 3 && AtomicNumber <= 10)
                return (AtomicNumber - 2) + 10;
            else if (AtomicNumber >= 11 && AtomicNumber <= 18)
                return AtomicNumber;
            else if (AtomicNumber >= 19 && AtomicNumber <= 20)
                return AtomicNumber - 18;
            else
                return -1; // 유효하지 않은 원자 번호
        }
        private void calculatePeriodAndGroup()
        {
            Period = (AtomicNumber <= 2) ? 1 : ((AtomicNumber <= 10) ? 2 : ((AtomicNumber <= 18) ? 3 : 4));
            Group = calculateGroupFromNumber();
        }

        /// this atom must be center atom. atom2 is others.
        public Atom(string symbol, int atomicNumber, double atomicWeight, double electronegativity)
        {
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            AtomicWeight = atomicWeight;
            ElectroneGravity = electronegativity;
            calculatePeriodAndGroup();
            InitOxidation();
        }

        /// Called before molecule calculate oxidation numbers for all.
        public void InitOxidation() {
            // fixed data
            if(Symbol=="O") OxidationNumber = -2;
            else if(Symbol=="F") OxidationNumber = -1;
            else if(Symbol=="H") OxidationNumber = 1;
            // left others.
        }
        public void Connect(Atom atom2)
        {
            ConnectedAtoms.Add(atom2);
            atom2.ConnectedAtoms.Add(this);
            if(ElectroneGravity > atom2.ElectroneGravity)
                OxidationNumber += atom2.OxidationNumber;
            else if(ElectroneGravity < atom2.ElectroneGravity)
                OxidationNumber -= atom2.OxidationNumber;
            else
                OxidationNumber = 0;
        }
        public double DifferenceOfELectroneGravity(Atom atom) => (this.ElectroneGravity - atom.ElectroneGravity);
        public void Display()
        {
            Console.WriteLine($"Symbol: {Symbol}");
            Console.WriteLine($"Atomic Number: {AtomicNumber}");
            Console.WriteLine($"Atomic Weight: {AtomicWeight}");
            Console.WriteLine($"Electrone Gravity: {ElectroneGravity}");
            Console.WriteLine($"Connected Atoms: {ConnectedAtoms.Count}");
            Console.WriteLine($"Shared Electron Pairs: {SharedElectronPairs}");
            Console.WriteLine($"Oxidation Number: {OxidationNumber}");
        }
    }

}
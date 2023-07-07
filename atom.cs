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
        public int OxidationNumber {get;set;} = 0;

        private void calculatePeriodAndGroup()
        {
            Period = (AtomicNumber <= 2) ? 1 : ((AtomicNumber <= 10) ? 2 : ((AtomicNumber <= 18) ? 3 : 4));
            Group = AtomicNumber % 10;
        }

        /// this atom must be center atom. atom2 is others.
        public void Connect(Atom atom2) {
            ConnectedAtoms.Add(atom2);
            OxidationNumber -= atom2.OxidationNumber;
        }
        public Atom(string symbol, int atomicNumber, double atomicWeight, double electronegativity, int oxidationnumber)
        {
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            AtomicWeight = atomicWeight;
            ElectroneGravity = electronegativity;
            OxidationNumber = oxidationnumber;
            calculatePeriodAndGroup();
        }
        public double DifferenceOfELectroneGravity(Atom atom) => (this.ElectroneGravity - atom.ElectroneGravity);

    }

}
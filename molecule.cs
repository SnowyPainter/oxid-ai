namespace oxid_ai
{
    public class Molecule
    {
        public List<Atom> Atoms { get; set; }

        public Molecule()
        {
            Atoms = new List<Atom>();
        }

        public void AddAtom(Atom atom)
        {
            Atoms.Add(atom);
        }

        public void ConnectAtoms(Atom atom1, Atom atom2)
        {
            if (Atoms.Contains(atom1) && Atoms.Contains(atom2))
            {
                atom1.Connect(atom2);
            }
        }

        /// Every molecule creation completed, must be called.
        public void CalculateSharedElectronPairs()
        {
            foreach (var atom in Atoms)
            {
                atom.SharedElectronPairs = atom.ConnectedAtoms.Count;
            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
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
        public void CalculateOxidationNumber() {
            // 미지수랑 미지수랑 커넥트 되면 전기음성도가 주어지지 않으면 못품
            Atoms = Atoms.Select((atom) => { atom.InitOxidation(); return atom; }).ToList();
        }

        public void Display()
        {
            foreach (var atom in Atoms)
            {
                atom.Display();
                Console.WriteLine();
            }
        }
        /// return formula
        public override string? ToString()
        {
            string f = "";
            foreach (var atom in Atoms)
            {
                f += atom.Symbol;
            }
            ChemicalFormulaConverter converter = new ChemicalFormulaConverter();
            string normalizedFormula = converter.ConvertToNormalizedForm(f);
            return normalizedFormula;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class ChemicalFormulaConverter
{
    public string ConvertToNormalizedForm(string formula)
    {
        Dictionary<char, int> elementCounts = new Dictionary<char, int>();
        StringBuilder normalizedFormula = new StringBuilder();

        for (int i = 0; i < formula.Length; i++)
        {
            char currentChar = formula[i];

            if (char.IsUpper(currentChar))
            {
                char elementSymbol = currentChar;
                int elementCount = 1;

                if (i + 1 < formula.Length && char.IsLower(formula[i + 1]))
                {
                    elementSymbol = formula[i + 1];
                    i++;
                }

                if (i + 1 < formula.Length && char.IsDigit(formula[i + 1]))
                {
                    int startIndex = i + 1;
                    int endIndex = GetEndIndex(formula, startIndex);
                    string countString = formula.Substring(startIndex, endIndex - startIndex + 1);
                    elementCount = int.Parse(countString);
                    i = endIndex;
                }

                if (elementCounts.ContainsKey(elementSymbol))
                    elementCounts[elementSymbol] += elementCount;
                else
                    elementCounts[elementSymbol] = elementCount;
            }
        }

        foreach (var element in elementCounts)
        {
            normalizedFormula.Append(element.Key);
            if (element.Value > 1) normalizedFormula.Append(element.Value);
        }

        return normalizedFormula.ToString();
    }

    private int GetEndIndex(string formula, int startIndex)
    {
        int endIndex = startIndex + 1;

        while (endIndex < formula.Length && char.IsDigit(formula[endIndex]))
            endIndex++;

        return endIndex - 1;
    }
}
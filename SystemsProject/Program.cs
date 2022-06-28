using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime;

namespace SystemsProject
{
    class Program
    {
        static int numberOfLines;
        static string Base;
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"src.txt");
            numberOfLines = lines.Count();
            int counter = 0;
            string[] labels = new string[numberOfLines];
            string[] Menmonics = new string[numberOfLines];
            string[] Operands = new string[numberOfLines];
            string[] Locations = new string[numberOfLines];
            int[] Formats = new int[numberOfLines];

            foreach (var line in lines)
            {
                string[] noSpacesLine;
                string label = GetLabel(line);
                Instruction instruction;

                //Checking if there's label in each instruction and assigning menmonics, operands, labels and locations in arrays.
                if (label == " ")
                {
                    noSpacesLine = line.Replace('\t', ' ').Split(" ".ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                    instruction = new Instruction(noSpacesLine[0]);
                    Menmonics[counter] = noSpacesLine[0];
                    labels[counter] = " ";
                    if (noSpacesLine.Length > 1)
                    {
                        Operands[counter] = noSpacesLine[1];
                    }
                    Formats[counter] = instruction.GetFormat();
                    counter++;
                    //newLine = Regex.Replace(line, @"\s+", " ");
                }
                else
                {
                    noSpacesLine = line.Replace('\t', ' ').Split(" ".ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                    instruction = new Instruction(noSpacesLine[1]);
                    Menmonics[counter] = noSpacesLine[1];
                    labels[counter] = noSpacesLine[0];
                    if (noSpacesLine.Length > 2)
                    {
                        Operands[counter] = noSpacesLine[2];
                    }
                    Formats[counter] = instruction.GetFormat();
                    counter++;
                }
            }

            //Calculating next Pc
            for (int i = 0; i < counter; i++)
            {
                if (i == 0)
                {
                    Locations[0] = Operands[0];
                }
                else
                {
                    //Reserve keywords
                    if (Menmonics[i - 1] == "RESW")
                    {
                        int op = int.Parse(Operands[i - 1]);
                        op *= 3;
                        string hex = op.ToString("X");
                        //string lineLoc = GetNewLocation(Locations[i - 1], Formats[i - 1]);

                        int linelocnum = Int32.Parse(Locations[i - 1], System.Globalization.NumberStyles.HexNumber);
                        int newLocationInt = op + linelocnum;
                        string newLocationHex = newLocationInt.ToString("X");

                        string hexFill = "";
                        for (int j = 0; j < 4 - newLocationHex.Length; j++)
                            hexFill += "0";
                        newLocationHex = hexFill + newLocationHex;
                        Locations[i] = newLocationHex;
                    }

                    else if (Menmonics[i - 1] == "RESB")
                    {
                        int op = int.Parse(Operands[i - 1]);
                        op *= 1;
                        string hex = op.ToString("X");

                        int linelocnum = Int32.Parse(Locations[i - 1], System.Globalization.NumberStyles.HexNumber);
                        int newLocationInt = op + linelocnum;
                        string newLocationHex = newLocationInt.ToString("X");

                        string hexFill = "";
                        for (int j = 0; j < 4 - newLocationHex.Length; j++)
                            hexFill += "0";
                        newLocationHex = hexFill + newLocationHex;
                        Locations[i] = newLocationHex;
                    }

                    else if (Menmonics[i - 1] == "RESDW")
                    {
                        int op = int.Parse(Operands[i - 1]);
                        op *= 6;
                        string hex = op.ToString("X");

                        int linelocnum = Int32.Parse(Locations[i - 1], System.Globalization.NumberStyles.HexNumber);
                        int newLocationInt = op + linelocnum;
                        string newLocationHex = newLocationInt.ToString("X");

                        string hexFill = "";
                        for (int j = 0; j < 4 - newLocationHex.Length; j++)
                            hexFill += "0";
                        newLocationHex = hexFill + newLocationHex;
                        Locations[i] = newLocationHex;
                    }

                    else if (Menmonics[i - 1] == "BYTE")
                    {
                        if (Operands[i - 1][0] == 'X')
                        {
                            int prevLoc = Int32.Parse(Locations[i - 1]);
                            string temps = Operands[i - 1].Substring(2, Operands[i-1].Length - 3);

                            if (temps.Length % 2 == 0)
                            {
                                string newLocationHex = GetNewLocation(Locations[i - 1], temps.Length / 2);
                                Locations[i] = newLocationHex;
                            }
                            else
                            {
                                string newLocationHex = GetNewLocation(Locations[i - 1], (temps.Length + 1) / 2);
                                Locations[i] = newLocationHex;
                            }
                        }
                        else if (Operands[i - 1][0] == 'C')
                        {
                            int prevLoc = Int32.Parse((String)Locations[i - 1]);
                            string temps = Operands[i - 1].Substring(2, Operands[i - 1].Length - 3);
                            string newLocationHex = GetNewLocation(Locations[i-1], temps.Length);
                            Locations[i] = newLocationHex;
                        }
                    }
                    //default setting of calculating next counter depending on format
                    else
                    {
                        Locations[i] = GetNewLocation(Locations[i - 1], Formats[i - 1]);
                    }
                }
            }

            //registering base value and X
            for (int i = 0; i < numberOfLines; i++)
            {
                if (Menmonics[i].ToUpper() == "BASE")
                {
                    if (Operands[i][0] == '#')
                    {
                        Base = Operands[i].Substring(1, Operands.Length - 1);
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < numberOfLines; j++)
                        {
                            if (Operands[i] == labels[j])
                            {
                                Base = Locations[j];
                                break;
                            }
                        }
                        break;
                    }
                }
                else
                    Base = "2000";
            }


            //Adding Literals
            int counterLiterals = 0;
            for (int i = 0; i < numberOfLines; i++)
            {               
                if (Operands[i][0] == '=')
                {
                    counterLiterals += 1;
                }
            }
            string[] Literals = new string[counterLiterals];
            string[] LiteralsLoc = new string[counterLiterals];
            string[] literalsObj = new string[counterLiterals];
            LiteralsLoc[0] = Locations[numberOfLines-1];

            counterLiterals = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                if (Operands[i][0] == '=')
                {
                    if (!Literals.Contains(Operands[i]))
                    {
                        Literals[counterLiterals] = Operands[i];
                        counterLiterals += 1;
                    }
                }
            }
            for (int i = 1; i < Literals.Length; i++)
            {
                int newloc;
                int loc = Int32.Parse(LiteralsLoc[i - 1], System.Globalization.NumberStyles.HexNumber);
                if (Literals[i-1].ElementAt(1) =='C' || Literals[i-1].ElementAt(1) == 'c')
                {
                    newloc = Literals[i - 1].Substring(3, Literals[i - 1].Length - 4).Count();
                    loc = loc + newloc;
                }
                else if (Literals[i - 1][1] == 'X' || Literals[i - 1][1] == 'x')
                {
                    if (Literals[i - 1].Substring(3, Literals[i - 1].Length - 4).Count() %2 ==0)
                    {
                        newloc = Literals[i - 1].Substring(3, Literals[i - 1].Length - 4).Count() / 2;
                        loc = loc + newloc;
                    }
                    else
                    {
                        newloc = Literals[i - 1].Substring(3, Literals[i - 1].Length - 4).Count() +1 / 2;
                        loc = loc + newloc;
                    }

                }
                LiteralsLoc[i] = loc.ToString("X");               
            }

            for (int i = 0; i < counterLiterals; i++)
            {
                if (Literals[i].ElementAt(1)=='X')
                {
                    literalsObj[i] = Literals[i].Substring(3, Literals[i].Length - 4);
                }
                else
                {
                    string temp = "";
                    int tempo;
                    foreach (var eachchar in Literals[i].Substring(3, Literals[i].Length - 4))
                    {
                        tempo = Convert.ToInt32(eachchar);
                        temp += tempo.ToString("X");
                    }
                    literalsObj[i] = temp;
                }
            }


            //Printing output
            PrintPC(Locations);
            PrintSymbolTable(numberOfLines, Locations, labels);
            PrintOut(Menmonics, Operands, labels, Locations, Literals, LiteralsLoc);
            PrintHTE(Menmonics, Operands, labels, Locations, Literals, LiteralsLoc, literalsObj);          
            Console.ReadKey();
        }

        static string WriteD(string[] labels, string[] locations)
        {
            string D = "D ";
            for (int i = 1; i < numberOfLines; i++)
            {
                if (labels[i]!="" && labels[i]!=" ")
                {
                    D += locations[i].PadLeft(6, '0');
                    D += " " + labels[i].PadRight(6, ' ') +" ";
                }
            }
            return D;
        }
        static string WriteR(string[] labels, string[] operands)
        {
            string R = "R ";
            for (int i = 0; i < numberOfLines; i++)
            {
                if (!char.IsDigit(operands[i][0]) && operands[i][0] != '=' 
                    && operands[i].Substring(0,2) != "X'" && operands[i].Substring(0, 2) != "C'" && operands[i] != "START")
                {
                    if (operands[i][0] == '#' || operands[i][0] == '@')
                    {
                        if (!labels.Contains(operands[i].Substring(1,operands[i].Length-1)) && !R.Contains(operands[i].Substring(1, operands[i].Length - 1)))
                        {
                            R+= operands[i].Substring(1, operands[i].Length - 1).PadRight(6,' ') + " ";
                        }
                    }
                    else
                    {
                        if (!labels.Contains(operands[i]) && !R.Contains(operands[i]))
                        {
                            R += operands[i].PadRight(6, ' ') + " ";
                        }
                    }
                }
            }
            return R;
        }
        static string[] WriteM(string[] Mnemonics,  string[] locations)
        {
            int c = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                if (Mnemonics[i][0] == '+')
                {
                    c++;
                }
            }
            string[] M = new string[c];
            c = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                if (Mnemonics[i][0] == '+')
                {
                    int tmp = Int32.Parse(locations[i], System.Globalization.NumberStyles.HexNumber);
                    tmp += 1;
                    M[c] = "M ";
                    M[c] += tmp.ToString("X").PadLeft(6,'0');
                    M[c] += " 05";
                    c++;
                }
            }
            return M;
        }
        static string WriteE(string[] locations)
        {
            string E = "E " + locations[0].PadLeft(6, '0');
            return E;
        }
        static string[] WriteT(string[] Mnemonics, string[] Operands, string[] labels, string[] locations, string[] literals,
            string[] literalsLoc, string[] literalsObj)
        {
            string[] objcodes = new string[numberOfLines+literals.Count()];
            string[] T = new string[numberOfLines+literals.Count()];
            

            int d;
            for (d = 0; d < numberOfLines; d++)
            {
                objcodes[d] = GetObjectCode(Mnemonics, d, Operands, labels, locations, literals, literalsLoc);
            }

            string[] objcodestot = new string[objcodes.Length + literalsObj.Length];
            objcodes.CopyTo(objcodestot, 0);
            literalsObj.CopyTo(objcodestot, objcodes.Length);
            
            string[] totLocations = new string[locations.Length + literals.Length];
            locations.CopyTo(totLocations, 0);
            literalsLoc.CopyTo(totLocations, locations.Length);

            string[] obj2 = new string[10];
            string temp = "";
            int jc = 0;
            for (int j = 0; j < objcodestot.Length; j++)
            {
                if (objcodestot[j] != "")
                {
                    obj2 = new string[10];
                    T[jc] = "T " + totLocations[j].PadLeft(6, '0') + " ";
                    for (int i = 0; temp.Length < 60; i++, j++)
                    {
                        if (j < objcodestot.Length)
                        {
                            temp += objcodestot[j];
                            if (objcodestot[j] != "" || objcodestot[j] == null)
                            {
                                obj2[i] = objcodestot[j];
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                            break;
                    }
                    j--;
                    int te = temp.Length / 2;
                    T[jc] = T[jc] + te.ToString("X").PadLeft(2,'0') + " ";
                    temp = "";
                    for (int i = 0; i < obj2.Count(); i++)
                    {
                        T[jc] = T[jc] + obj2[i] + " ";
                    }
                    jc++;
                }
                
            }

            return T;
        }
        static string WriteH(string[] Mnemonics, string[] Operands, string[] labels, string[] locations)
        {
            string H = "H " + labels[0].PadRight(6,' ') + " " + locations[0].PadLeft(6,'0') + " ";
            int temp = Int32.Parse(locations[numberOfLines-1], System.Globalization.NumberStyles.HexNumber);
            temp += 1;
            H += temp.ToString("X").PadLeft(6,'0');
            return H;
        }

        static void PrintHTE(string[] Mnemonics, string[] Operands, string[] labels, string[] locations, string[] literals,
            string[] literalsLoc, string[] literalsObj)
        {
            string[] T = WriteT(Mnemonics, Operands, labels, locations, literals, literalsLoc, literalsObj);
            T = T.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string E = WriteE(locations);
            string H = WriteH(Mnemonics, Operands, labels, locations);
            string[] M = WriteM(Mnemonics, locations);
            string R = WriteR(labels, Operands);
            string D = WriteD(labels, locations);
            string[] HTE = new string[T.Length + M.Length + 4];
            HTE[0] = H;
            HTE[1] = D;
            HTE[2] = R;
            T.CopyTo(HTE, 3);
            M.CopyTo(HTE, 3 + T.Length);
            HTE[HTE.Length-1] = E;
            System.IO.File.WriteAllLines("HTE.txt", HTE);

        }
        static void PrintOut(string[] Mnemonics, string[] Operands, string[] labels, string[] locations, string[] literals, string[] literalsLoc)
        {
            string[] objectsCode = new string[numberOfLines];
            for (int i = 0; i < numberOfLines; i++)
            {
                objectsCode[i] = GetObjectCode(Mnemonics, i, Operands, labels, locations, literals, literalsLoc);
            }
            System.IO.File.WriteAllLines("OUT.txt", objectsCode);
        }

        /*Thise method constructs object code by calling menthodes nixbpe, opcode and Address*/
        static string GetObjectCode (string[] Mnemonics, int lineNum, string[] Operands, string[] labels, string[] locations, string[] literals, string[] literalsLoc)
        {
            string temp = "";
            int tempo;
            string dispAddress;
            string opCode; 
            string nixbpe; 


            if (Mnemonics[lineNum] == "RESW" || Mnemonics[lineNum] == "RESB")
            {
                return "";
            }
            else if (Mnemonics[lineNum] == "BYTE")
            {
                if (Operands[lineNum].ElementAt(0) == 'X' || Operands[lineNum].ElementAt(0) == 'x')
                {
                    temp = Operands[lineNum].Substring(2, Operands[lineNum].Length - 3);
                    return temp;
                }
                else
                {
                    foreach (var eachChar in Operands[lineNum].Substring(2, Operands[lineNum].Length - 3))
                    {
                        tempo = Convert.ToInt32(eachChar);
                        temp += tempo.ToString("X");
                    }
                    return temp;
                }
            }
            else if (Mnemonics[lineNum] == "WORD")
            {
                return int.Parse(Operands[lineNum]).ToString("X").PadLeft(6, '0');
            }
            else {
                opCode = GetOpCode(Mnemonics[lineNum]);
                nixbpe = Getnixbpe(labels, locations, Operands, Mnemonics, lineNum);
                if (nixbpe != "")
                {
                    dispAddress = GetDispAddress(labels, locations, Operands, Mnemonics, literals, literalsLoc, lineNum, nixbpe.ElementAt(3).ToString());
                }
                else
                {
                    dispAddress = GetDispAddress(labels, locations, Operands, Mnemonics, literals, literalsLoc, lineNum, "0");
                }

                if (opCode + nixbpe != "")
                {
                    nixbpe = MysteryFormatNxixbpe(Mnemonics, dispAddress, nixbpe, lineNum);
                    tempo = Convert.ToInt32(opCode + nixbpe, 2);
                    temp += tempo.ToString("X");
                    Instruction instruction = new Instruction(Mnemonics[lineNum]);
                    if (opCode.Substring(0,4) == "0000")
                    {
                        if (instruction.GetFormat() == 3)
                        {
                            return (temp + dispAddress).PadLeft(6, '0');
                        }
                        else
                            return (temp + dispAddress).PadLeft(8, '0');
                    }
                    return temp + dispAddress;
                }
                else
                    return "";
            }
        }

        /*This method returns Disposition Address of a line of code in Hex*/
        static string GetDispAddress(string[] labels, string[] locations, string[] operands, string[] menmonics, string[] literals, 
            string[] literalsLoc, int lineNum, string b)
        {
            Instruction instruction = new Instruction(menmonics[lineNum]);
            if (operands[lineNum].Substring(operands[lineNum].Length-2,2)==",X"
                || operands[lineNum].Substring(operands[lineNum].Length - 2, 2) == ",x")
            {
                operands[lineNum] = operands[lineNum].Substring(0, operands[lineNum].Length - 2);
            }
            string address = "";
            string nextLoc;
            if (instruction.GetFormat() == 4)
            {
                if (operands[lineNum].Substring(0, 1) == "#")
                {
                    if (!char.IsDigit(operands[lineNum].ElementAt(1)))
                    {
                        address = int.Parse(operands[lineNum].Substring(1)).ToString("X");
                    }
                    else
                    {
                        if (b == "0")
                        {
                            for (int i = 0; i < numberOfLines; i++)
                            {
                                if (labels[i] == operands[lineNum])
                                {
                                    address = locations[i];
                                    nextLoc = locations[lineNum + 1];
                                    int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                    int nextLocInt = Int32.Parse(nextLoc, System.Globalization.NumberStyles.HexNumber);
                                    address = (addressInt - nextLocInt).ToString("X");
                                    break;
                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < numberOfLines; i++)
                            {
                                if (labels[i] == operands[lineNum])
                                {
                                    address = locations[i];
                                    int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                    int nextLocInt = Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                                    address = (addressInt - nextLocInt).ToString("X");
                                    break;
                                }

                            }

                        }
                    }
                }
                else if (operands[lineNum].Substring(0, 1) == "@")
                {
                    if (b == "0")
                    {
                        for (int i = 0; i < numberOfLines; i++)
                        {
                            if (labels[i] == operands[lineNum])
                            {
                                address = locations[i];
                                nextLoc = locations[lineNum + 1];
                                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                int nextLocInt = Int32.Parse(nextLoc, System.Globalization.NumberStyles.HexNumber);
                                address = (addressInt - nextLocInt).ToString("X");
                                break;
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < numberOfLines; i++)
                        {
                            if (labels[i] == operands[lineNum])
                            {
                                address = locations[i];
                                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                int nextLocInt = Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                                address = (addressInt - nextLocInt).ToString("X");
                                break;
                            }

                        }

                    }
                }
                else if (operands[lineNum].Substring(0, 1) == "=")
                {
                    for (int i = 0; i < literals.Length; i++)
                    {
                        if (operands[lineNum] == literals[i])
                        {
                            int loc = Int32.Parse(locations[lineNum + 1], System.Globalization.NumberStyles.HexNumber);
                            int newloc;
                            if (Int32.Parse(literalsLoc[i], System.Globalization.NumberStyles.HexNumber) - loc > 2047)
                            {
                                newloc = Int32.Parse(literalsLoc[i], System.Globalization.NumberStyles.HexNumber)
                                        - Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                            }
                            else
                            {
                                newloc = Int32.Parse(literalsLoc[i], System.Globalization.NumberStyles.HexNumber) - loc;
                            }

                            address = newloc.ToString("X").PadLeft(5, '0');
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        if (labels[i] == operands[lineNum])
                            address = locations[i];
                    }
                }
                address = address.PadLeft(5, '0');
            }
            else if (instruction.GetFormat() == 3)
            {
                if (operands[lineNum].Substring(0, 1) == "#")
                {
                    if (!char.IsDigit(operands[lineNum].ElementAt(1)))
                    {
                        address = int.Parse(operands[lineNum].Substring(1)).ToString("X");
                    }
                    else
                    {
                        if (b == "0")
                        {
                            for (int i = 0; i < numberOfLines; i++)
                            {
                                if (labels[i] == operands[lineNum])
                                {
                                    address = locations[i];
                                    nextLoc = locations[lineNum + 1];
                                    int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                    int nextLocInt = Int32.Parse(nextLoc, System.Globalization.NumberStyles.HexNumber);
                                    address = (addressInt - nextLocInt).ToString("X");
                                    break;
                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < numberOfLines; i++)
                            {
                                if (labels[i] == operands[lineNum])
                                {
                                    address = locations[i];
                                    int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                    int nextLocInt = Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                                    address = (addressInt - nextLocInt).ToString("X");
                                    break;
                                }

                            }

                        }
                    }
                }
                else if (operands[lineNum].Substring(0, 1) == "@")
                {
                    if (b == "0")
                    {
                        for (int i = 0; i < numberOfLines; i++)
                        {
                            if (labels[i] == operands[lineNum])
                            {
                                address = locations[i];
                                nextLoc = locations[lineNum + 1];
                                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                int nextLocInt = Int32.Parse(nextLoc, System.Globalization.NumberStyles.HexNumber);
                                address = (addressInt - nextLocInt).ToString("X");
                                break;
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < numberOfLines; i++)
                        {
                            if (labels[i] == operands[lineNum])
                            {
                                address = locations[i];
                                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                int nextLocInt = Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                                address = (addressInt - nextLocInt).ToString("X");
                                break;
                            }

                        }

                    }
                }
                else if (operands[lineNum].Substring(0, 1) == "=")
                {
                    for (int i = 0; i < literals.Length; i++)
                    {
                        if (operands[lineNum] == literals[i])
                        {
                            int loc = Int32.Parse(locations[lineNum + 1], System.Globalization.NumberStyles.HexNumber);
                            int newloc;
                            if (Int32.Parse(literalsLoc[i], System.Globalization.NumberStyles.HexNumber) - loc > 2047)
                            {
                            newloc = Int32.Parse(literalsLoc[i], System.Globalization.NumberStyles.HexNumber) 
                                    - Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                            }
                            else
                            { 
                            newloc = Int32.Parse(literalsLoc[i], System.Globalization.NumberStyles.HexNumber) - loc;
                            }

                            address = newloc.ToString("X").PadLeft(3, '0');
                        }
                    }
                }
                else
                {
                    if (b == "0")
                    {
                        for (int i = 0; i < numberOfLines; i++)
                        {
                            if (labels[i] == operands[lineNum])
                            {
                                address = locations[i];
                                nextLoc = locations[lineNum + 1];
                                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                int nextLocInt = Int32.Parse(nextLoc, System.Globalization.NumberStyles.HexNumber);
                                address = (addressInt - nextLocInt).ToString("X");
                                break;
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < numberOfLines; i++)
                        {
                            if (labels[i] == operands[lineNum])
                            {
                                address = locations[i];
                                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                                int nextLocInt = Int32.Parse(Base, System.Globalization.NumberStyles.HexNumber);
                                address = (addressInt - nextLocInt).ToString("X");
                                break;
                            }

                        }

                    }
                }
                address = address.PadLeft(3, '0');
            }
            else if (instruction.GetFormat() == 2)
            {
                switch (operands[lineNum].Substring(0,1))
                {
                    case "A":
                        address = "00"; break;
                    case "X":
                        address = "10"; break;
                    case "L":
                        address = "20"; break;
                    case "B":
                        address = "30"; break;
                    case "S":
                        address = "40"; break;
                    case "T":
                        address = "50"; break;
                    case "F":
                        address = "60"; break;
                    default:
                        break;
                }
                switch (operands[lineNum].Substring(2, 1))
                {
                    case "A":
                        address += "00"; break;
                    case "X":
                        address += "10"; break;
                    case "L":
                        address += "20"; break;
                    case "B":
                        address += "30"; break;
                    case "S":
                        address += "40"; break;
                    case "T":
                        address += "50"; break;
                    case "F":
                        address += "60"; break;
                    default:
                        break;
                }
            }
            else
                return address;
             return address;
        }
        

        /*This method returns new nixbpe for format 5 and 6*/
        static string MysteryFormatNxixbpe(string[] mnemonics, string address, string nixbpe, int lineNum)
        {
            string newNixbpe;
            if (mnemonics[lineNum].ElementAt(0) == '&')
            {
                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                if (addressInt % 2 == 0)
                    newNixbpe = "1" + nixbpe.Substring(1, 5);
                else
                    newNixbpe = "0" + nixbpe.Substring(1, 5);

                if (addressInt > 0)
                    newNixbpe = newNixbpe[0] + "1" + newNixbpe.Substring(2, 4);
                else
                    newNixbpe = newNixbpe[0] + "0" + newNixbpe.Substring(2, 4);

                if (addressInt == 0)
                    newNixbpe = newNixbpe.Substring(0, 5) + "1";
                else
                    newNixbpe = newNixbpe.Substring(0, 5) + "0";

                return newNixbpe;
            }
            else if (mnemonics[lineNum].ElementAt(0) == '$')
            {
                int addressInt = Int32.Parse(address, System.Globalization.NumberStyles.HexNumber);
                if (addressInt % 2 == 0)
                    newNixbpe = nixbpe.Substring(0, 3) + "0" + nixbpe.Substring(4, 2);
                else
                    newNixbpe = nixbpe.Substring(0, 3) + "1" + nixbpe.Substring(4, 2);

                if (addressInt == 0)
                    newNixbpe = newNixbpe.Substring(0, 4) + "0" + newNixbpe[5];
                else
                    newNixbpe = newNixbpe.Substring(0, 4) + "1" + newNixbpe[5];

                if (address == Base)
                    newNixbpe = newNixbpe.Substring(0, 5) + "0";
                else
                    newNixbpe = newNixbpe.Substring(0, 5) + "1";
                return newNixbpe;
            }
            else
                return nixbpe;
        }
        /*This method returns nixbpe as one string of a certain line of code in binary*/
        static string Getnixbpe(string[] labels, string[] locations, string[] operands, string[] menmonics, int lineNum)
        {
            string n, i, x, b, p, e;
            Instruction instruction = new Instruction(menmonics[lineNum]);

            //FORMAT 4
            if (instruction.GetFormat() == 4)
            {
                e = "1"; b = "0"; p = "0";
                if (operands[lineNum].Substring(operands[lineNum].Length - 2, 2) == ",X" || 
                    operands[lineNum].Substring(operands[lineNum].Length - 2, 2) == ",x")
                    x = "1";
                else
                    x = "0";

                if (operands[lineNum].Substring(0,1) == "#")
                {
                    n =  "0"; i = "1";
                }
                else if (operands[lineNum].Substring(0,1) == "@")
                {
                    n = "1"; i = "0";
                }
                else
                {
                    n = "1"; i = "1";

                }
                return n + i + x + b + p + e;
            }
            //FORMAT 3
            else if (instruction.GetFormat() == 3)
            {
                e = "0"; b = "0"; p = "0";

                if (operands[lineNum].Substring(operands[lineNum].Length - 2, 2) == ",X" || 
                    operands[lineNum].Substring(operands[lineNum].Length - 2, 2) == ",x")
                    x = "1";
                else
                    x = "0";

                if (operands[lineNum].Substring(0, 1) == "#")
                {
                    n = "0"; i = "1";
                    if (!char.IsDigit(operands[lineNum].ElementAt(1)))
                    {             
                        for (int j = 0; j < numberOfLines; j++)
                        {
                            if (operands[lineNum].Substring(1, operands[lineNum].Length - 1) == labels[j])
                            {
                                int loc = Int32.Parse(locations[j], System.Globalization.NumberStyles.HexNumber);
                                int nextLoc = Int32.Parse(locations[lineNum + 1], System.Globalization.NumberStyles.HexNumber);
                                if ((loc - nextLoc) > 2048 || loc - nextLoc < -2048)
                                {
                                    b = "1"; p = "0";
                                }
                                else
                                {
                                    b = "0"; p = "1";
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        b = "0"; p = "0";
                    }
                }

                else if (operands[lineNum].Substring(0, 1) == "@")
                {
                    n = "1"; i = "0";
                    if (!char.IsDigit(operands[lineNum].ElementAt(1)))
                    {
                        for (int j = 0; j < numberOfLines; j++)
                        {
                            if (operands[lineNum].Substring(1, operands[lineNum].Length - 1) == labels[j])
                            {
                                int loc = Int32.Parse(locations[j], System.Globalization.NumberStyles.HexNumber);
                                int nextLoc = Int32.Parse(locations[lineNum + 1], System.Globalization.NumberStyles.HexNumber);
                                if ((loc - nextLoc) > 2048 || loc - nextLoc < -2048)
                                {
                                    b = "1"; p = "0";
                                }
                                else
                                {
                                    b = "0"; p = "1";
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        b = "0"; p = "0";
                    }
                }

                else
                {
                    n = "1"; i = "1";
                    for (int j = 0; j < numberOfLines; j++)
                    {
                        if (operands[lineNum] == labels[j])
                        {
                            int loc = Int32.Parse(locations[j], System.Globalization.NumberStyles.HexNumber);
                            int nextLoc = Int32.Parse(locations[lineNum + 1], System.Globalization.NumberStyles.HexNumber);
                            if ((loc - nextLoc) > 2048 || loc - nextLoc < -2048)
                            {
                                b = "1"; p = "0";
                            }
                            else
                            {
                                b = "0"; p = "1";
                            }
                            break;
                        }
                    }
                }

                return n + i + x + b + p + e;

            }
            else
            {
                return "";
            }

        }

        /*this method recives operation keyword 
        and transform hex op code from instruction class to 6 character binary op code.*/
        static string GetOpCode(string s)
        {
            Instruction instruction = new Instruction(s);
            string opcode = instruction.GetOperationCode();
            if (opcode != "")
            {
                string opcode1 = opcode.ElementAt(0).ToString();
                string opcode2 = opcode.ElementAt(1).ToString();
                opcode1 = Convert.ToString(Convert.ToInt32(opcode1, 16), 2).PadLeft(4, '0');
                opcode2 = Convert.ToString(Convert.ToInt32(opcode2, 16), 2).PadLeft(4, '0');

                string opcodeBinary = opcode1 + opcode2;
                if (instruction.GetFormat() == 2 || instruction.GetFormat() == 1)
                {
                    return opcodeBinary;
                }
                return opcodeBinary.Remove(opcodeBinary.Length - 2);
            }
            else
                return "";
        }

        //this method receives current location counter in hex 
        //and increases it with integer size.
        static string GetNewLocation(string s, int size)
        {
            int value = Int32.Parse(s, System.Globalization.NumberStyles.HexNumber);
            int newLoc = value + size;
            string hex = newLoc.ToString("X");
            string fill = "";
            for (int c = 0; c < 4 - hex.Length; c++)
            {
                fill += "0";
            }
            return fill + hex;
        }

        //this method receives one SICXE line of code 
        //and extracts label.
        static string GetLabel(string s)
        {

            if (s.ElementAt(0) == ' ')
            {
                return " ";
            }
            else
            {
                return Regex.Replace(s.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            }
        }

        //Prints txt file of PC
        static void PrintPC(string[] locationsToPrint)
        {
            System.IO.File.WriteAllLines("PC.txt", locationsToPrint);
        }

        //prints txt file of SymbolTable
        static void PrintSymbolTable(int numLines, string[] locationsToPrint, string[] labelsToPrint)
        {
            string[] symbolTable = new string[numLines];
            for (int i = 0; i < numLines; i++)
            {
                if (labelsToPrint[i] != " ")
                {
                    symbolTable[i] = locationsToPrint[i] + " " + labelsToPrint[i];
                }
            }
            System.IO.File.WriteAllLines("SymbolTable.txt", symbolTable);
        }
    }
}


using System;

namespace SystemsProject
{
    class Instruction
    {
        string OperationCode;
        int Format;

        public Instruction(string Mnemonic)
        {
            switch (Mnemonic)
            {
                case "ADD":
                    OperationCode = "18"; Format = 3; 
                    break;
                case "+ADD":
                    OperationCode = "18"; Format = 4; 
                    break;

                case "&ADD":
                    OperationCode = "18"; Format = 3; 
                    break;
                case "$ADD":
                    OperationCode = "18"; Format = 4; 
                    break;

                case "ADDF":
                    OperationCode = "58"; Format = 3; 
                    break;
                case "+ADDF":
                    OperationCode = "58"; Format = 4; 
                    break;
                case "&ADDF":
                    OperationCode = "58"; Format = 3; 
                    break;
                case "$ADDF":
                    OperationCode = "58"; Format = 4; 
                    break;


                case "AND":
                    OperationCode = "40"; Format = 3; 
                    break;
                case "+AND":
                    OperationCode = "40"; Format = 4; 
                    break;
                case "&AND":
                    OperationCode = "40"; Format = 3; 
                    break;
                case "$AND":
                    OperationCode = "40"; Format = 4; 
                    break;



                case "COMP":
                    OperationCode = "28"; Format = 3; 
                    break;
                case "+COMP":
                    OperationCode = "28"; Format = 4; 
                    break;
                case "$COMP":
                    OperationCode = "28"; Format = 4; 
                    break;
                case "&COMP":
                    OperationCode = "28"; Format = 3; 
                    break;


                case "COMPF":
                    OperationCode = "88"; Format = 3; 
                    break;
                case "+COMPF":
                    OperationCode = "88"; Format = 4; 
                    break;
                case "$COMPF":
                    OperationCode = "88"; Format = 4; 
                    break;
                case "&COMPF":
                    OperationCode = "88"; Format = 3; 
                    break;



                case "DIV":
                    OperationCode = "24"; Format = 3; 
                    break;
                case "+DIV":
                    OperationCode = "24"; Format = 4; 
                    break;
                case "$DIV":
                    OperationCode = "24"; Format = 4; 
                    break;
                case "&DIV":
                    OperationCode = "24"; Format = 3; 
                    break;

                case "DIVF":
                    OperationCode = "64"; Format = 3; 
                    break;
                case "+DIVF":
                    OperationCode = "64"; Format = 4; 
                    break;
                case "$DIVF":
                    OperationCode = "64"; Format = 4; 
                    break;
                case "&DIVF":
                    OperationCode = "64"; Format = 3; 
                    break;


                case "J":
                    OperationCode = "3C"; Format = 3; 
                    break;
                case "+J":
                    OperationCode = "3C"; Format = 4; 
                    break;
                case "$J":
                    OperationCode = "3C"; Format = 4; 
                    break;
                case "&J":
                    OperationCode = "3C"; Format = 3; 
                    break;



                case "JEQ":
                    OperationCode = "30"; Format = 3; 
                    break;
                case "+JEQ":
                    OperationCode = "30"; Format = 4; 
                    break;
                case "$JEQ":
                    OperationCode = "30"; Format = 4; 
                    break;
                case "&JEQ":
                    OperationCode = "30"; Format = 3; 
                    break;


                case "JGT":
                    OperationCode = "34"; Format = 3; 
                    break;
                case "+JGT":
                    OperationCode = "34"; Format = 4; 
                    break;
                case "$JGT":
                    OperationCode = "34"; Format = 4; 
                    break;
                case "&JGT":
                    OperationCode = "34"; Format = 3; 
                    break;

                case "JLT":
                    OperationCode = "38"; Format = 3; 
                    break;
                case "+JLT":
                    OperationCode = "38"; Format = 4; 
                    break;
                case "$JLT":
                    OperationCode = "38"; Format = 4; 
                    break;
                case "&JLT":
                    OperationCode = "38"; Format = 3; 
                    break;

                case "JSUB":
                    OperationCode = "48"; Format = 3; 
                    break;
                case "+JSUB":
                    OperationCode = "48"; Format = 4; 
                    break;
                case "$JSUB":
                    OperationCode = "48"; Format = 4; 
                    break;
                case "&JSUB":
                    OperationCode = "48"; Format = 3; 
                    break;


                case "LDA":
                    OperationCode = "00"; Format = 3; 
                    break;
                case "+LDA":
                    OperationCode = "00"; Format = 4; 
                    break;
                case "$LDA":
                    OperationCode = "00"; Format = 4; 
                    break;
                case "&LDA":
                    OperationCode = "00"; Format = 3; 
                    break;

                case "LDB":
                    OperationCode = "68"; Format = 3; 
                    break;
                case "+LDB":
                    OperationCode = "68"; Format = 4; 
                    break;
                case "$LDB":
                    OperationCode = "68"; Format = 4; 
                    break;
                case "&LDB":
                    OperationCode = "68"; Format = 3; 
                    break;

                case "LDCH":
                    OperationCode = "50"; Format = 3; 
                    break;
                case "+LDCH":
                    OperationCode = "50"; Format = 4; 
                    break;
                case "$LDCH":
                    OperationCode = "50"; Format = 4; 
                    break;
                case "&LDCH":
                    OperationCode = "50"; Format = 3; 
                    break;

                case "LDF":
                    OperationCode = "70"; Format = 3; 
                    break;
                case "+LDF":
                    OperationCode = "70"; Format = 4; 
                    break;
                case "$LDF":
                    OperationCode = "70"; Format = 4; 
                    break;
                case "&LDF":
                    OperationCode = "70"; Format = 3; 
                    break;

                case "LDL":
                    OperationCode = "08"; Format = 3; 
                    break;
                case "+LDL":
                    OperationCode = "08"; Format = 4; 
                    break;
                case "$LDL":
                    OperationCode = "08"; Format = 4; 
                    break;
                case "&LDL":
                    OperationCode = "08"; Format = 3; 
                    break;


                case "LDS":
                    OperationCode = "6C"; Format = 3; 
                    break;
                case "+LDS":
                    OperationCode = "6C"; Format = 4; 
                    break;
                case "$LDS":
                    OperationCode = "6C"; Format = 4; 
                    break;
                case "&LDS":
                    OperationCode = "6C"; Format = 3; 
                    break;


                case "LDT":
                    OperationCode = "74"; Format = 3; 
                    break;
                case "+LDT":
                    OperationCode = "74"; Format = 4; 
                    break;
                case "$LDT":
                    OperationCode = "74"; Format = 4; 
                    break;
                case "&LDT":
                    OperationCode = "74"; Format = 3; 
                    break;


                case "LDX":
                    OperationCode = "04"; Format = 3; 
                    break;
                case "+LDX":
                    OperationCode = "04"; Format = 4; 
                    break;
                case "$LDX":
                    OperationCode = "04"; Format = 4; 
                    break;
                case "&LDX":
                    OperationCode = "04"; Format = 3; 
                    break;

                case "LPS":
                    OperationCode = "D0"; Format = 3; 
                    break;
                case "+LPS":
                    OperationCode = "D0"; Format = 4; 
                    break;
                case "$LPS":
                    OperationCode = "D0"; Format = 4; 
                    break;
                case "&LPS":
                    OperationCode = "D0"; Format = 3; 
                    break;


                case "MUL":
                    OperationCode = "20"; Format = 3; 
                    break;
                case "+MUL":
                    OperationCode = "20"; Format = 4; 
                    break;
                case "$MUL":
                    OperationCode = "20"; Format = 4; 
                    break;
                case "&MUL":
                    OperationCode = "20"; Format = 3; 
                    break;


                case "OR":
                    OperationCode = "44"; Format = 3; 
                    break;
                case "+OR":
                    OperationCode = "44"; Format = 4; 
                    break;
                case "$OR":
                    OperationCode = "44"; Format = 4; 
                    break;
                case "&OR":
                    OperationCode = "44"; Format = 3; 
                    break;

                case "RD":
                    OperationCode = "D8"; Format = 3; 
                    break;
                case "+RD":
                    OperationCode = "D8"; Format = 4; 
                    break;
                case "$RD":
                    OperationCode = "D8"; Format = 4; 
                    break;
                case "&RD":
                    OperationCode = "D8"; Format = 3; 
                    break;



                case "RSUB":
                    OperationCode = "4C"; Format = 3; 
                    break;
                case "+RSUB":
                    OperationCode = "4C"; Format = 4; 
                    break;
                case "$RSUB":
                    OperationCode = "4C"; Format = 4; 
                    break;
                case "&RSUB":
                    OperationCode = "4C"; Format = 3; 
                    break;



                case "STA":
                    OperationCode = "0C"; Format = 3; 
                    break;
                case "+STA":
                    OperationCode = "0C"; Format = 4; 
                    break;
                case "$STA":
                    OperationCode = "0C"; Format = 4; 
                    break;
                case "&STA":
                    OperationCode = "0C"; Format = 3; 
                    break;


                case "STCH":
                    OperationCode = "54"; Format = 3; 
                    break;
                case "+STCH":
                    OperationCode = "54"; Format = 4; 
                    break;
                case "$STCH":
                    OperationCode = "54"; Format = 4; 
                    break;
                case "&STCH":
                    OperationCode = "54"; Format = 3; 
                    break;

                case "STB":
                    OperationCode = "78"; Format = 3; 
                    break;
                case "+STB":
                    OperationCode = "78"; Format = 4; 
                    break;
                case "$STB":
                    OperationCode = "78"; Format = 4; 
                    break;
                case "&STB":
                    OperationCode = "78"; Format = 3; 
                    break;

                case "STF":
                    OperationCode = "80"; Format = 3; 
                    break;
                case "+STF":
                    OperationCode = "80"; Format = 4; 
                    break;
                case "$STF":
                    OperationCode = "80"; Format = 4; 
                    break;
                case "&STF":
                    OperationCode = "80"; Format = 3; 
                    break;


                case "STL":
                    OperationCode = "14"; Format = 3; 
                    break;
                case "+STL":
                    OperationCode = "14"; Format = 4; 
                    break;
                case "$STL":
                    OperationCode = "14"; Format = 4; 
                    break;
                case "&STL":
                    OperationCode = "14"; Format = 3; 
                    break;



                case "STSW":
                    OperationCode = "E8"; Format = 3; 
                    break;
                case "+STSW":
                    OperationCode = "E8"; Format = 4; 
                    break;
                case "$STSW":
                    OperationCode = "E8"; Format = 4; 
                    break;
                case "&STSW":
                    OperationCode = "E8"; Format = 3; 
                    break;

                case "STX":
                    OperationCode = "10"; Format = 3; 
                    break;
                case "+STX":
                    OperationCode = "10"; Format = 4; 
                    break;
                case "$STX":
                    OperationCode = "10"; Format = 4; 
                    break;
                case "&STX":
                    OperationCode = "10"; Format = 3; 
                    break;


                case "SUB":
                    OperationCode = "1C"; Format = 3; 
                    break;
                case "+SUB":
                    OperationCode = "1C"; Format = 4; 
                    break;
                case "$SUB":
                    OperationCode = "1C"; Format = 4; 
                    break;
                case "&SUB":
                    OperationCode = "1C"; Format = 3; 
                    break;

                case "TD":
                    OperationCode = "E0"; Format = 3; 
                    break;
                case "+TD":
                    OperationCode = "E0"; Format = 4; 
                    break;
                case "$TD":
                    OperationCode = "E0"; Format = 4; 
                    break;
                case "&TD":
                    OperationCode = "E0"; Format = 3; 
                    break;

                case "TIX":
                    OperationCode = "2C"; Format = 3; 
                    break;
                case "+TIX":
                    OperationCode = "2C"; Format = 4; 
                    break;
                case "$TIX":
                    OperationCode = "2C"; Format = 4; 
                    break;
                case "&TIX":
                    OperationCode = "2C"; Format = 3; 
                    break;


                case "WD":
                    OperationCode = "DC"; Format = 3; 
                    break;
                case "+WD":
                    OperationCode = "DC"; Format = 4; 
                    break;
                case "$WD":
                    OperationCode = "DC"; Format = 4; 
                    break;
                case "&WD":
                    OperationCode = "DC"; Format = 3; 
                    break;


                case "BYTE":
                    OperationCode = ""; Format = 1; 
                    break;
                case "RESB":
                    OperationCode = ""; Format = 1; 
                    break;
                case "FIX":
                    OperationCode = "C4"; Format = 1;
                    break;
                case "FLOAT":
                    OperationCode = "C0"; Format = 1;
                    break;
                case "HIO":
                    OperationCode = "F4"; Format = 1;
                    break;
                case "NORM":
                    OperationCode = "C8"; Format = 1;
                    break;
                case "SIO":
                    OperationCode = "F0"; Format = 1;
                    break;
                case "TIO":
                    OperationCode = "F8"; Format = 1;
                    break;
                case "RESW":
                    OperationCode = "";  Format = 3;
                    break;
                case "WORD":
                    OperationCode = ""; Format = 3; 
                    break;
                case "START":
                    OperationCode = ""; Format = 0; 
                    break;
                case "END":
                    OperationCode = ""; Format = 0; 
                    break;

                case "BASE":
                    OperationCode = "No OB CODE "; Format = 0; 
                    break;

                //Format 2 instructions
                case "COMPR":
                    OperationCode = "A0"; Format = 2; 
                    break;
                case "ADDR":
                    OperationCode = "90"; Format = 2; 
                    break;
                case "CLEAR":
                    OperationCode = "B4"; Format = 2; 
                    break;
                case "DIVR":
                    OperationCode = "9C"; Format = 2; 
                    break;
                case "MULR":
                    OperationCode = "98"; Format = 2; 
                    break;
                case "RMO":
                    OperationCode = "AC"; Format = 2; 
                    break;
                case "SUBR":
                    OperationCode = "94"; Format = 2; 
                    break;
                case "TIXR":
                    OperationCode = "B8"; Format = 2; 
                    break;


                default:
                    Console.WriteLine("Wrong instruction inserted!");
                    break;
            }
        }

        public string GetOperationCode()
        {
            return OperationCode;
        }
        public int GetFormat()
        {
            return Format;
        }
    }
}


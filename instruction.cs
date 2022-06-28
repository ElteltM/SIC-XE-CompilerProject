using System;

public class instruction
{
    String obNumber;
    int form;
    String location;
    String label;
    String operand;


    public instruction(String Mnemonic, String lbl)
    {
        switch (Mnemonic)
        {
            case "ADD": this.obNumber = "18"; this.form = 3; this.label = lbl;
                break;
            case "+ADD": this.obNumber = "18"; this.form = 4; this.label = lbl;
                break;
            case "$ADD": this.obNumber = "18"; this.form = 5; this.label = lbl;
                break;

            case "ADDF": this.obNumber = "58"; this.form = 3; this.label = lbl;
                break;
            case "+ADDF": this.obNumber = "58"; this.form = 4; this.label = lbl;
                break;
            case "$ADDF": this.obNumber = "58"; this.form = 5; this.label = lbl;
                break;

            case "AND": this.obNumber = "40"; this.form = 3; this.label = lbl;
                break;
            case "+AND": this.obNumber = "40"; this.form = 4; this.label = lbl;
                break;
            case "$AND": this.obNumber = "40"; this.form = 5; this.label = lbl;
                break;

            case "COMP": this.obNumber = "28"; this.form = 3; this.label = lbl;
                break;
            case "+COMP": this.obNumber = "28"; this.form = 4; this.label = lbl;
                break;
            case "$COMP": this.obNumber = "28"; this.form = 5; this.label = lbl;
                break;

            case "COMPF": this.obNumber = "88"; this.form = 3; this.label = lbl;
                break;
            case "+COMPF": this.obNumber = "88"; this.form = 4; this.label = lbl;
                break;
            case "$COMPF": this.obNumber = "88"; this.form = 5; this.label = lbl;
                break;

            case "DIV": this.obNumber = "24"; this.form = 3; this.label = lbl;
                break;
            case "+DIV": this.obNumber = "24"; this.form = 4; this.label = lbl;
                break;
            case "$DIV": this.obNumber = "24"; this.form = 5; this.label = lbl;
                break;

            case "DIVF": this.obNumber = "64"; this.form = 3; this.label = lbl;
                break;
            case "+DIVF": this.obNumber = "64"; this.form = 4; this.label = lbl;
                break;
            case "$DIVF": this.obNumber = "64"; this.form = 5; this.label = lbl;
                break;

            case "J": this.obNumber = "3C"; this.form = 3; this.label = lbl;
                break;
            case "+J": this.obNumber = "3C"; this.form = 4; this.label = lbl;
                break;
            case "$J": this.obNumber = "3C"; this.form = 5; this.label = lbl;
                break;

            case "JEQ": this.obNumber = "30"; this.form = 3; this.label = lbl;
                break;
            case "+JEQ": this.obNumber = "30"; this.form = 4; this.label = lbl;
                break;
            case "$JEQ": this.obNumber = "30"; this.form = 5; this.label = lbl;
                break;

            case "JGT": this.obNumber = "34"; this.form = 3; this.label = lbl;
                break;
            case "+JGT": this.obNumber = "34"; this.form = 4; this.label = lbl;
                break;
            case "$JGT": this.obNumber = "34"; this.form = 5; this.label = lbl;
                break;

            case "JLT": this.obNumber = "38"; this.form = 3; this.label = lbl;
                break;
            case "+JLT": this.obNumber = "38"; this.form = 4; this.label = lbl;
                break;
            case "$JLT": this.obNumber = "38"; this.form = 5; this.label = lbl;
                break;

            case "JSUB": this.obNumber = "48"; this.form = 3; this.label = lbl;
                break;
            case "+JSUB": this.obNumber = "48"; this.form = 4; this.label = lbl;
                break;
            case "$JSUB": this.obNumber = "48"; this.form = 5; this.label = lbl;
                break;

            case "LDA": this.obNumber = "00"; this.form = 3; this.label = lbl;
                break;
            case "+LDA": this.obNumber = "00"; this.form = 4; this.label = lbl;
                break;
            case "$LDA": this.obNumber = "00"; this.form = 5; this.label = lbl;
                break;

            case "LDB": this.obNumber = "68"; this.form = 3; this.label = lbl;
                break;
            case "+LDB": this.obNumber = "68"; this.form = 4; this.label = lbl;
                break;
            case "$LDB": this.obNumber = "68"; this.form = 5; this.label = lbl;
                break;

            case "LDCH": this.obNumber = "50"; this.form = 3; this.label = lbl;
                break;
            case "+LDCH": this.obNumber = "50"; this.form = 4; this.label = lbl;
                break;
            case "$LDCH": this.obNumber = "50"; this.form = 5; this.label = lbl;
                break;

            case "LDF": this.obNumber = "70"; this.form = 3; this.label = lbl;
                break;
            case "+LDF": this.obNumber = "70"; this.form = 4; this.label = lbl;
                break;
            case "$LDF": this.obNumber = "70"; this.form = 5; this.label = lbl;
                break;

            case "LDL": this.obNumber = "08"; this.form = 3; this.label = lbl;
                break;
            case "+LDL": this.obNumber = "08"; this.form = 4; this.label = lbl;
                break;
            case "$LDL": this.obNumber = "08"; this.form = 5; this.label = lbl;
                break;

            case "LDS": this.obNumber = "6C"; this.form = 3; this.label = lbl;
                break;
            case "+LDS": this.obNumber = "6C"; this.form = 4; this.label = lbl;
                break;
            case "$LDS": this.obNumber = "6C"; this.form = 5; this.label = lbl;
                break;

            case "LDT": this.obNumber = "74"; this.form = 3; this.label = lbl;
                break;
            case "+LDT": this.obNumber = "74"; this.form = 4; this.label = lbl;
                break;
            case "$LDT": this.obNumber = "74"; this.form = 5; this.label = lbl;
                break;

            case "LDX": this.obNumber = "04"; this.form = 3; this.label = lbl;
                break;
            case "+LDX": this.obNumber = "04"; this.form = 4; this.label = lbl;
                break;
            case "$LDX": this.obNumber = "04"; this.form = 5; this.label = lbl;
                break;

            case "LPS": this.obNumber = "D0"; this.form = 3; this.label = lbl;
                break;
            case "+LPS": this.obNumber = "D0"; this.form = 4; this.label = lbl;
                break;
            case "$LPS": this.obNumber = "D0"; this.form = 5; this.label = lbl;
                break;

            case "MUL": this.obNumber = "20"; this.form = 3; this.label = lbl;
                break;
            case "+MUL": this.obNumber = "20"; this.form = 4; this.label = lbl;
                break;
            case "$MUL": this.obNumber = "20"; this.form = 5; this.label = lbl;
                break;

            case "OR": this.obNumber = "44"; this.form = 3; this.label = lbl;
                break;
            case "+OR": this.obNumber = "44"; this.form = 4; this.label = lbl;
                break;
            case "$OR": this.obNumber = "44"; this.form = 5; this.label = lbl;
                break;

            case "RD": this.obNumber = "D8"; this.form = 3; this.label = lbl;
                break;
            case "+RD": this.obNumber = "D8"; this.form = 4; this.label = lbl;
                break;
            case "$RD": this.obNumber = "D8"; this.form = 5; this.label = lbl;
                break;

            case "RSUB": this.obNumber = "4C"; this.form = 3; this.label = lbl;
                break;
            case "+RSUB": this.obNumber = "4C"; this.form = 4; this.label = lbl;
                break;
            case "$RSUB": this.obNumber = "4C"; this.form = 5; this.label = lbl;
                break;

            case "STA": this.obNumber = "0C"; this.form = 3; this.label = lbl;
                break;
            case "+STA": this.obNumber = "0C"; this.form = 4; this.label = lbl;
                break;
            case "$STA": this.obNumber = "0C"; this.form = 5; this.label = lbl;
                break;

            case "STCH": this.obNumber = "54"; this.form = 3; this.label = lbl;
                break;
            case "+STCH": this.obNumber = "54"; this.form = 4; this.label = lbl;
                break;
            case "$STCH": this.obNumber = "54"; this.form = 5; this.label = lbl;
                break;

            case "STB": this.obNumber = "78"; this.form = 3; this.label = lbl;
                break;
            case "+STB": this.obNumber = "78"; this.form = 4; this.label = lbl;
                break;
            case "$STB": this.obNumber = "78"; this.form = 5; this.label = lbl;
                break;

            case "STF": this.obNumber = "80"; this.form = 3; this.label = lbl;
                break;
            case "+STF": this.obNumber = "80"; this.form = 4; this.label = lbl;
                break;
            case "$STF": this.obNumber = "80"; this.form = 5; this.label = lbl;
                break;

            case "STL": this.obNumber = "14"; this.form = 3; this.label = lbl;
                break;
            case "+STL": this.obNumber = "14"; this.form = 4; this.label = lbl;
                break;
            case "$STL": this.obNumber = "14"; this.form = 5; this.label = lbl;
                break;

            case "STSW": this.obNumber = "E8"; this.form = 3; this.label = lbl;
                break;
            case "+STSW": this.obNumber = "E8"; this.form = 4; this.label = lbl;
                break;
            case "$STSW": this.obNumber = "E8"; this.form = 5; this.label = lbl;
                break;

            case "STX": this.obNumber = "10"; this.form = 3; this.label = lbl;
                break;
            case "+STX": this.obNumber = "10"; this.form = 4; this.label = lbl;
                break;
            case "$STX": this.obNumber = "10"; this.form = 5; this.label = lbl;
                break;

            case "SUB": this.obNumber = "1C"; this.form = 3; this.label = lbl;
                break;
            case "+SUB": this.obNumber = "1C"; this.form = 4; this.label = lbl;
                break;
            case "$SUB": this.obNumber = "1C"; this.form = 5; this.label = lbl;
                break;

            case "TD": this.obNumber = "E0"; this.form = 3; this.label = lbl;
                break;
            case "+TD": this.obNumber = "E0"; this.form = 4; this.label = lbl;
                break;
            case "$TD": this.obNumber = "E0"; this.form = 5; this.label = lbl;
                break;

            case "TIX": this.obNumber = "2C"; this.form = 3; this.label = lbl;
                break;
            case "+TIX": this.obNumber = "2C"; this.form = 4; this.label = lbl;
                break;
            case "$TIX": this.obNumber = "2C"; this.form = 5; this.label = lbl;
                break;

            case "WD": this.obNumber = "DC"; this.form = 3; this.label = lbl;
                break;
            case "+WD": this.obNumber = "DC"; this.form = 4; this.label = lbl;
                break;
            case "$WD": this.obNumber = "DC"; this.form = 5; this.label = lbl;
                break;

            case "BYTE": this.obNumber = ""; this.form = 1; this.label = lbl;
                break;
            case "RESB": this.obNumber = ""; this.form = 1; this.label = lbl;
                break;
            case "RESW": this.obNumber = "No Object Code"; this.label = lbl; this.form = 3;
                break;
            case "WORD": this.obNumber = ""; this.form = 3; this.label = lbl;
                break;
            case "START": this.obNumber = ""; this.form = 0; this.label = lbl;
                break;
            case "END": this.obNumber = ""; this.form = 0; this.label = lbl;
                break;

            case "BASE": this.obNumber = "No OB CODE "; this.form = 0; this.label = lbl;
                break;
            
                //Format 2 instructions
            case "COMPR": this.obNumber = "A0"; this.form = 2; this.label = lbl;
                break;
            case "ADDR": this.obNumber = "90"; this.form = 2; this.label = lbl;
                break;
            case "CLEAR": this.obNumber = "4"; this.form = 2; this.label = lbl;
                break;
            case "DIVR": this.obNumber = "9C"; this.form = 2; this.label = lbl;
                break;
            case "MULR": this.obNumber = "98"; this.form = 2; this.label = lbl;
                break;
            case "RMO": this.obNumber = "AC"; this.form = 2; this.label = lbl;
                break;
            case "SUBR": this.obNumber = "94"; this.form = 2; this.label = lbl;
                break;
            case "TIXR": this.obNumber = "B8"; this.form = 2; this.label = lbl;
                break;
            case "RESDW": this.obNumber = "NO Obj Code"; this.form = 6; this.label = lbl;
                break;


            default: Console.WriteLine("Wrong instruction given");
                break;
        }
    }

    public String getObNumber()
    {
        return obNumber;
    }
    public int getFormat()
    {
        return form;
    }
}
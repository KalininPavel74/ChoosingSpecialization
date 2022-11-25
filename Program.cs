// Добавление элемента в конец входного массива.
String[] addElementToArray(String[] arInput, String temp) {
    if(arInput == null) arInput = new String[0];
    String[] arResult = new String[arInput.Length + 1];
    for(int i=0; i<arInput.Length; i++)
        arResult[i] = arInput[i];
    arResult[arInput.Length] = temp;
    return arResult;
}

// Преобразование массива в строку в виде массива.
String ArrayToString(String[] ar) {
    if(ar == null) ar = new String[0];
    String s = "";
    for(int i=0; i<ar.Length; i++) 
        s += "\""+ar[i]+"\", ";
    s = s.Substring(0,s.Length-2);
    s = "[" + s + "]";     
    return s;
}

String sInput = "";
String sOutput = "";
String[] arInput  = null;
String[] arOutput = null;

Console.WriteLine("Формат массива строк:"
   + " 1) разделитель строк - запятая; 2) пробел - часть строки."
   +" Например: abc,1234 ,:=),\"1 , ,,c d,   ");
Console.WriteLine("Введите массив строк:");
// Принять входной массив строк.
sInput = Console.ReadLine() ?? "";
// Тестовая строка.
//sInput =" abc,1234 ,:=),\"1 , ,,c d,   ";

if(sInput != "") {
    // Получить массив строк разделив по запятым.
    //String[] arInput = sInput.Split(",");
    // через массивы
    String temp = "";
    bool isSingleElement = true;
    for(int i=0; i<sInput.Length; i++) {
        if(sInput[i]==',') {
            isSingleElement = false;
            arInput = addElementToArray(arInput, temp);
            temp = "";
        } else temp += sInput[i];
    }
    if(isSingleElement) arInput = new String[]{temp};
    else arInput = addElementToArray(arInput, temp);
    //Console.WriteLine($"Входной массив:\n[\"{String.Join(",",arInput).Replace(",","\", \"")}\"]");
    // через массивы
    Console.WriteLine($"Входной массив:\n{ArrayToString(arInput)}");

    int lenArrayNoMore3Char = 0;
    for(int i=0; i<arInput.Length; i++) {
        // Определить кол-во строк требуемой длинны.
        // Остальные обнулить, для последующей фильтрации. 
        if (arInput[i].Length<=3) lenArrayNoMore3Char++;
        else arInput[i] = null;   
    }    
    if(lenArrayNoMore3Char != 0) {
        arOutput = new String[lenArrayNoMore3Char];
        // Заполнить новый массив.
        for(int i=0, j=0; i<arInput.Length; i++) 
            if (arInput[i] != null) arOutput[j++] = arInput[i];
        // Преобразовать массив строк в строку.
        //sOutput = "[\"" + String.Join(",",arOutput).Replace(",","\", \"") + "\"]"; 
        // через массивы
        sOutput = ArrayToString(arOutput);
    }    
} else Console.WriteLine($"Входной массив:\n[]");

// Вывести результат.
Console.WriteLine($"Выходной массив:");
if(arOutput == null || arOutput.Length == 0) Console.Write("[]");
else Console.Write(sOutput);
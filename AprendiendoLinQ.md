# Aprendiendo System.Linq

### Antes de aprender LinQ se debe tener presente tener conocimientos previos de:

- [x] **Iteradores**
- [x] **Colecciones**
- [x] **Genéricos**
- [x] **Interfaces**
- [x] **Otros conceptos avanzados** 

LINQ es un acrónimo de Language Integrated Query. LINQ se introduce en .NET 3.5. Antes de LINQ, los desarrolladores necesitan usar diferentes idiomas para recuperar y guardar diferentes fuentes de datos. Por ejemplo, si desea recuperar datos de SQL o de la base de datos Oracle, debe aprender algunos conceptos básicos del lenguaje de consulta SQL, y para recuperar datos de archivos XML necesita aprender analizadores XML.

LINQ proporciona un lenguaje de consulta unificado para consultar diferentes fuentes de datos. Puede recuperar y guardar datos en la base de datos SQL / Oracle con exactamente el mismo código. Además, LINQ proporciona métodos de extensión que nos ayudan a escribir consultas en línea sobre objetos escritos para filtrar, agrupar y unir resultados.

[LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/getting-started-with-linq) es una biblioteca utilizada para ejecutar consultas directamente en la sintaxis de C # contra muchos tipos de datos. Se implementa como un conjunto de **métodos** de **extensión** de la interfaz `IEnumerable<T>`.

**Variaciones de LINQ**

- LINQ a objetos
- LINQ a SQL
- LINQ a XML
- LINQ a Entidades

**Ventajas de LINQ**

- LINQ ayuda a escribir consultas más rápidas, lo que ayuda a un desarrollo más rápido.
- Las consultas LINQ son más fáciles de depurar.
- Permitir la misma sintaxis de consulta para diferentes fuentes de datos.
- Verificación de tipos en tiempo de compilación y composición dinámica de consultas.
- LINQ es extensible y le permite crear proveedores de consultas para cualquier fuente de datos nueva.

Comandos de instalación:

NuGet

```
Install-Package System.Linq -Version 4.3.0
```

NET CLI

```
dotnet add package System.Linq --version 4.3.0
```

**Antes de comenzar a aprender el lenguaje LINQ, debemos aprender algunos conocimientos básicos de los conceptos más utilizados en LINQ.**

## Sequence - Secuencia

Una secuencia es cualquier objeto de colección que implementa la interfaz IEnumerable <>. Las consultas LINQ solo funcionan con las secuencias.

```c#
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ListaDePaises = new List<string>();
            ListaDePaises.Add("Venezuela");
            ListaDePaises.Add("USA");
            ListaDePaises.Add("Colombia");

            foreach (var i in ListaDePaises)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
```

Resultado:

- Venezuela
- USA
- Colombia

En el ejemplo anterior, una List <string> ha implementado la interfaz IEnumerable y los países son la secuencia.

## Element - Elemento

Una secuencia está compuesta por dos objetos, entonces esta secuencia tiene dos elementos.

Como se muestra en el ejemplo anterior, cada cadena de país en la variable de países anterior es un elemento.

## Query Operators - Operadores de consultas

Los operadores de consulta son funciones que transforman una secuencia. La secuencia se pasa al operador de consulta como un parámetro de entrada. Como resultado, el operador de consulta cambia el elemento de secuencia y devuelve un resultado.

Por ejemplo, hay un operador de consulta "Where" en LINQ que toma una secuencia de entrada y un predicado para filtrar los elementos. Como salida, devuelve solo aquellos elementos en una secuencia que tienen una condición de filtro coincidente.

## Extension Methods - Métodos de extensión

Todo el lenguaje LINQ está basado en métodos de extensión. Los métodos de extensión son métodos estáticos de una clase estática que se pueden invocar como un método de instancia. Estos métodos son útiles cuando tenemos que agregar nuevos comportamientos a una clase existente sin modificar la clase base.

```c#
class Program
{
    static void Main(string[] args)
    {
        string name = "Kapil";
 
        name = name.AddComma();
 
        Console.WriteLine(name); //Print Kapil,
    }
}
 
static class StringExtensionMethods
{
    public static string AddComma(this string input)
    {
        return input + ",";
    }
}
```

No podemos introducir nuevos métodos en la clase de cadena, ya que no podemos cambiar el código fuente de la clase de cadena. Así que creamos un nuevo método de extensión basado en la clase de cadena.

Primero declaramos una clase estática StringExtensionMethods y declaramos un método AddComma. Este primer parámetro del método debe comenzar con **this** y **escribir el nombre** en el que deseamos agregar un nuevo método.

En el ejemplo anterior, la variable de nombre de cadena tiene ahora un nuevo nombre de método AddComma que agrega "," al final de la cadena.

## [Métodos de extensión (Guía de programación de C#)](https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

Los métodos de extensión permiten "agregar" métodos a los tipos existentes sin crear un nuevo tipo derivado, recompilar o modificar de otra manera el tipo original. Los métodos de extensión son una clase especial de método estático, pero se les llama como si fueran métodos de instancia en el tipo extendido. En el caso del código de cliente escrito en C#, F# y Visual Basic, no existe ninguna diferencia aparente entre llamar a un método de extensión y llamar a los métodos realmente definidos en un tipo.

Los métodos de extensión más comunes son los operadores de consulta LINQ estándar, que agregan funciones de consulta a los tipos System.Collections.IEnumerable y System.Collections.Generic.IEnumerable<T> existentes. Para usar los operadores de consulta estándar, inclúyalos primero en el ámbito con una directiva using System.Linq. A partir de ese momento, cualquier tipo que implemente IEnumerable<T> parecerá tener métodos de instancia como GroupBy, OrderBy, Average, etc. Puede ver estos métodos adicionales en la finalización de instrucciones de IntelliSense al escribir "." Punto después de una instancia de un tipo IEnumerable<T>, como List<T> o Array. 

En el ejemplo siguiente se muestra cómo llamar al método OrderBy de operador de consulta estándar en una matriz de enteros. La expresión entre paréntesis es una expresión lambda. Muchos operadores de consulta estándar toman expresiones lambda como parámetros, pero no es un requisito para los métodos de extensión. Para obtener más información, vea Expresiones lambda.

```c#
class ExtensionMethods2    
{
    
    static void Main()
    {            
        int[] ints = { 10, 45, 15, 39, 21, 26 };
        var result = ints.OrderBy(g => g);
        foreach (var i in result)
        {
            System.Console.Write(i + " ");
        }           
    }        
}
//Output: 10 15 21 26 39 45
```

Los métodos de extensión se definen como métodos estáticos, pero se les llama usando la sintaxis de método de instancia. El primer parámetro especifica en qué tipo funciona el método, y el parámetro está precedido del modificador [this](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/this). Los métodos de extensión únicamente se encuentran dentro del ámbito cuando el espacio de nombres se importa explícitamente en el código fuente con una directiva `using`.

## Anonymous Types - Tipos anónimos

Los tipos anónimos son clases temporales que son útiles para almacenar resultados intermedios. Estos tipos no tiene todas las características de los tipos regulares. A continuación se presentan las restricciones en los tipos anónimos.

- Los tipos anónimos solo pueden contener campos públicos.
- Los campos de tipos anónimos deben ser inicializados.
- Los tipos anónimos no pueden especificar ningún método.
- Los tipos anónimos no pueden implementar interfaz o clase abstracta.

```c#
var var1 = new { FirstName = "Kapil", LastName = "Malhotra" };
 
Console.WriteLine(var1.FirstName + " " + var1.LastName); //Print Kapil Malhotra
```

En el ejemplo anterior, hemos creado un tipo anónimo que tiene dos campos públicos, Nombre y Apellido. No hemos especificado ningún nombre de clase después de la nueva palabra clave. Este nuevo tipo anónimo tiene solo dos propiedades y ningún método.

## Delegates - Delegados

Los delegados nos permiten almacenar una referencia de funciones que se pueden ejecutar en el momento adecuado. En el delegado solo podemos almacenar aquellas funciones que tienen parámetros coincidentes y tipos de retorno.

Por ejemplo, si declaramos un delegado que acepta un parámetro int y devuelve el resultado de la cadena. Luego, en ese delegado solo podemos asignar una referencia a aquellas funciones que toman int como un solo parámetro y devuelven el resultado de la cadena.

```c#
class Program
{
    delegate int CalcSum(int a, int b);
 
    static void Main(string[] args)
    {
        CalcSum sumFunctions = Sum;
        int result = Sum(4,5);
        Console.WriteLine(result); //Print 9;
 
        sumFunctions = WrongSumFunction; //Gives Error at compile time
    }
 
    static int Sum(int a, int b)
    {
        return a + b;
    }
 
    static int WrongSumFunction(int a)
    {
        return a + a;
    }
}
```

En el ejemplo anterior, declaramos un delegado simple CalcSum que toma dos parámetros int y devuelve el resultado int.

Declaramos dos funciones Suma y WrongSumFunction. Solo la función Suma tiene dos parámetros int y devuelve el resultado. Podemos asignar fácilmente este método a la instancia CalcSum. La segunda función WrongSumFunction toma solo un parámetro y devuelve los resultados int. Debido a que WrongSumFunction solo tiene un parámetro int, no podemos asignar ese método a la instancia del delegado CalcSum como se muestra en el ejemplo anterior y da un error en el momento de la compilación.

Al aprender LINQ, es importante tener un buen entendimiento de los delegados en C #. Muchas de las capacidades más poderosas de LINQ hacen uso de delegados.

Los delegados de C # son similares a los punteros a las funciones, en C o C ++. Un **delegado** es una variable de tipo de referencia que contiene la referencia a un método. La referencia se puede cambiar en tiempo de ejecución.

Los delegados se utilizan especialmente para implementar eventos y los métodos de devolución de llamada. Todos los delegados se derivan implícitamente de la clase **System.Delegate** 

La declaración del delegado determina los métodos a los que puede hacer referencia el delegado. Un delegado puede referirse a un método, que tiene la misma firma que la del delegado.

Por ejemplo, considere un delegado -

```c#
public delegate int MyDelegate (string s);
```

El delegado anterior se puede usar para hacer referencia a cualquier método que tenga un solo parámetro de *cadena* y devuelva una variable de tipo *int* .

La sintaxis para la declaración de delegado es -

```c#
delegate <return type> <delegate-name> <parameter list>
```

## Creando delegados

Una vez que se declara un tipo de delegado, se debe crear un objeto delegado con la **nueva** palabra clave y asociarse con un método en particular. Al crear un delegado, el argumento pasado a la **nueva** expresión se escribe de forma similar a una llamada de método, pero sin los argumentos del método. Por ejemplo

El siguiente ejemplo demuestra la declaración, la creación de instancias y el uso de un delegado que se puede usar para hacer referencia a métodos que toman un parámetro entero y devuelven un valor entero.



```c#
public delegate void printString(string s);
...
printString ps1 = new printString("WriteToScreen");
printString ps2 = new printString("WriteToFile"");	
```

Un delegado es simplemente una referencia a un método. Los delegados pueden almacenarse y pasarse en una variable, y por lo tanto deben tener una definición de tipo:

```c#
private delegate int FuncTwoInts(int one, int two);
```

La línea de arriba define el tipo `FuncTwoInts`. El tipo `FuncTwoInts` es una referencia a un método que toma dos parámetros de tipo `int`y devuelve un solo `int`resultado.

Otro Ejemplo:

```c#
using System;

namespace ConsoleApp
{
    public delegate void MiDelegado(string x);
    public class ClaseA
    {
        public static void MetodoClaseA(string mensajeA)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Estamos en la clase A");
            Console.WriteLine("Esto es un mensaje {0}", mensajeA);
        }
    }

    public class ClaseB
    {
        public static void MetodoClaseB(string mensajeB)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Estamos en la clase B");
            Console.WriteLine("Esto es un mensaje {0}", mensajeB);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado delegado = new MiDelegado(ClaseA.MetodoClaseA);
            delegado("Hello World");

            delegado = new MiDelegado(ClaseB.MetodoClaseB);
            delegado("Good Bye");
            Console.ReadKey();
        }
    }
}
```

## Anonymous Methods - Métodos anónimos 

Es un método en línea que solo tiene cuerpo sin nombre. Solo podemos definir parámetros y tipos de retorno de los métodos.

A continuación se muestra un ejemplo de Método Anónimo.

```c#
class Program
{
    delegate int MyDelegate(int x, int y);
    static void Main(string[] args)
    {
        MyDelegate multiplyMethod = delegate(int x, int y)
        {
            return x * y;
        };
 
        int result = multiplyMethod(2, 4);
        Console.WriteLine(result); //Print 8
    }
}
```

En el ejemplo anterior, creamos un delegado y le asignamos un método en línea sin nombre. El método debe tener el mismo número de parámetros y el mismo tipo que coincidir con el tipo de delegado.

## Action<T> delegate  - Delegado de acción 

Es un delegado predefinido de .NET framework que solo toma parámetros y no devuelve ningún valor. Podemos especificar un máximo de 16 parámetros en el delegado de acción

```c#
Action<int, int> Multipler = delegate(int x, int y)
{
    Console.WriteLine(x * y);
};
Multipler(4, 5);    // Print 20
```

## Predicate delegate - Delegado Predicado 

Delegado Predicado es un delegado que toma solo un solo parámetro y devuelve un valor bool.

```c#
static void Main(string[] args)
{
    Predicate<string> hasValueK = delegate(string par)
    {
        return par.Contains("K");
    };
    bool result1 = hasValueK("Kapil");
    bool result2 = hasValueK("Malhotra");
 
    Console.WriteLine(result1); // Print true
    Console.WriteLine(result2); // Print false
}
```

En el ejemplo anterior, especificamos un delegado de predicado hasValueK que toma solo un parámetro de cadena y devuelve el resultado booleano.

## Func <> delegate - El delegado funcional

 También es un delegado genérico proporcionado por .NET framework. En el delegado funcional podemos especificar 16 parámetros y un tipo de retorno

```c#
static void Main(string[] args)
{
    Func<int,int, int> multiplier = delegate(int a, int b)
    {
        return a * b;
    };
    int result = multiplier(2, 9);
 
    Console.WriteLine(result); // Print 18
}
```

En el ejemplo anterior, especificamos un delegado Func <int, int, int>. El último int es un tipo de resultado y los dos primeros int son tipos de parámetros.

## Lambda Expressions - Expresiones lambda

Lambda Expressions es solo un método abreviado para escribir métodos anónimos. => es un operador lambda. A la izquierda del operador lambda especificamos los parámetros de entrada y en el lado derecho escribimos el cuerpo del método.

```c#
delegate int MultiplierDelegate(int a, int b);
static void Main(string[] args)
{
 
    MultiplierDelegate multiplier = (a, b) => a * b;
    int result = multiplier(2, 9);
 
    Console.WriteLine(result); // Print 18

```

oooooooooooooooooooooooooooo

# Iteradores 

Un *iterador* puede usarse para recorrer colecciones como listas y matrices.

Un método iterador o un descriptor de acceso `get` realiza una iteración personalizada en una colección. Un iterador usa la instrucción [yield return](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/yield) para devolver cada elemento de uno en uno. Cuando se alcanza una instrucción `yield return`, se recuerda la ubicación actual en el código. La ejecución se reinicia desde esa ubicación la próxima vez que se llama a la función del iterador.

Para consumir un método iterador desde código de cliente, use una instrucción [foreach](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/foreach-in) o una consulta de LINQ.

En el ejemplo siguiente, la primera iteración del bucle `foreach` hace que continúe la ejecución del método de iterador `SomeNumbers` hasta que se alcance la primera instrucción `yield return`. Esta iteración devuelve un valor de 3, y la ubicación actual del método de iterador se conserva. En la siguiente iteración del bucle, la ejecución del método iterador continúa desde donde se dejó, deteniéndose de nuevo al alcanzar una instrucción `yield return`. Esta iteración devuelve un valor de 5, y la ubicación actual del método de iterador se vuelve a conservar. El bucle se completa al alcanzar el final del método iterador.

```c#
static void Main()
{
    foreach (int number in SomeNumbers())
    {
        Console.Write(number.ToString() + " ");
    }
    // Output: 3 5 8
    Console.ReadKey();
}

public static System.Collections.IEnumerable SomeNumbers()
{
    yield return 3;
    yield return 5;
    yield return 8;
}
```

El tipo de valor devuelto de un método de iterador o descriptor de acceso `get`puede ser [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerable), [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerable-1), [IEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerator) o [IEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerator-1).

Puede usar una instrucción `yield break` para finalizar la iteración.

## Iterador simple

El ejemplo siguiente tiene una única instrucción `yield return` que está dentro de un bucle [for](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/for). En `Main`, cada iteración del cuerpo de la instrucción `foreach` crea una llamada a la función de iterador, que continúa a la instrucción `yield return`siguiente.

```c#
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            foreach (int number in RangoNumerosPares(1, 10))
            {
                Console.WriteLine("Numeros Pares del 1 al 10: " + number.ToString() + " ");
            }
            // Output: 6 8 10 12 14 16 18
            Console.ReadKey();
        }
		//public static System.Collections.Generic.IEnumerable<int> RangoNumerosPares(int A, int B)
        public static IEnumerable<int> RangoNumerosPares(int A, int B)
        {
            // Yield even numbers in the range.
            for (int number = A; number <= B; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }
    }
}

```

## Creación de una clase de colección

En el ejemplo siguiente, la clase `DiasDeLaSemana` implementa la interfaz [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerable), que requiere un método [GetEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerable.getenumerator). El compilador llama implícitamente al método `GetEnumerator`, que devuelve un [IEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerator).

El método `GetEnumerator` devuelve las cadenas de una en una mediante la instrucción `yield return`.

```c#
using System;
using System.Collections;

namespace ConsoleApp
{
    public class DiasDeLaSemana : IEnumerable
    {
        private string[] ObjetoDias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
        // Implementando Metodo de la interfaz ' IEnumerator GetEnumerator() '
        public IEnumerator GetEnumerator()
        {
            // Resumen:
            // Devuelve un enumerador que itera a través de una colección.
            //
            // Devoluciones:
            // Un objeto System.Collections.IEnumerator que se puede usar para iterar a través de
            //     la colección.
            // IEnumerator GetEnumerator();
            for (int index = 0; index < ObjetoDias.Length; index++)
            {
                // Cede cada día de la semana.
                yield return ObjetoDias[index];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DiasDeLaSemana dias = new DiasDeLaSemana();

            foreach (string i in dias)
            {
                Console.Write(i + " ");
            }
            // Output: Sun Mon Tue Wed Thu Fri Sat
            Console.ReadKey();
        }
    }

}
```

En el ejemplo siguiente se crea una clase `Zoo` que contiene una colección de animales.

La instrucción `foreach` que hace referencia a la instancia de clase (`theZoo`) llama implícitamente al método `GetEnumerator`. Las instrucciones `foreach` que hacen referencia a las propiedades `Birds` y `Mammals` usan el método iterador con el nombre `AnimalsForType`.

```c#
static void Main()
{
    Zoo theZoo = new Zoo();

    theZoo.AddMammal("Whale");
    theZoo.AddMammal("Rhinoceros");
    theZoo.AddBird("Penguin");
    theZoo.AddBird("Warbler");

    foreach (string name in theZoo)
    {
        Console.Write(name + " ");
    }
    Console.WriteLine();
    // Output: Whale Rhinoceros Penguin Warbler

    foreach (string name in theZoo.Birds)
    {
        Console.Write(name + " ");
    }
    Console.WriteLine();
    // Output: Penguin Warbler

    foreach (string name in theZoo.Mammals)
    {
        Console.Write(name + " ");
    }
    Console.WriteLine();
    // Output: Whale Rhinoceros

    Console.ReadKey();
}

public class Zoo : IEnumerable
{
    // Private members.
    private List<Animal> animals = new List<Animal>();

    // Public methods.
    public void AddMammal(string name)
    {
        animals.Add(new Animal { Name = name, Type = Animal.TypeEnum.Mammal });
    }

    public void AddBird(string name)
    {
        animals.Add(new Animal { Name = name, Type = Animal.TypeEnum.Bird });
    }

    public IEnumerator GetEnumerator()
    {
        foreach (Animal theAnimal in animals)
        {
            yield return theAnimal.Name;
        }
    }

    // Public members.
    public IEnumerable Mammals
    {
        get { return AnimalsForType(Animal.TypeEnum.Mammal); }
    }

    public IEnumerable Birds
    {
        get { return AnimalsForType(Animal.TypeEnum.Bird); }
    }

    // Private methods.
    private IEnumerable AnimalsForType(Animal.TypeEnum type)
    {
        foreach (Animal theAnimal in animals)
        {
            if (theAnimal.Type == type)
            {
                yield return theAnimal.Name;
            }
        }
    }

    // Private class.
    private class Animal
    {
        public enum TypeEnum { Bird, Mammal }

        public string Name { get; set; }
        public TypeEnum Type { get; set; }
    }
}
```

## Uso de iteradores con una lista genérica

En el ejemplo siguiente, la clase genérica [Stack](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.stack-1) implementa la interfaz genérica [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerable-1). El método [Push](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.stack-1.push) asigna valores a una matriz de tipo `T`. El método [GetEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerable-1.getenumerator) devuelve los valores de la matriz con la instrucción `yield return`.

Además del método [GetEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerable-1.getenumerator) genérico, el método [GetEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerable.getenumerator) no genérico también debe implementarse. Esto es porque [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerable-1) se hereda de [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerable). La implementación no genérica aplaza la implementación genérica.

El ejemplo usa iteradores con nombre para admitir distintas formas de recorrer en iteración la misma colección de datos. Estos iteradores con nombre son las propiedades `TopToBottom` y `BottomToTop`, y el método `TopN`.

La propiedad `BottomToTop` usa un iterador en un descriptor de acceso `get`.

```c#
static void Main()
{
    Stack<int> theStack = new Stack<int>();

    //  Add items to the stack.
    for (int number = 0; number <= 9; number++)
    {
        theStack.Push(number);
    }

    // Retrieve items from the stack.
    // foreach is allowed because theStack implements IEnumerable<int>.
    foreach (int number in theStack)
    {
        Console.Write("{0} ", number);
    }
    Console.WriteLine();
    // Output: 9 8 7 6 5 4 3 2 1 0

    // foreach is allowed, because theStack.TopToBottom returns IEnumerable(Of Integer).
    foreach (int number in theStack.TopToBottom)
    {
        Console.Write("{0} ", number);
    }
    Console.WriteLine();
    // Output: 9 8 7 6 5 4 3 2 1 0

    foreach (int number in theStack.BottomToTop)
    {
        Console.Write("{0} ", number);
    }
    Console.WriteLine();
    // Output: 0 1 2 3 4 5 6 7 8 9

    foreach (int number in theStack.TopN(7))
    {
        Console.Write("{0} ", number);
    }
    Console.WriteLine();
    // Output: 9 8 7 6 5 4 3

    Console.ReadKey();
}

public class Stack<T> : IEnumerable<T>
{
    private T[] values = new T[100];
    private int top = 0;

    public void Push(T t)
    {
        values[top] = t;
        top++;
    }
    public T Pop()
    {
        top--;
        return values[top];
    }

    // This method implements the GetEnumerator method. It allows
    // an instance of the class to be used in a foreach statement.
    public IEnumerator<T> GetEnumerator()
    {
        for (int index = top - 1; index >= 0; index--)
        {
            yield return values[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> TopToBottom
    {
        get { return this; }
    }

    public IEnumerable<T> BottomToTop
    {
        get
        {
            for (int index = 0; index <= top - 1; index++)
            {
                yield return values[index];
            }
        }
    }

    public IEnumerable<T> TopN(int itemsFromTop)
    {
        // Return less than itemsFromTop if necessary.
        int startIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;

        for (int index = top - 1; index >= startIndex; index--)
        {
            yield return values[index];
        }
    }

}
```

## Información sobre la sintaxis

**Un iterador se puede producir como un método o como un descriptor de acceso** `get`. **Un iterador no puede aparecer en un evento, un constructor de instancia, un constructor estático o un finalizador estático**.

Debe existir una conversión implícita del tipo de expresión en la instrucción `yield return` al argumento de tipo para el IEnumerable<T> devuelto por el iterador.

En C#, un método iterador no puede tener ningún parámetro `in`, `ref` o `out`.

En C#, "yield" no es una palabra reservada y solo tiene un significado especial cuando se usa antes de una palabra clave `return` o `break`.

## Implementación técnica

Aunque un iterador se escribe como un método, el compilador lo traduce a una clase anidada que es, en realidad, una máquina de estados. Esta clase realiza el seguimiento de la posición del iterador mientras el bucle `foreach` continúe en el código de cliente.

Para ver lo que hace el compilador, puede usar la herramienta Ildasm.exe para ver el código de lenguaje intermedio de Microsoft que se genera para un método de iterador.

Cuando crea un iterador para una [clase](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/class) o [struct](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/struct), no necesita implementar la interfaz [IEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerator) completa. Cuando el compilador detecta el iterador, genera automáticamente los métodos `Current`, `MoveNext` y `Dispose` de la interfaz [IEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerator) o [IEnumerator](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerator-1).

En cada iteración sucesiva del bucle `foreach` (o la llamada directa a `IEnumerator.MoveNext`), el cuerpo de código del iterador siguiente se reanuda después de la instrucción `yield return` anterior. Después continúa con la siguiente instrucción `yield return` hasta que se alcanza el final del cuerpo del iterador, o hasta que se encuentra una instrucción `yield break`.

Los iteradores no admiten el método [IEnumerator.Reset](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerator.reset). Para volver a recorrer en iteración desde el principio, se debe obtener un nuevo iterador. Una llamada a [Reset](https://docs.microsoft.com/es-es/dotnet/api/system.collections.ienumerator.reset) en el iterador devuelto por un método de iterador inicia una excepción [NotSupportedException](https://docs.microsoft.com/es-es/dotnet/api/system.notsupportedexception).

Para obtener más información, vea la [Especificación del lenguaje C#](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/language-specification/classes#iterators).

## Uso de iteradores

Los iteradores permiten mantener la simplicidad de un bucle `foreach` cuando se necesita usar código complejo para rellenar una secuencia de lista. Esto puede ser útil si quiere hacer lo siguiente:

- Modificar la secuencia de lista después de la primera iteración del bucle `foreach`.
- Evitar que se cargue totalmente una lista grande antes de la primera iteración de un bucle `foreach`. Un ejemplo es una búsqueda paginada para cargar un lote de filas de tabla. Otro ejemplo es el método [EnumerateFiles](https://docs.microsoft.com/es-es/dotnet/api/system.io.directoryinfo.enumeratefiles), que implementa iteradores en .NET Framework.
- Encapsular la creación de la lista en el iterador. En el método iterador, puede crear la lista y después devolver cada resultado en un bucle.

# Colecciones en C#. Conceptos básicos 

**Para muchas aplicaciones, puede que desee crear y administrar grupos de objetos relacionados. Existen dos formas de agrupar objetos: mediante la creación de matrices de objetos y con la creación de colecciones de objetos**.

Las **matrices** son muy útiles para crear y trabajar con un número fijo de objetos fuertemente tipados.

Puede almacenar varias variables del mismo tipo en una estructura de datos de matriz. Puede declarar una matriz mediante la especificación del tipo de sus elementos.

```c#
type[] arrayName;
```

Los ejemplos siguientes crean matrices unidimensionales, multidimensionales y escalonadas:

```c#
class TestArraysClass
{
    static void Main()
    {
        // Declare a single-dimensional array. 
        int[] array1 = new int[5];

        // Declare and set array element values.
        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        // Alternative syntax.
        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        // Declare a two dimensional array.
        int[,] multiDimensionalArray1 = new int[2, 3];

        // Declare and set array element values.
        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // Declare a jagged array.
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged array structure.
        jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
    }
}
```

Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación. Para algunas colecciones, puede asignar una clave a cualquier objeto que incluya en la colección para, de este modo, recuperar rápidamente el objeto con la clave.

Una colección es una clase, por lo que debe declarar una instancia de la clase para poder agregar elementos a dicha colección.

Si la colección contiene elementos de un solo tipo de datos, puede usar una de las clases del espacio de nombres [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic). Una colección genérica cumple la seguridad de tipos para que ningún otro tipo de datos se pueda agregar a ella. Cuando recupera un elemento de una colección genérica, no tiene que determinar su tipo de datos ni convertirlo.

## Uso de una colección Simple

Los ejemplos de esta sección usan la clase genérica [List](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1) ( [List<T>](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1)), que le permite trabajar con una lista de objetos fuertemente tipados.

En el ejemplo siguiente se crea una lista de cadenas y luego se recorren en iteración mediante una instrucción [foreach](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/foreach-in).

```c#
using System;
using System.Collections.Generic; // Libreria Genericos

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of strings.
            var BancosNacionales = new List<string>();
            BancosNacionales.Add("Banesco");
            BancosNacionales.Add("Venezuela");
            BancosNacionales.Add("Venezolano de Credito");
            BancosNacionales.Add("Vicentenario");
            BancosNacionales.Add("Mercantil");
            BancosNacionales.Add("Del Tesoro");

            // Iterate through the list.
            foreach (var bancos in BancosNacionales)
            {
                Console.Write(bancos + " ");
            }
            //Contador De Elementos en BancosNacionales
            Console.WriteLine(BancosNacionales.Count);
            // Metodo para remover un elemento.
            BancosNacionales.Remove("Banesco");
            BancosNacionales.Remove("Venezuela");
            // Output: Banesco,Venezuela,Venezolano de Credito,Vicentenario,Mercantil,Del Tesoro.
            Console.ReadKey();
        }
    }
}

```

[List<Generic> o List <T>](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1) también permite hacer referencia a elementos individuales a través del **índice**. Coloque el índice entre los tokens `[` y `]` después del nombre de la lista. C# 

```c#
using System;
using System.Collections.Generic; // Libreria Genericos

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ListaDeNombres = new List<string> { "Maria", "Ana", "Pedro" };
                foreach (var nombres in ListaDeNombres)
                {
                    Console.WriteLine($"Hello {nombres.ToUpper()}!");
                }
                Console.WriteLine();

                foreach (var nombre in ListaDeNombres)
                {
                    Console.WriteLine($"Hello {nombre.ToUpper()}!");
                }
                Console.WriteLine($"My name is {ListaDeNombres[0]}");
                Console.WriteLine($"I've added {ListaDeNombres[1]} and {ListaDeNombres[2]} to the list");
            }
            catch (Exception WTF)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Error W4T3FA. por favor contactese con el departamento de sistmas.", WTF);
                //Console.WriteLine(WTF);
                Console.ReadKey();

            }
            Console.ReadKey();
        }
    }
}

```

Recuerde que los índices empiezan en 0, por lo que el índice más grande válido es uno menos que el número de elementos de la lista. 

```c#
var ListaDeEmpresas = new List<string> { "Amazon", "Ebay", "Bibliota.tk" };

var index = ListaDeEmpresas.IndexOf("Amazon");
if (index == -1)
{
    Console.WriteLine($"El Elemento Buscando no se encuentra en la lista. Return: {index}");
}
else
{
    Console.WriteLine($"El Elemento '{ListaDeEmpresas[index]}' su index es: {index}");
}
```

Puede comprobar durante cuánto tiempo la lista usa la propiedad [Count](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1.count). Agregue el código siguiente al final del método Main:

```c#
var ListaDeNombres = new List<string> { "Maria", "Ana", "Pedro" };
int contadorDeNombres = ListaDeNombres.Count;
Console.WriteLine(contadorDeNombres);
```
Si el contenido de una colección se conoce de antemano, puede usar un *inicializador de colección* para inicializar la colección. Para obtener más información, vea [Inicializadores de objeto y colección](https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers).

El ejemplo siguiente es el mismo que el ejemplo anterior, excepto que se usa un inicializador de colección para agregar elementos a la colección.

```c#
// Create a list of strings by using a
// collection initializer.
var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

// Iterate through the list.
foreach (var salmon in salmons)
{
    Console.Write(salmon + " ");
}
// Output: chinook coho pink sockeye
```

Puede usar una instrucción [for](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/for) en lugar de una instrucción `foreach` para recorrer en iteración una colección. Esto se consigue con el acceso a los elementos de la colección mediante la posición de índice. El índice de los elementos comienza en 0 y termina en el número de elementos menos 1.

El ejemplo siguiente recorre en iteración los elementos de una colección mediante `for` en lugar de `foreach`.

```c#
// Create a list of strings by using a
// collection initializer.
var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

for (var index = 0; index < salmons.Count; index++)
{
    Console.Write(salmons[index] + " ");
}
// Output: chinook coho pink sockeye
```

El ejemplo siguiente quita elementos de una lista genérica. En lugar de una instrucción `foreach`, se usa una instrucción [for](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/for) que procesa una iteración en orden descendente. Esto es porque el método [RemoveAt](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1.removeat) hace que los elementos después de un elemento quitado tengan un valor de índice inferior.

```c#
var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Remove odd numbers.
for (var index = numbers.Count - 1; index >= 0; index--)
{
    if (numbers[index] % 2 == 1)
    {
        // Remove the element by specifying
        // the zero-based index in the list.
        numbers.RemoveAt(index);
    }
}

// Iterate through the list.
// A lambda expression is placed in the ForEach method
// of the List(T) object.
numbers.ForEach(
    number => Console.Write(number + " "));
// Output: 0 2 4 6 8
```



## Listas de otros tipos

Hasta el momento, se ha usado el tipo `string` en las listas. Se va a crear una lista [List](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1) con un tipo distinto. 

Para el tipo de elementos de tipo  [List](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1), también puede definir su propia clase. En el ejemplo siguiente, la clase `Empleado` usa [List](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1) 

```c#
using System;
using System.Collections.Generic; // Libreria Genericos

namespace ConsoleApp
{
    class Program
    {
        private static void IterarATravezDeLaLista()
        {
            var EmpleadosDeLaEmpresa = new List<Empleado>
            {
                new Empleado() { DNI = "20477895", Nombre = "Maria", Edad = 28},
                new Empleado() { DNI = "15788444", Nombre = "Jose", Edad = 33},
                new Empleado() { DNI = "25046519", Nombre = "Carlos", Edad = 16},
                new Empleado() { DNI = "9272853", Nombre = "Alfredo", Edad = 64}
            };
            Console.WriteLine("Total de Empleados:" +EmpleadosDeLaEmpresa.Count);
            foreach (Empleado i in EmpleadosDeLaEmpresa)
            {
                Console.WriteLine(i.DNI + "  " + i.Nombre + " " + i.Edad);
            }

            // Output: 20477895  Maria 28
            //         15788444 Jose 33
            //         25046519 Carlos 16
            //         9272853 Alfredo Edad 64
        }

        public class Empleado
        {
            public string DNI { get; set; }
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }
        static void Main(string[] args)
        {
            IterarATravezDeLaLista();
            Console.ReadKey();
        }

    }
}

```

## Tipos de colecciones

.NET Framework proporciona muchas colecciones comunes. Cada tipo de colección está diseñado para un fin específico.

En esta sección se describen algunas de las clases de colecciones comunes:

- Clases [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic)
- Clases [System.Collections.Concurrent](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent)
- Clases [System.Collections](https://docs.microsoft.com/es-es/dotnet/api/system.collections)

### Clases System.Collections.Generic

Puede crear una colección genérica mediante una de las clases del espacio de nombres [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic). Una colección genérica es útil cuando todos los elementos de la colección tienen el mismo tipo. Una colección genérica exige el establecimiento de fuertes tipos al permitir agregar solo los tipos de datos deseados.

En la tabla siguiente se enumeran algunas de las clases usadas con frecuencia del espacio de nombres [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic):

| Clase                                                        | Descripción                                                  |
| :----------------------------------------------------------- | :----------------------------------------------------------- |
| [Dictionary](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2) | Representa una colección de pares de clave y valor que se organizan según la clave. |
| [List](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1) | Representa una lista de objetos a los que puede tener acceso el índice. Proporciona métodos para buscar, ordenar y modificar listas. |
| [Queue](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.queue-1) | Representa una colección de objetos de primeras entradas, primeras salidas (FIFO). |
| [SortedList](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.sortedlist-2) | Representa una colección de pares clave-valor que se ordenan por claves según la implementación de [IComparer](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.icomparer-1) asociada. |
| [Stack](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.stack-1) | Representa una colección de objetos de últimas entradas, primeras salidas (LIFO). |

Para obtener más información, vea [Tipos de colección utilizados normalmente](https://docs.microsoft.com/es-es/dotnet/standard/collections/commonly-used-collection-types), [Seleccionar una clase de colección](https://docs.microsoft.com/es-es/dotnet/standard/collections/selecting-a-collection-class) y [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic).

### Clases System.Collections

Las clases del espacio de nombres [System.Collections](https://docs.microsoft.com/es-es/dotnet/api/system.collections) no almacenan los elementos como objetos de tipo específico, sino como objetos del tipo `Object`.

Siempre que sea posible, debe usar las colecciones genéricas del espacio de nombres [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic) o del espacio de nombres [System.Collections.Concurrent](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent) en lugar de los tipos heredados del espacio de nombres `System.Collections`.

En la siguiente tabla se enumeran algunas de las clases usadas con frecuencia en el espacio de nombres `System.Collections`:

| Clase                                                        | Descripción                                                  |
| :----------------------------------------------------------- | :----------------------------------------------------------- |
| [ArrayList](https://docs.microsoft.com/es-es/dotnet/api/system.collections.arraylist) | Representa una matriz cuyo tamaño aumenta dinámicamente cuando es necesario. |
| [Hashtable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.hashtable) | Representa una colección de pares de clave y valor que se organizan por código hash de la clave. |
| [Queue](https://docs.microsoft.com/es-es/dotnet/api/system.collections.queue) | Representa una colección de objetos de primeras entradas, primeras salidas (FIFO). |
| [Stack](https://docs.microsoft.com/es-es/dotnet/api/system.collections.stack) | Representa una colección de objetos de últimas entradas, primeras salidas (LIFO). |

El espacio de nombres [System.Collections.Specialized](https://docs.microsoft.com/es-es/dotnet/api/system.collections.specialized) proporciona clases de colección especializadas y fuertemente tipadas como, por ejemplo, colecciones de solo cadena y diccionarios híbridos y de lista vinculada.

Representa una colección ordenada de un objeto que se puede indexar individualmente. Es básicamente una alternativa a una matriz. Sin embargo, a diferencia de la matriz, puede agregar y eliminar elementos de una lista en una posición específica utilizando un **índice** y la matriz se redimensiona automáticamente. También permite la asignación dinámica de memoria, agregando, buscando y ordenando elementos en la lista.

### Clases System.Collections.Concurrent

En .NET Framework 4 o posterior, las colecciones del espacio de nombres [System.Collections.Concurrent](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent) proporcionan operaciones eficaces y seguras para subprocesos con el fin de obtener acceso a los elementos de la colección desde varios subprocesos.

Las clases del espacio de nombres [System.Collections.Concurrent](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent) deben usarse en lugar de los tipos correspondientes de los espacios de nombres [System.Collections.Generic](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic) y [System.Collections](https://docs.microsoft.com/es-es/dotnet/api/system.collections) cada vez que varios subprocesos tengan acceso de manera simultánea a la colección. Para obtener más información, vea [Colecciones seguras para subprocesos](https://docs.microsoft.com/es-es/dotnet/standard/collections/thread-safe/index) y [System.Collections.Concurrent](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent).

Algunas clases incluidas en el espacio de nombres [System.Collections.Concurrent](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent)son [BlockingCollection](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent.blockingcollection-1), [ConcurrentDictionary](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent.concurrentdictionary-2), [ConcurrentQueue](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent.concurrentqueue-1) y [ConcurrentStack](https://docs.microsoft.com/es-es/dotnet/api/system.collections.concurrent.concurrentstack-1).



# Información general de tipos genéricos

Los desarrolladores utilizan genéricos en todo momento en .NET, ya sea implícita o explícitamente. Al usar LINQ en .NET, ¿alguna vez observó que estaba trabajando con [IEnumerable](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.ienumerable-1)? O si alguna vez ha visto un ejemplo en línea de un "repositorio genérico" para comunicarse con bases de datos mediante Entity Framework, ¿observó que la mayoría de los métodos devuelven IQueryable<T>?Probablemente se pregunte qué significa la **T** en estos ejemplos y por qué aparece.

Introducidos por primera vez en .NET Framework 2.0, los **genéricos** son esencialmente una "plantilla de código" que permite a los desarrolladores definir estructuras de datos [con seguridad de tipos](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/hbzz1a9a(v=vs.100)) sin confirmar un tipo de datos real. Por ejemplo, [List](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1) es una [colección genérica](https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic) que se puede declarar y usar con cualquier tipo, como `List<int>`, `List<string>` o `List<Person>`.

Para entender por qué los genéricos son útiles, vamos a echar un vistazo a una clase específica antes y después de agregar genéricos: [ArrayList](https://docs.microsoft.com/es-es/dotnet/api/system.collections.arraylist). En .NET Framework 1.0, los elementos `ArrayList` eran de tipo [Object](https://docs.microsoft.com/es-es/dotnet/api/system.object). Esto significaba que cualquier elemento agregado se convertía desapercibidamente en un `Object`. Lo mismo podría suceder al leer los elementos de la lista. Este proceso se conoce como [conversión boxing y unboxing](https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/types/boxing-and-unboxing), y afecta al rendimiento. Sin embargo, más que eso, hay ninguna manera de determinar el tipo de datos en la lista en el tiempo de compilación. Por ello, algunos códigos son frágiles. Los genéricos solucionan este problema definiendo el tipo de datos que va a contener cada instancia de la lista. Por ejemplo, solo puede agregar enteros a `List<int>` y solo puede agregar personas a `List<Person>`.

Los genéricos también están disponibles en el tiempo de ejecución. Esto significa que el tiempo de ejecución conoce qué tipo de estructura de datos está usando y puede almacenarla en memoria de modo más eficaz.

El ejemplo siguiente es un pequeño programa que muestra la eficacia que supone conocer el tipo de estructura de datos en el tiempo de ejecución:

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Comparacion de velocidad entre
            //  Una Lista Generica y una No Generica
            //
            List<int> ListaGenerica = new List<int> { 1, 2, 3, 4 };
            ArrayList ListaNoGenerica = new ArrayList { 1, 2, 3, 4 };
            //
            // temporizador para ordenación genérica
            Stopwatch s = Stopwatch.StartNew();
            ListaGenerica.Sort();
            s.Stop();
            Console.WriteLine($"Ordenado Generico: {ListaGenerica}  \n Velocidad: {s.Elapsed.TotalMilliseconds}ms");

            // temporizador para ordenación no genérica
            Stopwatch s2 = Stopwatch.StartNew();
            ListaNoGenerica.Sort();
            s2.Stop();
            Console.WriteLine($"Ordenado NO Generico: {ListaNoGenerica}  \n Velocidad: {s2.Elapsed.TotalMilliseconds}ms");
            Console.ReadLine();
        }
    }
}
```

|                                                 | TEst de velocidad   |
| ----------------------------------------------: | :------------------ |
| Lista Genérica System.Collections.Generic.List: | Velocidad: 0.0141ms |
| Lista NO Genérica System.Collections.ArrayList: | Velocidad: 0.1429ms |

Lo primero que verá aquí es que la ordenación de la lista genérica es significativamente más rápida que la de la lista no genérica. También puede observar que el tipo de la lista genérica es distinto ([System.Int32]), mientras que el tipo de la lista no genérica es generalizado. Dado que el tiempo de ejecución sabe que el genérico `List<int>` es de tipo `ArrayList`, puede almacenar los elementos de la lista en una matriz de enteros subyacente en memoria, mientras el no genérico [Int32](https://docs.microsoft.com/es-es/dotnet/api/system.int32) tiene que convertir cada elemento de la lista en un objeto. Como se muestra en este ejemplo, las conversiones adicionales consumen tiempo y ralentizan la ordenación de la lista.

Otra ventaja adicional de que el tiempo de ejecución conozca el tipo de la clase genérica es una mejor experiencia de depuración. Cuando se depura un genérico en C#, sabe qué tipo de cada elemento se encuentra en la estructura de datos. Sin genéricos, no sabría qué tipo de cada elemento estaba presente.

**Los genéricos le** **permiten definir la especificación del tipo de datos de los elementos de programación en una clase o un método**, hasta que realmente se utiliza en el programa. **En otras palabras, los genéricos le permiten escribir una clase o método que puede funcionar con cualquier tipo de datos.**

Usted escribe las especificaciones para la clase o el método, con parámetros sustitutos para los tipos de datos. Cuando el compilador encuentra un constructor para la clase o una llamada de función para el método, genera un código para manejar el tipo de datos específico. Un ejemplo simple ayudaría a entender el concepto:

```c#
using System;
using System.Collections.Generic;

namespace GenericApplication
{   // Array del tipo Generico 
    // Se Encapsulara codigo para re utilizarlo.
    // Ejemplo usando el mismo array<T> para almacenar datos del tipo <int> y <char>

    // tipo del objeto generico
    // <A> ó <B> ó  <C> ó <D> ó <T> ó 
    // Del Tipo <T> <Generico>
    public class EjemplodeArray<Generico>
    {
        private Generico[] array;

        public EjemplodeArray(int tamanoDelArray)
        {
            array = new Generico[tamanoDelArray + 1];
        }
        public Generico ObtenerElemento(int i)
        {
            return array[i];
        }
        public void AgregarElemento(int i, Generico generico)
        {
            array[i] = generico;
        }
    }
    class Tester
    {
        static void Main(string[] args)
        {
            int TamanoDelArray = 10;
            // Declaramos nuestro array del tipo entero 
            EjemplodeArray<int> intArray = new EjemplodeArray<int>(TamanoDelArray);

            //  Ciclo para almacenar valores en el array
            for (int i = 0; i < TamanoDelArray; i++)
            {
                intArray.AgregarElemento(i, i * 1);
            }

            // Imprimiendo Array
            for (int i = 0; i < TamanoDelArray; i++)
            {
                Console.Write(intArray.ObtenerElemento(i) + " ");
            }
            Console.WriteLine();

            // Declaramos nuestro array del tipo character 
            EjemplodeArray<char> charArray = new EjemplodeArray<char>(TamanoDelArray);

            //setting values
            for (int i = 0; i < TamanoDelArray; i++)
            {
                charArray.AgregarElemento(i, (char)(i + 97));
            }

            //retrieving the values
            for (int i = 0; i < TamanoDelArray; i++)
            {
                Console.Write(charArray.ObtenerElemento(i) + " ");
            }
            Console.WriteLine();
            // Salida:
            // 0 1 2 3 4 5 6 7 8 9
            // a b c d e f g h i j
            Console.ReadKey();
        }
    }
}
```

## Características de los genéricos

Los genéricos son una técnica que enriquece sus programas de las siguientes maneras:

- Le ayuda a maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- Puedes crear clases de colección genéricas. La biblioteca de clases de .NET Framework contiene varias clases de colecciones genéricas nuevas en el espacio de nombres *System.Collections.Generic* . Puede usar estas clases de colección genéricas en lugar de las clases de colección en el espacio de nombres *System.Collections* .
- Puede crear sus propias interfaces genéricas, clases, métodos, eventos y delegados.
- Puede crear clases genéricas restringidas para permitir el acceso a métodos en tipos de datos particulares.
- Puede obtener información sobre los tipos utilizados en un tipo de datos genéricos en tiempo de ejecución por medio de la reflexión.

## Métodos genéricos

En el ejemplo anterior, hemos utilizado una clase genérica; Podemos declarar un método genérico con un parámetro de tipo. El siguiente programa ilustra el concepto:





































# LINQ EN ACCION



Las palabras clave LINQ proporcionan la base para realizar una consulta. En ciertos sentidos,
estas palabras clave funcionan y actúan como las palabras clave en SQL. Como se mencionó, el
las palabras clave proporcionan parámetros que le dicen a LINQ qué buscar. Como mínimo, usted
debe definir una de la palabra clave. El dónde, ordenar, unir y dejar las palabras clave.
Proporcionar condiciones adicionales. Las siguientes secciones describen cada uno de los
Palabras clave LINQ.

La palabra clave **from** es la única palabra clave que debe incluir como parte de un
Consulta LINQ. La palabra clave **from** determina la **fuente** **de datos utilizada**.

```c#
using System;
using System.Linq; // Libreria LinQ

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] ObjetoString = { "A", "B", "C", "D", "E" };
            var EstoEsUnQuery =
                (from i 
                 in ObjetoString
                 select i);
            Console.ReadKey();
        }
    }
}
//EstoEsUnQuery=System.Linq.Enumerable.SelectArrayIterator<string, string>
```



### Fundamentos de LINQ


A un alto nivel, hay varios beneficios que pueden obtenerse al usar LINQ (Language Integrated Query), incluyendo:

- Reducir la cantidad de código que se necesita escribir.
  Una mejor comprensión de la intención de lo que está haciendo el código.
- Una vez aprendido, puede usar un conjunto similar de conocimientos de consultas LINQ contra diferentes fuentes de datos (objetos en memoria, o fuentes remotas como SQL Server o incluso Twitter).
- Las consultas se pueden componer juntas y construir en etapas.
- Las consultas ofrecen la seguridad de la verificación de tipos en tiempo de compilación.

Esencialmente, LINQ permite que las consultas se traten como ciudadanos de primera clase en C # y Visual Basic.

### Los bloques de construcción de LINQ

Los dos bloques de construcción fundamentales de LINQ son los conceptos de elementos y secuencias.

Una secuencia puede considerarse como una lista de elementos, y cada elemento de la lista es un elemento. 

Una secuencia es una instancia de una clase que implementa la interfaz IEnumerable <T>.

Si una matriz de números se declarara como: int [] fibonacci = {0, 1, 1, 2, 3, 5}; la variable fibonacci representa una secuencia con cada int en la matriz como un elemento individual.

Una secuencia podría ser una secuencia local de objetos en memoria o una secuencia remota, como una base de datos de SQL Server. En el caso de fuentes de datos remotas (por ejemplo, SQL Server), estas secuencias remotas también implementan la interfaz IQueryable <T>.

Las consultas, o más específicamente los operadores de consulta, trabajan en una secuencia de entrada y producen algún valor de salida. Este valor de salida podría ser una versión transformada de la secuencia de entrada, es decir, una secuencia de salida o un único valor escalar, como un conteo del número de elementos en la secuencia de entrada.

Las consultas que se ejecutan en secuencias locales se conocen como consultas locales o consultas de LINQ to Objects.

Hay una gran cantidad de operadores de consulta que se implementan como métodos de extensión en la clase estática System.Linq.Enumerable. Este conjunto de operadores de consulta se conocen como operadores de consulta estándar. 

Una cosa importante a tener en cuenta cuando se utilizan operadores de consulta es que no alteran la secuencia de entrada; más bien, el operador de consulta devolverá una nueva secuencia (o un valor escalar).

## Scalar return values and output sequences - Valores de retorno escalares y secuencias de salida .

Un operador de consulta devuelve una secuencia de salida o un valor escalar. En el siguiente código, la secuencia de entrada fibonacci es operada primero por el operador de consulta de conteo que produce un único valor escalar que representa el número de elementos en la secuencia de entrada. A continuación, la misma secuencia de entrada es operada por el operador de consulta Distinct que produce una nueva secuencia de salida que contiene los elementos de la secuencia de entrada, pero con elementos duplicados eliminados.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }; // The Fibonacci Sequence
            int NumeroDeElementos = fibonacci.Count(); // Retorna el numero de elementos de una secuencia.
            Console.WriteLine("Total de Elementos: {0}", NumeroDeElementos); // Output sequence return value 
            IEnumerable<int> NumerosDistintos = fibonacci.Distinct(); //Devuelve elementos distintos de una secuencia utilizando el comparador de igualdad predeterminado para comparar valores.
            Console.WriteLine("Elementos distintos de la sequence:");
            foreach (var number in NumerosDistintos)
            {
                Console.WriteLine(number);
            }
            // Salida: 0,1,2,3,5,8,13,21,34
        }
    }
}
```

## Deferred execution - Ejecución diferida

La mayoría de los operadores de consulta no se ejecutan inmediatamente; Su ejecución se aplaza hasta un momento posterior en la ejecución del programa. **Esto significa que la consulta no se ejecuta cuando se crea, sino cuando se usa o se enumera.** 

La ejecución diferida significa que la secuencia de entrada se puede modificar después de que se construya la consulta, pero antes de que se ejecute la consulta. Solo cuando se ejecuta la consulta se procesa la secuencia de entrada.
En el siguiente código, la secuencia de entrada se modifica después de que se construye la consulta, pero antes de que se ejecute.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 }; // Array
            IEnumerable<int> MayoresQueDos;

            MayoresQueDos = fibonacci.Where(x => x > 2); 
            
            foreach (var i in MayoresQueDos)
            {
                Console.WriteLine("{0}" + ",", i);
            }
            Console.ReadKey();
            Console.Clear();

            fibonacci[0] = 99; // Aqui
            foreach (var i in MayoresQueDos)
            {
                Console.WriteLine("{0}" + ",", i);
            }
        }
    }
}
```

Observe que el valor 99 se ha incluido en los resultados, aunque en el momento en que se construyó la consulta, el primer elemento seguía siendo el valor original de 0.
Con la excepción de aquellos que devuelven un valor escalar (o un solo elemento de la secuencia de entrada) como **Count**, **Min** y **Last**; Los operadores de consulta estándar trabajan de esta forma de ejecución diferida. Por lo tanto, utilizar operadores como **Count** **hará que la consulta se ejecute inmediatamente y no se aplace.**
Hay una serie de operadores de conversión que también causan la ejecución inmediata de consultas, como ToList, ToArray, ToLookup y ToDictionary.

En el siguiente código, la matriz de fibonacci se modifica como en el código de ejemplo anterior, pero en este ejemplo, en el momento en que se realiza la modificación (fibonacci [0] = 99), la consulta ya se ha ejecutado debido a la ToArray adicional. ().

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 }; // Array
            IEnumerable<int> MayoresQueDos;

            MayoresQueDos = fibonacci.Where(x => x > 2).ToArray();
            // En este punto, la consulta se ha ejecutado debido a .ToArray()
            foreach (var i in MayoresQueDos)
            {
                Console.WriteLine("{0}" + ",", i);
            }
            Console.ReadKey();
            Console.Clear();

            fibonacci[0] = 99; // Aqui
            foreach (var i in MayoresQueDos)
            {
                Console.WriteLine("{0}" + ",", i);
            }
        }
    }
}
```

Algunos operadores de consulta permiten proporcionar lógica personalizada. Esta lógica personalizada se puede suministrar al operador de consulta mediante una expresión lambda.
El código de

```c#
 14. fibonacci.Where (x => x> 2)
```

 en el ejemplo de código anterior es un ejemplo de un operador de consulta que recibe alguna lógica personalizada. Aquí, la expresión lambda x => x> 2 solo devolverá elementos (en este caso, ints) que son mayores que 2.
**Cuando un operador de consulta toma una expresión lambda, aplicará la lógica en la expresión lambda a cada elemento individual en la secuencia de entrada.**
El tipo de expresión lambda que se proporciona a un operador de consulta depende de qué tarea está realizando el operador de consulta.

![](https://github.com/imyourpartner/MyFiles/blob/master/fibonacciwheretoarray.png)

 En la Figura , podemos ver la firma del operador de consulta Where; aquí se proporciona el elemento de entrada int y se debe devolver un valor de boole que las determinaciones del elemento se incluirán en la secuencia de salida.

Como alternativa al uso de una expresión lambda, también es posible usar un delegado tradicional que apunta a un método

## Fluent and Query Expression Styles -  Estilos de expresión fluida y de consulta.

Hay dos estilos para escribir consultas LINQ: 

- El estilo fluido (o sintaxis fluida) 
- El estilo de expresión de consulta (o sintaxis de consulta).

## El estilo fluido 

Utiliza métodos de extensión de operador de consulta para crear consultas, mientras que el estilo de expresión de consulta utiliza una sintaxis diferente que el compilador traducirá en una sintaxis fluida.

Las muestras de código hasta este punto han utilizado la sintaxis fluida.
La sintaxis fluida hace uso de los métodos de extensión del operador de consulta como se define en la clase estática System.Linq.Enumerable (o System.Linq.Queryable para interpretado o
System.Linq.ParallelEnumerable para consultas PLINQ). 

Estos métodos de extensión agregan métodos adicionales a las instancias de IEnumerable <T>. Esto significa que cualquier instancia de una clase que implemente esta interfaz puede usar estos métodos de extensión LINQ fluidos.
Los operadores de consultas se pueden utilizar individualmente o encadenados para crear consultas más complejas.

## Operadores de consulta encadenados

El siguiente código utilizará tres operadores de consulta encadenados: Where, OrderBy y Select.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

class Ingrediente
{
    public string Nombre { get; set; }
    public int NumeroDeCalorias { get; set; }   
}

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingrediente[] Ingredientes =
            {
                new Ingrediente{ Nombre = "Azucar", NumeroDeCalorias = 500},
                new Ingrediente { Nombre = "Huevos", NumeroDeCalorias = 100},
                new Ingrediente { Nombre = "Leche", NumeroDeCalorias = 150},
                new Ingrediente { Nombre = "Harina", NumeroDeCalorias = 50},
                new Ingrediente { Nombre = "Mantequilla", NumeroDeCalorias = 200}
            };

            IEnumerable<string> IngredientesDeAltaCaloriasQuery =
                Ingredientes.Where(x => x.NumeroDeCalorias >= 150)
                    .OrderBy(x => x.Nombre)
                    .Select(x => x.Nombre);

            foreach (var ingrediente in IngredientesDeAltaCaloriasQuery)
            {
                Console.WriteLine(ingrediente);
            }
        }
    }
}
```

La ejecución de este código produce el siguiente resultado:

- Mantequilla
-  Leche 
- Azúcar

La la siguiente figura  muestra una representación gráfica de esta cadena de operadores de consulta. Cada operador trabaja en la secuencia proporcionada por el operador de consulta anterior. Observe que la secuencia de entrada inicial (representada por los ingredientes de la variable) es un **IEnumerable<Ingrediente>** , mientras que la secuencia de salida (representada por la variable IngredientesDeAltaCaloriasQuery) es un tipo diferente; es un **IEnumerable<string>**

![](https://github.com/imyourpartner/MyFiles/blob/master/Ienurableingredientes.png)

En este ejemplo, la cadena de operadores está trabajando con una secuencia de elementos Ingrediente hasta que el operador Seleccionar transforma cada elemento en la secuencia; Cada objeto Ingrediente se transforma en una cadena simple. Esta transformación se llama proyección. Los elementos de entrada se proyectan en elementos de salida transformados.

La expresión lambda proporcionada al operador de consulta Seleccionar decide qué "forma" tomarán los elementos en la secuencia de salida.

 La expresión lambda x => x.Nombre está indicando al operador Seleccionar "para cada elemento Ingrediente, genere un elemento de cadena con el valor de la propiedad Nombre desde el Ingrediente de entrada".

## Query expression style - Estilo de expresión de consulta

Las expresiones de consulta ofrecen una amabilidad sintáctica sobre la sintaxis fluida.
El siguiente código muestra la versión equivalente utilizando la sintaxis de consulta de la consulta de estilo fluido anterior.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

class Ingrediente
{
    public string Nombre { get; set; }
    public int NumeroDeCalorias { get; set; }   
}

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingrediente[] Ingredientes =
            {
                new Ingrediente{ Nombre = "Azucar", NumeroDeCalorias = 500},
                new Ingrediente { Nombre = "Huevos", NumeroDeCalorias = 100},
                new Ingrediente { Nombre = "Leche", NumeroDeCalorias = 150},
                new Ingrediente { Nombre = "Harina", NumeroDeCalorias = 50},
                new Ingrediente { Nombre = "Mantequilla", NumeroDeCalorias = 200}
            };

            IEnumerable<string> IngredientesDeAltaCaloriasQuery = from i in Ingredientes
                                                                  where i.NumeroDeCalorias >= 150
                                                                  orderby i.Nombre
                                                                  select i.Nombre;

            foreach (var ingrediente in IngredientesDeAltaCaloriasQuery)
            {
                Console.WriteLine(ingrediente);
            }
        }
    }
}
```

- The fluent style (or fluent syntax)  - El estilo fluido (o sintaxis fluida) 

```c#
IEnumerable<string> IngredientesDeAltaCaloriasQuery =
    Ingredientes.Where(x => x.NumeroDeCalorias >= 150)
        .OrderBy(x => x.Nombre)
        .Select(x => x.Nombre);
```

- The query expression style (or query syntax). - El estilo de expresión de consulta (o sintaxis de consulta).

```c#
IEnumerable<string> IngredientesDeAltaCaloriasQuery = 
    from i in Ingredientes
    where i.NumeroDeCalorias >= 150
    orderby i.Nombre
    select i.Nombre;
```

La ejecución de este código produce el mismo resultado que la versión de sintaxis fluida: 

- Mantequilla 
- Leche
- Azúcar)

Los pasos que se realizan son los mismos que en la versión de sintaxis fluida, con cada cláusula de consulta (**`from, where, orderby, select`**) pasando una secuencia modificada a la siguiente cláusula de consulta.

La expresión de consulta en el código anterior comienza con la cláusula from. La cláusula from tiene dos propósitos: 

- El primero es describir cuál es la secuencia de entrada (en este caso, los ingredientes); 
- El segundo es introducir una variable de rango.

La cláusula final es la cláusula de selección, que describe cuál será la secuencia de salida de toda la consulta. Al igual que con la versión de sintaxis fluida, la cláusula de selección en el código anterior está proyectando una secuencia de objetos Ingrediente en una secuencia de string objects.

## Range variables - Una variable de rango

Una variable de rango es un identificador que representa cada elemento en la secuencia a su vez. Es similar a la variable utilizada en una sentencia `foreach`; a medida que se procesa la secuencia, esta variable de rango representa el elemento actual que se está procesando.

 En el código anterior, la variable de rango i está siendo declarada. Aunque se utiliza el mismo identificador de variable de rango i en cada cláusula, la secuencia en que la variable de rango "atraviesa" es diferente. Cada cláusula funciona con la secuencia de entrada producida a partir de la cláusula anterior (o la entrada inicial `IEnumerable <T>`).

 Esto significa que cada cláusula está procesando una secuencia diferente; es simplemente el nombre del identificador de variable de rango que se está reutilizando.

Además de la variable de rango introducida en la cláusula `from`, se pueden agregar variables de rango adicionales utilizando otras cláusulas o palabras clave. Lo siguiente puede introducir nuevas variables de rango en una expresión de consulta:

- Additional `from` clauses
- The `let` clause
- The `into` keyword
- The `join` clause

## The let clause - La cláusula let

Una cláusula `let` en una expresión de consulta LINQ permite la introducción de una variable de rango adicional. Esta variable de rango adicional se puede usar en otras cláusulas que la siguen.

En el siguiente código, la cláusula let se usa para introducir una nueva variable de rango llamada esLacteo, que será de tipo booleano.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

class Ingrediente
{
    public string Nombre { get; set; }
    public int NumeroDeCalorias { get; set; }   
}

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingrediente[] Ingredientes =
            {
                new Ingrediente{ Nombre = "Azucar", NumeroDeCalorias = 500},
                new Ingrediente { Nombre = "Huevos", NumeroDeCalorias = 100},
                new Ingrediente { Nombre = "Leche", NumeroDeCalorias = 150},
                new Ingrediente { Nombre = "Harina", NumeroDeCalorias = 50},
                new Ingrediente { Nombre = "Mantequilla", NumeroDeCalorias = 200}
            };

            IEnumerable<Ingrediente> IngredientesDeAltaCaloriasQuery = 
                from i in Ingredientes
                let esLacteo = i.Nombre == "Leche" || i.Nombre == "Mantequilla"
                where i.NumeroDeCalorias >= 150 && esLacteo
                select i;

            foreach (var ingrediente in IngredientesDeAltaCaloriasQuery)
            {
                Console.WriteLine(ingrediente.Nombre);
            }

            Console.WriteLine("Hola");
            Console.ReadKey();
        }
    }
}
```

La salida de este código produce:

- Mantequilla
-  Leche

En el código anterior, la variable de rango EsLacteo se introduce y luego se utiliza en la cláusula where. Observe que la variable de rango original i permanece disponible para la cláusula de selección.
En este ejemplo, la nueva variable de rango es un valor escalar simple, pero también puede usarse para introducir una subsecuencia. En el siguiente ejemplo de código, los ingredientes de la variable de rango no son un valor escalar, sino una serie de array strings

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] csvRecipes = 
            {
                "milk,sugar,eggs",
                "flour,BUTTER,eggs",
                "vanilla,ChEEsE,oats"
            };
            var dairyQuery = 

                from csvRecipe in csvRecipes
                let ingredients = csvRecipe.Split(',')

                from ingredient in ingredients
                let uppercaseIngredient = ingredient.ToUpper()

                where  uppercaseIngredient == "MILK" || 
                       uppercaseIngredient == "BUTTER" || 
                       uppercaseIngredient == "CHEESE"
                select uppercaseIngredient;

            foreach (var dairyIngredient in dairyQuery)
            {
                Console.WriteLine("{0} is dairy", dairyIngredient);
            }

            Console.WriteLine("Hola");
            Console.ReadKey();
        }
    }
}
```

Observe en el código anterior que estamos usando varias cláusulas `let` y también cláusulas adicionales. 

El uso de cláusulas adicionales es otra forma de introducir nuevas variables de rango en una expresión de consulta.

## The `into` keyword  - La palabra clave `into`

La palabra clave `into` también permite declarar un nuevo identificador que puede almacenar el resultado de una cláusula de selección (así como las cláusulas de `group` y `join`).

El siguiente código demuestra cómo usar para crear un nuevo tipo anónimo y luego usarlo en el resto de la expresión de consulta.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient[] ingredients = 
            {
                new Ingredient{ Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 150 },
                new Ingredient { Name = "Flour", Calories = 50 },
                new Ingredient { Name = "Butter", Calories = 200 }
            };

            IEnumerable<Ingredient> highCalDairyQuery = 
                from i in ingredients
                select new // anonymous type *
                {
                    OriginalIngredient = i,
                    IsDairy = i.Name == "Milk" || i.Name == "Butter",
                    IsHighCalorie = i.Calories >= 150
                } 
                into temp
                where temp.IsDairy && temp.IsHighCalorie
                // cannot write "select i;" as into hides the previous range variable i 
                select temp.OriginalIngredient;

            foreach (var ingredient in highCalDairyQuery)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
    }
    class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}
```

> Salida: Milk Butter

Tenga en cuenta que al utilizar la variable de rango anterior `i` oculta. Esto significa que no se puede utilizar en la selección final.

Sin embargo, la cláusula `let` no oculta la (s) variable (s) de rango anterior, lo que significa que aún pueden usarse más adelante en expresiones de consulta.



## The `join` clause  - La cláusula de unión

Toma dos secuencias de entrada en las que los elementos de cualquiera de las dos secuencias no tienen necesariamente una relación directa en el modelo de dominio de clase.

Para realizar una unión, algún valor de los elementos en la primera secuencia se compara para igualar con algún valor de los elementos en la segunda secuencia. 

Es importante tener en cuenta que la cláusula de unión realiza equi-joins; Los valores de ambas secuencias se comparan para la igualdad. 

Esto significa que la cláusula de unión no admite non-equijoins como desigualdad, o comparaciones como mayor que o menor que. Debido a esto, en lugar de especificar elementos unidos utilizando un operador como == en C #, se utiliza la palabra clave equals. El diseño que está pensando en introducir esta palabra clave es dejar muy claro que las uniones son equi-joins.

Los tipos comunes de uniones incluyen:

- Inner joins. Uniones internas.
- Group joins. Uniones grupales.
- Left outer joins. Uniones externas izquierdas.

Los siguientes ejemplos de código de unión asumen que se han definido las siguientes clases:

```c#
class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Review
{
    public int RecipeId { get; set; }
    public string ReviewText { get; set; }
}
```

Estas dos clases modelan el hecho de que los Recipes pueden tener 0, 1 o muchas revisiones

 La clase Review tiene una propiedad ID que contiene el mismo ID de Recipe, Recipe a la que pertenece la Review; 

Tenga en cuenta que aquí no hay una relación directa en forma de una propiedad de tipo Recipe.

## `Inner join` - Unir internamente

Una unión interna devuelve un elemento en la secuencia de salida para cada elemento en la primera secuencia que tiene elementos coincidentes en la segunda secuencia. Si un elemento en la primera secuencia no tiene ningún elemento coincidente en la segunda secuencia, no aparecerá en la secuencia de salida.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

namespace ConsoleApp
{
    class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Review
    {
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Recipe[] recipes = 
            {
                new Recipe { Id = 1, Name = "Mashed Potato" },
                new Recipe { Id = 2, Name = "Crispy Duck" },
                new Recipe { Id = 3, Name = "Sachertorte" }
            };

            Review[] reviews = 
            {
                new Review { RecipeId = 1, ReviewText = "Tasty!" },
                new Review { RecipeId = 1, ReviewText = "Not nice :(" },
                new Review { RecipeId = 1, ReviewText = "Pretty good" },
                new Review { RecipeId = 2, ReviewText = "Too hard" },
                new Review { RecipeId = 2, ReviewText = "Loved it" }
            };
            var query = 
                from recipe in recipes
                join review in reviews on recipe.Id equals review.RecipeId
                select new // anonymous type 
                {
                    RecipeName = recipe.Name, RecipeReview = review.ReviewText
                };

            foreach (var item in query)
            {
                Console.WriteLine("{0} - '{1}'", item.RecipeName, item.RecipeReview);
            }
        }
    }
}
```

En este código anterior, se crean dos secuencias de entrada: recipes, que contienen una cantidad de recetas, y una segunda secuencia, revisiones del tipo de objeto de Revisiónes.

La expresión de consulta comienza con la cláusula habitual que apunta a la primera secuencia (recetas) y declara la receta de la variable de rango.

Luego viene el uso de la cláusula de unión. Aquí se introduce otra variable de rango (revisión) que representa los elementos que se procesan en la secuencia de entrada de las revisiones. 

La palabra clave `on` permite especificar qué valor del objeto variable de rango de receta se relaciona con qué valor del objeto variable de rango de revisión.

 De nuevo, la palabra clave `equals` se utiliza aquí para representar una equi-join. Esta cláusula de unión básicamente indica que las revisiones pertenecen a recetas identificadas por los valores comunes de Id en Recipe y RecipeId en Review.

>Salida:
>
>Mashed Potato - 'Tasty!' 
>
>Mashed Potato - 'Not nice :(' 
>
>Mashed Potato - 'Pretty good' 
>
>Crispy Duck - 'Too hard' 
>
>Crispy Duck - 'Loved it'

Observe aquí que la receta "Sachertorte" no existe en la salida. Esto se debe a que no hay revisiones para ello, es decir, no hay elementos coincidentes en la segunda secuencia de entrada (revisiones).

También tenga en cuenta que el resultado es "plano", lo que significa que no hay un concepto de grupos de revisiones que pertenezcan a una receta "principal".


## Group join - Una unión de grupo 

Puede producir un resultado jerárquico agrupado donde los elementos de la segunda secuencia se comparan con los elementos de la primera secuencia.
A diferencia de la combinación interna anterior, la salida de una combinación de grupo puede organizarse jerárquicamente con las revisiones agrupadas en su receta relacionada.

```c#
using System;
using System.Collections.Generic; // Collecciones genericas
using System.Linq; // LinQ

namespace ConsoleApp
{
    class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Review
    {
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Recipe[] recipes = 
            {
                new Recipe { Id = 1, Name = "Mashed Potato" },
                new Recipe { Id = 2, Name = "Crispy Duck" },
                new Recipe { Id = 3, Name = "Sachertorte" }
            };

            Review[] reviews = 
            {
                new Review { RecipeId = 1, ReviewText = "Tasty!" },
                new Review { RecipeId = 1, ReviewText = "Not nice :(" },
                new Review { RecipeId = 1, ReviewText = "Pretty good" },
                new Review { RecipeId = 2, ReviewText = "Too hard" },
                new Review { RecipeId = 2, ReviewText = "Loved it" }
            };

            var query = from recipe in recipes
                        join review in reviews on recipe.Id equals review.RecipeId into reviewGroup
                        select new // anonymous type 
                        {
                            RecipeName = recipe.Name, Reviews = reviewGroup // collection of related reviews 
                        };

            foreach (var item in query)
            {
                Console.WriteLine("Reviews for {0}", item.RecipeName);

                foreach (var review in item.Reviews)
                {
                    Console.WriteLine(" - {0}", review.ReviewText);
                }
            }
        }
    }
}
```

En esta versión, observe la adición de la palabra clave en. Esto permite la creación de resultados jerárquicos. La variable de rango reviewGroup representa una secuencia de revisiones que coinciden con la expresión de unión, en este caso donde la receta.Id es igual a review.RecipeId.
Para crear la secuencia de salida de los grupos (donde cada grupo contiene las revisiones relacionadas), el resultado de la consulta se proyecta en un tipo anónimo. Cada instancia de este tipo anónimo en la secuencia de salida representa cada grupo. El tipo anónimo tiene dos propiedades: Nombre de receta que proviene del elemento en la primera secuencia y Revisiones que provienen de los resultados de la expresión de unión, es decir, las revisiones que pertenecen a la receta.
La salida de este código produce lo siguiente:
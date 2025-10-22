using Math;

// opciones para el menu, util su almacenado en constantes para mejor la sostenibilidad y legibilidad del código
const int OPCION_MENU_SUMAR = 1;
const int OPCION_MENU_RESTAR = 2;
const int OPCION_MENU_MULTIPLICAR = 3;
const int OPCION_MENU_DIVIDIR = 4;
const int OPCION_MENU_RAIZ = 5;
const int OPCION_MENU_FACTORIAL = 6;
const int OPCION_MENU_PRIMO = 7;
const int OPCION_MENU_SALIR = 8;


Main {

    writeLine("➗ Bienvenido a la Calculadora ➕");

    ejecutarMenu(); // delegamos lo antes posible ya que estamos en el Main
}

// contiene el bucle controla el menu. este no finaliza hasta que no se introduce la opcion de salir
procedure ejecutarMenu() {

    int opcionElegida = 0; // inicializada para evitar posibles fallos 

    do {

        writeLine("---- MENÚ -----");
        writeLine(OPCION_MENU_SUMAR + ".- Sumar.");
        writeLine(OPCION_MENU_RESTAR + ".- Restar.");
        writeLine(OPCION_MENU_MULTIPLICAR + ".- Multiplicar.");
        writeLine(OPCION_MENU_DIVIDIR + ".- Dividir.");
        writeLine(OPCION_MENU_RAIZ + ".- Raíz cuadrada.");
        writeLine(OPCION_MENU_FACTORIAL + ".- Factorial.");
        writeLine(OPCION_MENU_PRIMO + ".- ¿Es primo?.");
        writeLine(OPCION_MENU_SALIR + ".- Salir.");

        opcionElegida = leerEntero("Opción elegida: ");

        switch (opcionElegida) {

            case OPCION_MENU_SUMAR:
                sumar();
                break;

            case OPCION_MENU_RESTAR:
                restar();
                break;

            case OPCION_MENU_MULTIPLICAR:
                multiplicar();
                break;

            case OPCION_MENU_DIVIDIR:
                dividir();
                break;

                case OPCION_MENU_RAIZ:
                calcularRaiz();
                break;

            case OPCION_MENU_FACTORIAL:
                gestionarFactorial();
                break;

            case OPCION_MENU_PRIMO:
                comprobarPrimo();
                break;

            case OPCION_MENU_SALIR:
                writeLine("Ha sido un placer... 😌");
                break;

            default:
                writeLine("❌ Error en la entrada de datos. Por favor, introduzca una opción de las " + OPCION_MENU_SALIR + " posibles.");
                break;
        }

    } while (opcionElegida != OPCION_MENU_SALIR); // si no se el da a salir sigue
}


procedure sumar() {

    int cantidadNumeros = 0;
    decimal res = 0.0;
    bool isValido = false;

    do {

        cantidadNumeros = leerEntero("¿Cuántos números quieres sumar?: ");

        isValido = isAlMenosDos(cantidadNumeros);

        if (!isValido) {

            writeLine("Introduce al menos 2 números para sumar.");

        } else {


            for (int i = 1; i <= cantidadNumeros; i += 1) {
            
                res += leerDecimal(i + "º Número = ");
            }
            writeLine("Resultado de la suma = " + res);
        }

    } while (!isValido);
}


procedure restar() {

    int cantidadNumeros = 0;
    decimal res = 0;
    bool isValido = false;

    do {

        cantidadNumeros = leerEntero("¿Cuántos números quieres restar?: ");

        isValido = isAlMenosDos(cantidadNumeros);

        if (!isValido) {

            writeLine("Introduce al menos 2 números para restar.");

        } else {

            res = leerDecimal("1º Número = ");

            for (int i = 2; i <= cantidadNumeros; i += 1) {
            
                res -= leerDecimal(i + "º Número = ");
            }
            writeLine("Resultado de la resta = " + res);
        }

    } while (!isValido);
}


procedure multiplicar() {

    int cantidadNumeros = 0;
    decimal res = 1.0;
    bool isValido = false;

    do {

        cantidadNumeros = leerEntero("¿Cuántos números quieres multiplicar?: ");

        isValido = isAlMenosDos(cantidadNumeros);

        if (!isValido) {

            writeLine("Introduce al menos 2 números para multiplicar.");

        } else {

            for (int i = 1; i <= cantidadNumeros; i += 1) {
            
                res *= leerDecimal(i + "º Número = ");
            }
            writeLine("Resultado de la multiplicación = " + res);
        }

    } while (!isValido);
}

procedure dividir() {

    decimal dividendo = 0.0;
    decimal divisor;
    decimal cociente = 0.0;
    decimal resto = 0.0;
    bool isValido = false;

    do {
        dividendo = leerDecimal("Dividendo: ");
        divisor = leerDecimal("Divisor: ");

        isValido = isDivisorValido(divisor);

        if (isValido) {

            cociente = dividendo / divisor;
            resto = dividendo % divisor;

            writeLine("Cociente de la división: " + cociente);
            writeLine("Resto de la división: " + resto);
        }

    } while (!isValido);
}


procedure calcularRaiz() {

    decimal num = 0.0;
    decimal res = 0.0;
    bool isValido = false;

    do {

        num = leerDecimal("Raíz cuadrada de: ");

        if (num < 0.0) {
            writeLine("❌ Introduce un valor positivo.");
            //throw new RaizNegativaException ("No existen las raíces de valores negativos.");

        } else {

            isValido = true;

            res = Math.sqrt(num);
            writeLine("Raíz cuadrada =" + res);
        }

    } while (!isValido);
}

procedure gestionarFactorial() {

    int num = 0;
    int res = 0;
    bool isValido = false;
    

    do {
        num = leerEntero("Factorial de: ");
        res = calcularFactorial(num);

        if (res >= 1) {

            isValido = true;
            writeLine("El factorial de "+ num + " es " + res);
        }

    } while (!isValido);
}

function int calcularFactorial(int num) {

    if (num < 0) {
        writeLine("❌ Introduce un valor positivo.");
        return 0;

    } else if (num == 0 || num == 1) {
        return 1;

    } else {
        return num * calcularFactorial(num-1); // recursivo
    }
}


procedure comprobarPrimo() {
    int num = 0;
    bool isPrimo = true;

    bool isValido = false;

    do {

        num = leerEntero("Número a comprobar: ");

        if (num <= 1) {
            writeLine("❌ Introduce un valor superior a 1.");
            isValido = false;

        } else if (num == 2) {
            isPrimo = true;

        } else if ((num % 2 == 0) && (num != 2)){
            isValido = true;
            isPrimo = false;

        } else {

            isValido = true;
            for (int i = 3; i <= num/2; i += 2) {

                if (num % i == 0) {
                    isPrimo = false;
                    break;
                }

            }
        }

    } while (!isValido);

    if (isPrimo) {
        writeLine(num + " es Primo 🎉");
    } else {
        writeLine(num + " no es Primo.");
    }
}






function bool isDivisorValido(decimal divisor) {

    if (divisor == 0.0) {
        throw new DivideByZeroException("❌ No se puede dividir por cero.");
    }
    return true;
}


function decimal leerDecimal(string message) {

    decimal num = 0.0;
    bool isValido = false; //flag
    do {

        writeLine(message);

        try {
            num = (decimal)readLine();
            isValido = true;

        } catch (Exception e) {
            writeLine("❌ Error en la entrada de datos. Por favor, introduzca un número");
        }

    } while (!isValido);
    
    return num;
}


function int leerEntero(string message) {

    int num = 0;
    bool isValido = false; //flag
    do {

        writeLine(message);

        try {
            num = (int)readLine();
            isValido = true;

        } catch (Exception e) {
            writeLine("❌ Error en la entrada de datos. Por favor, introduzca un número entero.");
        }

    } while (!isValido);
    
    return num;
}


function bool isAlMenosDos(int cantidadNumeros) {

    if (cantidadNumeros < 2) {
        return false;
    } else {
        return true;
    }
}

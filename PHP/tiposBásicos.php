<?php

//---------TIPO INT-------------
echo 11;
echo "\n";

var_dump(11);

echo PHP_INT_MAX, "\n";
echo PHP_INT_MIN, "\n";
echo 017, "\n"; //base Octal
echo 0b1100111, "\n"; //base Binária
echo 0x117acf0, "\n"; // base hexadecimal

//---------TIPO FLOAT-------------
echo 1.1, "\n";

var_dump(1.1);

echo PHP_FLOAT_MAX, "\n";
echo PHP_FLOAT_MIN, "\n";
echo 1.2e3, "\n";
echo 13E-3, "\n";

//---------OPERAÇÕES ARITMÉTICAS-------------
echo 1 + 1, "\n";

var_dump(1 + 1);

echo 1 + 2.5, "\n";
echo 10 - 2, "\n";
echo 2 * 5, "\n";
echo 7 / 4, "\n";
echo intdiv(7, 4), "\n";
echo round(7 / 4), "\n";
echo 7 % 4, "\n";

// echo 7 / 0, "\n";
echo 4 ** 2, "\n";

//Precedência de operadores
echo 2 + 3 * 4, "\n";
echo (2 + 3) * 4, "\n";
echo 2 + 3 * 4 ** 2, "\n";
echo ((2 + 3) * 4) ** 2, "\n";

//---------TIPO STRING-------------
echo 'String', "\n";

var_dump('String');

//Concatenação
echo "String 1 " . 'String 2', "\n";
echo "String 1 " . 'Número ' . 123, "\n";
echo "String 1", " String 2", " String 3", "\n";

echo "'Teste' ", '"Teste" ', "\"Teste\"" , "\n";

echo "\\", "\n";

print("Função Print\n");
print "Função Print 2\n";

//Algumas funções
echo strtoupper('maiusculo '), strtolower('MINUSCULO'), "\n";

echo ucfirst('primeira letra maiúscula'), "\n";
echo ucwords('primeira de todas maiuscula'), "\n";
echo 'Quantas letras?', ' ', strlen("Quantas letras?"), "\n";
// echo 'Quantas letras com encode', ' ' . mb_strlen("Quantas letras são?", "utf-8"); INSTALAR SEPARADO PARA O PHP RECONHECER A FUNÇÃO
echo substr('Só uma parte ', 4), "\n";

echo str_replace('isso', 'aquilo', 'Trocar isso'), "\n";

echo strpos('AbcBACabc', 'abc'), "\n";
echo stripos('AbcBACabc', 'abc'), "\n";

//---------TIPO BOOLEAN-------------
echo TRUE, "\n";
echo FALSE, "\n";

var_dump(TRUE);
var_dump(FALSE);

echo is_bool(true), "\n";

//REGRAS
var_dump((bool) 0);

echo var_dump((bool) 20), "\n";

var_dump((bool) '');

echo var_dump((bool) ' '), "\n";

var_dump((bool) !' ');
var_dump((bool) !'');
var_dump((bool) !!'');

//---------CONVERSÕES-------------
var_dump((float) 3);
echo "\n";
var_dump(intval('2.8', 10));
var_dump((int) round(2.8));
echo "\n";

//Operações com string
var_dump(3 + "2");
var_dump(3 . "2");
// var_dump(1 + "string");
var_dump((int) '2');
var_dump((float) '2.5');
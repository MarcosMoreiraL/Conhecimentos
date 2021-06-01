<?php
$numeroA = 13;
echo $numeroA, "\n";
var_dump($numeroA);

$a = 3;
$b = 2;
$c = $a + $b;
echo $c, "\n";

echo isset($c), "\n";
unset($c);
echo isset($c), "\n";

//Tipagem fraca
$variavel = 10;
echo var_dump($variavel);
$variavel = '10';
echo var_dump($variavel);

//Nomes de variável
$var = 'válida';
$vár = 'válida';
$var2 = 'válida';
$var_2 = 'válida';
$_var_2 = 'válida';
$VAR2 = 'válida';
$varDois = 'válida';
// $2var = 'inválida';
// $%var = 'inválida'
// $var% = 'inválida'
// $var-2 = 'inválida'

var_dump($_SERVER["HTTP_HOST"]);